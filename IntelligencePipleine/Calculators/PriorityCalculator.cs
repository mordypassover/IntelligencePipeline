using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;


namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {
        private  string[] CriticalKeywords = { "missile", "explosion", "attack", "fire" };
        private  string[] CriticalSignalKeywords = { "target", "attack" };
        private  string[] HighKeywords = { "weapon", "suspicious", "border" };
        private  string[] MediumKeywords = { "movement", "vehicle", "activity" };
        public Priority Calculate(Report report)
        {
            Priority calculatedPriority = Priority.Low;
            //checks if Medium
            if (ContainsKeyword(report.Description, MediumKeywords) ||
                ((report is RadarReport adar1) && (adar1.Speed >= 150 || 
                adar1.ReliabilityScore >= 7)))
            {
                calculatedPriority = Priority.Medium;
            }
            //checks if High
            if (ContainsKeyword(report.Description, HighKeywords) ||
                ((report is DroneReport drone1) && drone1.Altitude < 500) ||
                ((report is RadarReport radar2) && radar2.Speed >= 400) ||
                ((report is SoldierReport soldier) && soldier.ConfidenceLevel >= 4))
            {
                calculatedPriority = Priority.High;
            }
            // checks if critical
            if (ContainsKeyword(report.Description, CriticalKeywords) ||
                (report is RadarReport radar3 && radar3.Speed >= 800) ||
                ((report is SignalReport) && ContainsKeyword(report.Description, CriticalSignalKeywords)))
            {
                calculatedPriority = Priority.Critical;
            }

            return calculatedPriority;
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach ( string word in keywords)
            {
                if (text.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
