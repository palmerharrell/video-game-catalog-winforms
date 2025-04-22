using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCollection_WinForms.Repositories;

namespace VideoGameCollection_WinForms
{
    public static class MainDebugger
    {
        public static void MainDebug()
        {
            // Test Code goes here

            // TODO: Research, setup, and test connection to network SQL Server database 

            GamesSqlRepo.GetGames();

            //try

            //{

            //    String str = "server=MUNESH-PC;database=windowapp;UID=sa;password=123";

            //    String query = "select * from data";

            //    SqlConnection con = new SqlConnection(str);

            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    DataSet ds = new DataSet();

            //    MessageBox.Show("connect with sql server");

            //    con.Close();

            //}

            //catch (Exception es)

            //{

            //    MessageBox.Show(es.Message);



            //}
        }
    }
}
