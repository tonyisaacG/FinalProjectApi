using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
    public class Order
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime date { get; set; } // order default date from system
        [Required]
        [Column(TypeName ="money")]
        public int? totalPrice { get; set; }
        [MinLength(20)]
        public string  notes { get; set; } 
        public string orderType { get; set; } //(delivery / in restaurant)
        public string orderStatus { get; set; } //(Ok|cancel|wait)
        #endregion

        #region Relation
        public virtual ICollection<Cutomer> Cutomers { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion
    }
}
