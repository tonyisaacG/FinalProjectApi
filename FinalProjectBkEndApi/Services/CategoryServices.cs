using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class CategoryServices : IGenericServices<IParentModel, Categories>
    {
        private readonly RestaurantDbContext _DbContext;
        public CategoryServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public bool Delete(int id)
        {
            try
            {
                var item = _DbContext.Categories.FirstOrDefault(i => i.id == id);
                _DbContext.Categories.Remove(item);
                _DbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public IParentModel Get(int id)
        {
            var item = _DbContext.Categories.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                return (IParentModel)item;
            }
            else
                return null;
        }

        public IEnumerable<IParentModel> GetAll()
        {
            try
            {
                var catLst = _DbContext.Categories.ToList();
                if (catLst != null)
                    return (IEnumerable<IParentModel>)catLst;
                else
                    return null;
            }
            catch { return null; };
        }

        public IParentModel Post(Categories entity)
        {
            if (entity != null)
            {
                var cat = entity;
                _DbContext.Entry(cat).State = EntityState.Added;
                _DbContext.SaveChanges();
                return (IParentModel)entity;
            }
            else
            {
                return null;
            }
        }

        public bool Put(int id, Categories model)
        {
            var cat = _DbContext.Categories.FirstOrDefault(i => i.id == id);
            if (cat != null)
            {
                cat.name = model.name;
                cat.description = model.description;
                cat.imagePath = model.imagePath;
                _DbContext.Entry(cat).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
