using DevExtreme.AspNet.Mvc;
using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAppEF.Controllers
{
	public abstract class BaseController<TKey, TModel, TStore> : Controller
		where TKey : IEquatable<TKey>
		where TModel : class, new()
		where TStore : IDataStore<TKey, TModel>
	{
		readonly IDataStore<TKey, TModel> mainDataStore;
		public BaseController(IDataStore<TKey, TModel> mainDataStore)
		{
			this.mainDataStore = mainDataStore;
		}

		protected virtual IDataStore<TKey, TModel> DataStore { get => mainDataStore; }
		protected virtual bool PrimaryKeyPagination { get => false; }

		protected virtual void PopulateModel(TModel model, string values)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));
			if (string.IsNullOrWhiteSpace(values))
				throw new ArgumentNullException(nameof(values));
			var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
			valuesDict.AssignToObject(model);
		}

		protected virtual TModel CreateModel()
		{
			return new TModel();
		}

		public async virtual Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
		{
			return Json(await mainDataStore.SelectWithOptionsAsync(loadOptions));
		}

		public virtual async Task<IActionResult> Post(string values)
		{
			var model = CreateModel();
			PopulateModel(model, values);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			var r = await mainDataStore.CreateAsync(model);

			if (r.Success)
				return Json(r.Results.FirstOrDefault().ID);
			else
				return BadRequest(string.Join(" ", r.Messages(DataValidationResultType.Error)));
		}

		public async virtual Task<IActionResult> Put(TKey key, string values)
		{
			var model = mainDataStore.GetByKey(key);
			PopulateModel(model, values);

			if (!TryValidateModel(model))
				return BadRequest(GetFullErrorMessage(ModelState));

			var r = await mainDataStore.UpdateAsync(model);

			if (r.Success)
				return Json(r.Results.FirstOrDefault().ID);
			else
				return BadRequest(string.Join(" ", r.Messages(DataValidationResultType.Error)));
		}

		public async virtual Task Delete(TKey key)
		{
			var result = await mainDataStore.DeleteAsync(key);
			if (!result.Success)
				throw new DataValidationException<TKey>(result);
		}

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
