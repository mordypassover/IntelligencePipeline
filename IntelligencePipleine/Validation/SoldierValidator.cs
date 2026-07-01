using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    abstract class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            return ValidationResult.Success();
        }
    }
}