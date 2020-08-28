using AutoMapper;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Models
{
	public class CustomerStore : EFDataStore<ChinookContext, int, DTOCustomer, Customer>
	{
		public CustomerStore(ChinookContext context, IMapper mapper) : base(context, mapper, new CustomerValidator())
		{
		}

		public override int DBModelKey(Customer model) { return model.CustomerId; }

		public override int ModelKey(DTOCustomer model)
		{ 
			return model.CustomerId.HasValue ? model.CustomerId.Value : 0; 
		}
	}

	public class CustomerValidator : DataValidator<ChinookContext, int, DTOCustomer, Customer>
	{

	}
}
