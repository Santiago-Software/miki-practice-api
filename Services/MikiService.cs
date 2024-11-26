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

        public List<MikiProducts> GetAll()
        {
            var records = new List<MikiProducts>(); 
            using (var connection =  new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, NAME, PRICE, STOCK FROM MIKI_TABLE"; 

                using (var command = new OracleCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //mapping the columns
                            //if needed change GetInt32 to GetInt64
                            records.Add(new MikiProducts
                                {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetInt32(2),
                                Stock = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return records; //a list where each row is a JSON
        }
    }
}
