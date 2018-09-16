using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceMvc.Models
{
    public class AllProducts
    {
        public AllProducts()
        {
            InventoriesModels = new List<InventoriesModel>();
        }
        public List<InventoriesModel> InventoriesModels { get; set; }
    }
    public class InventoriesModel
    {
        public long Id { get; set; }
        
        public string GroupName { get; set; }
        
        public long ItemsCount { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdatedBy { get; set; }
        public string ProductName { get; set; }
    }
}