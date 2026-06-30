using System;

namespace IntelligencePipeline.Models.Reports
{
    class SoldierReport : Report
    {
        private string _soldierName;
        private string _soldierID;
        private string _unit;
        private int _confidenceLevel;

        string SoldierName { get; set; }
        string SoldierID { get; set; } 
        string Unit { get; set; } 
        int ConfidenceLevel { get; set; }

        public SoldierReport(int reportId, DateTime timestamp, double latitude, double longitude,
            string description, string soldierName, string soldierID, string unit, int confidenceLevel) 
            : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            Unit = unit;
            ConfidenceLevel = confidenceLevel;
        }
        public override string GetSourceType() => "Soldier";
        public override int CalculateReliabilityScore()
        {
            return 0;
        }
    }
}