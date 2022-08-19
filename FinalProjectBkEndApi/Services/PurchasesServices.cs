using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class PurchasesServices : IBill<PurchasesSalesModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public PurchasesServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IParentModel AddBillDetails(int idBill, PurchasesSalesDetailsModel purchasesSalesDetailsModel)
        {
            var purchases = _DbContext.PurchasesConsumptions.Where(od => od.id == idBill).FirstOrDefault();
            var item = _DbContext.Items.Where(i => i.id == purchasesSalesDetailsModel.item_id).FirstOrDefault();
            if (purchases != null && item != null)
            {
                var oldPurchasesDetails = _DbContext.PurchasesDetails.Where(op => op.item_id == purchasesSalesDetailsModel.item_id &&
                op.purchases_id == idBill).FirstOrDefault();
                if (oldPurchasesDetails == null)
                {
                    var newobject = new PurchasesConsumptionDetails();
                    newobject.quantity = purchasesSalesDetailsModel.quantity;
                    newobject.price = purchasesSalesDetailsModel.price;
                    newobject.PurchasesConsumption = purchases;
                    newobject.Items = item;
                    _DbContext.Entry(newobject).State = EntityState.Added;
                    _DbContext.SaveChanges();
                    return newobject;
                }
                else
                {
                    oldPurchasesDetails.quantity += purchasesSalesDetailsModel.quantity;
                    oldPurchasesDetails.price += purchasesSalesDetailsModel.price;
                    _DbContext.Entry(oldPurchasesDetails).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                    return oldPurchasesDetails;
                }

            }
            else { return null; }
        }

        public bool ChangeTypeBill(int idBill, BillType billType)
        {
            var purchases = _DbContext.PurchasesConsumptions.FirstOrDefault(od => od.id == idBill);
            if (purchases != null)
            {
                purchases.type = billType.ToString();
                _DbContext.Entry(purchases).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var purchases = _DbContext.PurchasesConsumptions.FirstOrDefault(p => p.id == id);
            if (purchases != null)
            {
                _DbContext.PurchasesConsumptions.Remove(purchases);
                _DbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool DeleteBillDetails(int idBill, int idItem)
        {
            var purchasesDetails = _DbContext.PurchasesDetails.Where(p => p.purchases_id == idBill && p.item_id == idItem).FirstOrDefault();
            if (purchasesDetails != null)
            {
                _DbContext.Entry(purchasesDetails).State = EntityState.Deleted;
                _DbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool EditBillDetails(int idBill, int idItem, PurchasesSalesDetailsModel purchasesSalesDetailsModel)
        {
            var purchasesDeatails = _DbContext.PurchasesDetails.Where(p => p.purchases_id == idBill && p.item_id == idItem).FirstOrDefault();
            var item = _DbContext.Items.FirstOrDefault(i => i.id == idItem);
            if (purchasesDeatails != null)
            {
                purchasesDeatails.quantity = purchasesSalesDetailsModel.quantity;
                //purchasesDeatails.price = purchasesSalesDetailsModel.quantity * item.priceKilo;
                purchasesDeatails.price = purchasesSalesDetailsModel.price;
                _DbContext.Entry(purchasesDeatails).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public IEnumerable<IParentModel> Get(BillType type)
        {
            var purchasesLst = _DbContext.PurchasesConsumptions.Where(purch => purch.type == type.ToString()).Include(pd => pd.PurchasesDetails).ThenInclude(t => t.Items).ToList();
            if (purchasesLst != null)
            {
                List<PurchasesSalesModel> purchasesSalesModels = new List<PurchasesSalesModel>();
                foreach (var purchase in purchasesLst)
                {
                    purchasesSalesModels.Add(purchase.PurchasesDTOpurchasesModel());
                }
                return purchasesSalesModels;
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
            try
            {
                var purchasesLst = _DbContext.PurchasesConsumptions.Include(pd => pd.PurchasesDetails).ThenInclude(t => t.Items).ToList();
                if (purchasesLst != null)
                {
                    List<PurchasesSalesModel> purchasesSalesModels = new List<PurchasesSalesModel>();
                    foreach(var purchase in purchasesLst)
                    {
                        purchasesSalesModels.Add(purchase.PurchasesDTOpurchasesModel());
                    }
                    return purchasesSalesModels;
                }
                return null;
            }
            catch { return null; }
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
                var bill = _DbContext.PurchasesConsumptions.Include(p=>p.PurchasesDetails).ThenInclude(t => t.Items).FirstOrDefault(pu => pu.id == newBill.id);

                return bill.PurchasesDTOpurchasesModel();
            }
            return null;
        }

        public IParentModel Put(int id, PurchasesSalesModel model)
        {
            var oldPurchases = _DbContext.PurchasesConsumptions.Include(p=>p.PurchasesDetails).ThenInclude(i=>i.Items).FirstOrDefault(p => p.id == id);
            if (oldPurchases != null)
            {
                oldPurchases.date = model.bill_date;
                oldPurchases.totalPrice = model.totalPrice;
                oldPurchases.vendorName = model.vendorName;
                oldPurchases.type = model.type;
                _DbContext.Entry(oldPurchases).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return oldPurchases.PurchasesDTOpurchasesModel();
            }
            return null;
        }
    }
}
