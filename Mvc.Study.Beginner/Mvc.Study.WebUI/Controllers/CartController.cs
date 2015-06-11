using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CartController : Controller
    {
        public JsonResult AddProduct(Guid productId)
        {
            var cartStorage = new CartStorage(Session);
            var cart = cartStorage.LoadCart();

            cart.Add(getCartItem(productId));
            cartStorage.SaveCart(cart);

            return GetCartSummary();
        }

        public JsonResult RemoveProduct(Guid productId)
        {
            var cartStorage = new CartStorage(Session);
            var cart = cartStorage.LoadCart();

            cart.Remove(productId);
            cartStorage.SaveCart(cart);

            return GetCartSummary();
        }

        public JsonResult GetCartSummary()
        {
            var cartStorage = new CartStorage(Session);
            var cart = cartStorage.LoadCart();

            var summary = cart.GetSummary();
            return Json(summary, JsonRequestBehavior.AllowGet);
        }

        private CartItemModel getCartItem(Guid productId)
        {
            using (var db = new TestDbContext())
            {
                var product = db.Products.First(p => p.Id == productId);
                var cartItem = Mapper.Map<CartItemModel>(product);
                cartItem.Amount = 1;
                return cartItem;
            }
        }
    }
}
