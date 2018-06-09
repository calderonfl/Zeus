using System.Web.Optimization;

namespace Kadabra.UI
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include("~/Scrips/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/bootstrap/css").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/Bundles/bootstrap/js").Include("~/Scrips/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Bundles/admin/css").Include(
                "~/Content/Admin/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/Admin/css/sb-admin.css"));

            bundles.Add(new StyleBundle("~/Bundles/admin/js").Include(
                "~/Content/Admin/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/Admin/js/sb-admin.min.js")); ;
        }
    }
}