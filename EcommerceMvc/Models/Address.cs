using System;
using EcommerceMvc.Helper;
using EcommerceMvc.Pocos;
using PetaPoco;

namespace EcommerceMvc.Models
{
    [ExplicitColumns]
    [TableName("Address")]
    [PrimaryKey("Id")]
    public class Address
    {
        [Column]
        public long Id { get; set; }

        public User Person { get; set; }
        [Column]
        public long PersonId { get; set; }
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