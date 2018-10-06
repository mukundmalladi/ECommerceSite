using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(4, "Order Table")]
    public class OrderTable : Migration
    {
        public override void Up()
        {
            Create.Table("Order").WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("OrderedTime").AsDateTime().NotNullable()
                .WithColumn("PersonId").AsInt32().NotNullable().ForeignKey("PersonId", "Person", "Id").Indexed("Person")
                .WithColumn("TotalPayablePrice").AsDecimal().NotNullable()
                .WithColumn("ShippingCharges").AsDecimal().NotNullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
