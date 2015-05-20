using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Study.Beginner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Page",
                url: "Page/{pageId}",
                defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    }
                );
            routes.MapRoute(
                name: "PageContent",
                url: "PageContent/Index",
                defaults: new
                {
                    controller = "PageContent",
                    action = "Index"
                }
                );
            routes.MapRoute(
                name: "Menu",
                url: "Menu/Index",
                defaults: new
                    {
                        controller = "PageMenu",
                        action = "Index"
                    }
                );
            routes.MapRoute(
                name: "Default",
                url: string.Empty,
                defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    }
                );
        }
    }
}