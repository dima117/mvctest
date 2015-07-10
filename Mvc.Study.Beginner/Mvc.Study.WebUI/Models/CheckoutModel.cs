namespace Mvc.Study.Beginner.Models
{
    public class CheckoutModel
    {
        public CheckoutModel()
        {
            Items = new CartItemModel[]{};
            Customer = new CustomerModel();
        }

        public CartItemModel[] Items { get; set; }

        public decimal TotalCost { get; set; }

        public CustomerModel Customer { get; set; }
    }
}