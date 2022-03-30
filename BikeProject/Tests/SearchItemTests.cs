using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class SearchItemTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\searchValidItemData.csv" })]
        public void BasicSearchItem(string item, string email, string password)
        {
            _driver.Navigate().GoToUrl(url);

            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.SearchItem searchItem = new PageModels.SearchItem(_driver);
            searchItem.GetAnItem(item);

            Assert.AreEqual("Cautare : " + "\"" + item + "\"", Utils.GetTextFromPage(_driver, searchItem.ResultAfterSearchSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\searchInvalidItemData.csv" })]
        public void BasicSearchInvalidItem(string item, string email, string password)
        {
            _driver.Navigate().GoToUrl(url);

            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.SearchItem searchItem = new PageModels.SearchItem(_driver);
            searchItem.GetAnItem(item);

            Assert.IsTrue(searchItem.GetInvalidResult());

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
