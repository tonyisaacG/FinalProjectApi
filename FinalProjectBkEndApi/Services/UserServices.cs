using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Repositories;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.Services
{
    public class UserServices : IGenericServices<IParentModel, UserModel>
    {
        public IParentModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IParentModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IParentModel Post(UserModel entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Put(int id, UserModel model)
        {
            throw new System.NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
