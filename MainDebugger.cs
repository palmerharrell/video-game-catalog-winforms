using System.Data;
using VideoGameCollection_WinForms.Repositories;
using VideoGameCollection_WinForms.Utilities;
using VideoGameCollection_WinForms.WebScrapers;
using VideoGameCollection_WinForms.WebScrapers.PriceCharting;

namespace VideoGameCollection_WinForms
{
    public static class MainDebugger
    {
        public static void MainDebug()
        {
            // Show/Enable btnDebug on FormMain to use this
            // Test Code goes here

            // pricecharting.com webscraping examples
            var webScraper = new PriceChartingScraper();

            // Lunar Knights - Nintendo DS (083717241133)
            var test1 = webScraper.GetGameTitleAndPlatform("083717241133");

            // New Super Mario Bros. U + New Super Luigi U - Wii U (045496903251)
            var test2 = webScraper.GetGameTitleAndPlatform("045496903251");
            
        }
    }
}
