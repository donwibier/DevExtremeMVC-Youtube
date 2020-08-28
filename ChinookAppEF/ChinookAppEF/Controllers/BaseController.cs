using ChinookAppEF.Models.EF;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Controllers
{
	public abstract class BaseController<TKey, TModel> : Controller
		where TKey : IEquatable<TKey>
		where TModel : class, new()
	{
		protected virtual bool PrimaryKeyPagination { get => false; }

		protected void PopulateModel(TModel model, string values)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));
			if (string.IsNullOrWhiteSpace(values))
				throw new ArgumentNullException(nameof(values));
			var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
			valuesDict.AssignToObject(model);
		}

		//protected virtual async Task<IActionResult> PostAsync(string values)
		//{
		//	var model = new TModel();
		//	PopulateModel(model, values);

		//	if (!TryValidateModel(model))
		//		return BadRequest(GetFullErrorMessage(ModelState));

		//	var result = _context.Add(PopulateEntity(model, new TDBEntity()));
		//	await _context.SaveChangesAsync();

		//	return Json(result.Entity.GetPropertyValue<string>(PrimaryKey));
		//}


		//protected virtual async Task<IActionResult> PutAsync(int key, string values)
		//{
		//	var dbItem = await _context.FindAsync<TDBEntity>(key);
		//	if (dbItem == null)
		//		return StatusCode(409, "Object not found");

		//	var model = dbItem.Assign(new TModel());
		//	PopulateModel(model, values);

		//	if (!TryValidateModel(model))
		//		return BadRequest(GetFullErrorMessage(ModelState));

		//	PopulateEntity(model, dbItem);

		//	await _context.SaveChangesAsync();
		//	return Ok();
		//}


		//protected virtual async Task DeleteAsync(int key)
		//{
		//	var model = await _context.FindAsync<TDBEntity>(key);

		//	DBSet.Remove(model);
		//	await _context.SaveChangesAsync();
		//}


		//[HttpGet]
		//public async Task<IActionResult> EmployeeLookup(DataSourceLoadOptions loadOptions)
		//{
		//	var lookup = from i in _context.Employee
		//				 orderby i.Title
		//				 select new
		//				 {
		//					 Value = i.EmployeeId,
		//					 Text = i.Title
		//				 };
		//	return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
		//}

		protected string GetFullErrorMessage(ModelStateDictionary modelState)
		{
			var messages = new List<string>();

			foreach (var entry in modelState)
			{
				foreach (var error in entry.Value.Errors)
					messages.Add(error.ErrorMessage);
			}

			return string.Join(" ", messages);
		}

	}
}
