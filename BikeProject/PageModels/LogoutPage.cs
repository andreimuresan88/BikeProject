using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeProject.PageModels
{
    class LogoutPage : BasePage
    {
        const string logoutButtonSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.side-menu.col-lg-3.col-md-3.col-sm-12.col-xs-12 > div.row > ul:nth-child(5) > li > a";

        public LogoutPage(IWebDriver driver) : base(driver)
        {

        }

        public void Logout()
        {
            var logoutButtonElement = driver.FindElement(By.CssSelector(logoutButtonSelector));
            logoutButtonElement.Click();
        }
    }
}
