using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderServices _Oservices;
        public OrdersController(IOrderServices Oservices)
        {
            _Oservices = Oservices;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_Oservices.GetAll());
        }
        
        
        [HttpGet("{id:int}")]
        public IActionResult GetOrderDetails(int id)
        {
            var order = _Oservices.GetOrderDetails(id);
            if (order == null)
                return NotFound("order not exist in system");
            return Ok(order);
        }
        
        
        [HttpGet("getRangeDate")]
        public IActionResult GetByRangeDate(string fromDate,string toDate)
        {
            var order = _Oservices.GetByRangeDate(fromDate,toDate);
            if (order==null)
                return NotFound("order not exist in between range date");
            return Ok(order);
        }
        
        
        [HttpGet("getinday")]
        public IActionResult GetInDay()
        {
            var order = _Oservices.GetInDay();
            if (order==null)
                return NotFound("not exists anorder in this day");
            return Ok(order);
        }
        
        
        [HttpGet("getindaystatus")]
        public IActionResult GetInDayStatus(StatusOrder status)
        {
            var order = _Oservices.GetInDayStatus(status);
            if (order==null)
                return NotFound("not exists anorder in this day");
            return Ok(order);
        }
        
        
        [HttpPost]
        public IActionResult PostOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderbool = _Oservices.PostOrder(orderModel);
                return Ok(orderbool);
            }
            return BadRequest("data is not valid");
        }

        [HttpPut]
        public IActionResult PutOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderbool = _Oservices.PostOrder(orderModel);
                return Ok(orderbool);
            }
            return BadRequest("data is not valid");
        }
    }
}
