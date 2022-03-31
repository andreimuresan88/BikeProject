using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeProject.Tests
{
    class AddItemToFavorite : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\searchValidItemData.csv" })]
        public void BaseAddToFavorite(string item, string email, string password)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);

            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            landingPage.GoToLogInPage();

            PageModels.LoginPage loginPage = new PageModels.LoginPage(_driver);
            loginPage.Login(email, password);

            PageModels.SearchItem searchItem = new PageModels.SearchItem(_driver);
            searchItem.GetAnItem(item);

            PageModels.AddItemToFavorite addItemToFavorite = new PageModels.AddItemToFavorite(_driver);
            addItemToFavorite.AddProductToFavorite();

            Assert.IsTrue(addItemToFavorite.GetFavoriteLabelText());
        }
    }
}
