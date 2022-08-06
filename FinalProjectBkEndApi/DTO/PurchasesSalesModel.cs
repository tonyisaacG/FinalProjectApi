using System.ComponentModel.DataAnnotations;
using System;
using FinalProjectBkEndApi.Models;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.DTO
{
    public class PurchasesSalesModel:IParentModel
    {
        public int bill_id { get; set; }
        [Required]
        public DateTime bill_date { get; set; }
        [Required]
        public int totalPrice { get; set; }
        [StringLength(20)]
        public string vendorName { get; set; }
        public string type { get; set; }

        public virtual List<PurchasesSalesDetailsModel> PurchasesSalesDetailsModels { get; set; } = new List<PurchasesSalesDetailsModel>();
    }
}
