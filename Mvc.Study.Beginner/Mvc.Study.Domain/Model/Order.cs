using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Study.Domain.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalCost { get; set; }

        public string Fio { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsDeliveryRequired { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
