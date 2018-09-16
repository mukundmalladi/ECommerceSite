using System.Security.Principal;

namespace EcommerceMvc.Controllers
{
    public interface  ISecurityPrincple: IPrincipal
    {
        long UserId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}