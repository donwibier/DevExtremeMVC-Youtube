using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public int? TaskAssignedEmployeeId { get; set; }
        public int? TaskOwnerId { get; set; }
        public int? TaskCustomerEmployeeId { get; set; }
        public string TaskSubject { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskDueDate { get; set; }
        public string TaskStatus { get; set; }
        public int? TaskCompletion { get; set; }
        public bool? TaskReminder { get; set; }
        public DateTime? TaskReminderDate { get; set; }
        public DateTime? TaskReminderTime { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public int TaskPriority { get; set; }

        public virtual Employees TaskAssignedEmployee { get; set; }
        public virtual CustomerEmployees TaskCustomerEmployee { get; set; }
        public virtual Employees TaskOwner { get; set; }
    }
}
