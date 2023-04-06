using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace BlazorWebAssemblySignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

     public async Task SendToMe(string user, string message)
    {
        await Clients.Caller.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendToOthers(string user, string message)
    {
        await Clients.Others.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendPingToOthers(string user)
    {
        await Clients.Others.SendAsync("Pingusers", user);
    }
    }
}