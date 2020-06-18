using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class CustomerCommunications
    {
        public int CommId { get; set; }
        public int? CommEmployeeId { get; set; }
        public int? CommCustomerEmployeeId { get; set; }
        public DateTime? CommDate { get; set; }
        public string CommType { get; set; }
        public string CommPurpose { get; set; }

        public virtual CustomerEmployees CommCustomerEmployee { get; set; }
        public virtual Employees CommEmployee { get; set; }
    }
}
