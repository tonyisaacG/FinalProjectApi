using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class PurchasesConsumptionDetails
    {
        #region properties
        [ForeignKey("PurchasesConsumption")]
        public int purchases_id { get; set; }
        [ForeignKey("Items")]
        public int item_id { get; set; }
        [Range(minimum:0,maximum:int.MaxValue)]
        public int quantity { get; set; }
        [Column(TypeName ="money")]
        [Range(minimum:0,maximum:int.MaxValue)]
        public int price { get; set; }
        #endregion


        #region Relation
        public virtual Items Items { get; set; }
        public virtual PurchasesConsumption PurchasesConsumption { get; set; }
        #endregion

    }
}
