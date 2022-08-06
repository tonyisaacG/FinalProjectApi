using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectBkEndApi.Models;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesSalesController : ControllerBase
    {
        public readonly IBill<PurchasesSalesModel> _PSservices;
        public PurchasesSalesController(IBill<PurchasesSalesModel> PSservices)
        {
            _PSservices = PSservices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_PSservices.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var pur = _PSservices.Get(id);
            if (pur != null)
            {
                return Ok(pur);
            }
            return NotFound();
        }
        [HttpGet("byType")]
        public IActionResult Get(BillType type)
        {
            var pur = _PSservices.Get(type);
            if (pur != null)
            {
                return Ok(pur);
            }
            return NotFound();
        }
    }
}
