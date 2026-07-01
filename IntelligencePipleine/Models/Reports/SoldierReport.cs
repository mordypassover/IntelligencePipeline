using IntelligencePipleine.Models.Enums;
using System;

namespace IntelligencePipeline.Models.Reports
{
    class SoldierReport : Report
    {
        private string _soldierName;
        private string _soldierID;
        private string _unit;
        private int _confidenceLevel;

        string SoldierName { get => _soldierName; set { _soldierName = value; } }
        string SoldierID { get => _soldierID; set { _soldierID = value; } } 
        string Unit { get => _unit; set { _unit = value; } } 
        int ConfidenceLevel { get => _confidenceLevel; set { _confidenceLevel = value; } }

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
            int BASErELIABILITY = 4;
            int reliability = BASErELIABILITY + ConfidenceLevel;
             foreach (string word in Description.Split())
                if (Enum.TryParse(word,true, out DiscriptionKeyWords _))
                { 
                    reliability += 1; 
                    break;
                }
            return reliability;
        }
    }
}