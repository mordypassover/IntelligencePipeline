using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace IntelligencePipeline.Calculators
{
    class ClassificationCalculator
    {
        private string[] SecretKeywords = { "weapon", "border" };
        private string[] TopSecretKeywords = { "target",  "attack", "missile"};
        public Classification Calculate(Report report)
        {
            Classification CalculatedClassification = Classification.Unclassified;
            // checks if report is Restricted
            if (report.Priority == Priority.Medium || report is SoldierReport)
            {
                CalculatedClassification = Classification.Restricted;
            }
            // checks if report is Secret
            if (report.Priority == Priority.High || report is SignalReport ||
                ContainsKeyword(report.Description, SecretKeywords))
            {
                CalculatedClassification = Classification.Secret;
            }
            // checks if report is TopSecret
            if (report.Priority == Priority.Critical ||
                ContainsKeyword(report.Description, TopSecretKeywords))
            {
                CalculatedClassification = Classification.TopSecret;
            }

            return CalculatedClassification;
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach (string word in keywords)
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
