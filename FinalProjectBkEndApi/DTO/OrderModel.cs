using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectBkEndApi.DTO
{
    public class OrderModel
    {
        public int order_id { get; set; }
        [Required]
        public DateTime order_date { get; set; } // order default date from system
        [Required]
        [Range(minimum:0,maximum:int.MaxValue)]
        public int? totalPrice { get; set; }
        [StringLength(150), MaxLength(150)]

        public string notes { get; set; }
        [Required]
        public string orderType { get; set; } //(delivery / in restaurant)
        [Required]
        public string orderStatus { get; set; } //(Ok|cancel|wait)
        [Required]
        public string nameClient { get; set; }
        [RegularExpression(@"(010|011|015|012)[0-9]{8}")]
        public string phoneClient { get; set; }
        [Required]
        [StringLength(150)]
        public string addressClient { get; set; }
        public string username { get; set; }
        public List<OrderDetailsModel> orderDetailsModels { get; set; } = new List<OrderDetailsModel>();

    }
}
