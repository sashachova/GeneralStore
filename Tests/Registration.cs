// // 
// using System;
// using System.Text.Json;
// using GeneralStore.Configs;
// using GeneralStore.Pages;
// using NUnit.Framework;
// using NUnit.Framework.Internal;
// using OpenQA.Selenium.Appium.Android;
// using OpenQA.Selenium.Support.UI;
// using Allure.NUnit;
// using Allure.NUnit.Attributes;
// using OpenQA.Selenium.Interactions;
// using OpenQA.Selenium.Appium.Android.Enums;
// using OpenQA.Selenium.Appium.Interfaces;


// namespace GeneralStore.Tests
// {
//     [AllureNUnit]
//     [TestFixture]
//     [NonParallelizable]
    

//     public class Registation
//     {
//         //storing data case1:
//         private const string DefaultUserName = "AutoTest";
//         private AndroidDriver? driver;
//         private MainPage? _login;
//         private ProductsList? _productTitle;
//         private TestData? testData;

//         public void GoBack(AndroidDriver driver, string mode = "swipe")
//         {
//             if (mode.ToLower() == "swipe")
//             {
//                 var size = driver.Manage().Window.Size;

//                 int startX = (int)(size.Width * 0.05);
//                 int endX = (int)(size.Width * 0.7);
//                 int y = size.Height / 2;

//                 var finger = new PointerInputDevice(PointerKind.Touch);
//                 var swipe = new ActionSequence(finger, 0);

//                 swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, y, TimeSpan.Zero));
//                 swipe.AddAction(finger.CreatePointerDown(0));
//                 swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, endX, y, TimeSpan.FromMilliseconds(500)));
//                 swipe.AddAction(finger.CreatePointerUp(0));

//                 driver.PerformActions(new List<ActionSequence> { swipe });

//                 Thread.Sleep(5000);
//             }

//             else if (mode.ToLower() == "key")
//             {
//                 driver.PressKeyCode(AndroidKeyCode.Back);
//                 Thread.Sleep(1000);
//             }
//             else
//             {
//                 throw new ArgumentException("Mode must be either 'swipe' or 'key'.");
//             }
//         }
//         public void ScrollDown(AndroidDriver driver)
//         {
//             var size = driver.Manage().Window.Size;

//             int startX = size.Width / 2;
//             int startY = (int)(size.Height * 0.7);
//             int endY = (int)(size.Height * 0.3);

//             var finger = new PointerInputDevice(PointerKind.Touch);
//             var swipe = new ActionSequence(finger, 0);

//             swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, startY, TimeSpan.Zero));
//             swipe.AddAction(finger.CreatePointerDown(0));
//             swipe.AddAction(finger.CreatePointerMove(CoordinateOrigin.Viewport, startX, endY, TimeSpan.FromMilliseconds(600)));
//             swipe.AddAction(finger.CreatePointerUp(0));

//             driver.PerformActions(new List<ActionSequence> { swipe });

//             Thread.Sleep(3000);
//         }

//          public void CollapseAndResumeApp(AndroidDriver driver, int seconds = 5)

// {

//     const string packageName = "com.androidsample.generalstore";
 
   

//     if (driver.IsAppInstalled(packageName))

//     {

//         driver.TerminateApp(packageName);

//         Thread.Sleep(seconds * 1000); 
 
       

//         driver.ActivateApp(packageName);

//     }

//     else

//     {

//         throw new Exception("App is not installed: " + packageName);

//     }

// }
 
//         [OneTimeSetUp]
//         public void OneTimeSetUp()
//         {
//             var serverUrl = new Uri(Environment.GetEnvironmentVariable("APPIUM_SERVER_URL") ?? "http://localhost:4723");
//             driver = new AndroidDriver(
//                 serverUrl,
//                 AppiumConfig.BuildAndroidOptions(),
//                 TimeSpan.FromSeconds(180));

//             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
//             _login = new MainPage(driver);
//             _productTitle = new ProductsList(driver);
//             testData = LoadTestData("TestData.json");
//         }
//         //storing data case2:
//         public static TestData LoadTestData(string path)
//         {
//             var json = File.ReadAllText(path);
//             var options = new JsonSerializerOptions
//             {
//                 PropertyNameCaseInsensitive = true
//             };
//             return JsonSerializer.Deserialize<TestData>(json, options) ?? new TestData();
//         }

//         [Test]
//         [AllureTag("smoke")]
//         public void Registration_PositiveFlow_Female()
//         {
//             var user = testData!.Users.First(u => u.Gender.ToLower() == "female");
//             _login!.SelectCountry(user.Country);
//             _login.EnterName(user.Name);
//             _login.ClickRadioButtonFemale();
//             _login.ClickLetsShopButton();

//             Assert.That(_productTitle!.IsDisplayed, Is.True, "Product list title is not displayed");
//             CollapseAndResumeApp(driver, 5);
//         }
//         [Test]
//         public void Registration_PositiveFlow_Female_WithFaker()
//         {
//             string name = FakeDataGenerator.GenerateName();
//             string country = FakeDataGenerator.GenerateCountry();
//             _login!.SelectCountry(country);
//             _login.EnterName(name);
//             _login.ClickRadioButtonFemale();
//             _login.ClickLetsShopButton();

//             Assert.That(_productTitle!.IsDisplayed, Is.True, "Product list title is not displayed");
//             for (int i = 0; i < 3; i++)
// {
//     ScrollDown(driver);
// }
//         }

//         [Test]
//         public void Registration_PositiveFlow_Male()
//         {
//             _login.SelectCountry("Albania");
//             _login.EnterName(DefaultUserName);
//             _login.ClickRadioButtonMale();
//             _login.ClickLetsShopButton();

//             Assert.That(_productTitle.IsDisplayed, Is.True, "Product list title is not displayed");
//             GoBack(driver, "key");

//         }

//         [Test]
//         public void Registration_NegativeFlow_EmptyName()
//         {
//             _login.SelectCountry("Albania");
//             _login.ClickRadioButtonMale();
//             _login.ClickLetsShopButton();

//             Assert.That(_login.IsDisplayedNameValidation, Is.True, "Name validation error is not displayed");
//         }


//         [OneTimeTearDown]
//         public void OneTimeTearDown()

//         {
//             try
//             {
//                 driver?.RemoveApp("com.androidsample.generalstore");
//             }
//             catch (Exception e)
//             {
//                 TestContext.Progress.WriteLine($"Не удалось удалить приложение: {e.Message}");
//             }
//             finally
//             {
//                 driver?.Quit();
//                 driver?.Dispose();
//             }
//         }

//     }

// }
//
using System.Text.Json;
using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using System.IO;

namespace GeneralStore.Tests

{

    [AllureNUnit]
    [TestFixture]
    [NonParallelizable]

    public class Registration

    {
        private const string DefaultUserName = "AutoTest";
        private AndroidDriver? driver;
        private MainPage? _login;
        private ProductsList? _productTitle;
        private TestData? testData;
        private WebDriverWait Wait => new WebDriverWait(driver!, TimeSpan.FromSeconds(10));
        #region General methods
 
        public void GoBack(string mode = "swipe")
        {
            if (driver == null) throw new InvalidOperationException("Driver is not initialized.");
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
                Wait.Until(_ => true); 
            }
            else if (mode.ToLower() == "key")
            {
                driver.PressKeyCode(AndroidKeyCode.Back);
                Wait.Until(_ => true);
            }
            else
            {
                throw new ArgumentException("Mode must be either 'swipe' or 'key'.");
            }
        }
 
        public void ScrollDown()
        {
            if (driver == null) throw new InvalidOperationException("Driver is not initialized.");
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
            Wait.Until(_ => true);
        }
 
        public void CollapseAndResumeApp(int seconds = 5)
        {
            const string packageName = "com.androidsample.generalstore";
            if (driver == null) throw new InvalidOperationException("Driver is not initialized.");
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
 
        public static TestData LoadTestData(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Test data file not found: {path}");
            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<TestData>(json, options) ?? new TestData();
        }
 
        #endregion
 
        #region Setup and TearDown
        [OneTimeSetUp]
        public void OneTimeSetUp()

        {
            var serverUrl = new Uri(Environment.GetEnvironmentVariable("APPIUM_SERVER_URL") ?? "http://localhost:4723");
            driver = new AndroidDriver(serverUrl, AppiumConfig.BuildAndroidOptions(), TimeSpan.FromSeconds(180));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _login = new MainPage(driver);
            _productTitle = new ProductsList(driver);
            testData = LoadTestData("TestData.json");
        }

        // [OneTimeTearDown]
        // public void OneTimeTearDown()
        // {
        //     try
        //     {
        //         driver?.RemoveApp("com.androidsample.generalstore");
        //     }
        //     catch (Exception e)
        //     {
        //         TestContext.Progress.WriteLine($"Не удалось удалить приложение: {e.Message}");
        //     }
        //     finally
        //     {
        //         driver?.Quit();
        //         driver?.Dispose();
        //     }
        // }
     
 
[TearDown]
public void TakeScreenshotOnFailure()

{
    if (driver == null) return;
    var outcome = TestContext.CurrentContext.Result.Outcome.Status;
    if (outcome == TestStatus.Failed)

    {
        try
        {
            string testName = TestContext.CurrentContext.Test.Name;
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{testName}_{timestamp}.png";
            string screenshotDirectory = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
            if (!Directory.Exists(screenshotDirectory))
                Directory.CreateDirectory(screenshotDirectory);
            string filePath = Path.Combine(screenshotDirectory, fileName);
            var screenshot = driver.GetScreenshot();
            File.WriteAllBytes(filePath, screenshot.AsByteArray);
 
            TestContext.AddTestAttachment(filePath, "Screenshot on failure");
            Console.WriteLine($"📸 Screenshot saved: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error taking screenshot: {ex.Message}");
        }
    }
}
        #endregion
        #region Tests

        [Test]
        [AllureTag("smoke")]

        public void Registration_PositiveFlow_Female()
        {
            Assert.NotNull(_login);
            Assert.NotNull(_productTitle);
            Assert.NotNull(testData);
            var user = testData.Users.First(u => u.Gender.ToLower() == "female");
            _login.SelectCountry(user.Country);
            _login.EnterName(user.Name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();
            Assert.That(_productTitle.ProductTitleIsDisplayed, Is.True, "Product list title is not displayed");
            CollapseAndResumeApp();
        }
 
        [Test]

        public void Registration_PositiveFlow_Female_WithFaker()
        {
            Assert.NotNull(_login);
            Assert.NotNull(_productTitle);
            string name = FakeDataGenerator.GenerateName();
            string country = FakeDataGenerator.GenerateCountry();
            _login.SelectCountry(country);
            _login.EnterName(name);
            _login.ClickRadioButtonFemale();
            _login.ClickLetsShopButton();
 
            Assert.That(_productTitle.ProductTitleIsDisplayed, Is.True, "Product list title is not displayed");
            for (int i = 0; i < 3; i++)
                ScrollDown();
        }
 
        [Test]

        public void Registration_PositiveFlow_Male()

        {
            Assert.NotNull(_login);
            Assert.NotNull(_productTitle);
            _login.SelectCountry("Albania");
            _login.EnterName(DefaultUserName);
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();
            Assert.That(_productTitle.ProductTitleIsDisplayed, Is.True, "Product list title is not displayed");
            GoBack("key");

        }
 
        [Test]

        public void Registration_NegativeFlow_EmptyName()

        {
            Assert.NotNull(_login);
            _login.SelectCountry("Albania");
            _login.ClickRadioButtonMale();
            _login.ClickLetsShopButton();
            Assert.That(_login.IsDisplayedNameValidation, Is.True, "Name validation error is not displayed");
        }
 
        #endregion

    }

}

 