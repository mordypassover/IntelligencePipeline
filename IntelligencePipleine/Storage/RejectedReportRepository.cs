using IntelligencePipeline.Models.Reports;
using System;

namespace IntelligencePipeline.Storage
{
    class RejectedReportRepository
    {
        private List<Report> _rejectedReport;

        public List<Report> RejectedReport
        {
            get => _rejectedReport;
            set;

        }

        public RejectedReportRepository()
        {
            _rejectedReport = new List<Report>();
        }
        public void Add(Report report)
        {

        }
        public List<Report> GetAll() => RejectedReport;

        public int GetTotalCount() => RejectedReport.Count();

        public List<Report> GetByReason(string reasonKeyword) { }
    }

}