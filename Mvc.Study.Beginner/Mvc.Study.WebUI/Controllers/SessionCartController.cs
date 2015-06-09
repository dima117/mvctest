using System;
using System.Web.Mvc;
using AutoMapper;

namespace Mvc.Study.Beginner.Controllers
{
    public class SessionCartController : CartController
    {
        public override ActionResult Add(Guid productId)
        {
            var product = GetProduct(productId);

            var cart = Session["_CART"] as CartModel ?? new CartModel();
            cart.Items.Add(Mapper.Map<CartItemModel>(product));
            Session["_CART"] = cart;

            return new EmptyResult();
        }

        public override ActionResult Remove(Guid productId)
        {
            var cart = Session["_CART"] as CartModel ?? new CartModel();
            cart.Items.RemoveAll(i => i.ProductId == productId);
            Session["_CART"] = cart;

            return new EmptyResult();
        }

        public override ActionResult GetList()
        {
            var cart = Session["_CART"] as CartModel ?? new CartModel();

            return View(cart.Items);
        }
    }
}
