using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class States
    {
        public States()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
        }

        public int SateId { get; set; }
        public string StateShort { get; set; }
        public string StateLong { get; set; }
        public byte[] Flag48px { get; set; }
        public byte[] Flag24px { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
