using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CommonController : Controller
    {
		[OutputCache(Duration = 600)]
		public PartialViewResult MenuItems()
		{
			using (var db = new TestDbContext())
			{
				var items = db.Pages.OrderBy(p => p.SortOrder).ToArray();

				var model = items
					.Select(p => new MenuItemModel(p.Id, p.MenuTitle, p.UrlCode))
					.ToArray();

				return PartialView(model);
			}
		}

		[OutputCache(Duration = 600)]
		public PartialViewResult CatalogSections()
		{
			using (var db = new TestDbContext())
			{
				var items = db.CatalogSections.OrderBy(p => p.SortOrder).ToArray();

				var model = items
					.Select(p => new MenuItemModel(p.Id, p.MenuTitle, p.UrlCode))
					.ToArray();

				return PartialView(model);
			}
		}

        public ActionResult Error404()
        {
            return View();
        }
    }
}
