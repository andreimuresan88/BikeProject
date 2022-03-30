using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class RegistrationTests : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\registrationInvalidData.csv" })]
        public void BasicResistration(string email, string firstName, string lastName, string password, string confPassword, string errorInput,
                                    string emailInputError, string firtnameInputError, string lastnameInputError, string passwordInputError, string confirmPasswordInputError)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);

            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.RegisterPage registerPage = new PageModels.RegisterPage(_driver);

            Assert.IsTrue(registerPage.GetNewAccountText());

            registerPage.Register(email, firstName, lastName, password, confPassword);

            Assert.AreEqual(errorInput, registerPage.GetInputErrorText());
            Assert.AreEqual(emailInputError, registerPage.GetEmailErrorText(emailInputError));
            Assert.AreEqual(firtnameInputError, registerPage.GetFirstNameErrorText(firtnameInputError));      
            Assert.AreEqual(lastnameInputError, registerPage.GetLastNameErrorText(lastnameInputError));
            Assert.AreEqual(passwordInputError, registerPage.GetPasswordErrorText(passwordInputError));
            Assert.AreEqual(confirmPasswordInputError, registerPage.GetConfirmPasswordErrorText(confirmPasswordInputError));

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }

        [Test, TestCaseSource(typeof(Utils), "GetCredentialsDataCsv", new object[] { "TestData\\registrationWithSameData.csv" })]
        public void BasicResistrationWithTheSameCredentials(string email, string firstName, string lastName, string password, string confPassword, string errorInput)
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.RegisterPage registerPage = new PageModels.RegisterPage(_driver);
            Assert.IsTrue(registerPage.GetNewAccountText());
            registerPage.Register(email, firstName, lastName, password, confPassword);
            Assert.AreEqual(errorInput, registerPage.GetSameEmailAddress());

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
