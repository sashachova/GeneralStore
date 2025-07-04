using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace GeneralStore.Tests
{
    [TestFixture]
    public class StartAppTest
    {
        private AndroidDriver? driver;
        private WebDriverWait? wait;

        [SetUp]
        public void SetUp()
        {
            var options = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UIAutomator2"
            };

            options.DeviceName = "OnePlus ONEPLUS A6000";
            options.AddAdditionalAppiumOption("appPackage", "com.androidsample.generalstore");
            options.AddAdditionalAppiumOption("appActivity", ".SplashActivity");

            driver = new AndroidDriver(new Uri("http://localhost:4723"), options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            Assert.That(driver.CurrentPackage, Is.EqualTo("com.androidsample.generalstore"),
                "Incorrect app package launched.");
        }

        [Test]
        public void VerifySplasElementIsNotNull()
        {
            var splashElement = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen")));
            Assert.That(splashElement, Is.Not.Null, "Splash screen element not found.");
            Console.WriteLine("Splash screen element found.");
        }

        [Test]
        public void VerifySplashElementIsNotClickable()
        {
            var splashElement = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen")));
            Assert.That(splashElement.GetAttribute("clickable"), Is.EqualTo("false"), "Splash element is clickable");
            Console.WriteLine("Splash element is not clickable");
        }

        [Test]
        public void VerifySplashElementIsEnabled()
        {
            var splashElement = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen")));
            Assert.That(splashElement.Enabled, Is.True, "Splash element is disabled");
            Console.WriteLine("Splash element is enabled");
        }
        //add test splash is displayed
        [Test]
        public void VerifySelectCountryText()
        {
            string expectedResultText = "Select the country where you want to shop";
            var selectCountryText = wait!.Until(d => d.FindElement(By.XPath("//android.widget.TextView[@text='Select the country where you want to shop']")));
            string actualResultText = selectCountryText.Text;
            Assert.That(expectedResultText, Is.EqualTo(actualResultText),"Text does not match the expected 'Select the country where you want to shop'");
            Console.WriteLine("Select country Text is correct");
        }
        [Test]
        public void VerifySelectCountryDefaultValue()
        {
            string expectedDefaultValue = "Afghanistan";
            var selectedCountryValue = wait!.Until(d => d.FindElement(By.Id("android:id/text1")));
            Assert.That(selectedCountryValue.Text, Is.EqualTo(expectedDefaultValue), "The default value is wrong");
            Console.WriteLine("Default value is correct: " + expectedDefaultValue);
        }
        [Test]
        public void VerifyCountryCouldBeSelected()
        {
            var selectCountryDropDown = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/spinnerCountry")));
            selectCountryDropDown.Click();
            var countryList = wait!.Until(d => d.FindElements(By.XPath("//android.widget.ListView")));

            // Scroll using UiScrollable to the element with text
            var element = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Ukraine\"));"));
            element.Click();
            var selectedCountryValue = wait!.Until(d => d.FindElement(By.Id("android:id/text1")));
            Assert.That(selectedCountryValue.Text, Is.EqualTo("Ukraine"), "Wrong country was selected");
            Console.WriteLine("The country is correct");
        }
        [Test]
        public void VerifyNameField_NameIsEntered()
        {
            string testName = "Sasha";
            var enterNameField = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));
            enterNameField.Click();
            enterNameField.SendKeys(testName);
            Assert.That(enterNameField.Text, Is.EqualTo(testName), "Name was not entered");
            Console.WriteLine("Name was entered");
        }
        [Test]
        public void SelectGender()
        {
            var radioButtonFemale = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale")));
            Console.WriteLine("Before click: " + radioButtonFemale.GetAttribute("checked"));
            radioButtonFemale.Click();
            Console.WriteLine("After click: " + radioButtonFemale.GetAttribute("checked"));
            Assert.That(radioButtonFemale.GetAttribute("checked"), Is.EqualTo("true"), "Female radio button is not selected");
            Console.WriteLine("Female radiobutton is selected");
        }
        [Test]
        public void LoginPositiveFlow()
        {
            //select country
            var selectCountryDropDown = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/spinnerCountry")));
            selectCountryDropDown.Click();
            var element = driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Ukraine\"));"));
            element.Click();

            var enterNameField = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));
            enterNameField.Click();
            enterNameField.SendKeys("testName");
           
            var radioButtonFemale = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale")));
            radioButtonFemale.Click();

            var letsShopButton = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop")));
            letsShopButton.Click();

            var productsPageTitle = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/toolbar_title")));
            Assert.That(productsPageTitle.Text, Is.EqualTo("Products"), "Products page title is not correct after clicking Let's Shop button.");
            Console.WriteLine("USER IS LOGGED IN");
        }
        [Test]

public void Login_Positive_Flow()

{

    const string userName = "TestUser";
    // Имя
    var nameField = wait!.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/nameField")));
    nameField.Clear();
    nameField.SendKeys(userName);
 
    // Скрываем клавиатуру
    if (driver!.IsKeyboardShown()) driver.HideKeyboard();
    var femaleRadio = wait.Until(d =>
    {
        var el = d.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale"));
        return (el.Displayed && el.Enabled) ? el : null;
    });
    femaleRadio.Click();

    // Кнопка Let's Shop
    var btnLetsShop = wait.Until(d =>
    {
        var el = d.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop"));
        return (el.Displayed && el.Enabled) ? el : null;
    });
    btnLetsShop.Click();
 
    // Проверяем заголовок Products
    var toolbar = wait.Until(d => d.FindElement(By.Id("com.androidsample.generalstore:id/toolbar_title")));
    Assert.That(toolbar.Text, Is.EqualTo("Products"),"После логина заголовок страницы неверен.");

}

        [Test]

        public void LogInToProductPage()

        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            _registrationForm.EnterName("Test User");

            _registrationForm.ClickLetsShopButton();
 
            Assert.Multiple(() =>

            {

                Assert.That(_registrationForm.ToolbarTitleDisplayed, Is.True, "Toolbar title is not displayed.");

                Assert.That(_registrationForm.ToolbarTitleEnabled, Is.True, "Toolbar title is not enabled.");

                Assert.That(_registrationForm.ToolbarTitleText, Is.EqualTo("Products"), "Toolbar title text is not correct.");
 
                Assert.That(_registrationForm.ToolbarTitleText, Is.EqualTo("Products"), "Products page title is not correct after clicking Let's Shop button.");
 
                Assert.That(_productPage.ParentIsNotNull, "У RecyclerView нет родительского элемента");
 
 
                Assert.That(_productPage.ProductElementsCount, Is.GreaterThan(0), "RecyclerView does not contain any items.");

                Console.WriteLine("Items found in RecyclerView: " + _productPage.ProductElementsCount);
 
 
                Console.WriteLine("Product items found in RecyclerView: " + _productPage.ProductItemsCount);

                Assert.That(_productPage.ProductItemsCount, Is.GreaterThan(0), "Product items are not displayed in the RecyclerView.");

            });

        }
 

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.Quit();
                driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during teardown: {ex.Message}");
            }
            finally
            {
                driver = null;
            }
        }
    }
}
