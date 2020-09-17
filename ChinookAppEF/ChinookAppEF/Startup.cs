
using AutoMapper;
using ChinookAppEF.Models;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
using ChinookAppEF.Reports;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Library;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChinookAppEF
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connStr = Configuration.GetConnectionString("ChinookConnection");
			services.AddDbContext<ChinookContext>(options => options.UseSqlServer(connStr));
			services.AddAutoMapper(typeof(Startup).Assembly);
			services.AddDevExpressControls();

			//services.AddSingleton<IWebDocumentViewerReportResolver, ReportResolver>();
			services.AddScoped<ReportStorageWebExtension, Reports.ReportWebStorage>();

			services.AddScoped<IDataStore<int, DTOInvoice>, InvoiceStore>();
			services.AddScoped<IDataStore<int, DTOInvoiceLine>, InvoiceLineStore>();
			services.AddScoped<IDataStore<int, DTOCustomer>, CustomerStore>();
			// Add framework services.
			services
				.AddRazorPages()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

			services.ConfigureReportingServices(configurator =>
			{
				configurator.ConfigureReportDesigner(designerConfigurator =>
				{
					designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
				});
				configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
				{
					viewerConfigurator.UseCachedReportSourceBuilder();
				});
			});


			services.ConfigureReportingServices(configurator =>
			{
				configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
				{
					viewerConfigurator.UseCachedReportSourceBuilder();
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
			app.UseDevExpressControls();
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
		}
	}
}
