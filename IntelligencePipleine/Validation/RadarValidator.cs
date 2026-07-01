using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            List<string>? messages = new List<string>(); // colects all validation messeges 

            if (report is not RadarReport radarReport) { messages.Add("report is not a radar report"); }
            else // makes shore that if report is not radar report, wont try other validations and crash
            {
                if (radarReport.Speed < 0 || radarReport.Speed > 2000) { messages.Add("speed is not valid"); }
                if (radarReport.Direction < 0 || radarReport.Direction >= 360) { messages.Add("Direction is not valid"); }
                if (radarReport.Distance < 0 || radarReport.Distance > 100000) { messages.Add("Distance is not valid"); }
            }
            if (messages != null)
            {
                return ValidationResult.Failure(string.Join(", ", messages));
            }

            return ValidationResult.Success();
        }
    }
}
