using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectBkEndApi.Services;
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
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
