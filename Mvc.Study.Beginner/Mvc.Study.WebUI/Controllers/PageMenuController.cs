using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class PageMenuController : Controller
    {
        private Guid? _pageId
        {
            get
            {
                Guid pageId;
                return Guid.TryParse((string) RouteData.Values["pageId"], out pageId) && pageId != Guid.Empty
                           ? pageId
                           : (Guid?) null;
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Модель
            var model = new PageMenuViewModel
                {
                    Items = getItems(),
                    SelectedItemId = _pageId
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
