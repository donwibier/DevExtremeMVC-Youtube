using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class QuoteItems
    {
        public int QuoteItemId { get; set; }
        public int? QuoteId { get; set; }
        public int? QuoteItemProductId { get; set; }
        public int? QuoteItemProductUnits { get; set; }
        public decimal? QuoteItemProductPrice { get; set; }
        public decimal? QuoteItemDiscount { get; set; }
        public decimal? QuoteItemTotal { get; set; }

        public virtual Quotes Quote { get; set; }
        public virtual Products QuoteItemProduct { get; set; }
    }
}
