using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(3, "Product table")]
    public class ProductTable : Migration
    {
        public override void Up()
        {
            Create.Table("Product").WithColumn("Id").AsInt64().PrimaryKey().Identity().WithColumn("ProductName")
                .AsString().NotNullable().WithColumn("Price").AsCurrency().NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable().WithColumn("UpdatedBy").AsString().NotNullable();

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
