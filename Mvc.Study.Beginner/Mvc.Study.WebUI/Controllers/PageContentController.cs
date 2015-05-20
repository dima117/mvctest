using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner.Controllers
{
    public class PageContentController : Controller
    {
        [HttpGet]
        public ActionResult Index(Guid? pageId)
        {
            // Страница из базы
            var dbPage = getPage(pageId);

            // Модель
            var model = new PageContentViewModel
                {
                    Page = new PageViewModel
                        {
                            PageId = dbPage.Id,
                            PageTitle = dbPage.Title,
                            PageContent = dbPage.Content
                        }
                };

            return View(model);
        }

        private Page getPage(Guid? pageId)
        {
            using (var db = new TestDbContext())
            {
                return db.Pages.FirstOrDefault(p => p.Id == pageId) ?? new Page();
            }
        }
    }
}
