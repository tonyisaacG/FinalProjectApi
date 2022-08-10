
using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IBill<IModel>:IGenericServices<IParentModel,IModel>
    {
        IParentModel Get(BillType type);
        bool EditBillDetails(int idBill, int idItem, PurchasesSalesDetailsModel purchasesSalesDetailsModel);
        bool AddBillDetails(int idBill, PurchasesSalesDetailsModel purchasesSalesDetailsModel);
        bool ChangeTypeBill(int idBill, BillType billType);
        bool DeleteBillDetails(int idBill, int idItem);
    }
}
