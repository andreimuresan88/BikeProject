using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BikeProject.PageModels
{
    class RegisterPage : BasePage
    {
        const string newAccountLabelSelector = "#register-page > div > div.new-client-section.col-sm-7 > div.title-carousel > h1";
        const string loginLabelSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.title-carousel > h1"; 
        const string registerButtonSelector = "doRegister";//id
        const string emailInputSelector = "#__emailRegister";//id
        const string firstNameInputSelector = "__firstnameRegister";//id
        const string lastNameInputSelector = "__lastnameRegister";//id
        const string passwordInputSelector = "__passwordRegister";//id
        const string conformPasswordInputSelector = "__confirmPasswordRegister";//id
        const string termsCheckboxSelector = "agreePersonalInformation";//name
        const string submitButtonSelector = "doRegister";//id
        const string emailInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(1) > span";//css
        const string firstNameInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(3) > span";//css
        const string lastNameInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(2) > span";//css
        const string passwordInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(4) > span";//css
        const string confirmPasswordInputErrorSelector = "#_submitRegistration > div > div > div:nth-child(5) > span";//css
        const string errorInputSelector = "#_submitRegistration > div > p";//css
        const string emailAddressAlreadyExist = "#_submitRegistration > div > div > div:nth-child(1) > span";//css

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

            Thread.Sleep(1000);

            var emailElement = driver.FindElement(By.CssSelector(emailInputSelector));
            emailElement.SendKeys(email);

            Thread.Sleep(1000);

            var firstNameElement = driver.FindElement(By.Id(firstNameInputSelector));
            firstNameElement.SendKeys(firstName);

            Thread.Sleep(1000);

            var lastNameElement = driver.FindElement(By.Id(lastNameInputSelector));
            lastNameElement.SendKeys(lastName);

            Thread.Sleep(1000);

            var passwordElement = driver.FindElement(By.Id(passwordInputSelector));
            passwordElement.SendKeys(password);

            Thread.Sleep(1000);

            var conformPasswordElement = driver.FindElement(By.Id(conformPasswordInputSelector));
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
