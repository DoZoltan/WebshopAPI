using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
