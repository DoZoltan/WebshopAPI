using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DAL.Models;
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
