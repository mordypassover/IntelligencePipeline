using System;

namespace IntelligencePipeline.Models.Reports
{
    class RadarReport : Report
    {
        private int _speed;
        private int _direction;
        private int _distance;

        int Speed { get => _speed; set { _speed = value; } } 
        int Direction { get => _direction; set { _direction = value; } }
        int Distance { get => _distance; set { _distance = value; } }

        public RadarReport(int reportId, DateTime timestamp, double latitude,
        double longitude, string description, int speed, int direction, int distance)
        : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }
        public override string GetSourceType() => "Radar";

        public override int CalculateReliabilityScore()
        {
            int BASErELIABILITY = 6;
            int reliability = BASErELIABILITY;
            if (Distance > 70000) { reliability -= 2; }
            if (Distance > 500 && Distance < 30000) { reliability += 2;}
            if (Speed > 1500) { reliability -= 2; }
            if (Speed > 10 && Speed < 900) { reliability += 1; }

            return reliability;
        }
    }
}