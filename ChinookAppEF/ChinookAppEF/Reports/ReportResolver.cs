using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Reports
{
	public class ReportResolver : IWebDocumentViewerReportResolver
	{
		public ReportResolver() { }



		public XtraReport Resolve(string reportUniqueName)
		{
			//Uri u = new Uri(reportUniqueName);
			var parts = reportUniqueName.Split('?');
			string reportName = parts[0]; // reportUniqueName.Substring(0, reportUniqueName.IndexOf("?"));
			var pars = QueryHelpers.ParseQuery(parts[1]);
			switch (reportName)
			{
				case "Invoice":
					{
						var report = new InvoiceRpt();
						var ids = pars["ids"].Select(i => i).ToArray();
						report.Parameters["invoiceIds"].Value = string.Join(',', ids);
						return report;
					}
				default:
					// Try to create a report using the fully qualified type name.
					Type t = Type.GetType(reportUniqueName);
					return typeof(XtraReport).IsAssignableFrom(t)
						? (XtraReport)Activator.CreateInstance(t)
						: null;
			}
		}
	}
}
