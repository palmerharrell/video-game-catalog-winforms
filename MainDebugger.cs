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
            string firstGameID = string.Empty;

            DataTable games = GamesSqlRepo.GetGames();
            DataTable gamePricing;
            DataTable gameImages;

            if (games.Rows.Count > 0)
            {
                firstGameID = games.AsEnumerable().FirstOrDefault()?["VGID"].ToString();
                //gamePricing = GamesSqlRepo.GetGamePrices(firstGameID); //TODO: implement GetGamePrices
                //gameImages = GamesSqlRepo.GetGameImages(firstGameID);  //TODO: implement GetGameImages
            }

            var waitasec = true;
        }
    }
}
