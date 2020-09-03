using AutoMapper;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using DevExtreme.AspNet.Mvc.Builders;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
				.ForMember(d => d.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
				.ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Customer.Company))
				.ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
				.ForMember(d => d.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
				.ForMember(d => d.ItemCount, opt => opt.MapFrom(src => src.InvoiceLine.Count()))
				.ForMember(d => d.IsCorporate, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.Customer.Company)))
				.ReverseMap()
					.ForMember(q => q.Customer, option => option.Ignore())
					/*.AfterMap((src, dst) =>
					{
						if (dst.Customer != null)
						{
							dst.Customer.LastName = src.LastName;
							dst.Customer.FirstName = src.FirstName;
							dst.Customer.Company = src.Company;
						}
					})*/;
			CreateMap<Customer, DTOCustomer>()
				.ReverseMap();
			CreateMap<Customer, DTOCustomerLookup>()
				.ForMember(d => d.DisplayName,
						opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Company)
					? $"{src.LastName}, {src.FirstName}"
					: src.Company));

		}
	}
}
