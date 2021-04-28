using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Mvc.Builders;
using Library
	;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace ChinookAppEF.Models
{
	public static class AppGridExtensions
	{
		public static DataGridBuilder<T> ConfigureAppGridSettings<T>(this DataGridBuilder<T> gridBuilder,
			string controller, string keyField,
			bool enableInsert = true, bool enableUpdate = true, bool enableDelete = true)
		{
			gridBuilder.DataSource(ds =>
			{
				var r = ds.Mvc()
					.Controller(controller)
					.LoadAction("Get");
				if (enableInsert)
					r.InsertAction("Post");
				if (enableUpdate)
					r.UpdateAction("Put");
				if (enableDelete)
					r.DeleteAction("Delete");
				r.Key(keyField);
				return r;
			});
			gridBuilder
					.FilterRow(f => f.Visible(true))
					.Sorting(sorting => sorting.Mode(GridSortingMode.Multiple))
					.RemoteOperations(true)
					.AllowColumnReordering(true)
					 .Pager(p => p
						.ShowPageSizeSelector(true)
						.AllowedPageSizes(new[] { 5, 10, 20, })
					)
					//.Editing(e => e
					//	.AllowAdding(enableInsert)
					//	.AllowUpdating(enableUpdate)
					//	.AllowDeleting(enableDelete)
					//)
					;

			// more settings ...

			return gridBuilder;
		}

		/// <summary>
		/// WARNING: This method is a work-around for the currently missing support for the Editable annotation attribute 
		/// on the model.
		/// Once this feature is implemented, this method can be removed.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="gridBuilder"></param>
		/// <returns></returns>
		public static DataGridBuilder<T> FixEditingFromModel<T>(this DataGridBuilder<T> gridBuilder)
		{
			var options = gridBuilder.GetPropertyValue<IDictionary<string, object>>("Options");
			if (options != null)
			{
				var columns = options["columns"] as List<object>;
				columns.ForEach((c) =>
				{
					var col = c as IDictionary<string, object>;
					if (col != null && col.ContainsKey("dataField"))
					{
						var modelProp = typeof(T).GetProperty(col["dataField"].ToString());
						if (Attribute.IsDefined(modelProp, typeof(EditableAttribute)))
						{
							var attr = Attribute.GetCustomAttribute(modelProp, typeof(EditableAttribute)) as EditableAttribute;
							if (attr != null)
								col["allowEditing"] = attr.AllowEdit;
						}
					}
				});
			}
			return gridBuilder;
		}
	}
}
