using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FinalProjectBkEndApi.DTO;

namespace FinalProjectBkEndApi.Models
{
    public enum StatusOrder
    {
        Wait,
        Ok,
        Cancel,
        Delete
    }
    public enum TypeOrder
    {
        Delivery,
        Restaurant,
    }
    public class Order:IParentModel
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date { get; set; } // order default date from system
        [Column(TypeName ="money")]
        public int? totalPrice { get; set; }
        [StringLength(50)]
        public string  notes { get; set; }
        public string nameClient { get; set; }
        [RegularExpression(@"(010|011|015|012)[0-9]{8}")]
        public string phoneClient { get; set; }
        [StringLength(50)]
        public string AddressClient { get; set; }
        [Required]
        public string orderType { get; set; } //(delivery / in restaurant)
        [Required]
        public string orderStatus { get; set; } //(Ok|cancel|wait)

        #endregion

        #region Relation
        //[ForeignKey("Cutomer")]
        //public int? cutomer_id { get; set; }
        //public virtual Cutomer Cutomer { get; set; }
        [ForeignKey("User")]
        public int? user_id { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public static implicit operator Order(OrderDetails v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
