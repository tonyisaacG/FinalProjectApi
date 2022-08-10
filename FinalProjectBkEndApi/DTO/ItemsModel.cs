using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class ItemsModel:IParentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public int priceKilo { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue)]
        [Required]
        public int expectedQuantityInDay { get; set; }       //Amount expected to be used during the day    
        [StringLength(50)]
        public string description { get; set; }
    }
}
