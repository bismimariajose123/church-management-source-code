using System.Web;
using System.Web.Optimization;

namespace church_management_system
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/jquery").Include("~/js/jquery-ui.js"));
            //bundles.Add(new ScriptBundle("~/Script").Include("~/Scripts/jquery-ui.js","~/Scripts/jquery.validate - vsdoc", "~/Scripts/jquery.validate", "~/Scripts/jquery.validate.min", "~/Scripts/jquery.validate.unobtrusive", "~/Scripts/jquery.validate.unobtrusive.min", "~/Scripts/modernizr-2.6.2", "~/Scripts/jquery -1.10.2.intellisense", "~/Scripts/jquery-1.10.2", "~/Scripts/jquery-1.10.2.min", "~/Scripts/jquery-1.10.2.min", "~/Scripts/respond", "~/Scripts/respond.min"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.css",
                       "~/Content/css/style.css",
                       "~/Content/css/font-awesome.css", "~/Content/css/jquery-ui.css", "~/Content/css/normaluser_style.css", "~/Content/css/simplelightbox.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
"~/Content/js/bootstrap.js", "~/Content/js/easing.js", "~/Content/js/jquery-2.1.4.min.js", "~/Content/js/jquery-ui.js", "~/Content/js/jquery.flexisel.js", "~/Content/js/move-top.js", "~/Content/js/numscroller-1.0.js", "~/Content/js/simple-lightbox.js", "~/Content/js/SmoothScroll.min.js"));

        }
    }
}
