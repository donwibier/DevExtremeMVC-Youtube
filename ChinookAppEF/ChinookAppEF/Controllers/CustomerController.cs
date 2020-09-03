using ChinookAppEF.Models;
using ChinookAppEF.Models.DTO;
using ChinookAppEF.Models.EF;
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
	public class CustomerController : BaseController<int, DTOCustomer, CustomerStore>
	{
		public CustomerController(IDataStore<int, DTOCustomer> mainDataStore) : base(mainDataStore)
		{

		}

		[HttpGet]
		public async override Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
		{
			return await base.Get(loadOptions);
		}

		public async Task<IActionResult> Lookup(DataSourceLoadOptions loadOptions)
		{
			if (loadOptions == null)
				throw new ArgumentNullException(nameof(loadOptions));

			var result = DataStore.Query<DTOCustomerLookup>();
			var loadResult = await DataSourceLoader.LoadAsync(result, loadOptions);
			return Json(loadResult);

		}

		[HttpPost]
		public async override Task<IActionResult> Post(string values)
		{
			return await base.Post(values);
		}
		[HttpPut]
		public async override Task<IActionResult> Put(int key, string values)
		{
			return await base.Put(key, values);
		}
		[HttpDelete]
		public async override Task Delete(int key)
		{
			await base.Delete(key);
		}


	}
}