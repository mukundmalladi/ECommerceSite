using System;

namespace EcommerceMvc.Dapper
{
    public class ProductGroups
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public DateTime CreateDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public string Subgroup { get; set; }
    }
}