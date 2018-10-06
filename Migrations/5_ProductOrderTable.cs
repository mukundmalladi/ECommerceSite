using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(5, "Product Order Table")]
    public class ProductOrderTable : Migration
    {
        public override void Up()
        {
            Create.Table("ProductOrder").WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .Indexed("ProductOrderId")
                .WithColumn("ProductId").AsInt64().NotNullable().ForeignKey("ProductId", "Product", "Id")
                .Indexed("Product")
                .WithColumn("OrderId").AsInt64().NotNullable().ForeignKey("OrderId", "Order", "Id").Indexed("Order")
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("OrderDateTime").AsDateTime().NotNullable()
                .WithColumn("UpdatedBy").AsString().NotNullable()
                .WithColumn("Status").AsInt32().NotNullable();

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
