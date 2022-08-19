using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProjectBkEndApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var pur = _PSservices.GetAll();
            if (pur == null)
                return NotFound("not exist any item");
            return Ok(pur);
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


        [HttpPost]
        public IActionResult PostBill(PurchasesSalesModel purchasesSales)
        {
            if (ModelState.IsValid)
            {
                var purchasesbool = _PSservices.Post(purchasesSales);
                return Ok(purchasesbool);
            }
            return BadRequest("data is not valid");
        }

        [HttpPut("{id:int}")]
        public IActionResult PutBill(int id,PurchasesSalesModel purchasesSales)
        {
            if (ModelState.IsValid)
            {
                var purchasesbool = _PSservices.Put(id, purchasesSales);
                return Ok(purchasesbool);
            }
            return BadRequest("data is not valid");
        }

        [HttpPost("AddBillDetails/{id:int}")]
        public IActionResult AddBillDetails(int id, PurchasesSalesDetailsModel purchasesSales)
        {
            if (ModelState.IsValid)
            {
                var purbool = _PSservices.AddBillDetails(id, purchasesSales);
                if (purbool!=null)
                    return Ok(purbool);
                else
                    return NotFound();
            }
            return BadRequest("data is not valid");
        }
        [HttpPut("EditBillDetails/{idBill:int}/{idItem:int}")]
        public IActionResult EditBillDetails(int idBill, int idItem, PurchasesSalesDetailsModel purchasesSales)
        {
            if (ModelState.IsValid)
            {
                var purbool = _PSservices.EditBillDetails(idBill, idItem, purchasesSales);
                if (purbool)
                    return Ok("updated");
                else
                    NotFound("not found item");
            }
            return BadRequest("data is not valid");
        }
        [HttpDelete("DeleteBillDetails/{idBill:int}/{idItem:int}")]
        public IActionResult DeleteBillDetails(int idBill, int idItem)
        {
            try
            {
                var purbool = _PSservices.DeleteBillDetails(idBill, idItem);
                if (purbool)
                    return Ok("Deleted");
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("changetype/{id:int}/{type}")]
        public IActionResult ChangeTypeBill(int id, BillType type)
        {
            var pur = _PSservices.ChangeTypeBill(id, type);
            if (pur)
            {
                return Ok("change type");
            }
            else
            {
                return NotFound("this order not found");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var dbool = _PSservices.Delete(id);
            if (dbool)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("not  exist this item");
            }
        }
    }
}

