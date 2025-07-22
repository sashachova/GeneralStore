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


namespace GeneralStore.Tests
{
    [AllureNUnit]
    [TestFixture]
    [NonParallelizable]
    

    public class Registation
    {
        //storing data case1:
        private const string DefaultUserName = "AutoTest";
        private AndroidDriver? driver;
        private MainPage? _login;
        private ProductsList? _productTitle;
        private TestData? testData;

        public void GoBack(AndroidDriver driver, string mode = "swipe")
        {
            if (mode.ToLower() == "swipe")
            {
                var size = driver.Manage().Window.Size;

                int startX = (int)(size.Width * 0.05);
                int endX = (int)(size.Width * 0.7);
                int y = size.Height / 2;

                var finger = new PointerInputDevice(PointerKind.Touch);
                var swipe = new ActionSequence(finger, 0);

                swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, y, TimeSpan.Zero));
                swipe.AddAction(finger.CreatePointerDown(0));
                swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endX, y, TimeSpan.FromMilliseconds(500)));
                swipe.AddAction(finger.CreatePointerUp(0));

                driver.PerformActions(new List<ActionSequence> { swipe });

                Thread.Sleep(5000);
            }

            else if (mode.ToLower() == "key")
            {
                driver.PressKeyCode(AndroidKeyCode.Back);
                Thread.Sleep(1000);
            }
            else
            {
                throw new ArgumentException("Mode must be either 'swipe' or 'key'.");
            }
        }
        public void ScrollDown(AndroidDriver driver)
        {
            var size = driver.Manage().Window.Size;

            int startX = size.Width / 2;
            int startY = (int)(size.Height * 0.7);
            int endY = (int)(size.Height * 0.3);

            var finger = new PointerInputDevice(PointerKind.Touch);
            var swipe = new ActionSequence(finger, 0);

            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, startY, TimeSpan.Zero));
            swipe.AddAction(finger.CreatePointerDown(0));
            swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, endY, TimeSpan.FromMilliseconds(600)));
            swipe.AddAction(finger.CreatePointerUp(0));

            driver.PerformActions(new List<ActionSequence> { swipe });

            Thread.Sleep(3000);
        }

         public void CollapseAndResumeApp(AndroidDriver driver, int seconds = 5)

{

    const string packageName = "com.androidsample.generalstore";
 
   

    if (driver.IsAppInstalled(packageName))

    {

        driver.TerminateApp(packageName);

        Thread.Sleep(seconds * 1000); 
 
       

        driver.ActivateApp(packageName);

    }

    else

    {

        throw new Exception("App is not installed: " + packageName);

    }

}
 
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
        [AllureTag("smoke")]
        public void Registration_PositiveFlow_Female()
        {
            var user = testData!.Users.First(u => u.Gender.ToLower() == "female");
            _login!.SelectCountry(user.Country);
            _login.EnterName(user.Name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle!.IsDisplayed, Is.True, "Product list title is not displayed");
            CollapseAndResumeApp(driver, 5);
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
            for (int i = 0; i < 3; i++)
{
    ScrollDown(driver);
}
        }

        [Test]
        public void Registration_PositiveFlow_Male()
        {
            _login.SelectCountry("Albania");
            _login.EnterName(DefaultUserName);
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();

            Assert.That(_productTitle.IsDisplayed, Is.True, "Product list title is not displayed");
            GoBack(driver, "key");

        }

        [Test]
        public void Registration_NegativeFlow_EmptyName()
        {
            _login.SelectCountry("Albania");
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