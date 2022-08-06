using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.Services
{
    public class ItemsServices : IGenericServices<IParentModel, Items>
    {
        private readonly RestaurantDbContext _DbContext;
        public ItemsServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IParentModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IParentModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IParentModel Post(Items entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Put(int id, IParentModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
