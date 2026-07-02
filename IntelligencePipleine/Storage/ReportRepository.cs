using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipleine.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace IntelligencePipeline.Pipeline
{
    class ReportRepository
    {
        private List<Report> _reports;

        public List<Report> Reports 
        {
            get => _reports;
            set;
        }

        public ReportRepository()
        {
            _reports = new List<Report>();
        }
        public void Add(Report report)
        {

        }
        public List<Report> GetAll() => Reports;

        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> byStatusList = new List<Report>();
            foreach (Report report in Reports)
            {
                if (report.Status == status) { byStatusList.Add(report); }
            }
            return byStatusList;
        }
        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> byPrioretyList = new List<Report>();
            foreach (Report report in Reports)
            {
                if (report.Priority == priority) { byPrioretyList.Add(report); }
            }
            return byPrioretyList;
        }
        public List<Report> Search(string keyword)
        {
            List<Report> haveKeyWord = new List<Report>();
            foreach (Report report in Reports)
            {
                foreach (string word in report.Description.Split())
                {
                    if (word == keyword)
                    {
                        haveKeyWord.Add(report);
                        break;
                    }
                }
            }
            return haveKeyWord;
        }
        public Report? GetById(int reportId) 
        {
            foreach (Report report in Reports)
            {
                if (report.ReportId == reportId) { return report; }
            }
            return null;
        }
        public void UpdateStatus(int reportId, ReportStatus newStatus) 
        {
            Report? report = GetById(reportId);
            if (report != null) 
            { 
                report.Status = newStatus;
            }
        }
        public int GetTotalCount() => Reports.Count();
        public int GetCountByStatus(ReportStatus status) 
        {
            return GetByStatus(status).Count();
        }
    }
}
