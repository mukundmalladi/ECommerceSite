using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EcommerceMvc.Models.ModelHelpers;
using EcommerceMvc.Pocos;

namespace EcommerceMvc.Models
{
    public class CheckoutModel
    {
        public CheckoutModel()
        {
            ProductsData = new List<ProductsData>();
        }
        public long UserId { get; set; }

        public List<ProductsData> ProductsData { get; set; }

        public decimal TotalPriceOfAllProducts { get; set; }
    }

    public class ProductsData
    {
        [Required]
        public long Quantity { get; set; }
        [Required]
        public ProductData ProductData { get; set; }

        public decimal Price { get; set; }
    }

    public class ProductData
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}