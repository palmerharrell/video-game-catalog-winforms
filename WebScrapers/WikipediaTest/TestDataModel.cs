﻿namespace VideoGameCollection_WinForms.WebScrapers.WikipediaTest
{
    // Data for table on this wiki page:
    // https://en.wikipedia.org/wiki/List_of_cities_by_GDP
    public class TestDataModel
    {
        public string Rank {  get; set; }
        public string MetropolitanArea { get; set; }
        public string Country { get; set; }
        public string GdpByBillionUsd { get; set; }
        public string Population { get; set; }
        public string GdpPerCapita { get; set; }
    }
}
