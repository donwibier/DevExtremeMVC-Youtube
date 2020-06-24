using System;
using System.Collections.Generic;

namespace DevAVEF.Editing.Models.EF
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int? OrderInvoiceNumber { get; set; }
        public int? OrderCustomerId { get; set; }
        public int? OrderCustomerLocationId { get; set; }
        public int? OrderPoNumber { get; set; }
        public int? OrderEmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderSaleAmount { get; set; }
        public decimal? OrderShippingAmount { get; set; }
        public decimal? OrderTotalAmount { get; set; }
        public DateTime? OrderShipDate { get; set; }
        public string OrderShipMethod { get; set; }
        public string OrderTerms { get; set; }
        public string OrderComments { get; set; }

        public virtual Customers OrderCustomer { get; set; }
        public virtual Employees OrderEmployee { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
