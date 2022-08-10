using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class ProductModel:IParentModel
    {
       
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        [Range(minimum: 0, maximum: int.MaxValue)]
        public int product_price { get; set; }
        [StringLength(50)]
        public string product_description { get; set; }
        public IFormFile product_imagePathSrc { get; set; }
        public string product_imagePath { get; set; }

        public int cat_id { get; set; }
        public string cat_name { get; set; }
    }
}
