using DevExpress.DataAccess.ObjectBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Pages
{
	public class InvoiceReportModel : PageModel
	{
		[BindProperty(SupportsGet = true, Name = "id")]
		public int InvoiceID { get; set; }

		//public ObjectDataSource reportDS { get; private set; }
		public void OnGet()
		{

		}
	}
}
