
using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IBill<IModel>:IGenericServices<IParentModel,IModel>
    {
        IParentModel Get(BillType id);      
    }
}
