using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Данные о товаре в корзине
    /// </summary>
    public class CartItemModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }
    }
}