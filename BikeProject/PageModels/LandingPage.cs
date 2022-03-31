using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeProject.PageModels
{
    class LandingPage : BasePage
    {
        const string acceptCookieSelector = "__gomagCookiePolicy";
        const string homePageLabelSelector = "#wrapper > header > div.top-head-bg.container-h.full > div > div > div.col-md-5.col-sm-5.acount-section > ul > li.-g-user-icon > a > span";
        
        public LandingPage(IWebDriver driver) : base(driver)
        {

        }

        public void AcceptCookie()
        {
            driver.FindElement(By.Id(acceptCookieSelector)).Click();
        }

        public bool GetHomePageTextLabel()
        {
            var homePagelLabelElement = driver.FindElement(By.CssSelector(homePageLabelSelector));
            return homePagelLabelElement.Displayed;
        }

        public void GoToLogInPage()
        {
            driver.FindElement(By.CssSelector(homePageLabelSelector)).Click();
        }
    }
}
