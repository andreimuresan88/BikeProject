using OpenQA.Selenium;

namespace BikeProject.PageModels
{
    class LoginPage : BasePage
    {

        const string emailInputSelector = "_loginEmail";
        const string passwordInputSelector = "_loginPassword";
        const string loginButtonSelector = "doLogin";
        string credentialsErrorTextSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.register-form > form > span";
        string emailAfterLoginSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > div.account-info > ul > li:nth-child(3) > span";
        string emailLabelSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.register-form > form > div:nth-child(4) > label";
        string passwordLabelSelector = "#register-page > div > div.old-client-section.col-sm-5.pull-right > div > div.register-form > form > div:nth-child(5) > label";

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string EmailLabelSelector { get => emailLabelSelector; }
        public string PasswordLabelSelector { get => passwordLabelSelector; }
        public string CredentialsErrorTextSelector { get => credentialsErrorTextSelector; }
        public string EmailAfterLoginSelector { get => emailAfterLoginSelector; }

        public void Login(string email, string password)
        {
            var emailElement = driver.FindElement(By.Id(emailInputSelector));
            emailElement.Clear();
            emailElement.SendKeys(email);

            var passwordElement = driver.FindElement(By.Id(passwordInputSelector));
            passwordElement.Clear();
            passwordElement.SendKeys(password);

            var loginButtonElement = driver.FindElement(By.Id(loginButtonSelector));
            loginButtonElement.Submit();
        }
    }
}
