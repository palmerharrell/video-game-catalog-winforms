using System.Data;
using VideoGameCollection_WinForms.Repositories;
using VideoGameCollection_WinForms.Utilities;
using VideoGameCollection_WinForms.WebScraper;

namespace VideoGameCollection_WinForms
{
    public static class MainDebugger
    {
        public static void MainDebug()
        {
            // Test Code goes here
            DataTable games = GamesSqlRepo.GetGames();
            DataTable gameImages;
            string firstGameID = string.Empty;

            // Testing get from database (done, works)
            //if (games.Rows.Count > 0)
            //{
            //    firstGameID = games.AsEnumerable().FirstOrDefault()?["VGID"].ToString();
            //}

            // Image loading from disk/converting (done, works)
            //var imagePath = "C:\\PH\\workspace\\video_game_collection\\Test Images\\chrono trigger.jpg";
            //var byteArrayImageTest = ImageUtilities.GetByteArrayFromDiskImage(imagePath);
            //var imageFromByteArrayTest = ImageUtilities.ConvertByteArrayToImage(byteArrayImageTest);

            // Image INSERT byte[] or Image Data Types (done, works)
            //ImagesSqlRepo.InsertImage(2, byteArrayImageTest);
            //ImagesSqlRepo.InsertImage(22, imageFromByteArrayTest);

            // Display image from database on a form (done, works)
            //gameImages = ImagesSqlRepo.GetImagesByGame(2);
            //gameImages = ImagesSqlRepo.GetImagesByGame(22);
            //var testImage = ImageUtilities.ConvertByteArrayToImage(gameImages.AsEnumerable().FirstOrDefault()?["Image"] as byte[]);

            //using FormImageDisplay displayForm = new FormImageDisplay();
            //{
            //    displayForm.image = testImage;
            //    displayForm.ShowDialog();
            //}

            // Testing Web Scraper on a wiki page
            var scraper = new Scraper();
            var scraperTestData = scraper.GetTestData();

            var waitasec = true;
        }
    }
}
