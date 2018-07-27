using AvivaTestIanField.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Unity;
using Logger;

namespace SpecflowTest
{
    [Binding]
    public sealed class AvivaTestSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        private GoogleHome googlePage;

        private readonly UnityContainer unityContainer = new UnityContainer();
        public AvivaTestSteps()
        {
             googlePage = unityContainer.Resolve<GoogleHome>();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchString)
        {
            googlePage.Search(searchString);
            Log.Message("Google Page search initialised for " + searchString);
        }

        [Given(@"I want to use the Google Search Engine")]
        public void GivenIWantToUseTheGoogleSearchEngine()
        {
            googlePage.Navigate();
            Log.Message("Google Search Page Loaded");
        }

        [Then(@"I expect a result greater than ""(.*)""")]
        public void ThenIExpectAResultGreaterThan(int expectedResultText)
        {
            if (googlePage.SearchResult() >= expectedResultText)
            {
                Log.Message("Google search returned greater than or equal to " + expectedResultText);
            }
            else
            {
                Log.Message("Google search returned less than " + expectedResultText);
                Assert.Fail();
            }
        }

        [Then(@"I print link ""(.*)""")]
        public void ThenIPrintLink(int linkNumber)
        {
            var linkText = googlePage.PrintLink(linkNumber);
            Log.Message("Link number " + linkNumber + " was " + linkText);
        }

        [Then(@"I expect a no search results returned")]
        public void ThenIExpectANoSearchResultsReturned()
        {
            if (googlePage.NoResultsCheck())
            {
                Log.Message("No Search results were returned as expected");
            }
            else
            {
                Log.Message("Search results were returned");
                Assert.Fail();
            }

        }

        [Then(@"I expect ""(.*)"" link results on the first page")]
        public void ThenIExpectLinkResultsOnTheFirstPage(int expectedLinkNumber)
        {
            if (googlePage.LinkResultsNumber() == expectedLinkNumber)
            {
                Log.Message("Expected Link results are as expected on the first page");
            }
            else
            {
                Log.Message("Expected Link results are not equal to " + expectedLinkNumber);
                Assert.Fail();
            }
        }


    }
}
