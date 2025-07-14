using System;
using System.Text.Json;
using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit;


namespace GeneralStore.Tests
{
    [TestFixture]
    [NonParallelizable]
    [AllureNUnit]

    public class Registation
    {
        //storing data case1:
        private const string DefaultUserName = "AutoTest";
        private AndroidDriver? driver;
        private MainPage? _login;
        private ProductsList? _productTitle;
        private TestData? testData;


        [SetUp]
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
            testData = LoadTestData("TestData.json");
        }
        //storing data case2:
        public static TestData LoadTestData(string path)
        {
            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TestData>(json, options) ?? new TestData();
        }

        [Test]
        public void Registration_PositiveFlow_Female()
        {
            var user = testData!.Users.First(u => u.Gender.ToLower() == "female");
            _login!.SelectCountry(user.Country);
            _login.EnterName(user.Name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle!.IsDisplayed, Is.True, "Product list title is not displayed");
        }
        [Test]
        public void Registration_PositiveFlow_Female_WithFaker()
        {
            string name = FakeDataGenerator.GenerateName();
            string country = FakeDataGenerator.GenerateCountry();
            _login!.SelectCountry(country);
            _login.EnterName(name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle!.IsDisplayed, Is.True, "Product list title is not displayed");
        }

        [Test]
        public void Registration_PositiveFlow_Male()
        {
            _login.SelectCountry("Albania");
            _login.EnterName(DefaultUserName);
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle.IsDisplayed, Is.True, "Product list title is not displayed");
        }

        [Test]
        public void Registration_NegativeFlow_EmptyName()
        {
            _login.SelectCountry("Albania");
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();

            Assert.That(_login.IsDisplayedNameValidation, Is.True, "Name validation error is not displayed");
        }
        [TearDown]
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