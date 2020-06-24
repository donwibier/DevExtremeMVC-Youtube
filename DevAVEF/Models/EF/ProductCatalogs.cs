using System;
using System.Collections.Generic;

namespace DevAVEF.Models.EF
{
    public partial class ProductCatalogs
    {
        public int CatalogId { get; set; }
        public int? ProductId { get; set; }
        public byte[] CatalogPdf { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Products Product { get; set; }
    }
}
