using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using GeneralStore.Configs;
using OpenQA.Selenium.Appium;
using NUnit.Framework;

namespace GeneralStore.Pages
{
    public class ProductsList : DriverFactory
    {
        private readonly By _productTitle = By.Id("com.androidsample.generalstore:id/toolbar_title");
        private readonly By _cartButton = By.Id("com.androidsample.generalstore:id/appbar_btn_cart");
        private readonly By _addToCartButtons = By.XPath("//android.widget.TextView[@resource-id='com.androidsample.generalstore:id/productAddCart']");
        private readonly By _emptyCartWarning = By.XPath("(//android.widget.ImageView[@resource-id='com.androidsample.generalstore:id/productImage'])[3]");
        private readonly By _productCounter = By.Id("com.androidsample.generalstore:id/counterText");
        public ProductsList(AndroidDriver driver) : base(driver) { }
        public bool ProductTitleIsDisplayed => WaitFor(_productTitle).Displayed;
        public bool EmptyCartWarningIsDisplayed => WaitFor(_emptyCartWarning).Displayed;
        public bool ProductCounterIsDisplayed => WaitFor(_productCounter).Displayed;
        public void ClickCartButton()

        {
            WaitFor(_cartButton).Click();
        }
         public void ClickAddToCartButton()
    {
        var buttons = WaitForAll(_addToCartButtons);
        buttons.First().Click(); 
    }

    }
}