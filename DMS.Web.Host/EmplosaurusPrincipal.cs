using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace DMS.Web.Host
{
    public class DMSPrincipal : GenericPrincipal
    {
        public DMSPrincipal(DMSIdentity identity)
            : base(identity, null)
        { }

        public override bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException("role");
            }
            //TODO: Uncomment
            /*IUserService userService = DependencyResolver.Current.GetService<IUserService>();
            return userService.IsInRole(Identity.Name, role);*/
            return false;
        }

        public new DMSIdentity Identity
        {
            get
            {
                return (DMSIdentity)base.Identity;
            }
        }
    }
}