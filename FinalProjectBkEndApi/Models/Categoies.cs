using FinalProjectBkEndApi.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class Categories:IParentModel
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string imagePath { get; set; }
        public string description { get; set; }
        #endregion

        #region Realtion
        public virtual ICollection<Products> Products { get; set; }
        #endregion
    }
}
