using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet]
        public ActionResult CatalogItems()
        {
            return View(getItems());
        }

        [HttpGet]
        public ActionResult CatalogPage(string pageName)
        {
            // Страница из базы
            var page = getPage(pageName);

            // Если не нашлось страницы
            if (null == page)
                throw new HttpException(404, string.Empty);

            // Модель
            var model = new PageCatalogViewModel
                {
                    Id = page.Id,
                    Title = page.Title,
                    HtmlPrimary = page.ContentPrimary,
                    HtmlSecondary = page.ContentSecondary
                };

            return View(model);
        }

        /// <summary>
        /// Возвращает элементы меню
        /// </summary>
        /// <returns></returns>
        private CatalogItemViewModel[] getItems()
        {
            using (var db = new TestDbContext())
            {
                return db.Catalog
                         .OrderBy(p => p.OrderId)
                         .Select(
                             p => new CatalogItemViewModel
                             {
                                 Id = p.Id,
                                 Name = p.Name.ToLower(),
                                 Title = p.Title
                             })
                         .ToArray();
            }
        }

        private PageCatalog getPage(string pageName)
        {
            using (var db = new TestDbContext())
            {
                return db.Catalog.FirstOrDefault(p => p.Name.Equals(pageName, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
