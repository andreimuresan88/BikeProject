using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class AddItemToCartTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        //[TestCase("ion@ion.ro", "123", "casca")]
        [Test, TestCaseSource(typeof(Utils), "GetTestDataCsv", new object[] { "TestData\\searchValidItemData.csv" })]
        public void BaseAddToCart(string item, string email, string password)
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

            PageModels.AddItemToCart addItemToCart = new PageModels.AddItemToCart(_driver);
            addItemToCart.AddProductToCart();

            Assert.IsTrue(addItemToCart.GetOrder());
        }
    }
}
