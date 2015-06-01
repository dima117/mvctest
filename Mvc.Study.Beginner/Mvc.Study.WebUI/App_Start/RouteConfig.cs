using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc.Study.Beginner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Pages
            routes.MapRoute(
                name: "MenuItems",
                url: "Menu/MenuItems",
                defaults: new
                    {
                        controller = "Menu",
                        action = "MenuItems"
                    }
                );
            routes.MapRoute(
                name: "Page",
                url: "Page/{pageName}",
                defaults: new
                    {
                        controller = "Home",
                        action = "ContentPage"
                    }
                );

            // Catalog
            routes.MapRoute(
                name: "CatalogItems",
                url: "Catalog/CatalogItems",
                defaults: new
                    {
                        controller = "Catalog",
                        action = "CatalogItems"
                    }
                );
            routes.MapRoute(
                name: "Catalog",
                url: "Catalog/{pageName}",
                defaults: new
                    {
                        controller = "Catalog",
                        action = "CatalogPage"
                    }
                );

            // Defaults
            routes.MapRoute(
                name: "Default",
                url: string.Empty,
                defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    }
                );

            routes.MapRoute(
                name: "Error404",
                url: "Error404",
                defaults: new
                {
                    controller = "Error",
                    action = "Error404"
                }
                );
        }
    }
}