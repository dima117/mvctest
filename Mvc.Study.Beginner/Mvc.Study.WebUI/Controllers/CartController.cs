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
        private readonly CartStorage _cartStorage;

        public CartController()
        {
            _cartStorage = new CartStorage(this);
        }

        public ActionResult AddProduct(Guid productId)
        {
            var product = getProduct(productId);

            var cart = _cartStorage.LoadCart();
            cart.Add(product);
            _cartStorage.SaveCart(cart);

            return new EmptyResult();
        }

        public ActionResult RemoveProduct(Guid productId)
        {
            var cart = _cartStorage.LoadCart();
            cart.Remove(productId);
            _cartStorage.SaveCart(cart);

            return new EmptyResult();
        }

        public ActionResult GetCartSummary()
        {
            var cartSummary = _cartStorage
                .LoadCart()
                .GetSummary();
            return new EmptyResult();
        }

        private ProductModel getProduct(Guid productId)
        {
            using (var db = new TestDbContext())
            {
                var product = db.Products.First(p => p.Id == productId);
                return Mapper.Map<ProductModel>(product);
            }
        }
    }
}
