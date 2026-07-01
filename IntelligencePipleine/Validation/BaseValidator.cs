using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    abstract class BaseValidator :IValidator
    {
        public ValidationResult Validate(Report report)
        {
            // checks common fieldes then if success checks specific validator
            ValidationResult commonFieldsAreValid = ValidateCommonFields(report);
            if (commonFieldsAreValid.IsValid) 
            {
                return ValidateSpecificFields(report);
            }
            return commonFieldsAreValid;

        }
        protected ValidationResult ValidateCommonFields(Report report)
        {
            List<string>? messages = new List<string>(); // colects all validation messeges 

            if (report.Timestamp.Year < 2020 || report.Timestamp.Year > 2026) { messages.Add("timestamp not valid") ; }
            if( report.Latitude < 29.5000 || report.Latitude > 33.5000) { messages.Add("Latitude not valid"); }
            if (report.Longitude < 34.0000 || report.Longitude > 36.0000) { messages.Add("Longitude not valid"); }
            if (report.Description.Length < 10 || report.Description.Length > 500 ) { messages.Add("Description not valid"); }

            if (messages != null) 
            {
                return ValidationResult.Failure(string.Join(", ", messages));
            }
        
            return ValidationResult.Success();
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}