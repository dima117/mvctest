using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContentPage(string pageName)
        {
            // Страница из базы
            var page = getPage(pageName);

            // Если не нашлось страницы
            if (null == page)
                throw new HttpException(404, string.Empty);

            // Модель
            var model = new PageContentViewModel
                {
                    Id = page.Id,
                    Title = page.Title,
                    Html = page.Content
                };

            return View(model);
        }

        private PageContent getPage(string pageName)
        {
            using (var db = new TestDbContext())
            {
                return db.Pages.FirstOrDefault(p => p.Name.Equals(pageName, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
