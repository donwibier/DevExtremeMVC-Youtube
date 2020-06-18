using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class Quotes
    {
        public Quotes()
        {
            QuoteItems = new HashSet<QuoteItems>();
        }

        public int QuoteId { get; set; }
        public int? QuoteNumber { get; set; }
        public int? QuoteCustomerId { get; set; }
        public int? QuoteCustomerLocationId { get; set; }
        public int? QuoteEmployeeId { get; set; }
        public DateTime? QuoteDate { get; set; }
        public decimal? QuoteSubTotal { get; set; }
        public decimal? QuoteShippingAmount { get; set; }
        public decimal? OrderTotal { get; set; }
        public decimal? QuoteTotal { get; set; }
        public double? QuoteOpportunity { get; set; }

        public virtual Customers QuoteCustomer { get; set; }
        public virtual Employees QuoteEmployee { get; set; }
        public virtual ICollection<QuoteItems> QuoteItems { get; set; }
    }
}
