using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    class DroneValidator : BaseValidator 
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            List<string>? messages = new List<string>(); // colects all validation messeges 

            if (report is not DroneReport droneReport) { messages.Add("report is not a drone report"); }
            else // makes shore that if report is not a drone report, wont try other validations and crash
            {
                if (droneReport.ImageQuality < 0 || droneReport.ImageQuality > 100) { messages.Add("ImageQuality not valid"); }
                if (droneReport.Altitude > 100 || droneReport.Altitude < 100) { messages.Add("ImageQuality not valid"); }
            }
            if (messages != null)
            {
                return ValidationResult.Failure(string.Join(", ", messages));
            }
            return ValidationResult.Success();
        }
    }
}
