using AvivaTestIanField.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AvivaTestIanField.Base
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;
            Browser.Manage().Window.Maximize();
            PageFactory.InitElements(Browser, this);
        }

        public void SwitchToDefault() => Browser.SwitchTo().DefaultContent();
    }
}
