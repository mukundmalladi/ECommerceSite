using System;
using EcommerceMvc.Helper;
using EcommerceMvc.Pocos;
using PetaPoco;

namespace EcommerceMvc.Models
{
    [ExplicitColumns]
    [TableName("Order")]
    [PrimaryKey("Id")]
    public class Order
    {
        [Column]
        public long Id { get; set; }

        public User Person { get; set; }
        [Column]
        public long PersonId { get; set; }
      
        [Column]
        public Decimal TotalPayablePrice { get; set; }

        [Column]
        public DateTime OrderedTime { get; set; }

        [Column]
        public Decimal ShippingCharges { get; set; }
    }
}