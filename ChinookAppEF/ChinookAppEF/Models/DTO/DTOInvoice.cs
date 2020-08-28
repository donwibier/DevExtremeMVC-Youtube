using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Models.DTO
{
	public class DTOInvoice
	{
		[Key]
		[Editable(false)]
		public int? InvoiceId { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public DateTime Date { get; set; }

		public string Company { get; set; }
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public decimal Total { get; set; }
		[Editable(false)]
		public int? ItemCount { get; set; }

	}
}
