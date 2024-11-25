using miki_practice_api.Hubs;
using miki_practice_api.Services;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;



namespace miki_practice_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<MikiService>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


            builder.Services.AddSingleton<OracleConnection>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("OracleDb"); 
                return new OracleConnection(connectionString); 
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger and Swagger UI for development.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Use HTTPS redirection for secure communication.
            app.UseHttpsRedirection();

            app.MapHub<DataHub>("/dataHub");


            // Map controllers to their corresponding routes.
            app.MapControllers();

            // Run the application.
            app.Run();


        }
    }
}
