using AutoMapper;
using ChinookBlazorSvr.Models.DTO;
using ChinookBlazorSvr.Models.EF;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookBlazorSvr.Models
{
	public class CustomerStore : EFDataStore<ChinookContext, int, DTOCustomer, Customer>
	{
		public CustomerStore(ChinookContext context, IMapper mapper) : base(context, mapper, new CustomerValidator())
		{
		}

		public override int DBModelKey(Customer model) => model.CustomerId;

		public override int ModelKey(DTOCustomer model) => model.CustomerId.HasValue ? model.CustomerId.Value : 0;
	}

	public class CustomerValidator : DataValidator<ChinookContext, int, DTOCustomer, Customer>
	{
	}

	public class CustomerLookupStore : EFDataStore<ChinookContext, int, DTOCustomerLookup, Customer>
	{
		public CustomerLookupStore(ChinookContext context, IMapper mapper) : base(
			context,
			mapper,
			new CustomerLookupValidator())
		{
		}

		public override int DBModelKey(Customer model) => model.CustomerId;

		public override int ModelKey(DTOCustomerLookup model) => model.CustomerId.HasValue ? model.CustomerId.Value : 0;
	}

	public class CustomerLookupValidator : DataValidator<ChinookContext, int, DTOCustomerLookup, Customer>
	{
	}
}
