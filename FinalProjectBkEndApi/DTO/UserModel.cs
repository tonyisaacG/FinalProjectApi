using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class UserModel:IParentModel
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        [Required]
        public string username { get; set; }
        //[RegularExpression(@"(010|011|015|012)[0-9]{8}")]
        //public string phone { get; set; }
        [Required, RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public string password { get; set; }

        public int permission_id { get; set; }
        public string permission { get; set; }

    }
}
