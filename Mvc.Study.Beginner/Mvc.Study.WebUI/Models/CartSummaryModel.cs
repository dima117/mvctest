namespace Mvc.Study.Beginner
{
    /// <summary>
    /// Суммарные значения корзины
    /// </summary>
    public class CartSummaryModel
    {
        public int TotalAmount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}