using System.Web.Mvc;

namespace Mvc.Study.Beginner.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error404()
        {
            return View();
        }
    }
}
