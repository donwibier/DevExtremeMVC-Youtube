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
using ChinookAppEF.Models.EF;

namespace ChinookAppEF.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeesController : Controller
    {
        private ChinookContext _context;

        public EmployeesController(ChinookContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var employee = _context.Employee.Select(i => new {
                i.EmployeeId,
                i.LastName,
                i.FirstName,
                i.Title,
                i.ReportsTo,
                i.BirthDate,
                i.HireDate,
                i.Address,
                i.City,
                i.State,
                i.Country,
                i.PostalCode,
                i.Phone,
                i.Fax,
                i.Email
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "EmployeeId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(employee, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Employee();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Employee.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.EmployeeId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Employee.FirstOrDefaultAsync(item => item.EmployeeId == key);
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
            var model = await _context.Employee.FirstOrDefaultAsync(item => item.EmployeeId == key);

            _context.Employee.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> EmployeeLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Employee
                         orderby i.Title
                         select new {
                             Value = i.EmployeeId,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Employee model, IDictionary values) {
            string EMPLOYEE_ID = nameof(Employee.EmployeeId);
            string LAST_NAME = nameof(Employee.LastName);
            string FIRST_NAME = nameof(Employee.FirstName);
            string TITLE = nameof(Employee.Title);
            string REPORTS_TO = nameof(Employee.ReportsTo);
            string BIRTH_DATE = nameof(Employee.BirthDate);
            string HIRE_DATE = nameof(Employee.HireDate);
            string ADDRESS = nameof(Employee.Address);
            string CITY = nameof(Employee.City);
            string STATE = nameof(Employee.State);
            string COUNTRY = nameof(Employee.Country);
            string POSTAL_CODE = nameof(Employee.PostalCode);
            string PHONE = nameof(Employee.Phone);
            string FAX = nameof(Employee.Fax);
            string EMAIL = nameof(Employee.Email);

            if(values.Contains(EMPLOYEE_ID)) {
                model.EmployeeId = Convert.ToInt32(values[EMPLOYEE_ID]);
            }

            if(values.Contains(LAST_NAME)) {
                model.LastName = Convert.ToString(values[LAST_NAME]);
            }

            if(values.Contains(FIRST_NAME)) {
                model.FirstName = Convert.ToString(values[FIRST_NAME]);
            }

            if(values.Contains(TITLE)) {
                model.Title = Convert.ToString(values[TITLE]);
            }

            if(values.Contains(REPORTS_TO)) {
                model.ReportsTo = values[REPORTS_TO] != null ? Convert.ToInt32(values[REPORTS_TO]) : (int?)null;
            }

            if(values.Contains(BIRTH_DATE)) {
                model.BirthDate = values[BIRTH_DATE] != null ? Convert.ToDateTime(values[BIRTH_DATE]) : (DateTime?)null;
            }

            if(values.Contains(HIRE_DATE)) {
                model.HireDate = values[HIRE_DATE] != null ? Convert.ToDateTime(values[HIRE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ADDRESS)) {
                model.Address = Convert.ToString(values[ADDRESS]);
            }

            if(values.Contains(CITY)) {
                model.City = Convert.ToString(values[CITY]);
            }

            if(values.Contains(STATE)) {
                model.State = Convert.ToString(values[STATE]);
            }

            if(values.Contains(COUNTRY)) {
                model.Country = Convert.ToString(values[COUNTRY]);
            }

            if(values.Contains(POSTAL_CODE)) {
                model.PostalCode = Convert.ToString(values[POSTAL_CODE]);
            }

            if(values.Contains(PHONE)) {
                model.Phone = Convert.ToString(values[PHONE]);
            }

            if(values.Contains(FAX)) {
                model.Fax = Convert.ToString(values[FAX]);
            }

            if(values.Contains(EMAIL)) {
                model.Email = Convert.ToString(values[EMAIL]);
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