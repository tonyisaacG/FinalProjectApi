using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.Models
{
    public class Cutomer
    {
        #region properties
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [RegularExpression(@"(010|011|015|012)[0-9]{8}")]
        public string phone { get; set; }

        #endregion

        #region Relation
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CutomerAddress> CutomerAddresses { get; set; }

        #endregion

    }
}
