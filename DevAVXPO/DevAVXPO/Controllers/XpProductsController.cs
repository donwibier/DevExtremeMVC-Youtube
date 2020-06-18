using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.Extensions.Configuration;
using DevAVXPO.Models.DevAV;

namespace DevAVXPO.Controllers
{
    // If you need to use Data Annotation attributes, attach them to this view model instead of an XPO data model.
    public class XpProductsViewModel {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public DateTime? Product_Production_Start { get; set; }
        public bool? Product_Available { get; set; }
        public byte[] Product_Image { get; set; }
        public int? Product_Support_ID { get; set; }
        public int? Product_Engineer_ID { get; set; }
        public int? Product_Current_Inventory { get; set; }
        public int? Product_Backorder { get; set; }
        public int? Product_Manufacturing { get; set; }
        public byte[] Product_Barcode { get; set; }
        public byte[] Product_Primary_Image { get; set; }
        public decimal? Product_Cost { get; set; }
        public decimal? Product_Sale_Price { get; set; }
        public decimal? Product_Retail_Price { get; set; }
        public double? Product_Consumer_Rating { get; set; }
        public string Product_Category { get; set; }
    }

    [Route("api/[controller]/[action]")]
    public class XpProductsController : Controller
    {
        private UnitOfWork _uow;

        public XpProductsController(IConfiguration configuration) {
            this._uow = new UnitOfWork(ConnectionHelper.GetDataLayer(configuration, AutoCreateOption.SchemaAlreadyExists));
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var xpproducts = _uow.Query<XpProducts>().Select(i => new XpProductsViewModel {
                Product_ID = i.Product_ID,
                Product_Name = i.Product_Name,
                Product_Description = i.Product_Description,
                Product_Production_Start = i.Product_Production_Start,
                Product_Available = i.Product_Available,
                Product_Support_ID = i.Product_Support_ID.Employee_ID,
                Product_Engineer_ID = i.Product_Engineer_ID.Employee_ID,
                Product_Current_Inventory = i.Product_Current_Inventory,
                Product_Backorder = i.Product_Backorder,
                Product_Manufacturing = i.Product_Manufacturing,
                Product_Cost = i.Product_Cost,
                Product_Sale_Price = i.Product_Sale_Price,
                Product_Retail_Price = i.Product_Retail_Price,
                Product_Consumer_Rating = i.Product_Consumer_Rating,
                Product_Category = i.Product_Category
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Product_ID" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(xpproducts, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new XpProducts(_uow);
            var viewModel = new XpProductsViewModel();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);

            PopulateViewModel(viewModel, valuesDict);

            if(!TryValidateModel(viewModel))
                return BadRequest(GetFullErrorMessage(ModelState));

            await CopyToModelAsync(viewModel, model);

            await _uow.CommitChangesAsync();

            return Json(model.Product_ID);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = _uow.GetObjectByKey<XpProducts>(key, true);
            if(model == null)
                return StatusCode(409, "Object not found");

            var viewModel = new XpProductsViewModel {
                Product_ID = model.Product_ID,
                Product_Name = model.Product_Name,
                Product_Description = model.Product_Description,
                Product_Production_Start = model.Product_Production_Start,
                Product_Available = model.Product_Available,
                Product_Support_ID = model.Product_Support_ID?.Employee_ID,
                Product_Engineer_ID = model.Product_Engineer_ID?.Employee_ID,
                Product_Current_Inventory = model.Product_Current_Inventory,
                Product_Backorder = model.Product_Backorder,
                Product_Manufacturing = model.Product_Manufacturing,
                Product_Cost = model.Product_Cost,
                Product_Sale_Price = model.Product_Sale_Price,
                Product_Retail_Price = model.Product_Retail_Price,
                Product_Consumer_Rating = model.Product_Consumer_Rating,
                Product_Category = model.Product_Category
            };

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateViewModel(viewModel, valuesDict);

            if(!TryValidateModel(viewModel))
                return BadRequest(GetFullErrorMessage(ModelState));

            await CopyToModelAsync(viewModel, model);

            await _uow.CommitChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = _uow.GetObjectByKey<XpProducts>(key, true);

            _uow.Delete(model);
            await _uow.CommitChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> XpEmployeesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _uow.Query<XpEmployees>()
                         orderby i.Employee_First_Name
                         select new {
                             Value = i.Employee_ID,
                             Text = i.Employee_First_Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        const string PRODUCT_ID = nameof(XpProducts.Product_ID);
        const string PRODUCT_NAME = nameof(XpProducts.Product_Name);
        const string PRODUCT_DESCRIPTION = nameof(XpProducts.Product_Description);
        const string PRODUCT_PRODUCTION_START = nameof(XpProducts.Product_Production_Start);
        const string PRODUCT_AVAILABLE = nameof(XpProducts.Product_Available);
        const string PRODUCT_SUPPORT_ID = nameof(XpProducts.Product_Support_ID);
        const string PRODUCT_ENGINEER_ID = nameof(XpProducts.Product_Engineer_ID);
        const string PRODUCT_CURRENT_INVENTORY = nameof(XpProducts.Product_Current_Inventory);
        const string PRODUCT_BACKORDER = nameof(XpProducts.Product_Backorder);
        const string PRODUCT_MANUFACTURING = nameof(XpProducts.Product_Manufacturing);
        const string PRODUCT_COST = nameof(XpProducts.Product_Cost);
        const string PRODUCT_SALE_PRICE = nameof(XpProducts.Product_Sale_Price);
        const string PRODUCT_RETAIL_PRICE = nameof(XpProducts.Product_Retail_Price);
        const string PRODUCT_CONSUMER_RATING = nameof(XpProducts.Product_Consumer_Rating);
        const string PRODUCT_CATEGORY = nameof(XpProducts.Product_Category);

        private void PopulateViewModel(XpProductsViewModel viewModel, IDictionary values) {
            if(values.Contains(PRODUCT_ID)) {
                viewModel.Product_ID = Convert.ToInt32(values[PRODUCT_ID]);
            }
            if(values.Contains(PRODUCT_NAME)) {
                viewModel.Product_Name = Convert.ToString(values[PRODUCT_NAME]);
            }
            if(values.Contains(PRODUCT_DESCRIPTION)) {
                viewModel.Product_Description = Convert.ToString(values[PRODUCT_DESCRIPTION]);
            }
            if(values.Contains(PRODUCT_PRODUCTION_START)) {
                viewModel.Product_Production_Start = values[PRODUCT_PRODUCTION_START] != null ? Convert.ToDateTime(values[PRODUCT_PRODUCTION_START]) : (DateTime?)null;
            }
            if(values.Contains(PRODUCT_AVAILABLE)) {
                viewModel.Product_Available = values[PRODUCT_AVAILABLE] != null ? Convert.ToBoolean(values[PRODUCT_AVAILABLE]) : (bool?)null;
            }
            if(values.Contains(PRODUCT_SUPPORT_ID)) {
                viewModel.Product_Support_ID = values[PRODUCT_SUPPORT_ID] != null ? Convert.ToInt32(values[PRODUCT_SUPPORT_ID]) : (int?)null;
            }
            if(values.Contains(PRODUCT_ENGINEER_ID)) {
                viewModel.Product_Engineer_ID = values[PRODUCT_ENGINEER_ID] != null ? Convert.ToInt32(values[PRODUCT_ENGINEER_ID]) : (int?)null;
            }
            if(values.Contains(PRODUCT_CURRENT_INVENTORY)) {
                viewModel.Product_Current_Inventory = values[PRODUCT_CURRENT_INVENTORY] != null ? Convert.ToInt32(values[PRODUCT_CURRENT_INVENTORY]) : (int?)null;
            }
            if(values.Contains(PRODUCT_BACKORDER)) {
                viewModel.Product_Backorder = values[PRODUCT_BACKORDER] != null ? Convert.ToInt32(values[PRODUCT_BACKORDER]) : (int?)null;
            }
            if(values.Contains(PRODUCT_MANUFACTURING)) {
                viewModel.Product_Manufacturing = values[PRODUCT_MANUFACTURING] != null ? Convert.ToInt32(values[PRODUCT_MANUFACTURING]) : (int?)null;
            }
            if(values.Contains(PRODUCT_COST)) {
                viewModel.Product_Cost = values[PRODUCT_COST] != null ? Convert.ToDecimal(values[PRODUCT_COST], CultureInfo.InvariantCulture) : (decimal?)null;
            }
            if(values.Contains(PRODUCT_SALE_PRICE)) {
                viewModel.Product_Sale_Price = values[PRODUCT_SALE_PRICE] != null ? Convert.ToDecimal(values[PRODUCT_SALE_PRICE], CultureInfo.InvariantCulture) : (decimal?)null;
            }
            if(values.Contains(PRODUCT_RETAIL_PRICE)) {
                viewModel.Product_Retail_Price = values[PRODUCT_RETAIL_PRICE] != null ? Convert.ToDecimal(values[PRODUCT_RETAIL_PRICE], CultureInfo.InvariantCulture) : (decimal?)null;
            }
            if(values.Contains(PRODUCT_CONSUMER_RATING)) {
                viewModel.Product_Consumer_Rating = values[PRODUCT_CONSUMER_RATING] != null ? Convert.ToDouble(values[PRODUCT_CONSUMER_RATING], CultureInfo.InvariantCulture) : (double?)null;
            }
            if(values.Contains(PRODUCT_CATEGORY)) {
                viewModel.Product_Category = Convert.ToString(values[PRODUCT_CATEGORY]);
            }
        }

        private async Task CopyToModelAsync(XpProductsViewModel viewModel, XpProducts model) {
            model.Product_ID = viewModel.Product_ID;
            model.Product_Name = viewModel.Product_Name;
            model.Product_Description = viewModel.Product_Description;
            model.Product_Production_Start = viewModel.Product_Production_Start;
            model.Product_Available = viewModel.Product_Available;
            model.Product_Support_ID = await _uow.GetObjectByKeyAsync<XpEmployees>(viewModel.Product_Support_ID);
            model.Product_Engineer_ID = await _uow.GetObjectByKeyAsync<XpEmployees>(viewModel.Product_Engineer_ID);
            model.Product_Current_Inventory = viewModel.Product_Current_Inventory;
            model.Product_Backorder = viewModel.Product_Backorder;
            model.Product_Manufacturing = viewModel.Product_Manufacturing;
            model.Product_Cost = viewModel.Product_Cost;
            model.Product_Sale_Price = viewModel.Product_Sale_Price;
            model.Product_Retail_Price = viewModel.Product_Retail_Price;
            model.Product_Consumer_Rating = viewModel.Product_Consumer_Rating;
            model.Product_Category = viewModel.Product_Category;
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}