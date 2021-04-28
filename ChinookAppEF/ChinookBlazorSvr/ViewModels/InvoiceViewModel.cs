using ChinookBlazorSvr.Models.DTO;
using ChinookBlazorSvr.Shared;
using DevExpress.Blazor;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Library;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChinookBlazorSvr.ViewModels
{
	public interface IInvoiceViewModel
	{
		Task PDFSelectionClickAction();
		Task OnSelectionChanged(DataGridSelection<DTOInvoice> selection);

		int SelectedCount { get; }
		int StoredUnselectedCount { get; }
		int StoredSelectedCount { get; }

		Task PDFSingleClickAction(DTOInvoice invoice);
		Task<LoadResult> GetCustomersLookup(DataSourceLoadOptionsBase loadOptions, CancellationToken ct);

		event Action OnStateChange;

		Task<LoadResult> GetInvoices(DataSourceLoadOptionsBase loadOptions, CancellationToken ct);

		Task Initialize(CascadingState appState);
	}
	public class InvoiceViewModel : IInvoiceViewModel
	{
		readonly IDataStore<int, DTOInvoice> invoiceStore;
		readonly IDataStore<int, DTOCustomerLookup> customerLookupStore;
		readonly NavigationManager navigationManager;
		CascadingState appState;

		public event Action OnStateChange;
		public InvoiceViewModel(NavigationManager navigationManager,
			IDataStore<int, DTOInvoice> invoiceStore, IDataStore<int, DTOCustomerLookup> customerLookupStore)
		{
			this.navigationManager = navigationManager;
			this.customerLookupStore = customerLookupStore;
			this.invoiceStore = invoiceStore;
		}

		public void TriggerStateChange()
		{
			OnStateChange?.Invoke();
		}

		public async Task Initialize(CascadingState appState)
		{
			this.appState = appState;
			await Task.Delay(0);
		}

		public async Task<LoadResult> GetInvoices(DataSourceLoadOptionsBase loadOptions, CancellationToken ct)
		{
			return await invoiceStore.SelectWithOptionsAsync(loadOptions, ct);
		}

		public async Task<LoadResult> GetCustomersLookup(DataSourceLoadOptionsBase loadOptions, CancellationToken ct)
		{
			return await customerLookupStore.SelectWithOptionsAsync(loadOptions, ct);
		}

		public int StoredSelectedCount { get; private set; }
		public int StoredUnselectedCount { get; private set; }
		public int SelectedCount { get; private set; }

		private IEnumerable<object> selectedKeys;
		public async Task OnSelectionChanged(DataGridSelection<DTOInvoice> selection)
		{
			StoredSelectedCount = selection.SelectedKeysStored.Count();
			StoredUnselectedCount = selection.UnselectedKeysStored.Count();
			selectedKeys = await selection.SelectedKeys;
			SelectedCount = selectedKeys.Count();
			TriggerStateChange();
		}

		public Task PDFSingleClickAction(DTOInvoice invoice)
		{
			if (invoice.InvoiceId.HasValue)
			{
				appState.ClearSelection();
				appState.AddSelection(new int[] { invoice.InvoiceId.Value });
				navigationManager.NavigateTo("/reports/Invoice"); //?reportSelectedIds={invoice.InvoiceId}");
				TriggerStateChange();
			}
			return Task.CompletedTask;
		}

		public Task PDFSelectionClickAction()
		{
			if (SelectedCount > 0)
			{
				appState.ClearSelection();
				appState.AddSelection(selectedKeys.Select(i => Convert.ToInt32(i)));
				navigationManager.NavigateTo("/reports/Invoice"); //?reportSelectedIds={invoice.InvoiceId}");
				TriggerStateChange();
			}
			return Task.CompletedTask;
		}
	}
}
