using DMS.Domain.Repositories;
using DMS.Web.Host.App_Start;
using DMS.Web.Host.Resources;
using FluentValidation;
using FluentValidation.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace DMS.Web.Host
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new DMS.Domain.SampleData());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationModelValidatorProvider.Configure();
            ValidatorOptions.ResourceProviderType = typeof(ValidationResources);
            MapperConfig.Configure(AutoMapper.Mapper.Configuration);
            Database.SetInitializer<DMSDbContext>(new DevDbInitializer());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ka-GE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ka-GE");
        }

        private void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal currentPrincipal = HttpContext.Current.User;
            if (currentPrincipal.Identity.IsAuthenticated)
            {
                FormsIdentity formsIdentity = (FormsIdentity)currentPrincipal.Identity;
                DMSIdentity identity = new DMSIdentity(formsIdentity.Ticket);
                DMSPrincipal principal = new DMSPrincipal(identity);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}