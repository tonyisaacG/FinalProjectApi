using FinalProjectBkEndApi.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class Items:IParentModel
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Range(minimum: 0, maximum: int.MaxValue)]
        public int totalQuantity { get; set; } = 0;
        [Column(TypeName = "money")]
        public int priceKilo { get; set; } = 1;
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int? expectedQuantityInDay { get; set; } = 1;     //Amount expected to be used during the day    
        [StringLength(150), MaxLength(150)]
        public string description { get; set; }
        #endregion

        #region Relation 
        public virtual ICollection<PurchasesConsumptionDetails> PurchasesDetails { get; set; }
        #endregion
    }
}
