using FinalProjectBkEndApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class OrderDetails:IParentModel
    {
        #region properties
        [ForeignKey("Order")]
        public int order_id { get; set; } //(fk,pk)
        [ForeignKey("Products")]
        public int product_id {get; set; } //(fk,pk)
        public int quantityMeal { get; set; }
        [Column(TypeName ="money")]
        public int priceMeal { get;set; }
        [StringLength(150), MaxLength(150)]

        public string desription { get; set; }
        #endregion

        #region Relation

        public virtual Order Order { get; set; }
        public virtual Products Products { get; set; }
        #endregion
    }
}
