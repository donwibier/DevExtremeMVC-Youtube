//-----------------------------------------------------------------------
// <copyright file="C:\git\DevExtremeMVC-YouTube\DevAVEF.Editing\Controllers\ProductsController.cs" company="">
//     Author: Don Wibier
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using DevAVEF.Editing.Models.EF;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace DevAVEF.Editing.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private DevAVContext _context;

        public ProductsController(DevAVContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var products = _context.Products
                .Select(i => new
            {
                i.ProductId,
                i.ProductName,
                i.ProductDescription,
                i.ProductProductionStart,
                i.ProductAvailable,
                i.ProductSupportId,
                i.ProductEngineerId,
                i.ProductCurrentInventory,
                i.ProductBackorder,
                i.ProductManufacturing,
                i.ProductCost,
                i.ProductSalePrice,
                i.ProductRetailPrice,
                i.ProductConsumerRating,
                i.ProductCategory
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ProductId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(products, loadOptions));
        }


        [HttpGet]
        public IActionResult PrimaryImage(int id)
        {
            var data = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if(data != null)
            {
                if(data.ProductPrimaryImage.Length > 0)
                {
                    string mimeType = string.Empty;
                    byte[] thumb = data.ProductPrimaryImage.CreateThumbArray(60, 60, out mimeType);

                    return File(thumb, mimeType);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Products();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.ProductId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Products.FirstOrDefaultAsync(item => item.ProductId == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.Products.FirstOrDefaultAsync(item => item.ProductId == key);

            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> EmployeesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Employees
                orderby i.EmployeeFirstName
                select new { Value = i.EmployeeId, Text = i.EmployeeFirstName };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Products model, IDictionary values)
        {
            string PRODUCT_ID = nameof(Products.ProductId);
            string PRODUCT_NAME = nameof(Products.ProductName);
            string PRODUCT_DESCRIPTION = nameof(Products.ProductDescription);
            string PRODUCT_PRODUCTION_START = nameof(Products.ProductProductionStart);
            string PRODUCT_AVAILABLE = nameof(Products.ProductAvailable);
            string PRODUCT_SUPPORT_ID = nameof(Products.ProductSupportId);
            string PRODUCT_ENGINEER_ID = nameof(Products.ProductEngineerId);
            string PRODUCT_CURRENT_INVENTORY = nameof(Products.ProductCurrentInventory);
            string PRODUCT_BACKORDER = nameof(Products.ProductBackorder);
            string PRODUCT_MANUFACTURING = nameof(Products.ProductManufacturing);
            string PRODUCT_COST = nameof(Products.ProductCost);
            string PRODUCT_SALE_PRICE = nameof(Products.ProductSalePrice);
            string PRODUCT_RETAIL_PRICE = nameof(Products.ProductRetailPrice);
            string PRODUCT_CONSUMER_RATING = nameof(Products.ProductConsumerRating);
            string PRODUCT_CATEGORY = nameof(Products.ProductCategory);

            if(values.Contains(PRODUCT_ID))
            {
                model.ProductId = Convert.ToInt32(values[PRODUCT_ID]);
            }

            if(values.Contains(PRODUCT_NAME))
            {
                model.ProductName = Convert.ToString(values[PRODUCT_NAME]);
            }

            if(values.Contains(PRODUCT_DESCRIPTION))
            {
                model.ProductDescription = Convert.ToString(values[PRODUCT_DESCRIPTION]);
            }

            if(values.Contains(PRODUCT_PRODUCTION_START))
            {
                model.ProductProductionStart = values[PRODUCT_PRODUCTION_START] != null
                    ? Convert.ToDateTime(values[PRODUCT_PRODUCTION_START])
                    : (DateTime?)null;
            }

            if(values.Contains(PRODUCT_AVAILABLE))
            {
                model.ProductAvailable = values[PRODUCT_AVAILABLE] != null
                    ? Convert.ToBoolean(values[PRODUCT_AVAILABLE])
                    : (bool?)null;
            }

            if(values.Contains(PRODUCT_SUPPORT_ID))
            {
                model.ProductSupportId = values[PRODUCT_SUPPORT_ID] != null
                    ? Convert.ToInt32(values[PRODUCT_SUPPORT_ID])
                    : (int?)null;
            }

            if(values.Contains(PRODUCT_ENGINEER_ID))
            {
                model.ProductEngineerId = values[PRODUCT_ENGINEER_ID] != null
                    ? Convert.ToInt32(values[PRODUCT_ENGINEER_ID])
                    : (int?)null;
            }

            if(values.Contains(PRODUCT_CURRENT_INVENTORY))
            {
                model.ProductCurrentInventory = values[PRODUCT_CURRENT_INVENTORY] != null
                    ? Convert.ToInt32(values[PRODUCT_CURRENT_INVENTORY])
                    : (int?)null;
            }

            if(values.Contains(PRODUCT_BACKORDER))
            {
                model.ProductBackorder = values[PRODUCT_BACKORDER] != null
                    ? Convert.ToInt32(values[PRODUCT_BACKORDER])
                    : (int?)null;
            }

            if(values.Contains(PRODUCT_MANUFACTURING))
            {
                model.ProductManufacturing = values[PRODUCT_MANUFACTURING] != null
                    ? Convert.ToInt32(values[PRODUCT_MANUFACTURING])
                    : (int?)null;
            }

            if(values.Contains(PRODUCT_COST))
            {
                model.ProductCost = values[PRODUCT_COST] != null
                    ? Convert.ToDecimal(values[PRODUCT_COST], CultureInfo.InvariantCulture)
                    : (decimal?)null;
            }

            if(values.Contains(PRODUCT_SALE_PRICE))
            {
                model.ProductSalePrice = values[PRODUCT_SALE_PRICE] != null
                    ? Convert.ToDecimal(values[PRODUCT_SALE_PRICE], CultureInfo.InvariantCulture)
                    : (decimal?)null;
            }

            if(values.Contains(PRODUCT_RETAIL_PRICE))
            {
                model.ProductRetailPrice = values[PRODUCT_RETAIL_PRICE] != null
                    ? Convert.ToDecimal(values[PRODUCT_RETAIL_PRICE], CultureInfo.InvariantCulture)
                    : (decimal?)null;
            }

            if(values.Contains(PRODUCT_CONSUMER_RATING))
            {
                model.ProductConsumerRating = values[PRODUCT_CONSUMER_RATING] != null
                    ? Convert.ToDouble(values[PRODUCT_CONSUMER_RATING], CultureInfo.InvariantCulture)
                    : (double?)null;
            }

            if(values.Contains(PRODUCT_CATEGORY))
            {
                model.ProductCategory = Convert.ToString(values[PRODUCT_CATEGORY]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach(var entry in modelState)
            {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}