using ChinookAppEF.Models.EF;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
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
	public class CustomersController : Controller
	{
		private ChinookContext _context;

		public CustomersController(ChinookContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
		{
			var customer = _context.Customer.Select(i => new
			{
				i.CustomerId,
				i.FirstName,
				i.LastName,
				i.Company,
				i.Address,
				i.City,
				i.State,
				i.Country,
				i.PostalCode,
				i.Phone,
				i.Fax,
				i.Email,
				i.SupportRepId
			});

			// If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
			// In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
			// Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
			// loadOptions.PrimaryKey = new[] { "CustomerId" };
			// loadOptions.PaginateViaPrimaryKey = true;

			return Json(await DataSourceLoader.LoadAsync(customer, loadOptions));
		}

		[HttpPost]
		public async Task<IActionResult> Post(string values)
		{
			var model = new Customer();
			var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
			valuesDict.AssignToObject(model);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			var result = _context.Customer.Add(model);
			await _context.SaveChangesAsync();

			return Json(result.Entity.CustomerId);
		}

		[HttpPut]
		public async Task<IActionResult> Put(int key, string values)
		{
			var model = await _context.Customer.FirstOrDefaultAsync(item => item.CustomerId == key);
			if (model == null)
				return StatusCode(409, "Object not found");

			var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
			valuesDict.AssignToObject(model);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			await _context.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete]
		public async Task Delete(int key)
		{
			var model = await _context.Customer.FirstOrDefaultAsync(item => item.CustomerId == key);

			_context.Customer.Remove(model);
			await _context.SaveChangesAsync();
		}


		[HttpGet]
		public async Task<IActionResult> EmployeeLookup(DataSourceLoadOptions loadOptions)
		{
			var lookup = from i in _context.Employee
						 orderby i.Title
						 select new
						 {
							 Value = i.EmployeeId,
							 Text = i.Title
						 };
			return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
		}

		private string GetFullErrorMessage(ModelStateDictionary modelState)
		{
			var messages = new List<string>();

			foreach (var entry in modelState)
			{
				foreach (var error in entry.Value.Errors)
					messages.Add(error.ErrorMessage);
			}

			return String.Join(" ", messages);
		}
	}
}