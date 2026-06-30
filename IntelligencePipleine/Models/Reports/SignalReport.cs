using IntelligencePipeline.Models.Enums;
using System;

namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {
        private double _frequency;
        private string _content;
        private Language _language;
        private int _signalStrength;

        double Frequency { get; set; }
        string Content { get; set; }
        Language Language { get; set; }
        int SignalStrength { get; set; }

        public SignalReport(int reportId, DateTime timestamp, double latitude,
        double longitude, string description, double frequency, string content,
        Language language, int signalStrength) : base(reportId,
        timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";

        public override int CalculateReliabilityScore()
        {
            return 0;
        }
    }
}