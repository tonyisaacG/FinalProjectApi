using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProjectBkEndApi.DTO;

namespace FinalProjectBkEndApi.Models
{
    public class Products:IParentModel
    {
        #region properties
        [Key]
        public int id { get; set; } 
        [Required]
        public string name { get; set; }
        [Column(TypeName ="money")]
        [Range(minimum:0,maximum:int.MaxValue)]
        public int price { get; set; }
        [StringLength(50)]
        public string description { get; set; }
	    public string imagePath { get; set; }
        #endregion

        #region Relation
        [ForeignKey("Categories")]
        public int? catergory_id { get; set; }
        public virtual Categories Categories { get; set; }
        #endregion
    }
}
