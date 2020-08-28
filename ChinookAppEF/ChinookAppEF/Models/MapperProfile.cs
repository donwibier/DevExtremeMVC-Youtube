using AutoMapper;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Models
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Invoice, DTOInvoice>()
				.ForMember(d => d.Date, opt => opt.MapFrom(src => src.InvoiceDate))
				//.ForMember(d => d.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
				.ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Customer.Company))
				.ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
				.ForMember(d => d.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
				.ForMember(d => d.ItemCount, opt => opt.MapFrom(src => src.InvoiceLine.Count()))
				.ReverseMap()
					.ForMember(q => q.Customer, option => option.Ignore())
					.AfterMap((src, dst) =>
					{
						if (dst.Customer != null)
						{
							dst.Customer.LastName = src.LastName;
							dst.Customer.FirstName = src.FirstName;
							dst.Customer.Company = src.Company;
						}
					});
		}
	}
}
