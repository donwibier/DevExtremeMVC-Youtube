using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class CustomerStoreLocations
    {
        public CustomerStoreLocations()
        {
            CustomerEmployees = new HashSet<CustomerEmployees>();
        }

        public int CustomerStoreId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerStoreLocation { get; set; }
        public string CustomerStoreAddress { get; set; }
        public string CustomerStoreCity { get; set; }
        public int? CustomerStoreState { get; set; }
        public int? CustomerStoreZipcode { get; set; }
        public string CustomerStorePhone { get; set; }
        public string CustomerStoreFax { get; set; }
        public int? CustomerStoreTotalEmployees { get; set; }
        public int? CustomerStoreSquareFootage { get; set; }
        public decimal? CustomerStoreAnnualSales { get; set; }
        public int? CrestId { get; set; }

        public virtual Crests Crest { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<CustomerEmployees> CustomerEmployees { get; set; }
    }
}
