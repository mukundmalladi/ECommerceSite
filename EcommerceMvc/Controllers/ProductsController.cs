﻿using System;
using System.Collections.Generic;
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
    public class ProductsController : Controller
    {
        private readonly ILoggedInUser _loggedInUser;

        public ProductsController(ILoggedInUser loggedInUser)
        {
            _loggedInUser = loggedInUser;
        }

        // GET: Products
        public ActionResult Index()
        {
            //var getProducts = new InventoryQuery().GetGroups();
           // var rows = 
           // ViewBag.Prdu
            return View();
        }

        public ActionResult GetById(long? productId)
        {
            var inventorylist = new AllProducts();
            if (productId != null)
            {
                var groupName = (GroupName) productId;
                var query = new InventoryQuery().GetInventories(groupName.ToString());

                if (query != null)
                    foreach (var inventory in query)
                    {
                        var inverntoryModel = new InventoriesModel()
                        {
                            Id = inventory.Id,
                            GroupName = groupName.ToString(),
                            ItemsCount = inventory.ItemsCount,
                            ProductName = inventory.ProductName
                        };
                        inventorylist.InventoriesModels.Add(inverntoryModel);
                    }
            }

            return PartialView("ProductsGrid", inventorylist);
        }


        public ActionResult AddToCart(long productId, int quantity)
        {
            var user = _loggedInUser.GetLoggedInUser(System.Web.HttpContext.Current);
            if (user == null)
            {
                throw new HttpException("Unable to find User");
            }
            try
            {
                var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("usercart");
                var client = new ElasticClient(settings);

                var dataToIndex = new IndexToElasticSearch()
                {
                    Id = user.Id,
                };
                dataToIndex.Items.Add(productId, quantity);
                
                var indexExist = client.Get<IndexToElasticSearch>(new GetRequest("usercart", "IndexToElasticSearch", user.Id));

                if (!indexExist.Found)
                {
                   var indexResponse = client.Index(dataToIndex, descriptor => descriptor.Type("IndexToElasticSearch").Id(user.Id));
                    var indexResponseResult = indexResponse.ApiCall.Success;
                    if (!indexResponseResult)
                    {
                        throw  new ElasticsearchClientException("Index could not be created");
                    }
                }
                else if(indexExist.IsValid)
                {
                    var updateResponse = client.Update<IndexToElasticSearch, PartialIndexToElasticSearch>(dataToIndex, descriptor =>
                        {
                            var partialIndexToElasticSearch = new PartialIndexToElasticSearch()
                            {
                                Items = new Dictionary<long, long>()
                                {
                                    {productId, quantity}
                                }
                            };
                            
                            return descriptor.Doc(partialIndexToElasticSearch).Type("IndexToElasticSearch");
                        });

                    var updateResponseResult = updateResponse.ApiCall.Success;
                    if (!updateResponseResult)
                    {
                        throw new ElasticsearchClientException("Document could not be updated");
                    }
                    //TODO Handle errors
                }

                var searchResponse = client.Search<IndexToElasticSearch>(descriptor => descriptor.From(0).Size(100)
                                           .Type("IndexToElasticSearch").Query(containerDescriptor => containerDescriptor
                                           .Match(queryDescriptor => queryDescriptor.Field(search => search.Id).Query(user.Id.ToString()))));

                if (searchResponse.IsValid)
                {
                  //  System.Web.HttpContext.Current.User.Identity.
                    user.CartItems = searchResponse.Total;
                }
                
                return new JsonResult()
                {
                    
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new {Success = true}
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
       
    }
}