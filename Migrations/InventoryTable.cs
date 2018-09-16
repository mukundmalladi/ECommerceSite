using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(2, "Inventory table")]
    public class InventoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("Inventory").WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
                .WithColumn("GroupName").AsString().NotNullable()
                .WithColumn("ProductName").AsString().NotNullable()
                .WithColumn("ItemsCount").AsInt64().NotNullable()
                .WithColumn("UpdateDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedBy").AsString().NotNullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
