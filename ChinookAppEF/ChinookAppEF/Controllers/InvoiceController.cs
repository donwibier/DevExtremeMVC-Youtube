using ChinookAppEF.Models;
using ChinookAppEF.Models.DTO;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Controllers
{
	[Route("api/[controller]/[action]")]
	public class InvoiceController : BaseController<int, DTOInvoice>
	{
		readonly InvoiceStore invoiceStore;
		public InvoiceController(InvoiceStore invoiceStore)
		{
			this.invoiceStore = invoiceStore;
		}

		[HttpGet]
		public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
		{
			return Json(await invoiceStore.SelectWithOptionsAsync(loadOptions));
		}

		[HttpPost]
		public async Task<IActionResult> Post(string values)
		{
			var model = new DTOInvoice();
			PopulateModel(model, values);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			var r = await invoiceStore.CreateAsync(model);

			if (r.Success)
				return Json(r.Results.FirstOrDefault().ID);
			else
				return BadRequest(string.Join(" ", r.Messages(DataValidationResultType.Error)));
		}

		[HttpPut]
		public async Task<IActionResult> Put(int key, string values)
		{
			//return await PutAsync(key, values);
			var model = invoiceStore.GetByKey(key);
			PopulateModel(model, values);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			var r = await invoiceStore.UpdateAsync(model);

			if (r.Success)
				return Json(r.Results.FirstOrDefault().ID);
			else
				return BadRequest(string.Join(" ", r.Messages(DataValidationResultType.Error)));
		}

		[HttpDelete]
		public async Task Delete(int key)
		{
			var r = await invoiceStore.DeleteAsync(key);
			if (!r.Success)
				throw new DataValidationException<int>(r);
		}



		//[HttpGet]
		//public async Task<IActionResult> CustomerLookup(DataSourceLoadOptions loadOptions)
		//{
		//	var lookup = from i in invoiceStore.Db.Execute.Customer
		//				 orderby i.FirstName
		//				 select new
		//				 {
		//					 Value = i.CustomerId,
		//					 Text = string.IsNullOrWhiteSpace(i.Company) ? $"{i.LastName}, {i.FirstName}" : i.Company
		//				 };

		//	return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
		//}

	}
}