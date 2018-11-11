using System;
using System.Security.Principal;
using EcommerceMvc.Controllers;
using EcommerceMvc.Helper;

namespace EcommerceMvc.Registrations.ImplementationClasses
{
    public class SecurityPrinciple : ISecurityPrincple, IIdentity
    {
        private readonly User _user;

        public SecurityPrinciple(User user)
        {
            this._user = user;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity
        {
            get { return this; }
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated
        {
            get
            {
                return _user != null;
            }           
        }

        public User User
        {
            get { return _user; }
            
        }

        public string FullName { get; set; }

        
    }
}