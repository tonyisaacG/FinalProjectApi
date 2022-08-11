using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class OrderDetailsModel
    {
        public int product_id { get; set; } //(fk,pk)
        [Required]
        public string product_name { get; set; } //(fk,pk)
        [Required]
        [Range(minimum:1,maximum:int.MaxValue)]
        public int quantityMeal { get; set; }
        [Range(minimum:1,maximum:int.MaxValue)]
        public int priceMeal { get; set; }
        //[Stri(50)]
        public string desription { get; set; } 
    }
}
