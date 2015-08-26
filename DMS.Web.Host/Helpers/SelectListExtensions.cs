using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DMS.Web.Host.Helpers
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> PrependNull(this IEnumerable<SelectListItem> source, string nullText = "")
        {
            return new[]{ new SelectListItem()
            {
                Text = nullText,
                Value = string.Empty
            }}.Concat(source);
        }
    }
}
