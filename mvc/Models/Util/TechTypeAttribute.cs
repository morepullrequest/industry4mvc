using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Util
{
    public class TechTypeAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EmergingTechnologiesFeedback feedback = (EmergingTechnologiesFeedback)(validationContext.ObjectInstance);

            if (String.IsNullOrEmpty(feedback.EmergingTechnologiesName))
            {
                return new ValidationResult("Emerging technology name can't be empty.");
            }

            if (!DataConstants.TechTypes.Contains(feedback.EmergingTechnologiesName))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        protected string GetErrorMessage()
        {
            return "Emerging technology name must be " + String.Join(",", DataConstants.TechTypes);
        }
    }
}
