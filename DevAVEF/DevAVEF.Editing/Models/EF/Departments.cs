using System;
using System.Collections.Generic;

namespace DevAVEF.Editing.Models.EF
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
