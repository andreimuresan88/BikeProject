using BikeProject.Utilities;
using BikeProjects.Tests;
using NUnit.Framework;

namespace BikeProject.Tests
{
    class LandingPageTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        [Test]
        public void BaseLandingPage()
        {
            _driver.Navigate().GoToUrl(url);
            PageModels.LandingPage landingPage = new PageModels.LandingPage(_driver);
            landingPage.AcceptCookie();
            Assert.IsTrue(landingPage.GetHomePageTextLabel());

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
        }
    }
}
