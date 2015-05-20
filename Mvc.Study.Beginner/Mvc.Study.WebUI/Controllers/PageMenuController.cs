using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Common;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class PageMenuController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Параметры маршрута
            var pageId = (string) RouteData.Values["pageId"];

            // Модель
            var model = new PageMenuViewModel
                {
                    Items = getItems(),
                    SelectedItemId = ObjectHelper.ParseObject<Guid?>(pageId)
                };

            return View(model);
        }

        private PageMenuItemViewModel[] getItems()
        {
            using (var db = new TestDbContext())
            {
                return db.Pages
                         .Select(
                             p => new PageMenuItemViewModel
                                 {
                                     Id = p.Id,
                                     Title = p.Title
                                 })
                         .ToArray();
            }
        }
    }
}
