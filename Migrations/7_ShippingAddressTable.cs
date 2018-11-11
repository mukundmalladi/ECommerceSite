using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
   [Migration(7, "Shipping Address Table")]
   public class ShippingAddressTable : Migration
    {
        public override void Up()
        {
            Create.Table("ShippingAddress").WithColumn("ShippingId").AsInt64().NotNullable().Identity().PrimaryKey()
                .WithColumn("CreateDateTime").AsDateTime().NotNullable()
                .WithColumn("ProductOrderId").AsInt64().NotNullable()
                .ForeignKey("ProductOrderId", "ProductOrder", "Id")
                .WithColumn("SameAsHomeAddress").AsBoolean().NotNullable()
                .WithColumn("TrackingId").AsInt64().Nullable()
                .WithColumn("ShippingCompany").AsString().Nullable()
                .WithColumn("ZipCode").AsInt32().Nullable()
                .WithColumn("PoBox").AsInt32().Nullable()
                .WithColumn("HouseNo").AsInt32().Nullable()
                .WithColumn("AddressLine1").AsString().Nullable()
                .WithColumn("AddressLine2").AsString().Nullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("CreateDate").AsDateTime().Nullable()
                .WithColumn("City").AsString().Nullable()
                .WithColumn("UpdateDate").AsDateTime().Nullable()
                .WithColumn("UpdatedBy").AsString().Nullable()
                .WithColumn("ApartmentNo").AsInt64().Nullable();

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
