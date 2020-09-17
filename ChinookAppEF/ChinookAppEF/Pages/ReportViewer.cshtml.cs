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
		public ReportViewerModel() : base()
		{

		}
		[BindProperty(Name = "reportType")]
		public string ReportType { get; set; }

		[BindProperty(Name = "reportSelectedIds")]
		public string SelectedIDs { get; set; }

		public string ReportCommand { get => $"{ReportType}?ids={SelectedIDs}"; }

		public void OnGet(string reportType)
		{
			ReportType = reportType;
		}
		public void OnPost()
		{			
		}
	}
}
