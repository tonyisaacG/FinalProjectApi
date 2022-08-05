using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class CutomerAddress
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        #endregion

        #region Relation 
        [ForeignKey("Cutomer")]
        public int? cutomer_id { get; set; }
        public virtual Cutomer Cutomer { get; set; }
        #endregion

    }
}
