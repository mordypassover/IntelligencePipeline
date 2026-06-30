using System;

namespace IntelligencePipeline.Models.Reports
{
    class DroneReport: Report
    {
        private int _altitude;
        private int _imageQuality;

        int Altitude { get; set; } 
        int ImageQuality { get; set; }

        public DroneReport(int reportId, DateTime timestamp, double latitude, double longitude, string description,
            int altitude, int imageQuality) : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }
        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            return 0;
        }
    }
}