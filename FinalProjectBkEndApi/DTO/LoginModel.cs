using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class LoginModel:IParentModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
