using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBkEndApi.Services
{
    public class ItemsServices : IGenericServices<IParentModel, ItemsModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public ItemsServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
    

        public IParentModel Get(int id)
        {
            var item = _DbContext.Items.FirstOrDefault(i => i.id == id);
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
                var itemLst = _DbContext.Items.ToList();
                if (itemLst != null)
                    return itemLst;
                else
                    return null;
            }
            catch { return null; }
        }

        public IParentModel Post(ItemsModel entity)
        {
            
            if(entity!=null)
            {
                var item = entity.ItemsModelDTOItems();
                _DbContext.Entry(item).State = EntityState.Added;
                _DbContext.SaveChanges();
                return (IParentModel)item;
            }
            else
            {
                return null;
            }
        }

        public IParentModel Put(int id, ItemsModel entity)
        {
            var item = _DbContext.Items.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                item.name = entity.name;
                item.priceKilo = entity.priceKilo;
                item.description = entity.description;
                item.expectedQuantityInDay = entity.expectedQuantityInDay;
                _DbContext.Entry(item).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return item;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var item = _DbContext.Items.FirstOrDefault(i => i.id == id);
                _DbContext.Items.Remove(item);
                _DbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
