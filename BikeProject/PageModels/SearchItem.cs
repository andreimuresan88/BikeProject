using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeProject.PageModels
{
    class SearchItem : BasePage
    {
        const string searchInputSelector = "_autocompleteSearchMainHeader";
        const string searchButtonSelector = "_doSearch";
        string resultAfterSearchSelector = "#wrapper > div.container-h.container-bg.-g-breadcrumbs-container > div > ol > li:nth-child(2) > a";
        const string invalidSearchMessageSelector = "#result-page > h1";

        public string ResultAfterSearchSelector { get => resultAfterSearchSelector; set => resultAfterSearchSelector = value; }

        public SearchItem(IWebDriver driver) : base(driver)
        {
        }

        public void GetAnItem(string item)
        {
            var searchInputElement = driver.FindElement(By.Id(searchInputSelector));
            searchInputElement.Clear();
            searchInputElement.SendKeys(item);

            var searchButtonElement = driver.FindElement(By.Id(searchButtonSelector));
            searchButtonElement.Click();
        }

/*        public string GetResult()
        {
            var resultAfterSearchElement = driver.FindElement(By.CssSelector(ResultAfterSearchSelector));
            return resultAfterSearchElement.Text;
        }*/

        public bool GetInvalidResult()
        {
            var invalidSearchMessageElement = driver.FindElement(By.CssSelector(invalidSearchMessageSelector));
            return invalidSearchMessageElement.Displayed;
        }
    }
}
