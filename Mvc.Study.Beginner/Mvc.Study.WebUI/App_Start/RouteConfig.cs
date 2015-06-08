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
				name: "ContentPage",
				url: "info/{urlCode}",
				defaults: new { controller = "Home", action = "ContentPage" });

			routes.MapRoute(
				name: "CatalogSection",
				url: "catalog/{urlCode}",
				defaults: new { controller = "Catalog", action = "Section" });

			routes.MapRoute(
				name: "Product",
				url: "catalog/{urlCode}/{id}",
				defaults: new { controller = "Catalog", action = "Product" });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}