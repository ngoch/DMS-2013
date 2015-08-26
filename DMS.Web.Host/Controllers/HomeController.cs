using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Web.Host.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Projects.Index());
        }

        public virtual ActionResult Help()
        {
            return File(Server.MapPath(@"~\Help.pdf"), "application/pdf");
        }
    }
}
