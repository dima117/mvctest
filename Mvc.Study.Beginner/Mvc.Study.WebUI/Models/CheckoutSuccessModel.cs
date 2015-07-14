using System;

namespace Mvc.Study.Beginner.Models
{
    public class CheckoutSuccessModel
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderCost { get; set; }
    }
}