using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using EcommerceMvc.Helper;
using EcommerceMvc.Pocos;

namespace EcommerceMvc.Dapper
{
    public class PersonQuery
    {
        public Person GetFromDatabase(string emailId)
        {
            var sql = @"select * from [ECommerce].[dbo].[Person] where emailId = @emailId";
            using (var sqlConn = new SqlConnection("Data Source=.;Database=ECommerce;Integrated Security=True;"))
            {
                try
                {
                    sqlConn.Open();
                    var persons = sqlConn.Query<Person>(sql,
                        new
                        {
                            emailId = new DbString {Value = emailId, IsFixedLength = false, Length = 9, IsAnsi = true}
                        }).ToList();

                    return persons.First();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    sqlConn.Close();
                }
            }
            return new Person();
        }

        public PersonQuery WithPersonName(string personName)
        {

            AddParameter("@username", personName);
            return this;

        }

        private void AddParameter(string username, string personName)
        {
            throw new NotImplementedException();
        }
    }


    public interface IQueryRunner
    {
         
    }
}