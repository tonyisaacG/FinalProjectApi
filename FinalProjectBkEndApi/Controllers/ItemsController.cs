using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectBkEndApi.Services;
using System.Threading.Tasks;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.DTO;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ItemsController : ControllerBase
    {
        public readonly ItemsServices _Iservices;
        public ItemsController(ItemsServices Iservices)
        {
            _Iservices = Iservices;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_Iservices.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var item = _Iservices.Get(id);
            if(item == null)
            {
                return NotFound("itemis not exists");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(ItemsModel item)
        {
            if (ModelState.IsValid)
            {
                var ite = _Iservices.Post(item);
                if (ite != null)
                {
                    return Ok(ite);
                }
                else
                {
                    return BadRequest("can not create");
                }
            }
            else
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id,[FromBody] ItemsModel item)
        {
            if (ModelState.IsValid)
            {
                var itemBool = _Iservices.Put(id, item);
                if (itemBool!=null)
                {
                    return Ok(itemBool);
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
            var deleteBool = _Iservices.Delete(id);
            if (deleteBool)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("not found item");
            }
        }
    }
}
