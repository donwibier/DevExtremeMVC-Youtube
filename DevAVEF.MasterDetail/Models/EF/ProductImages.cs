using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class ProductImages
    {
        public int ImageId { get; set; }
        public int? ProductId { get; set; }
        public byte[] ProductImage { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Products Product { get; set; }
    }
}
