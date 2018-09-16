using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using EcommerceMvc.Pocos;

namespace EcommerceMvc.Dapper
{
    public class InventoryQuery
    {
        public List<Inventory> GetInventories(string groupName)
        {
            var sql = @"select * from [ECommerce].[dbo].[Inventory] where [GroupName] = @groupName";

            using (var sqlConn = new SqlConnection("Data Source=.;Database=ECommerce;Integrated Security=True;"))
            {
                try
                {
                    sqlConn.Open();
                    var inventories = sqlConn.Query<Inventory>(sql,
                        new
                        {
                            groupName = new DbString
                            {
                                Value = groupName,
                                IsFixedLength = false,
                                Length = 9,
                                IsAnsi = true
                            }
                        }).ToList();

                    return inventories;

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    sqlConn.Close();
                }
            }

            return new List<Inventory>();

        }
    }
}