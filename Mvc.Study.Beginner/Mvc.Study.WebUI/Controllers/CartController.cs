using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Mvc.Study.Beginner.Core;
using Mvc.Study.Beginner.Models;
using Mvc.Study.Domain;
using Mvc.Study.Domain.Model;

namespace Mvc.Study.Beginner.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public ActionResult Checkout()
        {
            var cart = loadCart();

            var model = new CheckoutModel
                {
                    Items = cart.GetItems(),
                    TotalCost = cart.GetSummary().TotalCost
                };

            SessionHelper.Put(SessionHelper.CartItems, model.Items);

            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutModel model)
        {
            model.Items = SessionHelper.Get<CartItemModel[]>(SessionHelper.CartItems);

            var successModel = new CheckoutSuccessModel();

            using (var db = new TestDbContext())
            {
                var order = new Order
                    {
                        OrderDate = DateTime.Now,
                        TotalCost = model.Items.Sum(i => i.Cost),
                        Fio = model.Customer.Fio,
                        Email = model.Customer.Email,
                        Phone = model.Customer.Phone,
                        DeliveryAddress = model.Customer.DeliveryAddress,
                        IsDeliveryRequired = model.Customer.IsDeliveryRequired
                    };
                order = db.Orders.Add(order);

                successModel.OrderId = order.Id;
                successModel.OrderCost = order.TotalCost;

                db.SaveChanges();
            }

            return View("CheckoutSuccess", successModel);
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
