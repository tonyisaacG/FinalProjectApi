using FinalProjectBkEndApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IAuthServices
    {
        string Login([FromBody] LoginModel model);
        bool Register([FromBody] RegisterModel model);
    }
}
