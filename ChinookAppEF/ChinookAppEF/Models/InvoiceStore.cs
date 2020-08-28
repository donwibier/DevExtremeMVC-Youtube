using AutoMapper;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Models
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

}
