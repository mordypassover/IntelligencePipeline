using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            return report.CalculateReliabilityScore();
        }
    }
}
