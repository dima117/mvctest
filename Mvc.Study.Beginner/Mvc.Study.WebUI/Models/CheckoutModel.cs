using System.Linq;

namespace Mvc.Study.Beginner.Models
{
    public class CheckoutModel
    {
        public CartItemModel[] Items { get; set; }

        public CustomerModel Customer { get; set; }

        public decimal TotalCost
        {
            get { return Items.Sum(i => i.Cost); }
        }
    }
}