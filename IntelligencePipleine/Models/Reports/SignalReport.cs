using IntelligencePipeline.Models.Enums;
using IntelligencePipleine.Models.Enums;
using System;

namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {
        private double _frequency;
        private string _content;
        private Language _language;
        private int _signalStrength;

        public double Frequency { get => _frequency; set { _frequency = value; } }
        public string Content { get => _content; set { _content = value; } }
        public Language Language { get => _language; set { _language = value; } }
        public int SignalStrength { get => _signalStrength; set { _signalStrength = value; } }

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
            int BASErELIABILITY = 5;
            int reliability = BASErELIABILITY;
            if (SignalStrength <= -100) { reliability -= 2; }
            if (SignalStrength >= -70) { reliability += 2; }
            else if (SignalStrength >= -40) { reliability += 3; }
            foreach (string word in Content.Split())
                if (Enum.TryParse(word, true, out ContentKeyWords _))
                {
                    reliability += 1;
                    break;
                }
            return reliability;
        }
    }
}