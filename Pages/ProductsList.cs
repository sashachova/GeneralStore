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

        public ProductsList(AndroidDriver driver) : base(driver) { }
         public bool IsDisplayed => WaitFor(_productTitle).Displayed;

    }
}