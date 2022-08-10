using FinalProjectBkEndApi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public enum BillType
    {
        Buy,
        Sell,
    }   
    public class PurchasesConsumption:IParentModel
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Column(TypeName ="date")]
        [Required]
        public DateTime date { get; set; }
        [Column(TypeName = "money")]
        public int totalPrice { get; set; }
        [StringLength(20)]
        public string vendorName { get; set; }
        public string type { get; set; } = BillType.Buy.ToString();
        #endregion

        #region Relation
        public virtual ICollection<PurchasesConsumptionDetails> PurchasesDetails { get; set; }
        #endregion
    }
}
