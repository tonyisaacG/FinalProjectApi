using FinalProjectBkEndApi.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class User:IParentModel
    {
        #region Properties
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [RegularExpression(@"(010|011|015|012)[0-9]{8}")]
        public string phone { get; set; }
        [Required,RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        public string password { get; set; }
        //public string permission { get; set; } //(admin- casher)
        #endregion

        #region Relation
        [ForeignKey("Role")]
        public int? Role_id { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        #endregion

    }
}
