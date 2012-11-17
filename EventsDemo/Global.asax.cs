using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventsDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new EventsDemoSeedInitializer());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            (new EventsDemo.Models.EventsDemoContext()).Events.ToList();
        }
    }
}