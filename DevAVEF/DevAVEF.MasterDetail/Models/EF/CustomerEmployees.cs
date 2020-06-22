using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class CustomerEmployees
    {
        public CustomerEmployees()
        {
            CustomerCommunications = new HashSet<CustomerCommunications>();
            Tasks = new HashSet<Tasks>();
        }

        public int CustomerEmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? CustomerStoreId { get; set; }
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }
        public string CustomerEmployeeFullName { get; set; }
        public string CustomerEmployeePrefix { get; set; }
        public string CustomerEmployeePosition { get; set; }
        public string CustomerEmployeeMobilePhone { get; set; }
        public string CustomerEmployeeEmail { get; set; }
        public bool? CustomerPurchaseAuthority { get; set; }
        public byte[] CustomerEmployeePicture { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual CustomerStoreLocations CustomerStore { get; set; }
        public virtual ICollection<CustomerCommunications> CustomerCommunications { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
