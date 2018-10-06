using System;
using EcommerceMvc.Pocos;
using PetaPoco;

namespace EcommerceMvc.Models
{
    [ExplicitColumns]
    [TableName("ProductOrder")]
    [PrimaryKey("Id")]
    public class ProductOrder
    {
        [Column]
        public long Id { get; set; }

        public Order Order { get; set; }
        
        public Product Product { get; set; }

        [Column]
        public long Quantity { get; set; }
        [Column]
        public DateTime OrderDateTime { get; set; }

        [Column]
        public string UpdatedBy { get; set; }

        [Column]
        public long OrderId
        {
            get;
            set;
        }
        [Column]
        public long ProductId
        {
            get;
            set;
        }

        [Column]
        public Status Status { get; set; }
      
    }


    public enum Status
    {
        Success,
        Failure,
        Shipped,
        Processing,
        Cancelled
    }
}