using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.Models
{
    public class Products
    {
        #region properties
        [Key]
        public int id { get; set; } 
        [Required]
        public string name { get; set; }
        [Column(TypeName ="money")]
        [Range(minimum:1,maximum:int.MaxValue)]
        public int price { get; set; }
        [MinLength(50)]
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
