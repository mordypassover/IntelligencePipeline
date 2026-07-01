using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    abstract class DroneValidator : BaseValidator 
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            return ValidationResult.Success();
        }
    }
}
