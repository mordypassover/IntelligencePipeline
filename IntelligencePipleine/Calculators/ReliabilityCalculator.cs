using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int reliability = report.CalculateReliabilityScore();

            //checks if reliability is valid and sets to 1 if not

            if (reliability < 1 || reliability > 10) { return 1;} 

            return reliability;
        }
    }
}
