using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly ProductServices _Pservices;
        private readonly IHostEnvironment _IwebHostEnvironment;


        public ProductsController(ProductServices Pservices, IHostEnvironment hostEnvironment)
        {
            _Pservices = Pservices;
            this._IwebHostEnvironment = hostEnvironment;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pro = _Pservices.GetAll();
            if (pro == null)
                return NotFound("not exist any item");
            return Ok(pro);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var product = _Pservices.Get(id);
            if (product == null)
            {
                return NotFound("product is not exists");
            }
            return Ok(product);
        }
        //[HttpPost("postImage")]
        #region
        //public IActionResult post( ProductModel product)
        //{


        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("resource", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return Ok("ok");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }

        //}
        #endregion
        [HttpPost]
        public IActionResult Post([FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productModel = UploadImage(product);
                    var ite = _Pservices.Post(productModel);                    
                    if (ite != null)
                    {
                        return Ok(productModel);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch { return NotFound(); }
              
            }
            else
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var productBool = _Pservices.Put(id, product);
                if (productBool!=null)
                {
                    return Ok(productBool);
                }
                else
                {
                    return NotFound("product not exist");
                }
            }
            else
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleteBool = _Pservices.Delete(id);
            if (deleteBool)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("not found product");
            }
        }


        private ProductModel UploadImage(ProductModel product)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    FileInfo f1 = new FileInfo(file.FileName);
                    var newfilename = Guid.NewGuid().ToString() + "_" + f1.Extension;
                    var path = Path.Combine("", _IwebHostEnvironment.ContentRootPath + "\\Resources\\Products\\" + newfilename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    };
                    product.product_imagePath = path;
                }
            }
            return product;
        }
        //private string UploadedFile(ProductModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.product_imagePath != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Resources");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.product_imagePath.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.product_imagePath.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
    }
}
