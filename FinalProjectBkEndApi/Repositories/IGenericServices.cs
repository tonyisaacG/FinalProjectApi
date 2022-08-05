using System.Collections.Generic;

namespace FinalProjectBkEndApi.Repositories
{
    public interface IGenericServices<TModel,TEntity>
    {
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        TModel Post(TEntity entity);
        bool Put(int id, TModel model);
        bool Delete(int id);
    }
}
