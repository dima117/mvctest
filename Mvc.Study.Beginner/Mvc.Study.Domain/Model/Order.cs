using System;

namespace Mvc.Study.Domain.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string Fio { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsDeliveryRequired { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
