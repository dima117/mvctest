using System.ComponentModel.DataAnnotations;
using Mvc.Study.Beginner.Models;

namespace Mvc.Study.Beginner.Core.Attributes
{
    public class ContactsValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as CustomerModel;

            if (null == model)
            {
                return new ValidationResult("invalid model type");
            }

            var isValid = !string.IsNullOrWhiteSpace(model.Email) ||
                          !string.IsNullOrWhiteSpace(model.Phone);

            if (!isValid)
            {
                return new ValidationResult("Не указаны контактные данные");
            }

            return ValidationResult.Success;
        }
    }
}