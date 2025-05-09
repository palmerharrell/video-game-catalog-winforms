using HtmlAgilityPack;

namespace VideoGameCollection_WinForms.WebScrapers.WikipediaTest
{
    public class WikiScraper
    {
        public List<TestDataModel> GetTestData()
        {
            var testData = new List<TestDataModel>();
            var htmlDoc = new HtmlWeb().Load(url: "https://en.wikipedia.org/wiki/List_of_cities_by_GDP");
            var rows = htmlDoc.QuerySelectorAll("table tr");

            for (int i = 2; i < rows.Count; i++)
            {
                var cells = rows[i].QuerySelectorAll("td");

                if (cells.Count == 4)
                {
                    //var rank = cells[0].InnerText.Trim();
                    var metropolitanArea = cells[0].InnerText.Trim();
                    var country = cells[1].InnerText.Trim();
                    var gdpByBillionUsd = cells[2].InnerText.Trim();
                    var population = cells[3].InnerText.Trim();
                    //var gdpPerCapita = cells[5].InnerText.Trim();

                    testData.Add(new TestDataModel
                    {
                        //Rank = rank,
                        MetropolitanArea = metropolitanArea,
                        Country = country,
                        GdpByBillionUsd = gdpByBillionUsd,
                        Population = population,
                        //GdpPerCapita=gdpPerCapita
                    });
                }
            }

            return testData;
        }

    }
}
