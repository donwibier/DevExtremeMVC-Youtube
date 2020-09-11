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

	public class DTOInvoiceLine
	{
		public int InvoiceLineId { get; set; }

		public int InvoiceId { get; set; }

		public int TrackId { get; set; }
		public string TrackName { get; set; }
		public string Composer { get; set; }
		public string MediaType { get; set; }
		public int MediaTypeId { get; set; }

		public int AlbumId { get; set; }
		public string AlbumName { get; set; }
		public string ArtistName { get; set; }

		public string Genre { get; set; }
		public int GenreId { get; set; }

		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }

		public decimal QuantityPrice { get; set; }
	}

	public class DTOReportingInvoice
	{
		public DTOReportingInvoice()
		{

		}

		public int InvoiceId { get; set; }
		public int CustomerId { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string BillingAddress { get; set; }
		public string BillingCity { get; set; }
		public string BillingState { get; set; }
		public string BillingCountry { get; set; }
		public string BillingPostalCode { get; set; }

		public bool IsCorporate { get; set; }

		public string ContactPhone { get; set; }
		public string ContactFax { get; set; }
		public string ContactEmail { get; set; }

		public decimal Total { get; set; }

		//public virtual DTOCustomer Customer { get; set; } = new DTOCustomer();

		public virtual List<DTOInvoiceLine> InvoiceLines { get; set; } = new List<DTOInvoiceLine>();
	}
}
