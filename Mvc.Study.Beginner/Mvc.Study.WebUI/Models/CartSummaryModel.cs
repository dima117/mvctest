using System;

namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Суммарные значения корзины
    /// </summary>
    [Serializable]
    public class CartSummaryModel
    {
        public int TotalAmount { get; set; }
        public decimal TotalCost { get; set; }
    }
}