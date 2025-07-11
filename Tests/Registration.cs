using System;
using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;


namespace GeneralStore.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]

    public class Registation
    {
        private AndroidDriver? driver;
        private MainPage? _login;
        private ProductsList? _productTitle;
        private WebDriverWait? wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var serverUrl = new Uri(Environment.GetEnvironmentVariable("APPIUM_SERVER_URL") ?? "http://localhost:4723");
            driver = new AndroidDriver(
                serverUrl,
                AppiumConfig.BuildAndroidOptions(),
                TimeSpan.FromSeconds(180));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _login = new MainPage(driver);
            _productTitle = new ProductsList(driver);
        }

        [Test]
        public void Registation_PositiveFlow_Female()
        {
            _login.SelectCountry("Ukraine");
            _login.EnterName("AutoTest");
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle.IsDisplayed, Is.True, "Product list title is not displayed");
        }

        [Test]
        public void Registation_PositiveFlow_Male()
        {
            _login.SelectCountry("Ukraine");
            _login.EnterName("AutoTest");
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle.IsDisplayed, Is.True, "Product list title is not displayed");
        }

        [Test]
        public void Registation_NegativeFlow_EmptyName()
        {
            _login.SelectCountry("Ukraine");
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();

            Assert.That(_login.IsDisplayedNameValidation, Is.True, "Name validation error is not displayed");
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
                TestContext.Progress.WriteLine($"Не удалось удалить приложение: {e.Message}");
            }
            finally
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }

    }

}