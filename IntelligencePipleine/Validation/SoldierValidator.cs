using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            List<string>? messages = new List<string>(); // colects all validation messeges 

            if (report is not SoldierReport soldierReport) { messages.Add("report is not a soldier report"); }
            else // makes shore that if report isnt a soldier report, wont try other validations and crash
            {
                if (soldierReport.SoldierName.Length < 2 || soldierReport.SoldierName.Length > 50) { messages.Add("SoldierName not valid"); }
                if (!(soldierReport.SoldierID.Length == 7 && int.TryParse(soldierReport.SoldierID, out int _))) { messages.Add("id is not valid"); }
                if (soldierReport.Unit.Length < 2 || soldierReport.Unit.Length > 50 ) { messages.Add("unit is not valid"); }
                if (soldierReport.ConfidenceLevel < 1 || soldierReport.ConfidenceLevel > 5 ) { messages.Add("confidenceLevel is not valid"); }
            }
            if (messages != null)
            {
                return ValidationResult.Failure(string.Join(", ", messages));
            }
            return ValidationResult.Success();
        }
    }
}