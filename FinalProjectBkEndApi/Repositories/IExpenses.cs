using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IExpenses<IModel> : IGenericServices<IParentModel, IModel>
    {
        IParentModel Get(BillType type);
        bool EditBillDetails(int idBill, int idItem, ExpensesDetailsModel expensesDetailsModel);
        bool AddBillDetails(int idBill, ExpensesDetailsModel expensesDetailsModel);
        bool ChangeTypeBill(int idBill, BillType billType);
        bool DeleteBillDetails(int idBill, int idItem);
    }
}