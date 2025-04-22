using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VideoGameCollection_WinForms.Repositories
{
    public class GamesSqlRepo
    {
        private const string _connectionString = "server=ORANGE;database=VideoGamesDB;Encrypt=false;UID=palmer;password=palmer";
        
        public GamesSqlRepo() { }

        public static void GetGames() //TODO: Return a DataTable, once I've figured out how to populate one
        {
            var queryString = $" SELECT * FROM GAMES ";
            QueryDatabase(queryString, _connectionString);
        }

        private static void QueryDatabase(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                var data = command.ExecuteReader(); // TODO: Look up how to use ExecuteReader properly and get rows into a DataTable
                var waitasec = true;
            }
        }
    }
}
