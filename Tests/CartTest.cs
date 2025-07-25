using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Appium.Android;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using GeneralStore;
using Allure.Net.Commons;
using NUnit.Allure.Core;

namespace GeneralStore.Tests
{
    [Allure.NUnit.AllureNUnit]
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
            AllureLifecycle.Instance.WrapInStep(() => { _login.SelectCountry(country); }, "Select country: " + country);
            //_login.SelectCountry(country);
            _login.EnterName(name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            _productTitle.ClickAddToCartButton();
            Assert.That(_productTitle.ProductCounterIsDisplayed, Is.True, "Counter was not updated");
            //ADD GetCartItemCount method
            //Assert.That(_productTitle.GetCartItemCount(), Is.EqualTo(1), "Expected 1 product in cart");

        }
     
    }
    
}