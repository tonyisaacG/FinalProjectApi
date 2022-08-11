using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        public readonly IExpenses<ExpensesModel> _Eservices;
        public ExpensesController(IExpenses<ExpensesModel> Eservices)
        {
            _Eservices = Eservices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pur = _Eservices.GetAll();
            if (pur == null)
                return NotFound("not exist any item");
            return Ok(pur);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var pur = _Eservices.Get(id);
            if (pur != null)
            {
                return Ok(pur);
            }
            return NotFound();
        }
        [HttpGet("byType")]
        public IActionResult Get(BillType type)
        {
            var pur = _Eservices.Get(type);
            if (pur != null)
            {
                return Ok(pur);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult PostBill(ExpensesModel expensesModel)
        {
            if (ModelState.IsValid)
            {
                var expensesbool = _Eservices.Post(expensesModel);
                return Ok(expensesbool);
            }
            return BadRequest("data is not valid");
        }

        [HttpPut("{id:int}")]
        public IActionResult PutBill(int id,ExpensesModel expensesModel)
        {
            if (ModelState.IsValid)
            {
                var purchasesbool = _Eservices.Put(id,expensesModel);
                return Ok(purchasesbool);
            }
            return BadRequest("data is not valid");
        }

        [HttpPost("AddBillDetails/{id:int}")]
        public IActionResult AddBillDetails(int id, ExpensesDetailsModel expenses)
        {
            if (ModelState.IsValid)
            {
                var purbool = _Eservices.AddBillDetails(id, expenses);
                if (purbool!=null)
                    return Ok(purbool);
                else
                    return NotFound();
            }
            return BadRequest("data is not valid");
        }
        [HttpPut("EditBillDetails/{idBill:int}/{idItem:int}")]
        public IActionResult EditBillDetails(int idBill, int idItem, ExpensesDetailsModel expenses)
        {
            if (ModelState.IsValid)
            {
                var purbool = _Eservices.EditBillDetails(idBill, idItem, expenses);
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
                var expbool = _Eservices.DeleteBillDetails(idBill, idItem);
                if (expbool)
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
            var pur = _Eservices.ChangeTypeBill(id, type);
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
            var dbool = _Eservices.Delete(id);
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

