using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Корзина покупок
    /// </summary>
    public class CartModel
    {
        private readonly List<CartItemModel> _items =
            new List<CartItemModel>();

        public void Add(CartItemModel cartItem)
        {
            if (null == cartItem)
                return;

            if(_items.All(i => i.Id != cartItem.Id))
            {
                _items.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }
        }

        public void Remove(Guid productId)
        {
            _items.RemoveAll(i => i.Id == productId);
        }

        public CartItemModel[] GetItems()
        {
            return _items.ToArray();
        }

        public CartSummaryModel GetSummary()
        {
            return new CartSummaryModel
                {
                    TotalAmount = _items.Sum(i => i.Amount),
                    TotalPrice = _items.Sum(i => i.Price*i.Amount)
                };
        }
    }
}