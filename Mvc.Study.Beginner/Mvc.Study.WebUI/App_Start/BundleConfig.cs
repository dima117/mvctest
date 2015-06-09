using System.Web.Optimization;

namespace Mvc.Study.Beginner
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(
				new ScriptBundle("~/Content/js").Include(
					"~/Content/js/jquery-2.1.4.min.js",
					"~/Content/js/bootstrap.min.js"));
         
            // CSS
            bundles.Add(
                new StyleBundle("~/Content/css").Include(
					"~/Content/css/bootstrap.min.css",
                    "~/Content/css/site.css"));
        }
    }
}