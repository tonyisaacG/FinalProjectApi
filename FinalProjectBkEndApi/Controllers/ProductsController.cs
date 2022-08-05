using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly ProductServices _Pservices;
        public ProductsController(ProductServices Pservices)
        {
            _Pservices = Pservices;
        }

    }
}
