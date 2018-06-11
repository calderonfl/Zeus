using System.Web.Optimization;

namespace Kadabra.UI
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/bootstrap/css").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Bundles/datatable/css").Include("~/Content/DataTables/css/dataTables.bootstrap4.min.css"));
            bundles.Add(new StyleBundle("~/Bundles/admin/css").Include("~/Content/Admin/vendor/font-awesome/css/font-awesome.min.css", "~/Content/Admin/css/sb-admin.css"));

            bundles.Add(new ScriptBundle("~/Bundles/jquery/js").Include("~/Scripts/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/bootstrap/js").Include("~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/admin/js").Include("~/Content/Admin/vendor/jquery-easing/jquery.easing.min.js", "~/Content/Admin/js/sb-admin.min.js"));
            bundles.Add(new ScriptBundle("~/Bundles/datatable/js").Include("~/Scripts/DataTables/jquery.dataTables.min.js", "~/Scripts/DataTables/dataTables.bootstrap4.min.js"));
        }
    }
}