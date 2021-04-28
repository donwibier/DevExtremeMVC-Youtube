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
	public class EmployeeStore : EFDataStore<ChinookContext, int, DTOEmployee, Employee>
	{
		public EmployeeStore(ChinookContext context, IMapper mapper)
			: base(context, mapper, new EmployeeValidator())
		{

		}

		public override int DBModelKey(Employee model)
		{
			return model.EmployeeId;
		}

		public override int ModelKey(DTOEmployee model)
		{
			return model.EmployeeId.HasValue ? model.EmployeeId.Value : 0;
		}
	}

	public class EmployeeValidator : DataValidator<ChinookContext, int, DTOEmployee, Employee>
	{

	}
}
