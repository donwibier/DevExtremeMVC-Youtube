using System;
using System.Collections.Generic;

namespace DevAVEF.MasterDetail.Models.EF
{
    public partial class PasteErrors
    {
        public int? CustomerStoreId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerStoreLocation { get; set; }
        public string CustomerStoreAddress { get; set; }
        public string CustomerStoreCity { get; set; }
        public string CrestId { get; set; }
        public string CustomerStoreState { get; set; }
        public int? CustomerStoreZipcode { get; set; }
        public string CustomerStorePhone { get; set; }
        public string CustomerStoreFax { get; set; }
        public int? CustomerStoreTotalEmployees { get; set; }
        public int? CustomerStoreSquareFootage { get; set; }
        public decimal? CustomerStoreAnnualSales { get; set; }
    }
}
