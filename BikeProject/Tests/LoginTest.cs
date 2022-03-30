using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class LoginTest : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\invalidLogin.csv" })]
        public void BasicLoginWithInvalidCredentials(string email, string password, string errorInput)
        {
            _driver.Navigate().GoToUrl(url);

            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            Assert.AreEqual(errorInput, Utils.GetTextFromPage(_driver, loginPage.CredentialsErrorTextSelector));
            Assert.AreEqual(FrameworkConstants.red, Utils.GetLabelColor(_driver, loginPage.PasswordLabelSelector));
            Assert.AreEqual(FrameworkConstants.red, Utils.GetLabelColor(_driver, loginPage.EmailLabelSelector));
            
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\validLogin.csv" })]
        public void BasicLoginWithValidCredentials(string email, string password, string emailAfterLogin)
        {
            _driver.Navigate().GoToUrl(url);
            
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage login = new PageModels.LoginPage(_driver);

            login.Login(email, password);
            Assert.AreEqual(emailAfterLogin, Utils.GetTextFromPage(_driver, login.EmailAfterLoginSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
