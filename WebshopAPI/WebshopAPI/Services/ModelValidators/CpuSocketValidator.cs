using System;
using System.ComponentModel.DataAnnotations;
using WebshopAPI.Enums;

namespace WebshopAPI.Services.ModelValidators
{
    public class CpuSocketValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectType;

            if (obj != null && Enum.IsDefined(typeof(CpuSocketEnum), value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("CPU socket type is invalid");
        }
    }
}
