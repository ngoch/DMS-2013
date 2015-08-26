using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FluentValidation;
using DMS.Domain.Services;
using DMS.Web.Host.Models;
using DMS.Web.Host.Resources;

namespace DMS.Web.Host.Controllers
{
    public partial class AuthController : Controller
    {
        readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual ActionResult LogOn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Authenticate(model.UserName, model.Password))
                {
                    Domain.User user = _userService.GetByUserName(model.UserName);
                    string userData = string.Join(DMSIdentity.UserDataSeparator.ToString(), user.UserId, user.ToString());
                    HttpCookie authCookie = FormsAuthentication.GetAuthCookie(model.UserName, false);
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userData, authCookie.Path);
                    authCookie.Value = FormsAuthentication.Encrypt(newTicket);

                    Response.Cookies.Add(authCookie);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(MVC.Home.Index());
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, LoginResources.IncorrectUsernameOrPassword);
                }
            }

            return View();
        }

        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Home.Index());
        }
    }
}
