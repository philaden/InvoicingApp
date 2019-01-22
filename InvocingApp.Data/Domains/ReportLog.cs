using InvocingApp.Data.Domains;
using InvocingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.BusinessDomains
{
    public class ReportLog : BaseEntity
    {
        public DateTime LastReportingTime { get; set; }
        public ReportType ReportType { get; set; }
        public RecurrenceInterval RecurrenceInterval { get; set; }
    }
}
