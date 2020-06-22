using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerEmployees = new HashSet<CustomerEmployees>();
            CustomerStoreLocations = new HashSet<CustomerStoreLocations>();
            Orders = new HashSet<Orders>();
            Quotes = new HashSet<Quotes>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public int? CustomerState { get; set; }
        public int? CustomerZipcode { get; set; }
        public string CustomerBillingAddress { get; set; }
        public string CustomerBillingCity { get; set; }
        public int? CustomerBillingState { get; set; }
        public int? CustomerBillingZipcode { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerFax { get; set; }
        public string CustomerWebsite { get; set; }
        public decimal? CustomerAnnualRevenue { get; set; }
        public int? CustomerTotalStores { get; set; }
        public int? CustomerTotalEmployees { get; set; }
        public string CustomerStatus { get; set; }
        public byte[] CustomerLogo { get; set; }
        public string CustomerProfile { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual States CustomerStateNavigation { get; set; }
        public virtual ICollection<CustomerEmployees> CustomerEmployees { get; set; }
        public virtual ICollection<CustomerStoreLocations> CustomerStoreLocations { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
