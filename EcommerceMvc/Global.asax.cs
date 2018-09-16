using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using EcommerceMvc.Controllers;
using EcommerceMvc.Helper;
using EcommerceMvc.Registrations.ImplementationClasses;
using Ninject;
using Ninject.Web.Common.WebHost;
using PetaPoco;

namespace EcommerceMvc
{
    public class MvcApplication : HttpApplication
    {
        protected new void Application_Start()
        {
           AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

       
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                var serializeModel = serializer.Deserialize<User>(authTicket.UserData);

                var newUser = new SecurityPrinciple(serializeModel);
                newUser.UserId = serializeModel.Id;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;
                HttpContext.Current.User = newUser;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("~/Views/Error/index.cshtml");
        }
    }
}
