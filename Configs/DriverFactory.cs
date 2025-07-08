using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace GeneralStore.Configs


{

    public abstract class DriverFactory

    {
        protected readonly AndroidDriver Driver;
        protected readonly WebDriverWait Wait;
        protected DriverFactory(AndroidDriver driver)
        {
            Driver = driver;
            Wait   = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
        protected IWebElement WaitFor(By locator) => Wait.Until(driver => driver.FindElement(locator));
 

    }

}
 