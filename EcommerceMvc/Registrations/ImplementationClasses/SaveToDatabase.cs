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

        public ITransaction GetTraction()
        {
            return _db.GetTransaction();
        }

        public void Update(object obj)
        {
            _db.Update(obj);
        }

        public abstract class TransactionScope : IDisposable
        {
            public abstract void Commit();
            public abstract void Dispose();
        }

        public class Transaction : TransactionScope
        {
            public override void Commit()
            {
                throw new NotImplementedException();
            }

            public override void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}