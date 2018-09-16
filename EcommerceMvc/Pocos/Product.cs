using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace EcommerceMvc.Pocos
{
    [ExplicitColumns]
    [TableName("Inventory")]
    [PrimaryKey("Id")]
    public class Product
    {
        [Column]
        public long Id { get; set; }

        [Column]
        public string ProductName { get; set; }

        [Column]
        public decimal Price { get; set; }

        [Column]
        public DateTime CreateDate { get; set; }

        [Column]
        public string UpdatedBy { get; set; }
       
    }
}