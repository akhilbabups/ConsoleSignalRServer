using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ConsoleSignalRServer
{
    public class MessageHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Connected", "connected");
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(MessageModel message)
        {
            await Clients.Others.SendAsync("ReceiveMessage", message);
        }
    }
}
