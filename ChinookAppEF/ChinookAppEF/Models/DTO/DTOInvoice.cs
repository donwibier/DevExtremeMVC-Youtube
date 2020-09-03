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
		[Display(Name = "#", AutoGenerateField = true)]
		[Editable(false)]
		public int? InvoiceId { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public DateTime Date { get; set; }

		public string Company { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public decimal Total { get; set; }
		[Editable(false)]
		public bool IsCorporate { get; set; }
		[Editable(false)]
		public int? ItemCount { get; set; }

	}
}
