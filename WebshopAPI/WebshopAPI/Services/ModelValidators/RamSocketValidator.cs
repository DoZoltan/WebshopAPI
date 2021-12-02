using System;
using System.ComponentModel.DataAnnotations;
using WebshopAPI.Enums;

namespace WebshopAPI.Services.ModelValidators
{
    public class RamSocketValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectType;

            if (obj != null && Enum.IsDefined(typeof(RamSocketEnum), value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("RAM socket type is invalid");
        }
    }
}
