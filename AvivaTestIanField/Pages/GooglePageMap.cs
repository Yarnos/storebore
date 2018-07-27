using AvivaTestIanField.Base;
using AvivaTestIanField.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvivaTestIanField.Pages
{
    public class GooglePageMap : BasePageElementMap
    {

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        public IWebElement SearchBox { get; set; }

        public IWebElement SearchResult
        {
            get
            {
                return Browser.FindElement(By.XPath("//div[@id='resultStats']"));
            }
        }

        public IWebElement NoSearchResults
        {
            get
            {
                return Browser.FindElement(By.XPath("//*[@id='topstuff']/div/div/p[1]"));
            }
        }

        public List<IWebElement> ResultsLinks()
        {
            WebDriverWait wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='rso']//h3/a")));
            return Driver.Browser.FindElements(By.XPath("//*[@id='rso']//h3/a")).ToList();
        }
    }
}
