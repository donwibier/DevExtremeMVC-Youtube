﻿using ChinookAppEF.Models;
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
	public class InvoiceController : BaseController<int, DTOInvoice, InvoiceStore>
	{
		public InvoiceController(IDataStore<int, DTOInvoice> mainDataStore) : base(mainDataStore)
		{

		}
		[HttpGet]
		public async override Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
		{
			return await base.Get(loadOptions);
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