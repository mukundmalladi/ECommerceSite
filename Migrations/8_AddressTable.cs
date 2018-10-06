using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(8, "Address")]
    public class AddressTable : Migration
    {
        public override void Up()
        {
            Create.Table("Address").WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("PersonId").AsInt32().NotNullable().ForeignKey("Person", "Id")
                .WithColumn("ZipCode").AsInt32().Nullable()
                .WithColumn("PoBox").AsInt32().Nullable()
                .WithColumn("HouseNo").AsInt32().Nullable()
                .WithColumn("AddressLine1").AsString().Nullable()
                .WithColumn("AddressLine2").AsString().Nullable()
                .WithColumn("State").AsString().NotNullable()
                .WithColumn("CreateDate").AsDateTime().Nullable()
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
