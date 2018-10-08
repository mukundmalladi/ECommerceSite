using System.ComponentModel.DataAnnotations;

namespace EcommerceMvc.Models
{
    public class LoginModel
    {
        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }

    //public class Validate : ValidationAttribute
    //{
    //    override 
    //}
}