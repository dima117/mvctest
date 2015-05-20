using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class PageMenuController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(getItems());
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
