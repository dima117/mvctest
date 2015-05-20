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
            using (var db = new TestDbContext())
            {
                // Параметры маршрута
                var pageId = (string) RouteData.Values["pageId"];

                // Модель
                var model = new PageMenuViewModel
                    {
                        Pages = db.Pages.ToArray(),
                        SelectedPageId = ObjectHelper.ParseObject<Guid?>(pageId)
                    };

                return View(model);
            }
        }
    }
}
