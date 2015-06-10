using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mvc.Study.Beginner.Models;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Корзина покупок
    /// </summary>
    public class CartModel
    {
        private readonly List<CartItemModel> _items =
            new List<CartItemModel>();

        public void Add(ProductModel product)
        {
            var cartItem = _items.FirstOrDefault(i => i.Id == product.Id);

            if (null == cartItem)
            {
                _items.Add(Mapper.Map<CartItemModel>(product));
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