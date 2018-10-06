using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EcommerceMvc.Dapper;
using EcommerceMvc.Helper;
using EcommerceMvc.Models;
using EcommerceMvc.Models.ModelHelpers;
using EcommerceMvc.Pocos;
using Elasticsearch.Net;
using Nest;
using WebGrease.Css.Extensions;
using Status = EcommerceMvc.Models.Status;

namespace EcommerceMvc.Controllers
{
    [ExceptionHandle]
    public class CheckoutController : Controller
    {
        private readonly ILoggedInUser _loggedInUser;
        private readonly ISaveToDatabase _saveToDatabase;

        public CheckoutController(ILoggedInUser loggedInUser, ISaveToDatabase saveToDatabase)
        {
            _loggedInUser = loggedInUser;
            _saveToDatabase = saveToDatabase;
        }
        
        public ActionResult Index()
        {
            try
            {
                var user = _loggedInUser.GetLoggedInUser(System.Web.HttpContext.Current);

                if (user == null)
                {
                    throw new HttpException("Unable to find User");
                }
                
                
                var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200"))
                    .DefaultIndex("usercart").DisableDirectStreaming();

                var client = new ElasticClient(settings);

                var searchResponse = client.Search<IndexToElasticSearch>(descriptor => descriptor.From(0).Size(10)
                    .Type("IndexToElasticSearch")
                    .Query(containerDescriptor => containerDescriptor
                    .Match(queryDescriptor => queryDescriptor.Field(search => search.Id).Query(user.Id.ToString()))));

                var requestBodyInBytes = searchResponse.ApiCall.RequestBodyInBytes;
                var requestBody = Encoding.UTF8.GetString(requestBodyInBytes);

                //Write or log this request to some where

                var isSuccess = searchResponse.IsValid;
                if (isSuccess)
                {
                    var checkoutModel = new FullCheckOutModel() { UserId = user.Id };

                    var totalListOfProducts = 0M;
                    var hits = searchResponse.Hits.ToList();

                    if (hits.Count > 1)
                    {
                        throw new ElasticsearchClientException("Not sure what es brought");
                    }

                    var listOfProducts = new List<long>();
                    foreach (var hit in hits)
                    {
                        var productsListForUser = hit.Source.Items.Keys.ToList();
                        listOfProducts.AddRange(productsListForUser);
                        
                        var products = new ProductsQuery().GetFromDatabase(listOfProducts);
                        
                        foreach (var product in products)
                        {
                            var cost = 0M;
                            if (hit.Source.Items.TryGetValue(product.Id, out var quant))
                            {
                                cost = quant * product.Price;
                                totalListOfProducts = totalListOfProducts + cost;
                            }

                            checkoutModel.ProductsData.Add(new ProductsData()
                            {
                                Price = cost,
                                ProductData = new ProductData() { Id = product.Id, ProductName = product.ProductName, Price = product.Price},
                                Quantity = quant
                            });
                        }
                    }

                    checkoutModel.TotalPriceOfAllProducts = totalListOfProducts;

                    return View("Checkout", checkoutModel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View("Checkout");
        }

        [HttpPost]
        public JsonResult Checkout(FullCheckOutModel checkoutModel)
        {
           // if (!ModelState.IsValid)
            {
               // var errorMessage = ModelState.Values.ForEach(x => x.Errors.)
           //     return new JsonResult() {Data = new {success = false, Message = "Enter valid data"}};
            }

            try
            {
                var user = _loggedInUser.GetLoggedInUser(System.Web.HttpContext.Current);

                if (user == null)
                {
                    throw new HttpException("Unable to find User");
                }

                //instead of this in future pull from cache, when an record in updated in database  insert to other table called cache and then have a windows service check that every 1 sec
                var listOfProducts = new Dictionary<long, long>();
                foreach (var productsData in checkoutModel.ProductsData)
                {
                    if (productsData.ProductData != null)
                        listOfProducts.Add(productsData.ProductData.Id, productsData.Quantity);
                }

                var products = new ProductsQuery().GetFromDatabase(listOfProducts.Keys.ToList());

                using (var transaction = _saveToDatabase.GetTraction())
                {

                    decimal totalPayablePrice = 0;
                    var order = new Order()
                    {
                        OrderedTime = DateTime.Now,
                        PersonId = user.Id,
                        ShippingCharges = checkoutModel.ShippingCharges,
                        TotalPayablePrice = totalPayablePrice
                    };
                    _saveToDatabase.Save(order);
                    var randorNumber = new Random(12);
                    foreach (var product in products)
                    {
                        long quant;
                        var cost = 0M;
                        if (listOfProducts.TryGetValue(product.Id, out quant))
                        {
                            cost = quant * product.Price;
                            totalPayablePrice = totalPayablePrice + cost;
                            var productOrder = new ProductOrder()
                            {
                                OrderId = order.Id,
                                OrderDateTime = DateTime.Now,
                                ProductId = product.Id,
                                Quantity = quant,
                                Status = Status.Success,
                                UpdatedBy = user.FirstName
                            };
                            _saveToDatabase.Save(productOrder);


                            var shippingAddress = new ShippingAddress
                            {
                                AddressLine1 = checkoutModel.AddressLine1,
                                AddressLine2 = checkoutModel.AddressLine2,
                                ApartmentNo = checkoutModel.ApartmentNo,
                                CreateDate = DateTime.Now,
                                CreateDateTime = DateTime.Now,
                                HouseNo = checkoutModel.HouseNo,
                                PoBox = checkoutModel.PoBox,
                                ProductOrderId = productOrder.Id,
                                SameAsHomeAddress = true,
                                State = checkoutModel.State,
                                ZipCode = checkoutModel.ZipCode,
                                ShippingCompany = "My Company",
                                UpdateDate = DateTime.Now,
                                UpdatedBy = "System",
                                TrackingId = randorNumber.Next() //can call a webservice to shipping company and get data
                            };
                            _saveToDatabase.Save(shippingAddress);
                        }
                    }
                    _saveToDatabase.Update(order);
                    transaction.Complete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var actionResult = new JsonResult(){Data = new {success= "Order Submitted", response = "/products"}, ContentType = "json", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            return actionResult;

        }

    }
}