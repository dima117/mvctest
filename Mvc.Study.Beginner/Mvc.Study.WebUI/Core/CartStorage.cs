using System.Web;

namespace Mvc.Study.Beginner
{
    public class CartStorage
    {
        private readonly HttpSessionStateBase _session;

        public CartStorage(HttpSessionStateBase session)
        {
            _session = session;
        }

        public CartModel LoadCart()
        {
            var cart = _session["_CART"] as CartModel;
            if (null == cart)
            {
                _session["_CART"] = cart = new CartModel();
            }
            return cart;
        }

        public void SaveCart(CartModel cart)
        {
            _session["_CART"] = cart;
        }
    }
}