using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.Models
{
    public enum Permission
    {
        Admin,
        Casher,User
    }
    public class Role
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        public string permission { get; set; } = Permission.User.ToString();
        #endregion

        #region Relation
        public virtual User Users { get; set; }
        #endregion 
    }
}
