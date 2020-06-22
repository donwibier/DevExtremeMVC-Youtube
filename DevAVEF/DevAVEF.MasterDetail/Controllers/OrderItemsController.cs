//-----------------------------------------------------------------------
// <copyright file="C:\git\DevExtremeMVC-YouTube\DevAVEF\DevAVEF.MasterDetail\Controllers\OrderItemsController.cs" company="">
//     Author: Don Wibier
//     Copyright (c) . All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using DevAVEF.MasterDetail.Models.EF;
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

namespace DevAVEF.MasterDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderItemsController : Controller
    {
        private DevAVContext _context;

        public OrderItemsController(DevAVContext context) { _context = context; }

        [HttpGet]
        public async Task<IActionResult> Get(int orderId, DataSourceLoadOptions loadOptions)
        {
            var orderitems = _context.OrderItems
                .Where(w => w.OrderId == orderId)
                .Select(i => new
                {
                    i.OrderItemId,
                    i.OrderId,
                    i.OrderItemProductId,
                    i.OrderItemProductUnits,
                    i.OrderItemProductPrice,
                    i.OrderItemDiscount,
                    i.OrderItemTotal
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "OrderItemId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(orderitems, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new OrderItems();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.OrderItems.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.OrderItemId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.OrderItems.FirstOrDefaultAsync(item => item.OrderItemId == key);
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
            var model = await _context.OrderItems.FirstOrDefaultAsync(item => item.OrderItemId == key);

            _context.OrderItems.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> OrdersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Orders
                orderby i.OrderShipMethod
                select new { Value = i.OrderId, Text = i.OrderShipMethod };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ProductsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Products
                orderby i.ProductName
                select new { Value = i.ProductId, Text = i.ProductName };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(OrderItems model, IDictionary values)
        {
            string ORDER_ITEM_ID = nameof(OrderItems.OrderItemId);
            string ORDER_ID = nameof(OrderItems.OrderId);
            string ORDER_ITEM_PRODUCT_ID = nameof(OrderItems.OrderItemProductId);
            string ORDER_ITEM_PRODUCT_UNITS = nameof(OrderItems.OrderItemProductUnits);
            string ORDER_ITEM_PRODUCT_PRICE = nameof(OrderItems.OrderItemProductPrice);
            string ORDER_ITEM_DISCOUNT = nameof(OrderItems.OrderItemDiscount);
            string ORDER_ITEM_TOTAL = nameof(OrderItems.OrderItemTotal);

            if(values.Contains(ORDER_ITEM_ID))
            {
                model.OrderItemId = Convert.ToInt32(values[ORDER_ITEM_ID]);
            }

            if(values.Contains(ORDER_ID))
            {
                model.OrderId = values[ORDER_ID] != null ? Convert.ToInt32(values[ORDER_ID]) : (int?)null;
            }

            if(values.Contains(ORDER_ITEM_PRODUCT_ID))
            {
                model.OrderItemProductId = values[ORDER_ITEM_PRODUCT_ID] != null
                    ? Convert.ToInt32(values[ORDER_ITEM_PRODUCT_ID])
                    : (int?)null;
            }

            if(values.Contains(ORDER_ITEM_PRODUCT_UNITS))
            {
                model.OrderItemProductUnits = values[ORDER_ITEM_PRODUCT_UNITS] != null
                    ? Convert.ToInt32(values[ORDER_ITEM_PRODUCT_UNITS])
                    : (int?)null;
            }

            if(values.Contains(ORDER_ITEM_PRODUCT_PRICE))
            {
                model.OrderItemProductPrice = values[ORDER_ITEM_PRODUCT_PRICE] != null
                    ? Convert.ToDecimal(values[ORDER_ITEM_PRODUCT_PRICE], CultureInfo.InvariantCulture)
                    : (decimal?)null;
            }

            if(values.Contains(ORDER_ITEM_DISCOUNT))
            {
                model.OrderItemDiscount = values[ORDER_ITEM_DISCOUNT] != null
                    ? Convert.ToDecimal(values[ORDER_ITEM_DISCOUNT], CultureInfo.InvariantCulture)
                    : (decimal?)null;
            }

            if(values.Contains(ORDER_ITEM_TOTAL))
            {
                model.OrderItemTotal = values[ORDER_ITEM_TOTAL] != null
                    ? Convert.ToDecimal(values[ORDER_ITEM_TOTAL], CultureInfo.InvariantCulture)
                    : (decimal?)null;
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