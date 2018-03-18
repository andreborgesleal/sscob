using System.Web;
using System.Web.Optimization;

namespace dwm_sscob
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      //"~/Content/site.css",
                      "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                      "~/Content/bower_components/jvectormap/jquery-jvectormap.css",
                      "~/Content/dist/css/AdminLTE.min.css",
                      "~/Content/dist/css/skins/_all-skins.min.css",
                      "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css"));
                      
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                        "~/Content/bower_components/fastclick/lib/fastclick.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/jquery-sparkline/dist/jquery.sparkline.min.js",
                        "~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                        "~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                        "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/bower_components/Chart.js/Chart.js",
                        "~/Content/dist/js/pages/dashboard2.js",
                        "~/Content/dist/js/demo.js",
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/bower_components/inputmask/dist/inputmaskt/inputmask.js",
                        "~/Content/bower_components/inputmask/dist/inputmaskt/inputmask.date.extensions.js",
                        "~/Content/bower_components/inputmask/dist/inputmaskt/inputmask.extesnsions.js",
                        "~/Content/bower_components/inputmask/dist/inputmaskt/inputmask.numeric.extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputs-jquery-ui").Include(
                            "~/Scripts/jquery.unobtrusive-ajax.js", // serve para renderizar a página dentro do DIV
                            "~/Scripts/jquery.maskedinput.js",
                            "~/Scripts/inputs-jquery-ui.js",
                            "~/scripts/js/bootstrap-datepicker.js",
                            "~/Scripts/modernizr-2.6.2.js"
                            ));
        }
    }
}
