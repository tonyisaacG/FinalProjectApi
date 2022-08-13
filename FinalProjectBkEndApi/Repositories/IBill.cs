
using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IBill<IModel>:IGenericServices<IParentModel,IModel>
    {
        IEnumerable<IParentModel> Get(BillType type);
        bool EditBillDetails(int idBill, int idItem, PurchasesSalesDetailsModel purchasesSalesDetailsModel);
        IParentModel AddBillDetails(int idBill, PurchasesSalesDetailsModel purchasesSalesDetailsModel);
        bool ChangeTypeBill(int idBill, BillType billType);
        bool DeleteBillDetails(int idBill, int idItem);
    }
}
