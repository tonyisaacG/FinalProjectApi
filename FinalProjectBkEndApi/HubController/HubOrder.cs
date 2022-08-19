using FinalProjectBkEndApi.DTO;
using FinalProjectBkEndApi.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Threading.Tasks;

namespace FinalProjectBkEndApi.HubController
{

    public class HubOrder:Hub
    {
        public readonly IOrderServices _Oservices;

        public HubOrder(IOrderServices Oservices)
        {
            _Oservices = Oservices;
        }
        public Task SendOrder(OrderModel order)
        {
            if (order != null)
            {
                var newOrder = _Oservices.PostOrder(order);
                return Clients.Others.SendAsync("ReceiveOrder", newOrder);

            }
                return Clients.Others.SendAsync("ReceiveOrder", new { });

        }
    }


}
