using AvivaTestIanField.Base;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AvivaTestIanField.Pages
{
    public class GoogleHome : BasePage<GooglePageMap>, IGoogleHome
    {
        public GoogleHome() : base(@"http://www.google.co.uk/")
        {
            Navigate();
        }

        public void Search(string searchString)
        {
            Map.SearchBox.SendKeys(searchString);
            Map.SearchBox.Submit();
        }

        public int SearchResult()
        {
            var resultSTring = Map.SearchResult.Text.Replace(",", "");
            var numberString = Regex.Match(resultSTring, @"\d+").Value;
            return int.Parse(numberString);
        }

        public int LinkResultsNumber()
        {
            return Map.ResultsLinks().Count();
        }

        public string PrintLink(int linkNumber)
        {
            var listLinks = Map.ResultsLinks();
            string linkText = listLinks[linkNumber - 1].Text;
            Console.WriteLine(linkText);
            return linkText;
        }

        public bool NoResultsCheck()
        {
            return Map.NoSearchResults.Displayed;
        }
    }
}
