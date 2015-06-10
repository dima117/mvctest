using System.Web;
using System.Web.Mvc;

namespace Mvc.Study.Beginner
{
    public class CartStorage
    {
        private readonly HttpSessionStateBase _session;

        public CartStorage(Controller sender)
        {
            _session = sender.Session;
        }

        public CartModel LoadCart()
        {
            return _session["_CART"] as CartModel ?? new CartModel();
        }

        public void SaveCart(CartModel cart)
        {
            _session["_CART"] = cart;
        }
    }
}