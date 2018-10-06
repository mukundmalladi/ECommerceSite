using System;
using PetaPoco;

namespace EcommerceMvc.Models
{
    [ExplicitColumns]
    [TableName("ShippingAddress")]
    [PrimaryKey("ShippingId")]
    public class ShippingAddress// : Address
    {
        [Column]
        public  long ShippingId { get; set; }
        [Column]
        public DateTime CreateDateTime { get; set; }

        public ProductOrder ProductOrder { get; set; }

        [Column]
        public long ProductOrderId { get; set; }

        [Column]
        public bool SameAsHomeAddress { get; set; }

        [Column]
        public long TrackingId { get; set; }

        [Column]
        public string ShippingCompany { get; set; }
        //TODO add a class for tracking package

        [Column]
        public int? ZipCode { get; set; }
        [Column]
        public int? PoBox { get; set; }
        [Column]
        public int? HouseNo { get; set; }
        [Column]
        public int? ApartmentNo { get; set; }
        [Column]
        public string AddressLine1 { get; set; }
        [Column]
        public string AddressLine2 { get; set; }
        [Column]
        public string State { get; set; }
        [Column]
        public DateTime CreateDate { get; set; }
        [Column]
        public DateTime UpdateDate { get; set; }
        [Column]
        public string UpdatedBy { get; set; }
    }
}