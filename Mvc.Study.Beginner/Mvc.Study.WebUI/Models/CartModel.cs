using System.Collections.Generic;
using System.Linq;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Корзина покупок
    /// </summary>
    public class CartModel
    {
        public List<CartItemModel> Items { get; set; }

        public decimal Total
        {
            get { return Items.Sum(i => i.ProductPrice*i.Amount); }
        }
    }
}