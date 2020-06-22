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
using DevAVEF.MasterDetail.Models.EF;

namespace DevAVEF.MasterDetail.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrdersController : Controller
    {
        private DevAVContext _context;

        public OrdersController(DevAVContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var orders = _context.Orders.Select(i => new {
                i.OrderId,
                i.OrderInvoiceNumber,
                i.OrderCustomerId,
                i.OrderCustomerLocationId,
                i.OrderPoNumber,
                i.OrderEmployeeId,
                i.OrderDate,
                i.OrderSaleAmount,
                i.OrderShippingAmount,
                i.OrderTotalAmount,
                i.OrderShipDate,
                i.OrderShipMethod,
                i.OrderTerms,
                i.OrderComments
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "OrderId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(orders, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Orders();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Orders.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.OrderId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.OrderId == key);
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
        public async Task Delete(int key) {
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.OrderId == key);

            _context.Orders.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CustomersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Customers
                         orderby i.CustomerName
                         select new {
                             Value = i.CustomerId,
                             Text = i.CustomerName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> EmployeesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Employees
                         orderby i.EmployeeFirstName
                         select new {
                             Value = i.EmployeeId,
                             Text = i.EmployeeFirstName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Orders model, IDictionary values) {
            string ORDER_ID = nameof(Orders.OrderId);
            string ORDER_INVOICE_NUMBER = nameof(Orders.OrderInvoiceNumber);
            string ORDER_CUSTOMER_ID = nameof(Orders.OrderCustomerId);
            string ORDER_CUSTOMER_LOCATION_ID = nameof(Orders.OrderCustomerLocationId);
            string ORDER_PO_NUMBER = nameof(Orders.OrderPoNumber);
            string ORDER_EMPLOYEE_ID = nameof(Orders.OrderEmployeeId);
            string ORDER_DATE = nameof(Orders.OrderDate);
            string ORDER_SALE_AMOUNT = nameof(Orders.OrderSaleAmount);
            string ORDER_SHIPPING_AMOUNT = nameof(Orders.OrderShippingAmount);
            string ORDER_TOTAL_AMOUNT = nameof(Orders.OrderTotalAmount);
            string ORDER_SHIP_DATE = nameof(Orders.OrderShipDate);
            string ORDER_SHIP_METHOD = nameof(Orders.OrderShipMethod);
            string ORDER_TERMS = nameof(Orders.OrderTerms);
            string ORDER_COMMENTS = nameof(Orders.OrderComments);

            if(values.Contains(ORDER_ID)) {
                model.OrderId = Convert.ToInt32(values[ORDER_ID]);
            }

            if(values.Contains(ORDER_INVOICE_NUMBER)) {
                model.OrderInvoiceNumber = values[ORDER_INVOICE_NUMBER] != null ? Convert.ToInt32(values[ORDER_INVOICE_NUMBER]) : (int?)null;
            }

            if(values.Contains(ORDER_CUSTOMER_ID)) {
                model.OrderCustomerId = values[ORDER_CUSTOMER_ID] != null ? Convert.ToInt32(values[ORDER_CUSTOMER_ID]) : (int?)null;
            }

            if(values.Contains(ORDER_CUSTOMER_LOCATION_ID)) {
                model.OrderCustomerLocationId = values[ORDER_CUSTOMER_LOCATION_ID] != null ? Convert.ToInt32(values[ORDER_CUSTOMER_LOCATION_ID]) : (int?)null;
            }

            if(values.Contains(ORDER_PO_NUMBER)) {
                model.OrderPoNumber = values[ORDER_PO_NUMBER] != null ? Convert.ToInt32(values[ORDER_PO_NUMBER]) : (int?)null;
            }

            if(values.Contains(ORDER_EMPLOYEE_ID)) {
                model.OrderEmployeeId = values[ORDER_EMPLOYEE_ID] != null ? Convert.ToInt32(values[ORDER_EMPLOYEE_ID]) : (int?)null;
            }

            if(values.Contains(ORDER_DATE)) {
                model.OrderDate = values[ORDER_DATE] != null ? Convert.ToDateTime(values[ORDER_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ORDER_SALE_AMOUNT)) {
                model.OrderSaleAmount = values[ORDER_SALE_AMOUNT] != null ? Convert.ToDecimal(values[ORDER_SALE_AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(ORDER_SHIPPING_AMOUNT)) {
                model.OrderShippingAmount = values[ORDER_SHIPPING_AMOUNT] != null ? Convert.ToDecimal(values[ORDER_SHIPPING_AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(ORDER_TOTAL_AMOUNT)) {
                model.OrderTotalAmount = values[ORDER_TOTAL_AMOUNT] != null ? Convert.ToDecimal(values[ORDER_TOTAL_AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(ORDER_SHIP_DATE)) {
                model.OrderShipDate = values[ORDER_SHIP_DATE] != null ? Convert.ToDateTime(values[ORDER_SHIP_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ORDER_SHIP_METHOD)) {
                model.OrderShipMethod = Convert.ToString(values[ORDER_SHIP_METHOD]);
            }

            if(values.Contains(ORDER_TERMS)) {
                model.OrderTerms = Convert.ToString(values[ORDER_TERMS]);
            }

            if(values.Contains(ORDER_COMMENTS)) {
                model.OrderComments = Convert.ToString(values[ORDER_COMMENTS]);
            }
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