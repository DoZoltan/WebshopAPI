using System;
using System.ComponentModel.DataAnnotations;
using WebshopAPI.Enums;

namespace WebshopAPI.Services.ModelValidators
{
    public class ProductTypeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectType;

            if (obj != null && Enum.IsDefined(typeof(ProductTypeEnum), value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Product type is invalid");
        }
    }
}
