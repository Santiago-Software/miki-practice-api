using Oracle.ManagedDataAccess.Client;
using miki_practice_api.Models;
using System.Collections.Generic; //for list<T>

namespace miki_practice_api.Services
{
    // Service to handle database operations.
    public class MikiService
    {
        //Get the connection string 
        private readonly string connectionString;


        // Constructor to initialize the connection string.
        public MikiService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!; //"!" = The connection string is not null
        }

        public List<MikiModel> GetAll()
        {
            var records = new List<MikiModel>();
            using (var connection =  new OracleConnection(connectionString))
            {
                connection.Open();
            }
        }
    }
}
