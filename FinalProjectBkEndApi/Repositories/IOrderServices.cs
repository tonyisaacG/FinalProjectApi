using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Models;
using System.Collections.Generic;
using System;
namespace FinalProjectBkEndApi.Repositories
{
    public interface IOrderServices
    {
        List<Order> GetAll();
        OrderModel GetOrderDetails(int id);
        bool PutOrder(int id,OrderModel order);
        bool PostOrder(OrderModel order);
        List<Order> GetInDay();
        List<Order> GetInDayStatus(StatusOrder statusOrder);
        List<Order> GetByRangeDate(string fromDate,string toDate);

    }
}
