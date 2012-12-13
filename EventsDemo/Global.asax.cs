using System.Web.Http;
using System.Web.Optimization;
using EventsDemo.Data;

namespace EventsDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        { 
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EventData.Initialize();
            IocConfig.Configure();
        }
    }
}