using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new TestDbContext())
            {
                var model = new MenuModel
                    {
                        Pages = db.Pages.ToArray()
                    };

                return View(model);
            }
        }
    }
}
