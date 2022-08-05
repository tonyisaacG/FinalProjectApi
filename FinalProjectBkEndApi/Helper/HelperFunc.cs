using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;

namespace FinalProjectBkEndApi.Helper
{
    public static class HelperFunc
    {
        public static User RegisterDTOUser(this RegisterModel registerModel)
        {
            return new User()
            {
                name = registerModel.name,
                username = registerModel.username,
                phone = registerModel.phone,
                password = registerModel.password,
            };
        }
    }
}
