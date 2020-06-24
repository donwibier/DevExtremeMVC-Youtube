using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class OrderItems
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public int? OrderItemProductId { get; set; }
        public int? OrderItemProductUnits { get; set; }
        public decimal? OrderItemProductPrice { get; set; }
        public decimal? OrderItemDiscount { get; set; }
        public decimal? OrderItemTotal { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products OrderItemProduct { get; set; }
    }
}
