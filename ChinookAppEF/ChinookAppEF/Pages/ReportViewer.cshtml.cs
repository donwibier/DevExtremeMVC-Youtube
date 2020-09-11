using DevExpress.DataAccess.ObjectBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Pages
{
	public class ReportViewerModel : PageModel
	{
		public string ReportType { get; set; }

		[BindProperty(SupportsGet = true, Name = "ids")]
		public int[] ItemIDs { get; set; }

		public string ReportCommand { get => $"{ReportType}?ids={(string.Join(",", ItemIDs))}"; }

		public void OnGet(string reportType, int id)
		{
			ReportType = reportType;
			ItemIDs = new int[] { id };
		}
	}
}
