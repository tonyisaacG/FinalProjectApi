using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IHostEnvironment _IwebHostEnvironment;


        public UploadsController(IHostEnvironment webHost)//, IHttpContextAccessor IhttpcontextAccessor)
        {
            this._IwebHostEnvironment = webHost;
            //this._IHttpContext = IhttpcontextAccessor;
        }
        [HttpPost]
        public IActionResult Upload()
        {

            try
            {
                var files = HttpContext.Request.Form.Files;
                var path = "";
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {

                        FileInfo f1 = new FileInfo(file.FileName);
                        var newfilename = Guid.NewGuid().ToString() + "_" + f1.Extension;
                        path = Path.Combine("", _IwebHostEnvironment.ContentRootPath + "\\Resources\\Products\\" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        };
                    }
                    return Ok(path);
                }
                return NotFound();   
            }
            catch { return NotFound(); }


        }
        [HttpDelete]
        public IActionResult Delete(string imagePath)
        {
            if(imagePath is null)
            {
                return BadRequest();
            }
            else
            {
                var Filepath = Path.GetFileName(imagePath);
                
                return Ok();
            }
        }
    
    }
}