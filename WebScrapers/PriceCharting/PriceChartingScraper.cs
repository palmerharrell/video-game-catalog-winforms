using HtmlAgilityPack;
using System.Net;

namespace VideoGameCollection_WinForms.WebScrapers.PriceCharting
{
    public class PriceChartingScraper
    {
        public PriceChartingGameData? GetGameDataByUPC(string upc)
        {
            var htmlDoc = new HtmlWeb().Load(url: $"https://www.pricecharting.com/search-products?type=videogames&q={upc.Trim()}");

            var title = htmlDoc.QuerySelector("[itemprop=\"name\"]")?.Attributes["content"].Value ?? string.Empty;

            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            var platform = htmlDoc.QuerySelector("[itemprop=\"gamePlatform\"]")?.Attributes["content"].Value ?? string.Empty;
            var genre = htmlDoc.QuerySelector("[itemprop=\"genre\"]")?.InnerText.Trim() ?? string.Empty;
            var releaseDate = htmlDoc.QuerySelector("[itemprop=\"datePublished\"]")?.InnerText.Trim() ?? string.Empty;
            var releaseYear = string.Empty;
            var developer = htmlDoc.QuerySelector("[itemprop=\"author\"]")?.InnerText.Trim() ?? string.Empty;
            var publisher = htmlDoc.QuerySelector("[itemprop=\"publisher\"]")?.InnerText.Trim() ?? string.Empty;
            var coverImageURL = htmlDoc.QuerySelector(".cover a img").Attributes["src"].Value.Replace("240.", "1600.") ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(releaseDate))
            {
                releaseYear = releaseDate.Substring(releaseDate.Length - 4);
            }

            return new PriceChartingGameData
            {
                Title = WebUtility.HtmlDecode(title),
                Platform = WebUtility.HtmlDecode(platform),
                Genre = WebUtility.HtmlDecode(genre),
                ReleaseYear = releaseYear,
                Developer = WebUtility.HtmlDecode(developer),
                Publisher = WebUtility.HtmlDecode(publisher),
                CoverImageURL = WebUtility.HtmlDecode(coverImageURL)
            };
        }
    }
}
