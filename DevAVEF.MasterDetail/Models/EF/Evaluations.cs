using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class Evaluations
    {
        public int NoteId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? EmployeeId { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Employees CreatedBy { get; set; }
        public virtual Employees Employee { get; set; }
    }
}
