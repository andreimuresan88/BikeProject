using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BikeProject.PageModels
{
    class AddItemToFavorite : BasePage
    {
        const string selectItemFromListSelector = "//*[@id='category-page']/div/div[3]/div[2]/div[1]/div[2]/div/div[1]/a/img";
        const string addToFavoriteSelector = "//*[@id='product-page']/div[1]/div[1]/div[3]/div[7]/a[1]/i";
        const string favoriteButtonSelector = "#wrapper > header > div.top-head-bg.container-h.full > div > div > div.col-md-5.col-sm-5.acount-section > ul > li.wishlist-header > a > span:nth-child(3)";
        const string wishlistLabelSelector = "#wrapper > div.account-h.container-h.container-bg > div > div.account-section.clearfix.col-lg-9.col-md-9.col-sm-12.col-xs-12 > h3";

        public AddItemToFavorite(IWebDriver driver) : base(driver)
        {

        }

        public void AddProductToFavorite()
        {
            var selectItemFromElement = driver.FindElement(By.XPath(selectItemFromListSelector));
            selectItemFromElement.Click();

            var addToFavoriteElement = Utils.WaitForElement(driver, 5, By.XPath(addToFavoriteSelector));
            addToFavoriteElement.Click();

            Thread.Sleep(5000);

            var favoriteButtonElement = Utils.WaitForElementClickable(driver, 5, By.CssSelector(favoriteButtonSelector));
            favoriteButtonElement.Click();
        }

        public bool GetFavoriteLabelText()
        {
            var wishlistLabelElement = driver.FindElement(By.CssSelector(wishlistLabelSelector));
            return wishlistLabelElement.Displayed;
        }
    }
}