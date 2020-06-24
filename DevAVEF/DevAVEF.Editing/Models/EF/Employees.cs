using System;
using System.Collections.Generic;

namespace DevAVEF.Editing.Models.EF
{
    public partial class Employees
    {
        public Employees()
        {
            CustomerCommunications = new HashSet<CustomerCommunications>();
            EvaluationsCreatedBy = new HashSet<Evaluations>();
            EvaluationsEmployee = new HashSet<Evaluations>();
            Orders = new HashSet<Orders>();
            ProductsProductEngineer = new HashSet<Products>();
            ProductsProductSupport = new HashSet<Products>();
            Quotes = new HashSet<Quotes>();
            TasksTaskAssignedEmployee = new HashSet<Tasks>();
            TasksTaskOwner = new HashSet<Tasks>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeePrefix { get; set; }
        public string EmployeeTitle { get; set; }
        public byte[] EmployeePicture { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeCity { get; set; }
        public int? EmployeeStateId { get; set; }
        public int? EmployeeZipcode { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeSkype { get; set; }
        public string EmployeeMobilePhone { get; set; }
        public string EmployeeHomePhone { get; set; }
        public DateTime? EmployeeBirthDate { get; set; }
        public DateTime? EmployeeHireDate { get; set; }
        public int? EmployeeDepartmentId { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeePersonalProfile { get; set; }
        public int? ProbationReason { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Departments EmployeeDepartment { get; set; }
        public virtual States EmployeeState { get; set; }
        public virtual ICollection<CustomerCommunications> CustomerCommunications { get; set; }
        public virtual ICollection<Evaluations> EvaluationsCreatedBy { get; set; }
        public virtual ICollection<Evaluations> EvaluationsEmployee { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Products> ProductsProductEngineer { get; set; }
        public virtual ICollection<Products> ProductsProductSupport { get; set; }
        public virtual ICollection<Quotes> Quotes { get; set; }
        public virtual ICollection<Tasks> TasksTaskAssignedEmployee { get; set; }
        public virtual ICollection<Tasks> TasksTaskOwner { get; set; }
    }
}
