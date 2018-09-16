using System.Web;
using EcommerceMvc.Helper;

public interface ILoggedInUser
{
    User GetLoggedInUser(HttpContext httpContext);
}