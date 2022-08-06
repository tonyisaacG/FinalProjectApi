using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using System.Collections.Generic;

namespace FinalProjectBkEndApi.Services
{
    public class ProductServices : IGenericServices<IParentModel, Products>
    {
        private readonly RestaurantDbContext _DbContext;
        public ProductServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IParentModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IParentModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IParentModel Post(Products entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Put(int id, Products entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
