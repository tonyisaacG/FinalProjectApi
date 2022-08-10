using FinalProjectBkEndApi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class Expenses:IParentModel
    {
        public enum BillType
        {
            Buy,
            Sell,
        }

        #region properties
        [Key]
        public int id { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime date { get; set; }
        public string type { get; set; } = BillType.Sell.ToString();
        #endregion

        #region Relation
        public virtual ICollection<ExpensesDetails> ExpensesDetails { get; set; }
        #endregion

    }
}
