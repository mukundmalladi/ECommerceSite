using System;
using System.Security.Principal;
using EcommerceMvc.Controllers;
using EcommerceMvc.Helper;

namespace EcommerceMvc.Registrations.ImplementationClasses
{
    public class SecurityPrinciple : ISecurityPrincple, IIdentity
    {
        private readonly User user;

        public SecurityPrinciple(User user)
        {
            this.user = user;
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
                return user != null;
            }           
        }

        public User User
        {
            get { return user; }
            
        }

        public string FullName { get; set; }
    }
}