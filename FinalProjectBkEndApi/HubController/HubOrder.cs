using FinalProjectBkEndApi.DTO;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Threading.Tasks;

namespace FinalProjectBkEndApi.HubController
{

    public class HubOrder:Hub
    {
        public Task SendOrder(OrderModel order)
        {
            return Clients.Others.SendAsync("ReceiveOrder", order);
        }
    }
}
