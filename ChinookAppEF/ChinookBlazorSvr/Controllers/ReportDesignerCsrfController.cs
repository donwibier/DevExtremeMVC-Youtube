using DevExpress.AspNetCore.Reporting.ReportDesigner;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChinookBlazorSvr.Controllers
{
	[Route("DesignerCsrf")]
	[ValidateAntiForgeryToken]
	public class ReportDesignerCsrfController : ReportDesignerController
	{
		/// <summary>
		/// <para></para>
		/// </summary>
		/// <param name="controllerService"></param>
		public ReportDesignerCsrfController(IReportDesignerMvcControllerService controllerService)
			: base(controllerService)
		{

		}
	}

}
