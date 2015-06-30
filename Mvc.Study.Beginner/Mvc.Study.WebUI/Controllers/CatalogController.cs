using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CatalogController : Controller
    {
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

		        var model = Mapper.Map<CatalogSectionModel>(section);
		        model.Products = db.Products
		                           .Where(p => p.CatalogSection.UrlCode == urlCode)
		                           .Select(Mapper.Map<ProductListItemModel>)
		                           .ToArray();

		        return View(model);
		    }
	    }

		public ActionResult Product(string urlCode, Guid id)
        {
			using (var db = new TestDbContext())
			{
				var product = db.Products.FirstOrDefault(p => p.Id == id &&  p.Id == id);

				// 404
				if (null == product)
				{
					throw new HttpException(404, string.Empty);
				}

                return View(Mapper.Map<ProductModel>(product));
			}
        }
    }
}
