using System;
using System.Text.Json;
using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using GeneralStore;

namespace CartTest.Tests
{
    [AllureNUnit]
    [TestFixture]
    [NonParallelizable]

    public class CartTest
    {
        private AndroidDriver? driver;
        private MainPage? _login;
        private ProductsList? _productTitle;
        

        [OneTimeSetUp]
        public void OneTimeSetUp()

        {
            var serverUrl = new Uri(Environment.GetEnvironmentVariable("APPIUM_SERVER_URL") ?? "http://localhost:4723");
            driver = new AndroidDriver(serverUrl, AppiumConfig.BuildAndroidOptions(), TimeSpan.FromSeconds(180));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _login = new MainPage(driver);
            _productTitle = new ProductsList(driver);
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                driver?.RemoveApp("com.androidsample.generalstore");
            }
            catch (Exception e)
            {
                TestContext.Progress.WriteLine($"The app was not deleted: {e.Message}");
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }

        [Test]
        [AllureTag("smoke")]

        public void ProductIsAddedToTheCart()
        {
            Assert.NotNull(_login);
            Assert.NotNull(_productTitle);
            string name = FakeDataGenerator.GenerateName();
            string country = FakeDataGenerator.GenerateCountry();
            _login.SelectCountry(country);
            _login.EnterName(name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            _productTitle.ClickAddToCartButton();
            Assert.That(_productTitle.ProductCounterIsDisplayed, Is.True, "Counter was not updated");

        }
     
    }
    
}