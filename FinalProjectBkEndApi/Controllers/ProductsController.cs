using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        public readonly ProductServices _Pservices;
        public ProductsController(ProductServices Pservices)
        {
            _Pservices = Pservices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_Pservices.GetAll());
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
        [HttpPost]
        public IActionResult Post(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var ite = _Pservices.Post(product);
                if (ite != null)
                {
                    return Ok("created product");
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
        public IActionResult Put([FromRoute] int id, [FromBody] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var productBool = _Pservices.Put(id, product);
                if (productBool)
                {
                    return Ok("data updated for product");
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
    }
}
