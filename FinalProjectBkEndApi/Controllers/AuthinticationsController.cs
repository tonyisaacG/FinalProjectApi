using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Repositories;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthinticationsController : ControllerBase
    {
        public readonly IUserServices _Uservices;
        public AuthinticationsController(IUserServices Uservices)
        {
            _Uservices = Uservices;
        }

        [HttpPost("register")]
        public IActionResult register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var regBool = _Uservices.Register(registerModel);
                if (regBool)
                {
                    return Ok("create new user");
                }
                else
                {
                    return BadRequest("user is exist");
                }
            }
            return BadRequest(ModelState.Values);
        }
        [HttpPost("login")]
        public IActionResult login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var token = _Uservices.Login(loginModel);
                if (token!=null)
                {
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest(ModelState.Values);
        }
    }
}
