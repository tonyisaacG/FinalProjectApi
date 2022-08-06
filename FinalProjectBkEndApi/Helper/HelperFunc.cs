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
     
    }
}
