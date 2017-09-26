using System;
using System.Collections.Generic;

namespace ThesisManagement_Core.DAL.Model
{
    public partial class ThesisInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string TicketNumber { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte IsDelete { get; set; }
        public string ThesisName { get; set; }
        public string ThesisFilelName { get; set; }
        public string CheckReportName { get; set; }
        public string CheckReportFileName { get; set; }
    }
}
