using DMS.Domain;
using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Web.Host.Controllers
{
    public partial class DefaultController : Controller
    {
        private DMSPrincipal _principal;
        protected new DMSPrincipal User
        {
            get
            {
                if (_principal == null)
                {
                    _principal = (DMSPrincipal)base.User;
                }
                return _principal;
            }
        }

        private User _currentUser;
        protected User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = DependencyResolver.Current.GetService<IUserService>().Get(User.Identity.UserId);
                }
                return _currentUser;
            }
        }
    }
}