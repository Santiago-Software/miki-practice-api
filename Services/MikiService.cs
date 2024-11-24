using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic; //for list<T>

namespace miki_practice_api.Services
{
    // Service to handle database operations.
    public class MikiService
    {
        //Get the connection string 
        private readonly string connectionString;

        public MikiService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!; //"!" = The connection string is not null
        }


    }
}
