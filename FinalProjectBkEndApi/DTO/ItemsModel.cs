using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class ItemsModel:IParentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int priceKilo { get; set; } = 1;
        [Range(minimum: 0, maximum: int.MaxValue)]
        public int? totalQuantity { get; set; } = 0;
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int? expectedQuantityInDay { get; set; } = 1;       //Amount expected to be used during the day    
        [StringLength(150), MaxLength(150)]

        public string description { get; set; }
    }
}
