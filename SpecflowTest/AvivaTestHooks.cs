using AvivaTestIanField.Core;
using AvivaTestIanField.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;

namespace SpecflowTest
{
    [Binding]
    public sealed class AvivaTestHooks
    {

        public readonly UnityContainer Container = new UnityContainer();

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Container.RegisterType<IGoogleHome, GoogleHome>(new ContainerControlledLifetimeManager());
            Driver.StartBrowser(BrowserTypes.Chrome);
            Container.RegisterInstance<IWebDriver>(Driver.Browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.StopBrowser();
        }
    }
}
