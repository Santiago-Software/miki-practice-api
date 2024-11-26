using Microsoft.AspNetCore.SignalR;

namespace miki_practice_api.Hubs
{
    public class DataHub : Hub
    {
        //doesn't need custom methods for server-initiated broadcast
        //No special methods required if you're just broadcasting
    }
}