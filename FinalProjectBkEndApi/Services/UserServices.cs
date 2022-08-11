using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class UserServices : IGenericServices<IParentModel, UserModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public UserServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IParentModel Get(int id)
        {
            var user = _DbContext.Users.Include(u => u.Role).FirstOrDefault(ui=>ui.id==id);
            if (user != null)
            {
                return user.UsersDTOUserModel();
            }
            return null;    
        }

        public IEnumerable<IParentModel> GetAll()
        {
            var users = _DbContext.Users.Include(u => u.Role).ToList();
            if (users != null)
            {
                List<UserModel> userModels = new List<UserModel>();
                foreach(var user in users)
                {
                    userModels.Add(user.UsersDTOUserModel());
                }
                return userModels;
            }
            return null;
        }

        public IParentModel Post(UserModel entity)
        {
            if (entity != null)
            {
                try
                {
                    var existuser = _DbContext.Users.FirstOrDefault(u=>u.phone==entity.phone&&u.username== entity.username
                    &&u.password==HelperFunc.EncodePasswordToBase64(entity.password));
                    if (existuser != null)
                        return (IParentModel)existuser;
                    var newUser = entity.UserModelDTOUser();
                    newUser.Role = _DbContext.Roles.Where(role => role.permission == entity.permission.ToString()).FirstOrDefault();
                    _DbContext.Users.Add(newUser);
                    _DbContext.SaveChanges();
                    return entity;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public IParentModel Put(int id, UserModel model)
        {
            var user = _DbContext.Users.FirstOrDefault(user => user.id == id);
            if (user != null)
            {
                user.name = model.user_name;
                user.username = model.username;
                user.password = model.password;
                user.phone = model.phone;
                user.Role = _DbContext.Roles.FirstOrDefault(r => r.permission == model.permission.ToString());
                _DbContext.Entry(user).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            var user = _DbContext.Users.FirstOrDefault(u => u.id == id);
            if (user != null)
            {
                _DbContext.Entry(user).State = EntityState.Deleted;
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
