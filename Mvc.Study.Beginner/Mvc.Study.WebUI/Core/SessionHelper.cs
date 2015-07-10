using System.Web;

namespace Mvc.Study.Beginner.Core
{
    public static class SessionHelper
    {
        public static T Put<T>(string key, T value)
        {
            HttpContext.Current.Session[key] = value;
            return value;
        }

        public static T Get<T>(string key)
        {
            return (T) HttpContext.Current.Session[key];
        }

        #region Keys

        public const string CartItems = "CART_ITEMS";

        #endregion
    }
}