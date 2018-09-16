using System.Collections.Generic;
using EcommerceMvc.Models.ModelHelpers;
using EcommerceMvc.Pocos;

namespace EcommerceMvc.Models
{
    public class CheckoutModel
    {
        public CheckoutModel()
        {
            Products = new List<ProductsData>();
        }
        public long UserId { get; set; }

        public List<ProductsData> Products { get; set; }

        public decimal TotalPriceOfAllProducts { get; set; }
    }

    public class ProductsData
    {
        public long Quantity { get; set; }

        public Product Product { get; set; }

        public decimal Price { get; set; }
    }
}