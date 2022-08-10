using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class CategoryModel:IParentModel
    {
        #region properties
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public IFormFile imagePath { get; set; }
        public string description { get; set; }
        #endregion

    }
}
