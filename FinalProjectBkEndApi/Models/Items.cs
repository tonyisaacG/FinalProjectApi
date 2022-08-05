using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class Items
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue)]
        [Required]
        public int totalQuantity { get; set; }
        [Column(TypeName ="money")]
        [Required]
        public int priceKilo { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue)]
        [Required]
        public int expectedQuantityInDay { get; set; }             //Amount expected to be used during the day    
        [MinLength(50)]
        public string description { get; set; }
        #endregion

        #region Relation 
        public virtual ICollection<PurchasesConsumptionDetails> PurchasesDetails { get; set; }
        #endregion
    }
}
