using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;
using System;

namespace BikeProject.Tests
{
    class ProfilePageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\updateProfileMissingData.csv" })]
        public void BasicProfileUpdateWithMissingData(string email, string password, string newEmail, string newFirstname, string newLastname, string newPhone, string errorMessage)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.ProfilePage profilePage = new PageModels.ProfilePage(_driver);
            profilePage.UpdateProfile(newEmail, newFirstname, newLastname, newPhone);

            string emptyFieldSelector = profilePage.GetEmptyField(newEmail, newFirstname, newLastname, newPhone);

            Assert.AreEqual(errorMessage, Utils.GetTextFromPage(_driver, profilePage.ErrorInputMessageSelector));
            Assert.AreEqual(FrameworkConstants.red, Utils.GetLabelColor(_driver, emptyFieldSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\updateProfileInvalideData.csv" })]
        public void BasicProfileUpdateWithInvalidData(string email, string password, string newEmail, string newFirstname, string newLastname, string newPhone, string errorMessage, string invalidField)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.ProfilePage profilePage = new PageModels.ProfilePage(_driver);
            profilePage.UpdateProfile(newEmail, newFirstname, newLastname, newPhone);
            
            string errorLabelSelector = profilePage.GetInvalidField(newEmail, newFirstname, newLastname, newPhone, invalidField);

            Assert.AreEqual(errorMessage, Utils.GetTextFromPage(_driver, profilePage.ErrorInputMessageSelector));
            Assert.AreEqual(FrameworkConstants.red, Utils.GetLabelColor(_driver, errorLabelSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\updateProfileValideData.csv" })]
        public void BasicProfileUpdateWithValidData(string email, string password, string newEmail, string newFirstname, string newLastname, string newPhone, string message)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.ProfilePage profilePage = new PageModels.ProfilePage(_driver);
            profilePage.UpdateProfile(newEmail, newFirstname, newLastname, newPhone);

            Assert.AreEqual(message, Utils.GetTextFromPage(_driver, profilePage.ConfUpdateTextSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\changePasswordData.csv" })]
        public void BasicChangePassword(string email, string password, string oldPassword, string newPassword, string confirmPassword, string errorMessage, string invalidData)
        {
            _driver.Navigate().GoToUrl(url);

            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.ProfilePage profilePage = new PageModels.ProfilePage(_driver);
            profilePage.ChangePassword(oldPassword, newPassword, confirmPassword);

            string errorLabelSelector = profilePage.GetInvalidFieldChangePassword(oldPassword, newPassword, confirmPassword, invalidData);

            Assert.AreEqual(errorMessage, Utils.GetTextFromPage(_driver, profilePage.ErrorInputChangePasswordMessageSelector));
            Assert.AreEqual(FrameworkConstants.red, Utils.GetLabelColor(_driver, errorLabelSelector));
            Console.WriteLine(Utils.GetLabelColor(_driver, errorLabelSelector));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
