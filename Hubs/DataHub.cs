using Microsoft.AspNetCore.SignalR;

namespace miki_practice_api.Hubs
{
    public class DataHub : Hub
    {
        // Example method for broadcasting data to all connected clients
        public async Task BroadcastData(string data)
        {
            // Sends data to all connected clients
            await Clients.All.SendAsync("ReceiveData", data); // "ReceiveData" is the client-side method name.
        }
    }
}