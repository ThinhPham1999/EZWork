using System.Web;
using System.Web.Optimization;

namespace EZWork.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Freelancer Theme

            bundles.Add(new Bundle("~/Content/Theme/FreelancerTheme/css").Include(
                "~/App_Themes/FreelancerTheme/css/bootstrap.min.css",
                "~/App_Themes/FreelancerTheme/css/normalize.css",
                "~/App_Themes/FreelancerTheme/css/scrollbar.css",
                "~/App_Themes/FreelancerTheme/css/fontawesome/fontawesome-all.css",
                "~/App_Themes/FreelancerTheme/css/font-awesome.min.css",
                "~/App_Themes/FreelancerTheme/css/owl.carousel.min.css",
                "~/App_Themes/FreelancerTheme/css/linearicons.css",
                "~/App_Themes/FreelancerTheme/css/jquery-ui.css",
                "~/App_Themes/FreelancerTheme/css/tipso.css",
                "~/App_Themes/FreelancerTheme/css/chosen.css",
                "~/App_Themes/FreelancerTheme/css/prettyPhoto.css",
                "~/App_Themes/FreelancerTheme/css/main.css",
                "~/App_Themes/FreelancerTheme/css/color.css",
                "~/App_Themes/FreelancerTheme/css/transitions.css",
                "~/App_Themes/FreelancerTheme/css/responsive.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/Theme/FreelancerTheme/js").Include(
                "~/App_Themes/FreelancerTheme/js/vendor/modernizr-2.8.3-respond-1.4.2.min.js",
                "~/App_Themes/FreelancerTheme/js/vendor/jquery-3.3.1.js",
                "~/App_Themes/FreelancerTheme/js/vendor/jquery-library.js",
                "~/App_Themes/FreelancerTheme/js/vendor/bootstrap.min.js",
                "~/App_Themes/FreelancerTheme/js/owl.carousel.min.js",
                "~/App_Themes/FreelancerTheme/js/chosen.jquery.js",
                "~/App_Themes/FreelancerTheme/js/scrollbar.min.js",
                "~/App_Themes/FreelancerTheme/js/tilt.jquery.js",
                "~/App_Themes/FreelancerTheme/js/prettyPhoto.js",
                "~/App_Themes/FreelancerTheme/js/jquery-ui.js",
                "~/App_Themes/FreelancerTheme/js/readmore.js",
                "~/App_Themes/FreelancerTheme/js/countTo.js",
                "~/App_Themes/FreelancerTheme/js/appear.js",
                "~/App_Themes/FreelancerTheme/js/tipso.js",
                "~/App_Themes/FreelancerTheme/js/jRate.js",
                "~/App_Themes/FreelancerTheme/js/main.js"
             ));

            //Admin Theme
        }
    }
}
