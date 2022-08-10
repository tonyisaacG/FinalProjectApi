using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectBkEndApi.DTO
{
    public class ExpensesModel:IParentModel
    {
        public int bill_id { get; set; }
        [Required]
        public DateTime bill_date { get; set; }
        public string type { get; set; }

        public virtual List<ExpensesDetailsModel> ExpensesDetailsModels { get; set; } = new List<ExpensesDetailsModel>();
    }
}
