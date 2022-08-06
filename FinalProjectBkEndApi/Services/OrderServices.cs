using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Helper;
using FinalProjectBkEndApi.Models;
using FinalProjectBkEndApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBkEndApi.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly RestaurantDbContext _DbContext;
        public OrderServices(RestaurantDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public List<Order> GetAll()
        {
            var orders =  _DbContext.Orders.ToList();
            if (orders.Count > 0)
            {
                return orders;
            }
            else
                return null;
        }

        public List<Order> GetByRangeDate(string fromDate, string toDate)
        {
            
                DateTime outFromDate;
                bool frombool = DateTime.TryParse(fromDate, out outFromDate);
                DateTime outToDate;
                bool tobool = DateTime.TryParse(toDate, out outToDate);
                if (frombool && tobool)
                {
                    var orders = _DbContext.Orders.Where(od => od.date.Date <= outToDate.Date && od.date.Date >= outFromDate.Date).ToList();
                    if (orders.Count > 0)
                    {
                        return orders;
                    }
                    else
                        return null;
                }
                return null;
        }

        public List<Order> GetInDay()
        {
            try
            {
                var orders = _DbContext.Orders.Where(od => od.date.Date==DateTime.Now.Date).ToList();
                if (orders.Count > 0)
                {
                    return orders;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public List<Order> GetInDayStatus(StatusOrder statusOrder)
        {
            try
            {
                var orders = _DbContext.Orders.Where(od => od.orderStatus == statusOrder.ToString() && od.date.Date == DateTime.Now.Date).ToList();
                if (orders.Count > 0)
                {
                    return orders;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public OrderModel GetOrderDetails(int id)
        {
            try
            {
                var order = _DbContext.Orders.Where(od => od.id == id).Include(od => od.OrderDetails).ThenInclude(t=>t.Products).FirstOrDefault();
                if (order!=null)
                {
                    return order.OrderDTOrderModel();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool PostOrder(OrderModel order)
        {
            if(order != null)
            {
                var newOrder = order.OrderModelDTOrder();
                newOrder.User = _DbContext.Users.FirstOrDefault(user => user.username == order.username);
                _DbContext.Orders.Add(newOrder);
                _DbContext.SaveChanges();
                // save deatils for order or exists
                if (order.orderDetailsModels.Count > 0)
                {
                    List<OrderDetails> orderDetails = new List<OrderDetails>();
                    foreach(var details in order.orderDetailsModels)
                    {
                        orderDetails.Add(new OrderDetails()
                        {
                            order_id = newOrder.id,
                            product_id = details.product_id,
                            quantityMeal = details.quantityMeal,
                            priceMeal = details.priceMeal
                        });
                    }
                    _DbContext.OrderDetails.AddRange(orderDetails);
                    _DbContext.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool PutOrder(int id,OrderModel order)
        {
            return true;
        }

      
    }
}
