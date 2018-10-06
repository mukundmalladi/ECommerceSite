using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(1)]
    public class CreateTable : Migration
    {
        public override void Up()
        {
          
                Create.Table("Person").WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .Identity()
                .WithColumn("FirstName").AsString(256).NotNullable()
                .WithColumn("LastName").AsString(256).NotNullable()
                .WithColumn("UserName").AsString(256).NotNullable()
                .WithColumn("EmailId").AsString(256).NotNullable()
                .WithColumn("CreatedBy").AsString(256).NotNullable()
                .WithColumn("Salt").AsString(128).NotNullable()
                .WithColumn("Password").AsString(512).NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable()
                .WithColumn("Phone").AsInt64().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Person");
        }
    }
}
