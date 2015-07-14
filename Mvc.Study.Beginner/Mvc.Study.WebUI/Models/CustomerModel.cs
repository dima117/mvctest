namespace Mvc.Study.Beginner.Models
{
    public class CustomerModel
    {
        public string Fio { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsDeliveryRequired { get; set; }

        public string DeliveryAddress { get; set; }
    }
}