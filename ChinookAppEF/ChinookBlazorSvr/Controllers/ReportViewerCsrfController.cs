using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChinookBlazorSvr.Controllers
{
	[Route("ViewerCsrf")]
	[ValidateAntiForgeryToken]
	public class ReportViewerCsrfController : WebDocumentViewerController
	{
		/// <summary>
		/// <para></para>
		/// </summary>
		/// <param name="controllerService"></param>
		public ReportViewerCsrfController(IWebDocumentViewerMvcControllerService controllerService) : base(
			controllerService)
		{
		}
	}

}
