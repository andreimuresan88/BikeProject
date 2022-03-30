using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class LogoutTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\validLogin.csv" })]
        public void BasicLogout(string email, string password, string emailText)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.LogoutPage logoutPage = new PageModels.LogoutPage(_driver);
            logoutPage.Logout();

            Assert.IsTrue(landingPage.GetHomePageTextLabel());

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
