using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ConsoleSignalRServer
{
    public class MessageHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveMessage", "connected");
            await base.OnConnectedAsync();
        }
    }
}
