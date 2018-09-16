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
    public class Inventory
    {
        [Column]
        public long Id { get; set; }

        [Column]
        public string GroupName { get; set; }

        [Column]
        public long ItemsCount { get; set; }

        [Column]
        public DateTime UpdateDate { get; set; }

        [Column]
        public string UpdatedBy { get; set; }
        
        [Column]
        public string ProductName { get; set; }

    }
}