using AutoMapper;
using ChinookBlazorSvr.Data;
using ChinookBlazorSvr.Models;
using ChinookBlazorSvr.Models.DTO;
using ChinookBlazorSvr.Models.EF;
using ChinookBlazorSvr.Reports;
using ChinookBlazorSvr.ViewModels;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Blazor.Reporting;
using DevExpress.XtraReports.Web.ClientControls;
using DevExpress.XtraReports.Web.Extensions;
using Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace ChinookBlazorSvr
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var connStr = Configuration.GetConnectionString("ChinookConnection");
			services.AddDbContext<ChinookContext>(options => options.UseSqlServer(connStr), ServiceLifetime.Transient);
			services.AddAutoMapper(typeof(Startup).Assembly);

			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<WeatherForecastService>();
			services.AddDevExpressBlazor();
			// Reporting: Add DevExpress.Blazor.Reporting nuget package
			services.AddDevExpressBlazorReporting();

			services.AddScoped<IDataStore<int, DTOInvoice>, InvoiceStore>();
			services.AddScoped<IDataStore<int, DTOInvoiceLine>, InvoiceLineStore>();
			services.AddScoped<IDataStore<int, DTOCustomer>, CustomerStore>();
			services.AddScoped<IDataStore<int, DTOCustomerLookup>, CustomerLookupStore>();
			services.AddScoped<IDataStore<int, DTOEmployee>, EmployeeStore>();

			services.AddScoped<IInvoiceViewModel, InvoiceViewModel>();


			//services.AddSingleton<IWebDocumentViewerReportResolver, ReportResolver>();
			services.AddScoped<ReportStorageWebExtension, ReportWebStorage>(); //Reporting
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseDevExpressBlazorReporting(); //Reporting

			app.UseEndpoints(
				endpoints =>
				{
					endpoints.MapControllers(); //reporting
					endpoints.MapBlazorHub();
					endpoints.MapFallbackToPage("/_Host");
				});
		}
	}
}
