using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace VideoGameCollection_WinForms.Repositories
{
    public class GamesSqlRepo : SqlRepository
    {   
        public GamesSqlRepo() { }

        public static DataTable GetGames()
        {
            var dataTable = new DataTable();
            var selectString = $" SELECT * FROM GAMES ";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlDataAdapter adapter = new SqlDataAdapter(selectString, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

    }
}
