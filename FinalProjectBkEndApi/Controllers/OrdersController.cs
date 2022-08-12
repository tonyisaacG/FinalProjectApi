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

        [HttpPut("{id:int}")]
        public IActionResult PutOrder(int id,OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderbool = _Oservices.PutOrder(id,orderModel);
                return Ok(orderbool);
            }
            return BadRequest("data is not valid");
        }

        ///[HttpPost("AddOrderDetails/{id:int}")]
        [HttpPost("AddOrderDetails/{id:int}")]
        public IActionResult AddOrderDetails(int id,OrderDetailsModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderbool = _Oservices.AddOrderDetails(id,orderModel);
                return Ok("Ok");
            }
            return BadRequest("data is not valid");
        }
        [HttpPut("EditOrderDetails/{idorder:int}/{idproduct:int}")]
        public IActionResult EditOrderDetails(int idorder,int idproduct, OrderDetailsModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var orderbool = _Oservices.EditOrderDetails(idorder,idproduct, orderModel);
                return Ok("updated");
            }
            return BadRequest("data is not valid");
        }
        [HttpDelete("DeleteOrderDetails/{idorder:int}/{idproduct:int}")]
        public IActionResult DeleteOrderDetails(int idorder, int idproduct)
        {
            try
            {
                var orderbool = _Oservices.DeleteOrderDetails(idorder, idproduct);
                return Ok("Deleted");
            }
            catch
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("changetype/{id:int}/{type}")]
        public IActionResult ChangeStatusOrder(int id,StatusOrder type)
        {
            var order = _Oservices.ChangeStatusOrder(id, type);
            if (order!=null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleteBool = _Oservices.DeleteOrder(id);
            if (deleteBool)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
