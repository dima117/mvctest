using System;
using System.Linq;
using System.Web.Mvc;
using Mvc.Study.Domain;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner.Controllers
{
    /// <summary>
    /// Базовый класс всех контроллеров корзин
    /// </summary>
    public abstract class CartController : Controller, ICart
    {
        public abstract ActionResult Add(Guid productId);
        public abstract ActionResult Remove(Guid productId);
        public abstract ActionResult GetList();

        /// <summary>
        /// Возвращает продукт по его идентифкатору
        /// </summary>
        protected Product GetProduct(Guid productId)
        {
            using (var db = new TestDbContext())
            {
                return db.Products.First(p => p.Id == productId);
            }
        }
    }
}
