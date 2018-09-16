using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EcommerceMvc.Dapper;
using EcommerceMvc.Models;
using EcommerceMvc.Models.ModelHelpers;
using Elasticsearch.Net;
using Nest;

namespace EcommerceMvc.Controllers
{
    [ExceptionHandle]
    public class CheckoutController : Controller
    {
        private readonly ILoggedInUser _loggedInUser;

        public CheckoutController(ILoggedInUser loggedInUser)
        {
            _loggedInUser = loggedInUser;
        }

        // GET: Checkout
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
                    var checkoutModel = new CheckoutModel { UserId = user.Id };

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

                            checkoutModel.Products.Add(new ProductsData()
                            {
                                Price = cost,
                                Product = product,
                                Quantity = quant
                            });
                        }
                    }

                    checkoutModel.TotalPriceOfAllProducts = totalListOfProducts;

                    return View(checkoutModel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View();
        }
    }
}