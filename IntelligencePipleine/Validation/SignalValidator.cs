using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    abstract class SignalValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            return ValidationResult.Success();
        }
    }
}
