using System;
using System.Collections.Generic;

namespace DevAVEF.Editing.Models.EF
{
    public partial class Products
    {
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
            ProductCatalogs = new HashSet<ProductCatalogs>();
            ProductImages = new HashSet<ProductImages>();
            QuoteItems = new HashSet<QuoteItems>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime? ProductProductionStart { get; set; }
        public bool? ProductAvailable { get; set; }
        public byte[] ProductImage { get; set; }
        public int? ProductSupportId { get; set; }
        public int? ProductEngineerId { get; set; }
        public int? ProductCurrentInventory { get; set; }
        public int? ProductBackorder { get; set; }
        public int? ProductManufacturing { get; set; }
        public byte[] ProductBarcode { get; set; }
        public byte[] ProductPrimaryImage { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? ProductSalePrice { get; set; }
        public decimal? ProductRetailPrice { get; set; }
        public double? ProductConsumerRating { get; set; }
        public string ProductCategory { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Employees ProductEngineer { get; set; }
        public virtual Employees ProductSupport { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<ProductCatalogs> ProductCatalogs { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<QuoteItems> QuoteItems { get; set; }
    }
}
