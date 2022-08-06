using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class SellBuyServices : IBill<PurchasesSalesModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public SellBuyServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IParentModel Get(BillType type)
        {
            var purchasesLst = _DbContext.PurchasesConsumptions.Where(purch => purch.type == type.ToString()).ToList();
            if(purchasesLst!=null)
            {
                return (IParentModel)purchasesLst;
            }
            return null;
        }

        public IParentModel Get(int id)
        {
            var purchasesLst =  _DbContext.PurchasesConsumptions.Where(p => p.id == id).Include(pd => pd.PurchasesDetails).ThenInclude(t => t.Items).FirstOrDefault();

            if (purchasesLst != null)
            {
                return purchasesLst.PurchasesDTOpurchasesModel();
            }
            return null;
        }

        public IEnumerable<IParentModel> GetAll()
        {
            var purchasesLst = _DbContext.PurchasesConsumptions.ToList();
            if (purchasesLst != null)
            {
                return purchasesLst;
            }
            return null;
        }

        public IParentModel Post(PurchasesSalesModel entity)
        {
            if (entity != null)
            {
                var newBill = entity.PurchasesModelDTPurchases();
                _DbContext.PurchasesConsumptions.Add(newBill);
                _DbContext.SaveChanges();
                // save deatils for order or exists
                if (entity.PurchasesSalesDetailsModels.Count > 0)
                {
                    List<PurchasesConsumptionDetails> consumptionDetails = new List<PurchasesConsumptionDetails>();
                    foreach (var details in entity.PurchasesSalesDetailsModels)
                    {
                        consumptionDetails.Add(new PurchasesConsumptionDetails()
                        {
                            purchases_id = newBill.id,
                            item_id = details.item_id,
                            quantity = details.quantity,
                            price = details.price
                        });

                    }
                    _DbContext.PurchasesDetails.AddRange(consumptionDetails);
                    _DbContext.SaveChanges();
                    // add quantity for items

                }
                return newBill;
            }
            return null;
        }

        public bool Put(int id, PurchasesSalesModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
