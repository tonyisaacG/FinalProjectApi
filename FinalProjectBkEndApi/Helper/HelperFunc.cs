using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
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
                phone = registerModel.phone,
                password = registerModel.password,
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
                AddressClient = order.AddressClient,
                orderStatus = order.orderStatus,
                orderType   =order.orderType,
                phoneClient = order.phoneClient,
                notes = order.notes
            
            };
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
                AddressClient = order.AddressClient,
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
    }
}
