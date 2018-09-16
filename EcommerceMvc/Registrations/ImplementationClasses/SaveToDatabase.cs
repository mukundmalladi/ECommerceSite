using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using PetaPoco;

namespace EcommerceMvc.Helper
{
    public class SaveToDatabase : ISaveToDatabase
    {
        private readonly IDatabase _db;

        public SaveToDatabase()
        {
             _db = DatabaseConfiguration.Build()
                .UsingConnectionStringName("mssql")
                .Create();
        }

        public void Save(object obj)
        {
            _db.Save(obj);
        }
    }
}