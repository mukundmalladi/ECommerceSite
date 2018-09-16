using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using EcommerceMvc.Pocos;

namespace EcommerceMvc.Dapper
{
    public class ProductsQuery
    {
        public List<Product> GetFromDatabase(List<long> productIds)
        {
            var sql = @"select * from [ECommerce].[dbo].[Product] where [Id] in @productId ";
            using (var sqlConn = new SqlConnection("Data Source=.;Database=ECommerce;Integrated Security=True;"))
            {
                try
                {
                    var productIdsList = new long[productIds.Count];
                    for (int i = 0; i < productIds.Count; i++)
                    {
                        productIdsList[i] = productIds[i];
                    }
                    var products = new List<Product>();
                    sqlConn.Open();
                    using (var reader = sqlConn.ExecuteReader(sql, new { productId = productIdsList }))
                    {
                        var productParser = reader.GetRowParser<Product>();
                        while (reader.Read())
                        {
                            var product = productParser(reader);
                            products.Add(product);
                        }
                    }
                    return products;

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    sqlConn.Close();
                }
            }
            return new List<Product>();

        }
    }
}