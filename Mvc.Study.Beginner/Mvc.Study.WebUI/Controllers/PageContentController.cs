using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner.Controllers
{
    public class PageContentController : Controller
    {
        public ActionResult Index(Guid? pageId)
        {
            using (var db = new TestDbContext())
            {
                var model = new PageContentModel
                    {
                        Page = db.Pages.FirstOrDefault(p => p.Id == pageId) ?? new Page()
                    };

                return View(model);
            }
        }
    }
}
