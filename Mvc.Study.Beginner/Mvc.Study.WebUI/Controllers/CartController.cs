using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CartController : Controller
    {
        private readonly CartStorage _cartStorage;

        public CartController()
        {
            _cartStorage = new CartStorage(this);
        }

        public ActionResult AddProduct(Guid productId)
        {
            var cart = _cartStorage.LoadCart();
            cart.Add(getCartItem(productId));
            _cartStorage.SaveCart(cart);

            return Json(cart.GetSummary());
        }

        public ActionResult RemoveProduct(Guid productId)
        {
            var cart = _cartStorage.LoadCart();
            cart.Remove(productId);
            _cartStorage.SaveCart(cart);

            return Json(cart.GetSummary());
        }

        public ActionResult GetCartSummary()
        {
            var cart = _cartStorage.LoadCart();
            return Json(cart.GetSummary());
        }

        private CartItemModel getCartItem(Guid productId)
        {
            using (var db = new TestDbContext())
            {
                var product = db.Products.First(p => p.Id == productId);
                return Mapper.Map<CartItemModel>(product);
            }
        }
    }
}
