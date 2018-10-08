using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceMvc.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public long Phone { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public int InputZip { get; set; }
        
        public int PoBox { get; set; }

        public int HouseNo { get; set; }
        
        public int ApartmentNo { get; set; }

        [StringLength(15)]
        public string InputAddress { get; set; }

        [StringLength(15)]
        public string InputAddress2 { get; set; }
        
        public string InputState { get; set; }

        public string City { get; set; }

    }
}