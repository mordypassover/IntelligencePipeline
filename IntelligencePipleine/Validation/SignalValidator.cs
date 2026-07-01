using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Validation
{
    class SignalValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            List<string>? messages = new List<string>(); // colects all validation messeges 

            if (report is not SignalReport signalReport) { messages.Add("report is not a signal report"); }
            else // checks that report is SignalReport befor validation
            {
                if (signalReport.Frequency > 1.0 || signalReport.Frequency < 3000.0) { messages.Add("frequency not valid"); }
                if (signalReport.Content.Length < 5 || signalReport.Content.Length > 3000) { messages.Add("content is not valid"); }
                //if (signalReport.Language is not Language) { messages.Add("language is not valid"); }
                if (signalReport.SignalStrength <= 0 || signalReport.SignalStrength > 120) { messages.Add("SignalStrength is not valid"); }
            }
            if (messages != null)
            {
                return ValidationResult.Failure(string.Join(", ", messages));
            }
            return ValidationResult.Success();
        }
    }
}