using System.Web.Optimization;

namespace Mvc.Study.Beginner
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-2.1.4.min.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-2.8.3.js"));

            // CSS
            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                    "~/Content/site.css",
                    "~/Content/bootstrap.min.css"));
        }
    }
}