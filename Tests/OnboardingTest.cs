using System;
using GeneralStore.Configs;
using GeneralStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace GeneralStore.Tests

{

    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]

    public class OnboardingTests

    {

        private AndroidDriver driver;

        private MainPage _splash;

        [OneTimeSetUp]

        public void OneTimeSetUp()

        {

            var serverUrl = new Uri(

                Environment.GetEnvironmentVariable("APPIUM_SERVER_URL")

                ?? "http://localhost:4723Í");

            driver = new AndroidDriver(

                serverUrl,

                AppiumConfig.BuildAndroidOptions(),

                TimeSpan.FromSeconds(180));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            _splash = new MainPage(driver);

        }

        [Test]

        public void SplashScreen_UI_basics()

        {

            Assert.Multiple(() =>

            {

                Assert.That(_splash.IsDisplayed, Is.True,  "Splash не отображается");

                Assert.That(_splash.IsEnabled,   Is.True,  "Splash не Enabled");

                Assert.That(_splash.IsClickable, Is.False, "Splash кликабелен");

                Assert.That(_splash.HasAnyText,  Is.False, "На Splash есть текст");

            });

        }

        [Test]

        public void NavigationBarBackground_visible_and_enabled()

        {

            Assert.Multiple(() =>

            {

                Assert.That(_splash.NavBarDisplayed, Is.True, "NavBarBackground не виден");

                Assert.That(_splash.NavBarEnabled,   Is.True, "NavBarBackground не Enabled");

            });

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
 