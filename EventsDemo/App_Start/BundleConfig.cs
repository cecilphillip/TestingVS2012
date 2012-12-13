using System.Web;
using System.Web.Optimization;

namespace EventsDemo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include("~/Scripts/modernizr-2.6.2.js"));
            bundles.Add(new ScriptBundle("~/scripts/js").Include(
                "~/Scripts/jquery-1.8.3.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/knockout-2.2.0.debug.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/app.dataservice.js",
                "~/Scripts/app.vm.js",
                "~/Scripts/app.main.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",

                "~/Content/site.css"
            ));
        }
    }
}