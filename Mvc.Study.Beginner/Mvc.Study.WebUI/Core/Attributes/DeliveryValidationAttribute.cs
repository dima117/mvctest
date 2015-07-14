using System.ComponentModel.DataAnnotations;
using Mvc.Study.Beginner.Models;

namespace Mvc.Study.Beginner.Core.Attributes
{
    public class DeliveryValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as CustomerModel;

            if (null == model)
            {
                return new ValidationResult("invalid model type");
            }

            var isValid = !model.IsDeliveryRequired || !string.IsNullOrWhiteSpace(model.DeliveryAddress);

            if (!isValid)
            {
                return new ValidationResult("Не указан адрес доставки");
            }
            
            return ValidationResult.Success;
        }
    }
}