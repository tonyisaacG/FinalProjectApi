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
    [Authorize]

    public class ProductsController : ControllerBase
    {
        public readonly ProductServices _Pservices;
        private readonly IWebHostEnvironment _IwebHostEnvironment;
        private readonly IHttpContextAccessor _IHttpContext;


        public ProductsController(ProductServices Pservices, IWebHostEnvironment webhostEnvironment, IHttpContextAccessor IHttpContext)
        {
            _Pservices = Pservices;
            this._IwebHostEnvironment = webhostEnvironment;
            this._IHttpContext = IHttpContext;

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var pro = _Pservices.GetAll();
            if (pro == null)
                return NotFound("not exist any item");
            return Ok(pro);
        }
        
        [HttpGet("productCatId/{id:int}")]
        public IActionResult GetProductCatId(int id)
        {
            var pro = _Pservices.GetProductCatId(id);
            if (pro == null)
                return NotFound("not exist any item");
            return Ok(pro);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetOne(int id)
        {
            var product = _Pservices.Get(id);
            if (product == null)
            {
                return NotFound("product is not exists");
            }
            return Ok(product);
        }
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
        public IActionResult Put([FromRoute]int id,[FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var oldImagePathProduct = _Pservices.Get(id);
                if(product.product_imagePathSrc !=null)
                {
                    RemoveImage(((ProductModel)oldImagePathProduct).product_imagePath);
                    var newPath = UploadImage(product);
                    product.product_imagePath = newPath.product_imagePath;
                }
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

                var path = Path.Combine(_IwebHostEnvironment.ContentRootPath, "Uploads");
                var newfilename = "";
                var BaseUrl = _IHttpContext.HttpContext.Request.Scheme + "://" +
                       _IHttpContext.HttpContext.Request.Host + _IHttpContext.HttpContext.Request.PathBase;

                foreach (var file in files)
                {
                    FileInfo f1 = new FileInfo(file.FileName);
                    newfilename = Guid.NewGuid().ToString() + "_" + f1.Extension;
                    string filePath = Path.Combine(path, newfilename);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);

                    }
                    product.product_imagePath = BaseUrl+"/"+ "Uploads" + "/"+newfilename;
                }
            }
            return product;
        }
      private  void RemoveImage(string imagePath)
        {
            try { 
            FileInfo f1 = new FileInfo(imagePath);
            if (f1.Exists)
            {
                f1.Delete();
            }
            }
            catch { }
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
