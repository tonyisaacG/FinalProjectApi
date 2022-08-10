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
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo f1 = new FileInfo(file.FileName);
                        var newfilename = "Image1" + f1.Extension;
                        var path = Path.Combine("", _IwebHostEnvironment.ContentRootPath + "\\Resources\\" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        };
                    }
                }
                return Ok("ok");

            }
            catch { return NotFound(); }


        }
    }
}