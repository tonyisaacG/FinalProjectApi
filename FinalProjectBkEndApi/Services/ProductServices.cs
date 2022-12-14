using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class ProductServices : IProducts<ProductModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public ProductServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public IParentModel Get(int id)
        {
            var product = _DbContext.Products.Include(cat=>cat.Categories).FirstOrDefault(p=>p.id==id);
            if (product != null)
            {
                return product.ProductsDTOProdcutModel();
            }
            else
                return null;
        }

        public IEnumerable<IParentModel> GetAll()
        {
            try
            {
                var products = _DbContext.Products.Include(cat => cat.Categories).ToList();
                List<ProductModel> productModel = new List<ProductModel>();
                foreach (var product in products)
                {
                    productModel.Add(product.ProductsDTOProdcutModel());
                }
                return productModel;
            }
            catch { return null; }
        }


       

        public IParentModel Post(ProductModel entity)
        {
            if (entity != null)
            {
                var newProduct = entity.ProductModelDTOProdcuts();
                newProduct.Categories = _DbContext.Categories.FirstOrDefault(cat => cat.id==entity.cat_id);
                if (newProduct.Categories != null)
                {
                    _DbContext.Products.Add(newProduct);
                    _DbContext.SaveChanges();
                    return (IParentModel)newProduct;

                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public IParentModel Put(int id, ProductModel entity)
        {
            var product = _DbContext.Products.FirstOrDefault(p => p.id == id);
            if (product != null)
            {
                product.name = entity.product_name;
                product.description = entity.product_description;
                product.imagePath = entity.product_imagePath;
                product.price = entity.product_price;
                product.Categories = _DbContext.Categories.FirstOrDefault(cat => cat.id == entity.cat_id);
                if (product.Categories != null)
                {
                    _DbContext.Entry(product).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                    return product;
                }
                else
                {
                    return null;
                }
             
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
                var product = _DbContext.Products.FirstOrDefault(i => i.id == id);
                _DbContext.Products.Remove(product);
                _DbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<ProductModel> GetProductCatId(int productCatId)
        {
            try
            {
                var products = _DbContext.Products.Include(cat => cat.Categories).Where(ca=>ca.id == productCatId).ToList();
                List<ProductModel> productModel = new List<ProductModel>();
                foreach (var product in products)
                {
                    productModel.Add(product.ProductsDTOProdcutModel());
                }
                return productModel;
            }
            catch { return null; }
        }
    }
}
