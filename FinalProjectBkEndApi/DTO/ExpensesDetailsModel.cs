using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class ExpensesDetailsModel:IParentModel
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        [Range(minimum: 0, maximum: int.MaxValue)]
        public int quantity { get; set; }
    }
}
