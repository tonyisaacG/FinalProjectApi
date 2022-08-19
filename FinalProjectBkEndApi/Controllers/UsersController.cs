using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        public readonly IGenericServices<IParentModel,UserModel> _Uservices;
        public UsersController(IGenericServices<IParentModel, UserModel> Iservices)
        {
            _Uservices = Iservices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_Uservices.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            var user = _Uservices.Get(id);
            if (user == null)
            {
                return NotFound("user is not exists");
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var ite = _Uservices.Post(user);

                if (ite != null)
                {
                    if (ite is UserModel)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest("Exist user");
                    }
                }
                else { return BadRequest(); }
            }
            else
            {
                return BadRequest("data is not valid");
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] UserModel user)
        {
            if (ModelState.IsValid)
            {
                var userBool = _Uservices.Put(id, user);
                if (userBool!=null)
                {
                    return Ok(userBool);
                }
                else
                {
                    return NotFound("user not exist");
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
            var deleteBool = _Uservices.Delete(id);
            if (deleteBool)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("not found user");
            }
        }
    }
}
