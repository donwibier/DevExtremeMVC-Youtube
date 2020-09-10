using AutoMapper;
using ChinookAppEF.Models;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ObjectBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Reports
{
	public class ReportDatasources
	{
	}
	[DisplayName("Invoices")]
	[HighlightedClass]
	public class InvoiceDatasource
	{
		readonly int[] invoiceIds;
		public InvoiceDatasource()
		{
			invoiceIds = new int[] { 10 };
		}
		[HighlightedMember]
		public InvoiceDatasource(int invoiceId)
		{
			invoiceIds = new int[] { invoiceId };
		}

		[HighlightedMember]
		public InvoiceDatasource(IEnumerable<int> invoiceIds)
		{
			this.invoiceIds = invoiceIds.ToArray();
		}
		[HighlightedMember]
		public IEnumerable<DTOReportingInvoice> GetInvoiceList()
		{
			using (var ctx = new ChinookContext())
			{
				var mapCfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
				var store = new InvoiceStore(ctx, mapCfg.CreateMapper());

				var results = store.Query<DTOReportingInvoice>().Where(i => invoiceIds.Contains(i.InvoiceId));
				return results;
			}
		}
	}
}
