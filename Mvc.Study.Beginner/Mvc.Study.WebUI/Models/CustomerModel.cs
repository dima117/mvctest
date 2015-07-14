using System.ComponentModel.DataAnnotations;
using Mvc.Study.Beginner.Core.Attributes;

namespace Mvc.Study.Beginner.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Не указано ФИО")]
        [StringLength(50)]
        public string Fio { get; set; }

        [ContactsValidation]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Адрес почты в некорректном формате")]
        [ContactsValidation]
        public string Email { get; set; }

        [DeliveryValidation]
        public bool IsDeliveryRequired { get; set; }

        [DeliveryValidation]
        public string DeliveryAddress { get; set; }
    }
}