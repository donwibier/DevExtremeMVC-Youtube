using AutoMapper;
using ChinookAppEF.Models;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ObjectBinding;
using Library;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Reports
{
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
		public InvoiceDatasource(int[] invoiceIds)
		{
			this.invoiceIds = invoiceIds;
		}

		[HighlightedMember]
		public IEnumerable<DTOReportingInvoice> GetInvoiceList()
		{
			using (var ctx = new ChinookContext())
			{
				var mapCfg = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
				var map = mapCfg.CreateMapper();
				var invoiceStore = new InvoiceStore(ctx, map);
				var invoiceLineStore = new InvoiceLineStore(ctx, map);

				var invoices = invoiceStore.Query<DTOReportingInvoice>()
					.Where(i => invoiceIds.Contains(i.InvoiceId)).ToList();

				var lines = invoiceLineStore.Query()
					.Where(i => invoiceIds.Contains(i.InvoiceId)).ToList();

				foreach (var invoice in invoices)
				{
					lines.RemoveAll(i => i.InvoiceId == invoice.InvoiceId,
									o => invoice.InvoiceLines.Add(o));
				}

				var r = invoices.ToList();
				return r;
			}
		}
	}
}
