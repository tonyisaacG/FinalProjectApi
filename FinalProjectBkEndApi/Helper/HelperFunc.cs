using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace FinalProjectBkEndApi.Helper
{
    public static class HelperFunc
    {
        public static User RegisterDTOUser(this RegisterModel registerModel)
        {
            return new User()
            {
                name = registerModel.name,
                username = registerModel.username,
                //phone = registerModel.phone,
                password = EncodePasswordToBase64(registerModel.password),
            };
        }
        public static OrderModel OrderDTOrderModel(this Order order)
        {
            var orderMolde = new OrderModel()
            {
                order_id = order.id,
                order_date = order.date,
                totalPrice = order.totalPrice,
                nameClient = order.nameClient,
                addressClient = order.AddressClient,
                orderStatus = order.orderStatus,
                orderType   =order.orderType,
                phoneClient = order.phoneClient,
                notes = order.notes
            
            };
            if (order.OrderDetails != null||order.OrderDetails.Count>0)
            {
                foreach (var details in order.OrderDetails)
                {
                    orderMolde.orderDetailsModels.Add(new OrderDetailsModel()
                    {
                        product_id = details.Products.id,
                        product_name = details.Products.name,
                        priceMeal = details.priceMeal,
                        quantityMeal = details.quantityMeal,
                        desription = details.desription

                    });
                }
            }
            else { orderMolde.orderDetailsModels =null; }
            return orderMolde;
        }
        public static Order OrderModelDTOrder(this OrderModel order)
        {
            return new Order()
            {
                date = order.order_date,
                orderStatus = order.orderStatus,
                orderType = order.orderType,
                totalPrice = order.totalPrice,
                phoneClient = order.phoneClient,
                nameClient =  order.nameClient,
                AddressClient = order.addressClient,
                notes = order.notes,
            };
        }
        public static PurchasesSalesModel PurchasesDTOpurchasesModel(this PurchasesConsumption purchases)
        {
            var purchasesMolde = new PurchasesSalesModel()
            {
                bill_id = purchases.id,
                bill_date = purchases.date,
                totalPrice = purchases.totalPrice,
                vendorName = purchases.vendorName,
                type =purchases.type,
            };
            foreach (var details in purchases.PurchasesDetails)
            {
                purchasesMolde.PurchasesSalesDetailsModels.Add(new PurchasesSalesDetailsModel()
                {
                   item_id = details.Items.id,
                   item_name = details.Items.name,
                   price = details.price,
                   quantity = details.quantity
                });
            }
            return purchasesMolde;
        }
        public static PurchasesConsumption PurchasesModelDTPurchases(this PurchasesSalesModel purchases)
        {
            return new PurchasesConsumption()
            {
               date = purchases.bill_date,
               totalPrice = purchases.totalPrice,
               type = purchases.type,
               vendorName = purchases.vendorName
            };
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static Items ItemsModelDTOItems(this ItemsModel item)
        {
            return new Items()
            {
                id = item.id,
                name = item.name,
                description = item.description,
                priceKilo = item.priceKilo,
                expectedQuantityInDay = item.expectedQuantityInDay,
            };
        }
      
        public static Products ProductModelDTOProdcuts(this ProductModel product)
        {
            return new Products()
            {
                id=product.product_id,
                name = product.product_name,
                description= product.product_description,
                imagePath = product.product_imagePath,
                price = product.product_price,
            };
        }
        public static ProductModel ProductsDTOProdcutModel(this Products product)
        {
            return new ProductModel()
            {
               product_id = product.id,
               product_name = product.name,
               product_description = product.description,
               product_imagePath = product.imagePath,
               product_price = product.price,
               cat_id = product.Categories?.id??0,
               cat_name = product.Categories?.name
            };
        }


        public static UserModel UsersDTOUserModel(this User user)
        {
            return new UserModel()
            {
                user_id = user.id,
                user_name = user.name,
                username = user.username,
                //phone = user.phone,
                password = user.password,
                permission_id = user.Role?.id??0,
                permission = user.Role?.permission
            };
        }
        public static User UserModelDTOUser(this UserModel user)
        {
            return new User()
            {
                name = user.user_name,
                username = user.username,
                //phone = user.phone,
                password = EncodePasswordToBase64(user.password),
            };
        }



        public static ExpensesModel ExpensesDTOExpensesModel(this Expenses expenses)
        {
            var expensesModel = new ExpensesModel()
            {
                bill_id = expenses.id,
                bill_date = expenses.date,
                type = expenses.type,
            };
            if (expenses.ExpensesDetails != null || expenses.ExpensesDetails.Count > 0)
            {
                foreach (var details in expenses.ExpensesDetails)
                {
                    expensesModel.ExpensesDetailsModels.Add(new ExpensesDetailsModel()
                    {
                        item_id = details.Items.id,
                        item_name = details.Items.name,
                        quantity = details.quantity
                    });
                }
            }
            else { expensesModel.ExpensesDetailsModels = null; }
            return expensesModel;
        }
        public static Expenses ExpensesModelDTExpenses(this ExpensesModel expenses)
        {
            return new Expenses()
            {
                id = expenses.bill_id,
                date = expenses.bill_date,
                type = expenses.type,
            };
        }






    }
}
