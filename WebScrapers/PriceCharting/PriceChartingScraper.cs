using HtmlAgilityPack;

namespace VideoGameCollection_WinForms.WebScrapers.PriceCharting
{
    public class PriceChartingScraper
    {
        public PriceChartingGameData GetGameTitleAndPlatform(string upc)
        {
            var htmlDoc = new HtmlWeb().Load(url: $"https://www.pricecharting.com/search-products?type=videogames&q={upc.Trim()}");

            return new PriceChartingGameData
            {
                Title = htmlDoc.QuerySelector("[itemprop=\"name\"]").Attributes["content"].Value,
                Platform = htmlDoc.QuerySelector("[itemprop=\"gamePlatform\"]").Attributes["content"].Value
            };
        }
    }
}
