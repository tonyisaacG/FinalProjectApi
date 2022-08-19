using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        public readonly CategoryServices _Cservices;
        private readonly IHostEnvironment _IwebHostEnvironment;

        public CategoriesController(CategoryServices Cservices, IHostEnvironment hostEnvironment)
        {
            _Cservices = Cservices;
            this._IwebHostEnvironment = hostEnvironment;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var catlst = _Cservices.GetAll();
            if (catlst == null)
                return NoContent();
            return Ok(catlst);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetOne(int id)
        {
            var item = _Cservices.Get(id);
            if (item == null)
            {
                return NotFound("category is not exists");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(Categories cat)
        {
            if (ModelState.IsValid)
            {
               
                var ite = _Cservices.Post(cat);
                if (ite != null)
                {
                    return Ok(ite);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Categories cat)
        {
            if (ModelState.IsValid)
            {
                var catBool = _Cservices.Put(id, cat);
                if (catBool!=null)
                {
                    return Ok(catBool);
                }
                else
                {
                    return NotFound("item not exist");
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
            var deleteBool = _Cservices.Delete(id);
            if (deleteBool)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("not found item");
            }

        }
        //private string UploadImage(CategoryModel cat)
        //{
        //    var files = HttpContext.Request.Form.Files;
        //    var path="";
        //    if (files != null && files.Count > 0)
        //    {
        //        foreach (var file in files)
        //        {
        //            FileInfo f1 = new FileInfo(file.FileName);
        //            var newfilename = Guid.NewGuid().ToString() + "_" + f1.Extension;
        //            path = Path.Combine("", _IwebHostEnvironment.ContentRootPath + "\\Resources\\Category\\" + newfilename);
        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            };
                   
        //        }
        //    }
        //    return path;
        //}

    }
}
