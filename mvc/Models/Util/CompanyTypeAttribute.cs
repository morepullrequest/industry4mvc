using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Util
{
    public class CompanyTypeAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CompanyAndOrganizationFeedback feedback = (CompanyAndOrganizationFeedback)(validationContext.ObjectInstance);

            if (String.IsNullOrEmpty(feedback.CompanyName))
            {
                return new ValidationResult("Company name can't be empty.");
            }

            if (!DataConstants.CompanysAndOrganizations.Contains(feedback.CompanyName))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        protected string GetErrorMessage()
        {
            return "Company name must be " + String.Join(",", DataConstants.CompanysAndOrganizations);
        }
    }
}
