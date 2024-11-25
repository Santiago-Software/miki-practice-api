using Microsoft.Extensions.Hosting;  // For IHostedService
using Microsoft.AspNetCore.SignalR; // For SignalR
using miki_practice_api.Services; // For your MikiService
using miki_practice_api.Hubs; // For DataHub
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace miki_practice_api.BackgroundTasks
{
    public class DatabaseNotifier : BackgroundService, IDisposable
    {
        private readonly IHubContext<DataHub> _hubContext;
        private readonly MikiService _mikiService;
        private Timer _timer;

        public DatabaseNotifier(IHubContext<DataHub> hubContext, MikiService mikiService)
        {
            _hubContext = hubContext;
            _mikiService = mikiService; 
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(NotifyClients, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));  // Trigger every 30 seconds
            return Task.CompletedTask; // Returning a completed task
        }
        private async void NotifyClients(object state)
        {
            var data = _mikiService.GetAll(); // Get data from DB via MikiService
            await _hubContext.Clients.All.SendAsync("ReceiveData", data); // Send data to all connected clients
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);  // Stop the timer when the service is stopped
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose(); // Dispose the timer when the service is disposed
        }

    }
    
}