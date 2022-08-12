using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class ExpensesServices : IExpenses<ExpensesModel>
    {
        private readonly RestaurantDbContext _DbContext;
        public ExpensesServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IParentModel AddBillDetails(int idBill, ExpensesDetailsModel ExpensesDetailsModel)
        {
            var expenses = _DbContext.Expenses.Where(e => e.id == idBill).FirstOrDefault();
            var item = _DbContext.Items.Where(i => i.id == ExpensesDetailsModel.item_id).FirstOrDefault();
            if (expenses != null && item != null)
            {
                var oldDetails = _DbContext.ExpensesDetails.Where(op => op.item_id == ExpensesDetailsModel.item_id &&
                op.expenses_id == idBill).FirstOrDefault();
                if (oldDetails == null)
                {
                    var newobject = new ExpensesDetails();
                    newobject.quantity = ExpensesDetailsModel.quantity;
                    newobject.Expenses = expenses;
                    newobject.Items = item;
                    _DbContext.Entry(newobject).State = EntityState.Added;
                    _DbContext.SaveChanges();
                    return newobject;
                }
                else
                {
                    oldDetails.quantity += ExpensesDetailsModel.quantity;
                    _DbContext.Entry(oldDetails).State = EntityState.Modified;
                    _DbContext.SaveChanges();
                    return oldDetails;
                }
            }
            else { return null; }
        }

        public bool ChangeTypeBill(int idBill, BillType billType)
        {
            var expenses = _DbContext.Expenses.FirstOrDefault(od => od.id == idBill);
            if (expenses != null)
            {
                expenses.type = billType.ToString();
                _DbContext.Entry(expenses).State = EntityState.Modified;
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
            var expenses = _DbContext.Expenses.FirstOrDefault(e => e.id == id);
            if (expenses != null)
            {
                _DbContext.Entry(expenses).State = EntityState.Deleted;
                _DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBillDetails(int idBill, int idItem)
        {
            var expensesD = _DbContext.ExpensesDetails.Where(e => e.expenses_id == idBill && e.item_id == idItem).FirstOrDefault();
            if (expensesD != null)
            {
                _DbContext.Entry(expensesD).State = EntityState.Deleted;
                _DbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool EditBillDetails(int idBill, int idItem, ExpensesDetailsModel ExpensesDetailsModel)
        {
            var expensesD = _DbContext.ExpensesDetails.Where(p => p.expenses_id == idBill && p.item_id == idItem).FirstOrDefault();
            var item = _DbContext.Items.FirstOrDefault(i => i.id == idItem);
            if (expensesD != null)
            {
                expensesD.quantity = ExpensesDetailsModel.quantity;
                _DbContext.Entry(expensesD).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public IParentModel Get(BillType type)
        {
            try
            {
                var expensesLst = _DbContext.Expenses.Where(ex => ex.type == type.ToString()).ToList();
                if (expensesLst != null)
                {
                    List<ExpensesModel> expensesModels = new List<ExpensesModel>();
                    foreach (var expenses in expensesLst)
                    {
                        expensesModels.Add(expenses.ExpensesDTOExpensesModel());
                    }
                    return (IParentModel)expensesModels;
                }
                return null;
            }
            catch { return null; }
        }

        public IParentModel Get(int id)
        {
            var expenses = _DbContext.Expenses.Where(e => e.id == id).Include(ed => ed.ExpensesDetails).ThenInclude(t => t.Items).FirstOrDefault();

            if (expenses != null)
            {
                return (IParentModel)expenses.ExpensesDTOExpensesModel();
            }
            return null;
        }

        public IEnumerable<IParentModel> GetAll()
        {
            try
            {
                var expensesLst = _DbContext.Expenses.Include(ed => ed.ExpensesDetails).ThenInclude(t => t.Items).ToList();
                if (expensesLst != null)
                {
                    List<ExpensesModel> expensesModels = new List<ExpensesModel>();
                    foreach(var expenses in expensesLst)
                    {
                       expensesModels.Add( expenses.ExpensesDTOExpensesModel());
                    }
                    return expensesModels;
                }
                return null;
            }
            catch { return null; }
        }

        public IParentModel Post(ExpensesModel entity)
        {
            if (entity != null)
            {
                var trasnsition = _DbContext.Database.BeginTransaction();
                try
                {
                    var newBill = entity.ExpensesModelDTExpenses();
                    _DbContext.Expenses.Add(newBill);
                    _DbContext.SaveChanges();

                    // save deatils for order or exists
                    if (entity.ExpensesDetailsModels.Count > 0)
                    {
                        List<ExpensesDetails> expensesDetails = new List<ExpensesDetails>();
                        foreach (var details in entity.ExpensesDetailsModels)
                        {
                            expensesDetails.Add(new ExpensesDetails()
                            {
                                expenses_id = newBill.id,
                                item_id = details.item_id,
                                quantity = details.quantity,
                            });

                        }

                        _DbContext.ExpensesDetails.AddRange(expensesDetails);
                        _DbContext.SaveChanges();
                       
                    }
                    trasnsition.Commit();
                    // add quantity for items
                    var expensesM = _DbContext.Expenses.Include(ed => ed.ExpensesDetails).ThenInclude(t => t.Items).FirstOrDefault(ex => ex.id == newBill.id);
                    return (IParentModel)expensesM.ExpensesDTOExpensesModel();

                }
                catch {
                    trasnsition.Rollback();
                    return null;
                }
            }
            return null;
        }

        public IParentModel Put(int id, ExpensesModel model)
        {
            var oldExpenses = _DbContext.Expenses.Include(p => p.ExpensesDetails).ThenInclude(i=>i.Items).FirstOrDefault(p => p.id == id);
            if (oldExpenses != null)
            {
                oldExpenses.date = model.bill_date;
                oldExpenses.type = model.type;
                _DbContext.Entry(oldExpenses).State = EntityState.Modified;
                _DbContext.SaveChanges();
                return oldExpenses.ExpensesDTOExpensesModel();
            }
            return null;

        }
    }
}

