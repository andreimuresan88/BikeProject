using OpenQA.Selenium;
using System.Threading;

namespace BikeProject.PageModels
{
    class RegisterPage : BasePage
    {
        const string newAccountLabelSelector = "#register-page > div > div.new-client-section.col-sm-7 > div.title-carousel > h1";
        const string loginLabelSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.title-carousel > h1"; 
        const string registerButtonSelector = "doRegister";
        const string emailInputSelector = "#__emailRegister";
        const string firstNameInputSelector = "__firstnameRegister";
        const string lastNameInputSelector = "__lastnameRegister";
        const string passwordInputSelector = "__passwordRegister";
        const string conformPasswordInputSelector = "__confirmPasswordRegister";
        const string termsCheckboxSelector = "agreePersonalInformation";
        const string submitButtonSelector = "doRegister";
        const string emailInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(1) > span";
        const string firstNameInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(3) > span";
        const string lastNameInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(2) > span";
        const string passwordInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(4) > span";
        const string confirmPasswordInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(5) > span";
        const string errorInputSelector = "#_submitRegistration > div > p";
        const string emailAddressAlreadyExist = "#_submitRegistration > div > div > div:nth-child(1) > span";

        public RegisterPage(IWebDriver driver) : base(driver)
        {

        }

        public bool GetNewAccountText()
        {
            var newAccountLabelElement = driver.FindElement(By.CssSelector(newAccountLabelSelector));
            return newAccountLabelElement.Displayed;
        }

        public bool GetLoginLabelText()
        {
            var loginLabelElement = driver.FindElement(By.CssSelector(loginLabelSelector));
            return loginLabelElement.Displayed;
        }

        public void Register(string email, string firstName, string lastName, string password, string confPassword)
        {
            var registerButtonElement = driver.FindElement(By.Id(registerButtonSelector));
            registerButtonElement.Click();

            var emailElement = Utils.WaitForElement(driver, 3, By.CssSelector(emailInputSelector));
            emailElement.SendKeys(email);

            var firstNameElement = Utils.WaitForFluentElement(driver, 1, By.Id(firstNameInputSelector));
            firstNameElement.SendKeys(firstName);

            var lastNameElement = Utils.WaitForFluentElement(driver, 1, By.Id(lastNameInputSelector));
            lastNameElement.SendKeys(lastName);

            var passwordElement = Utils.WaitForFluentElement(driver, 1, By.Id(passwordInputSelector));
            passwordElement.SendKeys(password);

            var conformPasswordElement = Utils.WaitForFluentElement(driver, 1, By.Id(conformPasswordInputSelector));
            conformPasswordElement.SendKeys(confPassword);

            var termsElement = driver.FindElement(By.Name(termsCheckboxSelector));
            termsElement.Click();

            var submitButtonElement = driver.FindElement(By.Id(submitButtonSelector));
            submitButtonElement.Submit();
        }

        public string GetInputErrorText()
        {
            var errorInputElement = driver.FindElement(By.CssSelector(errorInputSelector));
            return errorInputElement.Text;
        }

        public string GetSameEmailAddress()
        {
            var emailAddressAlreadyExistElement = driver.FindElement(By.CssSelector(emailAddressAlreadyExist));
            return emailAddressAlreadyExistElement.Text;
        }

        public string GetEmailErrorText(string expectedValue)
        {
            if (expectedValue == "") return "";

            var emailInputErrorElement = driver.FindElement(By.CssSelector(emailInputErrorSelector));
            return emailInputErrorElement.Text;
        }
        
        public string GetFirstNameErrorText(string expectedValue)
        {
            if (expectedValue == "") return "";

            var firstNameInputErrorElement = driver.FindElement(By.CssSelector(firstNameInputErrorSelector));
            return firstNameInputErrorElement.Text;
        }
        
        public string GetLastNameErrorText(string expectedValue)
        {
            if (expectedValue == "") return "";

            var lastNameInputErrorElement = driver.FindElement(By.CssSelector(lastNameInputErrorSelector));
            return lastNameInputErrorElement.Text;
        }
        
        public string GetPasswordErrorText(string expectedValue)
        {
            if (expectedValue == "") return "";

            var passwordInputErrorElement = driver.FindElement(By.CssSelector(passwordInputErrorSelector));
            return passwordInputErrorElement.Text;
        }
        
        public string GetConfirmPasswordErrorText(string expectedValue)
        {
            if (expectedValue == "") return "";

            var confirmPasswordErrorElement = driver.FindElement(By.CssSelector(confirmPasswordInputErrorSelector));
            return confirmPasswordErrorElement.Text;
        }
    }
}
