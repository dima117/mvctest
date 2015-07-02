namespace Mvc.Study.Beginner.Models
{
    public class CartCheckoutModel
    {
        public CartItemModel[] Items { get; set; }

        public decimal TotalCost { get; set; }

        public CustomerModel Customer { get; set; }
    }
}