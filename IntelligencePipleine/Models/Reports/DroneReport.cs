using System;

namespace IntelligencePipeline.Models.Reports
{
    class DroneReport: Report
    {
        private int _altitude;
        private int _imageQuality;

        int Altitude { get => _altitude; set { _altitude = value; } } 
        int ImageQuality { get => _imageQuality; set { _imageQuality = value; } }

        public DroneReport(int reportId, DateTime timestamp, double latitude, double longitude, string description,
            int altitude, int imageQuality) : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }
        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            int BASErELIABILITY = 5;
            int reliability = BASErELIABILITY;
            if (Altitude > 7000 ) { reliability -= 3; }
            if (Altitude <= 3000 && Altitude >= 500) { reliability += 2;}
            if (ImageQuality >= 80 ) { reliability += 3; }
            else if (ImageQuality >= 50) { reliability += 2; }
            return reliability;
        }
    }
}