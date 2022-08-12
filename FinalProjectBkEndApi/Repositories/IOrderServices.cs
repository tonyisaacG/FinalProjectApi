using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using System.Collections.Generic;
using System;
namespace FinalProjectBkEndApi.Repositories
{
    public interface IOrderServices
    {
        List<OrderModel> GetAll();
        OrderModel GetOrderDetails(int id);
        Order PutOrder(int id,OrderModel order);
        Order PostOrder(OrderModel order);
        List<Order> GetInDay();
        List<Order> GetInDayStatus(StatusOrder statusOrder);
        List<Order> GetByRangeDate(string fromDate,string toDate);
        bool EditOrderDetails(int idOrder, int idProduct, OrderDetailsModel orderDetailsModel);
        bool AddOrderDetails(int idOrder, OrderDetailsModel orderDetails);
        OrderModel ChangeStatusOrder(int idOrder, StatusOrder typeOrder);
        bool DeleteOrderDetails(int idOrder, int idProduct);
        bool DeleteOrder(int id);




    }
}
