using OpenQA.Selenium;

namespace BikeProject.PageModels
{
    class AddItemToCart : BasePage
    {
        const string selectItemFromListSelector = "//*[@id='category-page']/div/div[3]/div[2]/div[1]/div[2]/div/div[1]/a/img";
        //const string addToCartButtonSelector = "#product-page > div.container-h.product-top.-g-product-16748 > div.row.-g-product-row-box > div.col-sm-6.detail-prod-attr.pull-right > div.add-section.clearfix.-g-product-add-section-16748 > a";
        //const string addToCartButtonSelector = "#product-page > div.container-h.product-top.-g-product-16748 > div.row.-g-product-row-box > div.col-sm-6.detail-prod-attr.pull-right > div.add-section.clearfix.-g-product-add-section-16748 > a";
        const string addToCartButtonSelector = "//*[@id='product-page']/div[1]/div[1]/div[3]/div[4]/a";
        const string cartButtonSelector = "#wrapper > header > div.top-head-bg.container-h.full > div > div > div.col-md-5.col-sm-5.acount-section > ul > li.cart-header-btn.cart > a > i";
        const string finishOrderButtonSelector = "#shoppingcart > a.btn.btn-cmd.center";

        public AddItemToCart(IWebDriver driver) : base(driver)
        {

        }
        public void AddProductToCart()
        {
            var selectItemFromListElement = driver.FindElement(By.XPath(selectItemFromListSelector));
            selectItemFromListElement.Click();

            //var addToCartButtonElement = Utils.WaitForFluentElement(driver, 3, By.CssSelector(addToCartButtonSelector));
            var addToCartButtonElement = Utils.WaitForElement(driver, 10, By.XPath(addToCartButtonSelector));
            addToCartButtonElement.Click();

            var cartButtonElement = Utils.WaitForElement(driver, 10, By.CssSelector(cartButtonSelector));
            cartButtonElement.Click();
        }

        public bool GetOrder()
        {
            var finishOrderButtonElement = driver.FindElement(By.CssSelector(finishOrderButtonSelector));
            return finishOrderButtonElement.Displayed;
        }
    }
}
