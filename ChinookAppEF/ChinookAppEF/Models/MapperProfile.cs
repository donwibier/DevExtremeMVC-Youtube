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
			CreateMap<InvoiceLine, DTOReportingInvoiceLine>()
				.ForMember(d => d.TrackName, o => o.MapFrom(s => s.Track.Name))
				.ForMember(d => d.Composer, o => o.MapFrom(s => s.Track.Composer))
				.ForMember(d => d.MediaType, o => o.MapFrom(s => s.Track.MediaType.Name))
				.ForMember(d => d.MediaTypeId, o => o.MapFrom(s => s.Track.MediaTypeId))
				.ForMember(d => d.AlbumId, o => o.MapFrom(s => s.Track.Album.AlbumId))
				.ForMember(d => d.AlbumName, o => o.MapFrom(s => s.Track.Album.Title))
				.ForMember(d => d.ArtistName, o => o.MapFrom(s => s.Track.Album.Artist.Name))
				.ForMember(d => d.Genre, o => o.MapFrom(s => s.Track.Genre.Name))
				.ForMember(d => d.GenreId, o => o.MapFrom(s => s.Track.GenreId))
				.ForMember(d => d.QuantityPrice, o => o.MapFrom(s => Convert.ToDecimal(s.Quantity * s.UnitPrice)));
			CreateMap<Invoice, DTOReportingInvoice>()
				.ForMember(d => d.InvoiceId, o => o.MapFrom(s => s.InvoiceId))
				.ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId))
				.ForMember(d => d.InvoiceDate, o => o.MapFrom(s => s.InvoiceDate))
				.ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.BillingAddress))
				.ForMember(d => d.BillingCity, o => o.MapFrom(s => s.BillingCity))
				.ForMember(d => d.BillingState, o => o.MapFrom(s => s.BillingState))
				.ForMember(d => d.BillingCountry, o => o.MapFrom(s => s.BillingCountry))
				.ForMember(d => d.BillingPostalCode, o => o.MapFrom(s => s.BillingPostalCode))

				.ForMember(d => d.IsCorporate, o => o.MapFrom(s => !string.IsNullOrWhiteSpace(s.Customer.Company)))

				.ForMember(d => d.Title,
						o => o.MapFrom(s => $"{((!string.IsNullOrWhiteSpace(s.Customer.Company) ? $"{s.Customer.Company}\n" : string.Empty))}{s.Customer.FirstName} {s.Customer.LastName}"))
				.ForMember(d => d.Phone, o => o.MapFrom(s => s.Customer.Phone))
				.ForMember(d => d.Fax, o => o.MapFrom(s => s.Customer.Fax))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.Customer.Email))
				.ForMember(d => d.Total,
						o => o.MapFrom(s => s.InvoiceLine.Sum(i => Convert.ToDecimal(i.Quantity * i.UnitPrice))));

			//public virtual DTOCustomer Customer { get; set; } = new DTOCustomer();
			//public virtual List<DTOReportingInvoiceLine> InvoiceLines { get; set; } = new List<DTOReportingInvoiceLine>();

		}
	}
}
