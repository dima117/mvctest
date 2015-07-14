namespace Mvc.Study.Beginner.Models
{
    public class CheckoutModel
    {
        public CartItemModel[] Items { get; set; }

        public decimal TotalCost { get; set; }

        public CustomerModel Customer { get; set; }
    }
}