using System.Web.Optimization;

namespace Kadabra.UI
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Bundles/admin/css").Include(
                "~/Content/Admin/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/Admin/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/Admin/css/sb-admin.css"));

            bundles.Add(new StyleBundle("~/Bundles/admin/js").Include(
                "~/Content/Admin/vendor/jquery/jquery.min.js",
                "~/Content/Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Admin/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/Admin/js/sb-admin.min.js")); ;
        }
    }
}