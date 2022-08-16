using FinalProjectBkEndApi.DTO;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IProducts<IModel>: IGenericServices<IParentModel, IModel>
    {
        List<IModel>  GetProductCatId(int productCatId);
    }
}
