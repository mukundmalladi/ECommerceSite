using System;

namespace EcommerceMvc.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; }

        public long Phone { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }
    }
}