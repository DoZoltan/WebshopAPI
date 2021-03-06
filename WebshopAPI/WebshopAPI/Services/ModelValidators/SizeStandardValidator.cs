using System;
using System.ComponentModel.DataAnnotations;
using WebshopAPI.Enums;

namespace WebshopAPI.Services.ModelValidators
{
    public class SizeStandardValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectType;

            if (obj != null && Enum.IsDefined(typeof(MotherboardSizeStandardEnum), value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Motherboard size standard is invalid");
        }
    }
}
