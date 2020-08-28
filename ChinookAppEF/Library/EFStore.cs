using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChinookAppEF;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public abstract class EFDataStore<TEFContext, TKey, TModel, TDBModel>
		where TEFContext : DbContext, new()
		where TKey : IEquatable<TKey>
		where TModel : class, new()
		where TDBModel : class, new()
	{
		public EFDataStore(TEFContext context,
						IMapper mapper,
						DataValidator<TEFContext, TKey, TModel, TDBModel> validator)
		{
			Validator = validator;
			Mapper = mapper;
			DbContext = context;
		}

		public abstract TKey ModelKey(TModel model);

		public abstract TKey DBModelKey(TDBModel model);

		public IMapper Mapper { get; }

		public TEFContext DbContext { get; }

		public DataValidator<TEFContext, TKey, TModel, TDBModel> Validator { get; }

		protected virtual TDBModel EFGetByKey(TKey key)
		{
			return DbContext.Find<TDBModel>(key);
		}
		public virtual TModel GetByKey(TKey key)
		{
			TDBModel result = EFGetByKey(key);
			if (result != null)
				return Mapper.Map<TModel>(result);
			return default;
		}

		protected virtual IQueryable<TDBModel> EFQuery()
		{
			var results = DbContext.Set<TDBModel>();
			return results;
		}

		public virtual IQueryable<TModel> Query()
		{
			return EFQuery().ProjectTo<TModel>(Mapper.ConfigurationProvider);
		}

		public async virtual Task<LoadResult> SelectWithOptionsAsync(DataSourceLoadOptionsBase loadOptions)
		{
			if (loadOptions == null)
				throw new ArgumentNullException(nameof(loadOptions));

			var loadResult = await DataSourceLoader.LoadAsync(Query(), loadOptions);
			return loadResult;
		}

		public virtual DataValidationResults<TKey> Create(params TModel[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			var result = InternalStore(items, StoreMode.Create, true);
			return result;
		}

		public async virtual Task<DataValidationResults<TKey>> CreateAsync(params TModel[] items)
		{
			return await Task.FromResult(Create(items));
		}

		public virtual DataValidationResults<TKey> Update(params TModel[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			var result = InternalStore(items, StoreMode.Update, true);
			return result;
		}

		public async virtual Task<DataValidationResults<TKey>> UpdateAsync(params TModel[] items)
		{
			return await Task.FromResult(Update(items));
		}

		public virtual DataValidationResults<TKey> Store(params TModel[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			var result = InternalStore(items, StoreMode.Store, true);
			return result;
		}

		public async virtual Task<DataValidationResults<TKey>> StoreAsync(params TModel[] items)
		{
			return await Task.FromResult(Store(items));
		}

		public virtual DataValidationResults<TKey> Delete(params TKey[] ids)
		{
			if (ids == null)
				throw new ArgumentNullException(nameof(ids));

			var result = new DataValidationResults<TKey>();
			using (var dbTransaction = DbContext.Database.BeginTransaction())
			{
				foreach (var id in ids)
				{
					var item = DbContext.Set<TDBModel>().Find(id);
					if (item == null)
					{
						result.Add(DataValidationResultType.Error,
								DBModelKey(item),
								"KeyField",
								$"Unable to locate {typeof(TDBModel).Name}({DBModelKey(item)}) in datastore",
								0);
						break;
					}
					var canDelete = Validator?.Deleting(id, result, item);
					if (canDelete.ResultType == DataValidationResultType.Error)
					{
						dbTransaction.Rollback();
						result.Add(canDelete);
						break;
					}

					DbContext.Entry(item).State = EntityState.Deleted;

					var hasDeleted = Validator?.Deleted(id, item, result);
					if (hasDeleted.ResultType == DataValidationResultType.Error)
					{
						dbTransaction.Rollback();
						result.Add(hasDeleted);
						break;
					}
				}
				try
				{
					DbContext.SaveChanges();
					dbTransaction.Commit();
				}
				catch (Exception e)
				{
					result.Add(new DataValidationResult<TKey>
					{
						ResultType = DataValidationResultType.Error,
						Message = e.InnerException != null ? e.InnerException.Message : e.Message
					});
				}
			}
			return result;
		}
		public async virtual Task<DataValidationResults<TKey>> DeleteAsync(params TKey[] ids)
		{
			return await Task.FromResult(Delete(ids));
		}

		protected TKey EmptyKeyValue => default;




		protected virtual DataValidationResults<TKey> InternalStore(IEnumerable<TModel> items,
																	StoreMode mode,
																	bool continueOnError)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			DataValidationResults<TKey> result = new DataValidationResults<TKey>();

			// need to keep the db entities together with the model items so we can update 
			// the id's of the models afterwards.
			Dictionary<TDBModel, InsertHelper> batchPairs = new Dictionary<TDBModel, InsertHelper>();
			using (var dbTransaction = DbContext.Database.BeginTransaction())
			{
				foreach (var item in items)
				{
					var modelKey = ModelKey(item);
					if (modelKey.Equals(EmptyKeyValue) || mode == StoreMode.Create)
					{
						var canInsert = Validator?.Inserting(item, result);
						if (canInsert.ResultType == DataValidationResultType.Error)
						{
							result.Add(canInsert);
							if (!continueOnError)
							{
								dbTransaction.Rollback();
								break;
							}
						}

						var newItem = new TDBModel();
						Mapper.Map(item, newItem);
						DbContext.Set<TDBModel>().Add(newItem);
						DbContext.SaveChanges();

						var hasInserted = Validator?.Inserted(default, item, newItem, result);
						if (hasInserted.ResultType == DataValidationResultType.Error)
						{
							result.Add(hasInserted);
							if (!continueOnError)
							{
								dbTransaction.Rollback();
								break;
							}
						}
						batchPairs.Add(newItem, new InsertHelper(item, canInsert, hasInserted));
					}
					else if (!modelKey.Equals(EmptyKeyValue) && (mode != StoreMode.Create))
					{
						var canUpdate = Validator?.Updating(modelKey, item, result);
						if (canUpdate.ResultType == DataValidationResultType.Error)
						{
							result.Add(canUpdate);
							if (!continueOnError)
							{
								dbTransaction.Rollback();
								break;
							}
						}

						var updatedItem = EFGetByKey(modelKey);
						if (updatedItem == null)
						{
							result.Add(DataValidationResultType.Error,
								modelKey,
								"KeyField",
								$"Unable to locate {typeof(TDBModel).Name}({modelKey}) in datastore",
								0);
							break;
						}

						Mapper.Map(item, updatedItem);
						DbContext.Entry(updatedItem).State = EntityState.Modified;
						//DbContext.SaveChanges();

						var hasUpdated = Validator?.Updated(modelKey, item, updatedItem, result);
						if (hasUpdated.ResultType == DataValidationResultType.Error)
						{
							result.Add(hasUpdated);
							if (!continueOnError)
							{
								dbTransaction.Rollback();
								break;
							}
						}
					}
				}
				try
				{
					DbContext.SaveChanges();
					dbTransaction.Commit();
				}
				catch (Exception e)
				{
					result.Add(new DataValidationResult<TKey>
					{
						ResultType = DataValidationResultType.Error,
						Message = e.InnerException != null ? e.InnerException.Message : e.Message
					});
				}
			}

			//	try
			//	{
			//		w.ObjectSaved += (s, e) =>
			//		{
			//			// sync the model ids with the newly generated xpo id's
			//			var xpoItem = e.Object as TXPOClass;
			//			if (xpoItem != null && batchPairs.ContainsKey(xpoItem))
			//			{
			//				batchPairs[xpoItem].Model.ID = xpoItem.ID;
			//				batchPairs[xpoItem].InsertingResult.ID = xpoItem.ID;
			//				batchPairs[xpoItem].InsertedResult.ID = xpoItem.ID;
			//			}
			//		};
			//		w.FailedCommitTransaction += (s, e) =>
			//		{
			//			r.Add(new DataValidationResult<TKey>
			//			{
			//				ResultType = DataValidationResultType.Error,
			//				Message = e.Exception.InnerException != null ? e.Exception.InnerException.Message : e.Exception.Message
			//			});

			//			e.Handled = true;
			//		};
			//		w.CommitTransaction();
			//	}
			//	catch
			//	{
			//		w.RollbackTransaction();
			//	}
			//	return r;
			//});

			return result;
		}
		/// <summary>
		/// Small internal helper class to keep track of results
		/// </summary>
		class InsertHelper
		{
			public InsertHelper(TModel model,
								DataValidationResult<TKey> insertingResult,
								DataValidationResult<TKey> insertedResult)
			{
				Model = model;
				InsertingResult = insertingResult;
				InsertedResult = insertedResult;
			}

			public TModel Model { get; private set; }

			public DataValidationResult<TKey> InsertingResult { get; private set; }

			public DataValidationResult<TKey> InsertedResult { get; private set; }
		}

		protected enum StoreMode
		{
			Create,
			Update,
			Store
		}
	}
}
