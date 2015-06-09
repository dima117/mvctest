using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ContentPage(string urlCode)
        {
			using (var db = new TestDbContext())
			{
				var page = db.Pages.FirstOrDefault(p => p.UrlCode == urlCode);

				// 404
				if (page == null)
				{
					throw new HttpException(404, string.Empty);
				}

			    return View(Mapper.Map<ContentPageModel>(page));
			}
        }
    }
}
