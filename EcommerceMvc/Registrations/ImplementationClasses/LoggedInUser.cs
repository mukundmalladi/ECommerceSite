using System.Web;
using EcommerceMvc.Controllers;
using EcommerceMvc.Helper;
using EcommerceMvc.Registrations.ImplementationClasses;

public class LoggedInUser : ILoggedInUser
{
    public User GetLoggedInUser(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            return null;
        }
        var user = httpContext.User as SecurityPrinciple;
        var isAuthenticated = user != null && user.IsAuthenticated;
        if (isAuthenticated)
        {
            return user.User;
        }

        return null;
    }
}