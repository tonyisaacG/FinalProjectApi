using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using System.Collections.Generic;
using System;
namespace FinalProjectBkEndApi.Repositories
{
    public interface IOrderServices
    {
        List<OrderModel> GetAll();
        List<OrderModel> GetAllOrderNotOnlineInDay();
        OrderModel GetOrderDetails(int id);
        OrderModel PutOrder(int id,OrderModel order);
        OrderModel PostOrder(OrderModel order);
        List<Order> GetInDay();
        List<Order> GetInDayStatus(StatusOrder statusOrder);
        List<Order> GetByRangeDate(string fromDate,string toDate);
        bool EditOrderDetails(int idOrder, int idProduct, OrderDetailsModel orderDetailsModel);
        bool AddOrderDetails(int idOrder, OrderDetailsModel orderDetails);
        OrderModel ChangeStatusOrder(int idOrder, StatusOrder typeOrder);
        bool DeleteOrderDetails(int idOrder, int idProduct);
        bool DeleteOrder(int id);
        List<OrderModel> GetOnlineInDayOrder();
        List<OrderModel> GetInDayOrderType(TypeOrder type);



    }
}
