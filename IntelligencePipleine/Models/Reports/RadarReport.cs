using System;

namespace IntelligencePipeline.Models.Reports
{
    class RadarReport : Report
    {
        private int _speed;
        private int _direction;
        private int _distance;

        int Speed { get; set; } 
        int Direction { get; set; }
        int Distance { get; set; }

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
            return 0;
        }
    }
}