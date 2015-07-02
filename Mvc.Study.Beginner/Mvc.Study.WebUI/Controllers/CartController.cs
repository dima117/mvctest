using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;

namespace Mvc.Study.Beginner.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Checkout()
        {
            var cart = loadCart();

            var model = new CartCheckoutModel
                {
                    Items = cart.GetItems(),
                    TotalCost = cart.GetSummary().TotalCost
                };
            return View(model);
        }

        public JsonResult AddProduct(Guid productId)
        {
            var cart = loadCart();

            cart.Add(getCartItem(productId));
            saveCart(cart);

            return GetCartSummary();
        }

        public JsonResult RemoveProduct(Guid productId)
        {
            var cart = loadCart();

            cart.Remove(productId);
            saveCart(cart);

            return GetCartSummary();
        }

        public JsonResult GetCartSummary()
        {
            var cart = loadCart();

            var summary = cart.GetSummary();
            return Json(summary, JsonRequestBehavior.AllowGet);
        }

        #region Private

        private CartModel loadCart()
        {
            var cart = Session["_CART"] as CartModel;
            if (null == cart)
            {
                Session["_CART"] = cart = new CartModel();
            }
            return cart;
        }

        private void saveCart(CartModel cart)
        {
            Session["_CART"] = cart;
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

        #endregion
    }
}
