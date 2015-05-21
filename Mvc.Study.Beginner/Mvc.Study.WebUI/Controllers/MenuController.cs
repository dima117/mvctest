using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 600, VaryByParam = "none")]
        public ActionResult MenuItems()
        {
            return View(getItems());
        }

        /// <summary>
        /// Возвращает элементы меню
        /// </summary>
        /// <returns></returns>
        private MenuItemViewModel[] getItems()
        {
            using (var db = new TestDbContext())
            {
                return db.Pages
                         .Select(
                             p => new MenuItemViewModel
                                 {
                                     Id = p.Id,
                                     Title = p.Title
                                 })
                         .ToArray();
            }
        }
    }
}
