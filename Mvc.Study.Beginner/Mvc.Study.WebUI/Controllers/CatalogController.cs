using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CatalogController : Controller
    {
	    [HttpGet]
	    public ActionResult Section(string urlCode)
	    {
		    using (var db = new TestDbContext())
		    {
			    var section = db.CatalogSections.FirstOrDefault(p => p.UrlCode == urlCode);

			    // 404
			    if (null == section)
			    {
				    throw new HttpException(404, string.Empty);
			    }

			    var model = new CatalogSectionModel
							{
								Id = section.Id,
								MenuTitle = section.MenuTitle,
								ContentPrimary = section.ContentPrimary,
								ContentSecondary = section.ContentSecondary
							};

			    return View(model);
		    }
	    }

	    [HttpGet]
		public ActionResult Product(string urlCode, Guid id)
        {
			using (var db = new TestDbContext())
			{
				var product = db.Products.FirstOrDefault(p => p.Id == id &&  p.CatalogSection.UrlCode == urlCode);

				// 404
				if (null == product)
				{
					throw new HttpException(404, string.Empty);
				}

				var model = new ProductModel
				{
					Id = product.Id,
					Name = product.Name,
					Description = product.Description,
					FullDescription = product.FullDescription
				};

				return View(model);
			}
        }
    }
}
