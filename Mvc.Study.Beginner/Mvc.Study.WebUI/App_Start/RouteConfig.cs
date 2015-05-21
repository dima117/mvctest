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
                name: "Menu",
                url: "Menu/MenuItems",
                defaults: new
                    {
                        controller = "Menu",
                        action = "MenuItems"
                    }
                );
            routes.MapRoute(
                name: "Page",
                url: "Page/{pageId}",
                defaults: new
                    {
                        controller = "Home",
                        action = "ContentPage"
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