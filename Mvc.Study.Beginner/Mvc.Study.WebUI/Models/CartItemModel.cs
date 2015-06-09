using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные о товаре в корзине
    /// </summary>
    public class CartItemModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Amount { get; set; }
    }
}