﻿using AutoMapper;
using ChinookBlazorSvr.Models.DTO;
using ChinookBlazorSvr.Models.EF;
using Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookBlazorSvr.Models
{
	public class InvoiceStore : EFDataStore<ChinookContext, int, DTOInvoice, Invoice>
	{
		public InvoiceStore(ChinookContext db, IMapper mapper)
			: base(db, mapper, new InvoiceValidator())
		{

		}

		public override int DBModelKey(Invoice model)
		{
			return model.InvoiceId;
		}

		public override int ModelKey(DTOInvoice model)
		{
			return model.InvoiceId.HasValue ? model.InvoiceId.Value : 0;
		}

		protected override Invoice EFGetByKey(int key)
		{
			return EFQuery().Include(i => i.Customer).FirstOrDefault(i => i.InvoiceId == key);
		}
	}

	public class InvoiceValidator : DataValidator<ChinookContext, int, DTOInvoice, Invoice>
	{
	}


	public class InvoiceLineStore : EFDataStore<ChinookContext, int, DTOInvoiceLine, InvoiceLine>
	{
		public InvoiceLineStore(ChinookContext db, IMapper mapper)
			: base(db, mapper, new InvoiceLineValidator())
		{

		}

		public override int DBModelKey(InvoiceLine model)
		{
			return model.InvoiceId;
		}

		public override int ModelKey(DTOInvoiceLine model)
		{
			return model.InvoiceId;
		}

		//protected override EF.Invoice EFGetByKey(int key)
		//{
		//	return EFQuery().Include(i => i.Customer).FirstOrDefault(i => i.InvoiceId == key);
		//}

	}
	public class InvoiceLineValidator : DataValidator<ChinookContext, int, DTOInvoiceLine, InvoiceLine>
	{
	}

}
