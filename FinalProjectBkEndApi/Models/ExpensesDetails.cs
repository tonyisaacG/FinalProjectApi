using FinalProjectBkEndApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class ExpensesDetails:IParentModel
    {
        #region properties
        [ForeignKey("Expenses")]
        public int expenses_id { get; set; }
        [ForeignKey("Items")]
        public int item_id { get; set; }
        [Range(minimum: 0, maximum: int.MaxValue)]
        public int quantity { get; set; }
        #endregion


        #region Relation
        public virtual Items Items { get; set; }
        public virtual Expenses Expenses { get; set; }
        #endregion

    }
}
