using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    abstract class BaseValidator :IValidator
    {
        public ValidationResult Validate(Report report)
        {
            ValidationResult commonFieldsAreValidation = ValidateCommonFields(report);
            if (commonFieldsAreValidation.IsValid) 
            {
                return ValidateSpecificFields(report);
            }
            return commonFieldsAreValidation;

        }
        protected ValidationResult ValidateCommonFields(Report report)
        {
            // nead to add validations! 
            return ValidationResult.Success();
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}