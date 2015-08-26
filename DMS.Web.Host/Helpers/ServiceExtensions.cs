using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Web.Host.Helpers
{
    public static class ServiceExtensions
    {
        public static IEnumerable<SelectListItem> UsersSelectList(this IUserService userService)
        {
            return userService.GetAll().Select(user => new SelectListItem
            {
                Text = user.Name,
                Value = user.UserId.ToString()
            });
        }
    }
}