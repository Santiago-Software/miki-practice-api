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
    public class DatabaseNotifier : BackgroundService
    {
        private readonly IHubContext<DataHub> _hubContext;
        private readonly MikiService _mikiService;

        public DatabaseNotifier(IHubContext<DataHub> hubContext, MikiService mikiService)
        {
            _hubContext = hubContext;
            _mikiService = mikiService; 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var data = _mikiService.GetAll(); // Use MikiService to pull data from the database

                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", data);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

    }
    
}