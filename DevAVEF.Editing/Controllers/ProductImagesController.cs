//-----------------------------------------------------------------------
// <copyright file="C:\git\DevExtremeMVC-YouTube\DevAVEF.Editing\Controllers\ProductImagesController.cs" company="">
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevAVEF.Editing.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductImagesController : Controller
    {
        private DevAVContext _context;

        public ProductImagesController(DevAVContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int productId, DataSourceLoadOptions loadOptions)
        {
            var productimages = _context.ProductImages
                .Where(i => i.ProductId == productId)
                .Select(i => new
                {
                    i.ImageId,
                    i.ProductId
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ImageId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(productimages, loadOptions));
        }

        [HttpGet]
        public IActionResult Image(int id)
        {
            var data = _context.ProductImages.Where(p => p.ImageId == id).FirstOrDefault();
            if(data != null)
            {
                if(data.ProductImage.Length > 0)
                {
                    string mimeType = string.Empty;
                    byte[] thumb = data.ProductImage.CreateThumbArray(60, 60, out mimeType);

                    return File(thumb, mimeType);
                }
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new ProductImages();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.ProductImages.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.ImageId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.ProductImages.FirstOrDefaultAsync(item => item.ImageId == key);
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
            var model = await _context.ProductImages.FirstOrDefaultAsync(item => item.ImageId == key);

            _context.ProductImages.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> ProductsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Products
                orderby i.ProductName
                select new
                {
                    Value = i.ProductId,
                    Text = i.ProductName
                };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(ProductImages model, IDictionary values)
        {
            string IMAGE_ID = nameof(ProductImages.ImageId);
            string PRODUCT_ID = nameof(ProductImages.ProductId);

            if(values.Contains(IMAGE_ID))
            {
                model.ImageId = Convert.ToInt32(values[IMAGE_ID]);
            }

            if(values.Contains(PRODUCT_ID))
            {
                model.ProductId = values[PRODUCT_ID] != null ? Convert.ToInt32(values[PRODUCT_ID]) : (int?)null;
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