// using OpenQA.Selenium;
// using OpenQA.Selenium.Appium;
// using OpenQA.Selenium.Appium.Android;
// using OpenQA.Selenium.Support.UI;
// using System;
// using System.Drawing;
// using System.Threading;
// using OpenQA.Selenium.Appium.MultiTouch;
// using OpenQA.Selenium.Interactions;

// namespace GeneralStore
// {
//     public class OnboardingTest
//     {
//         private static AndroidDriver driver;

//         public static void Main(string[] args)
//         {
//             try
//             {
//                 // Setup desired capabilities
//                 AppiumOptions capabilities = new AppiumOptions();
//                 capabilities.AddAdditionalCapability("appium:deviceName", "OnePlus ONEPLUS A6000");
//                 capabilities.AddAdditionalCapability("appium:udid", "R58NA5CK9ME");
//                 capabilities.AddAdditionalCapability("platformName", "Android");
//                 capabilities.AddAdditionalCapability("appium:appPackage", "com.androidsample.generalstore");
//                 capabilities.AddAdditionalCapability("appium:appActivity", ".SplashActivity");
//                 capabilities.AddAdditionalCapability("appium:automationName", "UIAutomator2");

//                 // Initialize driver
//                 driver = new AndroidDriver(new Uri("http://localhost:4723/wd/hub"), capabilities);

//                 string currentPackage = driver.CurrentPackage;
//                 if (currentPackage.Equals("com.androidsample.generalstore"))
//                 {
//                     Console.WriteLine("Application has loaded successfully and the package is available");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Application failed and the package is not available");
//                     driver.Quit();
//                     return;
//                 }

//                 try
//                 {
//                     IWebElement bucket = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));
//                     Console.WriteLine("element with id 'com.androidsample.generalstore:id/splashscreen' is present");
//                 }
//                 catch (Exception e)
//                 {
//                     Console.WriteLine("element is not present");
//                 }

//                 // Finding all elements on the tab
//                 WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//                 IWebElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("com.androidsample.generalstore:id/toolbar_title")));
//                 IWebElement selectCountryText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Select the country where you want to shop\"]"));
//                 IWebElement yourNameText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Your Name\"]"));
//                 IWebElement genderText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Gender\"]"));
//                 IWebElement country = driver.FindElement(By.Id("android:id/text1"));
//                 IWebElement picture = driver.FindElement(By.XPath("//android.widget.ImageView"));
//                 IWebElement spinnerCountry = driver.FindElement(By.XPath("//android.widget.Spinner[@resource-id=\"com.androidsample.generalstore:id/spinnerCountry\"]"));
//                 IWebElement maleRadio = driver.FindElement(By.Id("com.androidsample.generalstore:id/radioMale"));
//                 IWebElement femaleRadio = driver.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale"));
//                 IWebElement inputName = driver.FindElement(By.Id("com.androidsample.generalstore:id/nameField"));
//                 IWebElement button = driver.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop"));
//                 IWebElement albania = driver.FindElement(By.XPath("(//android.widget.TextView[@resource-id='android:id/text1'])[1]"));

//                 Console.WriteLine("Checking property of the element find by ID");

//                 // Creating methods for verification
//                 VerifyElementProperties(title);
//                 VerifyTextProperties(selectCountryText);
//                 VerifyYourNameProperties(yourNameText);
//                 VerifyGenderProperties(genderText);
//                 VerifyCountryProperties(country);
//                 VerifyPictureProperties(picture);
//                 VerifySpinnerCountryProperties(spinnerCountry);
//                 VerifyMaleRadioProperties(maleRadio);
//                 VerifyFemaleRadioProperties(femaleRadio);
//                 VerifyInputProperties(inputName);
//                 driver.HideKeyboard();
//                 VerifyButtonProperties(button);

//                 ScrollDown();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Test execution failed: {ex.Message}");
//             }
//             finally
//             {
//                 driver?.Quit();
//             }
//         }

//         private static void VerifyElementProperties(IWebElement title)
//         {
//             // Check if Title is displayed
//             if (title.Displayed)
//             {
//                 Console.WriteLine("Title 'General store' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Title 'General store' is absent!!! on page");
//             }

//             // Check if Title is enabled
//             if (title.Enabled)
//             {
//                 Console.WriteLine("Title 'General store' is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Title 'General store' is not enable!!!");
//             }

//             // Check if the Title is clickable
//             string clickableAttribute = title.GetAttribute("clickable");
//             if ("false".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("Element is not clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is clickable!!!");
//             }

//             // Check if the Title is displayed
//             string displayedAttribute = title.GetAttribute("displayed");
//             if ("true".Equals(displayedAttribute))
//             {
//                 Console.WriteLine("Element is displayed");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is not displayed!!!");
//             }

//             // Check if the Title is focusable
//             string focusableAttribute = title.GetAttribute("focusable");
//             if ("false".Equals(focusableAttribute))
//             {
//                 Console.WriteLine("Element is not focusable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is focusable!!!");
//             }

//             // Check if the Title is focused
//             string focusedAttribute = title.GetAttribute("focused");
//             if ("false".Equals(focusedAttribute))
//             {
//                 Console.WriteLine("title is not focused");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is focused!!!");
//             }

//             // Check if the Title is scrollable
//             string scrollableAttribute = title.GetAttribute("scrollable");
//             if ("false".Equals(scrollableAttribute))
//             {
//                 Console.WriteLine("title is not scrollable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is scrollable!!!");
//             }

//             // Check if the Title is selected
//             string selectedAttribute = title.GetAttribute("selected");
//             if ("false".Equals(selectedAttribute))
//             {
//                 Console.WriteLine("title is not selected");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is selected!!!");
//             }

//             // Check if the Title's text is "General Store"
//             string expectedResultTitleText = "General Store";
//             string actualResultTitleText = title.Text;
//             if (actualResultTitleText.Equals(expectedResultTitleText))
//             {
//                 Console.WriteLine("Text 'General Store' is correct");
//                 Console.WriteLine($"Element text: {title.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'General Store' is not correct!!!");
//                 Console.WriteLine($"Element text: {title.Text}");
//             }
//         }

//         private static void VerifyTextProperties(AndroidElement selectCountryText)
//         {
//             // Check if selectCountryText is displayed
//             if (selectCountryText.Displayed)
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is absent!!! on page");
//             }

//             // Check if selectCountryText has text "Select the country where you want to shop"
//             string textAttribute = selectCountryText.GetAttribute("text");
//             if ("Select the country where you want to shop".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not correct!!!");
//             }

//             // Check if selectCountryText is enabled
//             if (selectCountryText.Enabled)
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not enable!!!!");
//             }

//             // Check if the selectCountryText is clickable
//             string clickableAttribute = selectCountryText.GetAttribute("clickable");
//             if ("false".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is not clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is clickable!!!");
//             }

//             // Additional attribute checks...
//             PerformStandardAttributeChecks(selectCountryText, "Select the country where you want to shop");

//             // Check if the Text is "Select the country where you want to shop"
//             string expectedResultText = "Select the country where you want to shop";
//             string actualResultText = selectCountryText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is correct");
//                 Console.WriteLine($"Element text: {selectCountryText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not correct!!!");
//                 Console.WriteLine($"Element text: {selectCountryText.Text}");
//             }
//         }

//         private static void VerifyYourNameProperties(AndroidElement yourNameText)
//         {
//             if (yourNameText.Displayed)
//             {
//                 Console.WriteLine("Text 'Your Name' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Your Name' is absent!!! on page");
//             }

//             string textAttribute = yourNameText.GetAttribute("text");
//             if ("Your Name".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Your Name' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Your Name' is not correct!!!");
//             }

//             PerformStandardAttributeChecks(yourNameText, "Your Name");

//             string expectedResultText = "Your Name";
//             string actualResultText = yourNameText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text is correct");
//                 Console.WriteLine($"Element text: {yourNameText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text is not correct!!!");
//                 Console.WriteLine($"Element text: {yourNameText.Text}");
//             }
//         }

//         private static void VerifyGenderProperties(AndroidElement genderText)
//         {
//             if (genderText.Displayed)
//             {
//                 Console.WriteLine("Text 'Gender' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is absent!!! on page");
//             }

//             string textAttribute = genderText.GetAttribute("text");
//             if ("Gender".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Gender' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is not correct!!!");
//             }

//             PerformStandardAttributeChecks(genderText, "Gender");

//             string expectedResultText = "Gender";
//             string actualResultText = genderText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text 'Gender' is correct");
//                 Console.WriteLine($"Element text: {genderText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is not correct!!!");
//                 Console.WriteLine($"Element text: {genderText.Text}");
//             }
//         }

//         private static void VerifyCountryProperties(AndroidElement country)
//         {
//             string countryTextByDefault = "Afghanistan";
//             string actualCountryText = country.Text;

//             if (actualCountryText.Equals(countryTextByDefault))
//             {
//                 Console.WriteLine("Country text by default is correct and equal 'Afghanistan' ");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! Country text by default is not correct!!! and equal {country.Text}");
//             }

//             if (country.Displayed)
//             {
//                 Console.WriteLine("Country 'Afghanistan' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Country 'Afghanistan' is absent!!! on page");
//             }

//             PerformStandardAttributeChecks(country, "Afghanistan");

//             string checkedAttribute = country.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("Country 'Afghanistan' is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Country 'Afghanistan' is checked!!!");
//             }
//         }

//         private static void VerifyPictureProperties(AndroidElement picture)
//         {
//             if (picture.Displayed)
//             {
//                 Console.WriteLine("Picture is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Picture is absent!!! on page");
//             }

//             if (picture.Enabled)
//             {
//                 Console.WriteLine("Picture is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Picture is not enable!!!!");
//             }

//             PerformStandardAttributeChecks(picture, "picture");

//             string checkedAttribute = picture.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("picture is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! picture is checked!!!");
//             }
//         }

//         private static void VerifyMaleRadioProperties(AndroidElement maleRadio)
//         {
//             if (maleRadio.Displayed)
//             {
//                 Console.WriteLine("male is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is absent!!! on page");
//             }

//             if (maleRadio.Enabled)
//             {
//                 Console.WriteLine("male is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not enable!!!!");
//             }

//             string clickableAttribute = maleRadio.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("male is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not clickable!!!");
//             }

//             string focusableAttribute = maleRadio.GetAttribute("focusable");
//             if ("true".Equals(focusableAttribute))
//             {
//                 Console.WriteLine("male is focusable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not focusable!!!");
//             }

//             string checkedAttribute = maleRadio.GetAttribute("checked");
//             if ("true".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("male picture is checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not checked!!!");
//             }

//             string checkableAttribute = maleRadio.GetAttribute("checkable");
//             if ("true".Equals(checkableAttribute))
//             {
//                 Console.WriteLine("male picture is checkable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not checkable!!!");
//             }
//         }

//         private static void VerifyFemaleRadioProperties(AndroidElement female)
//         {
//             string expectedFemaleRadioText = "Female";
//             string actualFemaleRadioText = female.Text;

//             if (actualFemaleRadioText.Equals(expectedFemaleRadioText))
//             {
//                 Console.WriteLine($"female text is correct and equal: {female.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! female text is not correct!!! and equal {female.Text}");
//             }

//             if (female.Displayed)
//             {
//                 Console.WriteLine("female is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is absent!!! on page");
//             }

//             string clickableAttribute = female.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("female is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is not clickable!!!");
//             }

//             string checkedAttribute = female.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("female picture is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is checked!!!");
//             }

//             string checkableAttribute = female.GetAttribute("checkable");
//             if ("true".Equals(checkableAttribute))
//             {
//                 Console.WriteLine("female picture is checkable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is not checkable!!!");
//             }

//             female.Click();

//             string checkedAttributeAfterTapping = female.GetAttribute("checked");
//             if ("true".Equals(checkedAttributeAfterTapping))
//             {
//                 Console.WriteLine("female is checked after tapping");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is NOT checked after tapping!!!");
//             }
//         }

//         private static void VerifyInputProperties(AndroidElement inputName)
//         {
//             string expectedPlaceholderText = "Enter name here";
//             string actualPlaceholderText = inputName.Text;

//             if (actualPlaceholderText.Equals(expectedPlaceholderText))
//             {
//                 Console.WriteLine($"placeholder text is correct and equal {inputName.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! placeholder text is not correct!!! and equal {inputName.Text}");
//             }

//             if (inputName.Displayed)
//             {
//                 Console.WriteLine("input is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is absent!!! on page");
//             }

//             if (inputName.Enabled)
//             {
//                 Console.WriteLine("input is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not enable!!!!");
//             }

//             string clickableAttribute = inputName.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("input is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not clickable!!!");
//             }

//             inputName.Click();

//             string focusedAttributeAfterTapping = inputName.GetAttribute("focused");
//             if ("true".Equals(focusedAttributeAfterTapping))
//             {
//                 Console.WriteLine("input is focused after tapping");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not focused after tapping!!!");
//             }

//             inputName.SendKeys("Ivan");

//             string expectedInputNameText = "Ivan";
//             string actualInputNameText = inputName.Text;

//             if (actualInputNameText.Equals(expectedInputNameText))
//             {
//                 Console.WriteLine($"name is correct and equal {inputName.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! name is not correct!!! and equal {inputName.Text}");
//             }
//         }

//         private static void VerifyButtonProperties(AndroidElement button)
//         {
//             string expectedButtonText = "Let's  Shop";
//             string actualButtonText = button.Text;

//             if (actualButtonText.Equals(expectedButtonText))
//             {
//                 Console.WriteLine($"button text is correct and equal {button.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! button text is not correct!!! and equal {button.Text}");
//             }

//             if (button.Displayed)
//             {
//                 Console.WriteLine("button is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is absent!!! on page");
//             }

//             if (button.Enabled)
//             {
//                 Console.WriteLine("button is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is not enable!!!");
//             }

//             string clickableAttribute = button.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("button is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is not clickable!!!");
//             }

//             PerformStandardAttributeChecks(button, "button");

//             button.Click();
//         }

//         private static void VerifySpinnerCountryProperties(AndroidElement spinnerCountry)
//         {
//             if (spinnerCountry.Enabled)
//             {
//                 Console.WriteLine("spinnerCountry is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not enable!!!!");
//             }

//             string clickableAttribute = spinnerCountry.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("spinnerCountry is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not clickable!!!");
//             }

//             string scrollableAttribute = spinnerCountry.GetAttribute("scrollable");
//             if ("true".Equals(scrollableAttribute))
//             {
//                 Console.WriteLine("spinnerCountry is scrollable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not scrollable!!!");
//             }

//             if (spinnerCountry.Displayed)
//             {
//                 Console.WriteLine("spinnerCountry is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is absent!!! on page");
//             }
//         }

//         private static void PerformStandardAttributeChecks(AndroidElement element, string elementName)
//         {
//             // Standard attribute checks that are repeated across methods
//             string displayedAttribute = element.GetAttribute("displayed");
//             if ("true".Equals(displayedAttribute))
//             {
//                 Console.WriteLine($"{elementName} is displayed");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! {elementName} is not displayed!!!");
//             }

//             string focusableAttribute = element.GetAttribute("focusable");
//             string focusedAttribute = element.GetAttribute("focused");
//             string scrollableAttribute = element.GetAttribute("scrollable");
//             string selectedAttribute = element.GetAttribute("selected");

//             // You can add more standard checks here as needed
//         }

//         private static void ScrollDown()
//         {
//             Size size = driver.Manage().Window.Size;
//             int startX = size.Width / 2;
//             int startY = (int)(size.Height * 0.80);
//             int endY = (int)(size.Height * 0.20);

//             Actions actions = new Actions(driver);
//             actions.ClickAndHold().MoveByOffset(0, startY - endY).Release().Perform();

            
//             TouchAction touchAction = new TouchAction(driver);
//             touchAction.Press(startX, startY)
//                       .WaitAction(500)
//                       .MoveTo(startX, endY)
//                       .Release()
//                       .Perform();
//             */

//             Thread.Sleep(500);
//         }
//     }
// }
// Selenium.Appium;
// using OpenQA.Selenium.Appium.Android;
// using OpenQA.Selenium.Support.UI;
// using System;
// using System.Drawing;
// using System.Threading;
// using OpenQA.Selenium.Appium.MultiTouch;
// using OpenQA.Selenium.Interactions;

// namespace GeneralStoreNew
// {
//     public class OnboardingTest
//     {
//         private static AndroidDriver<AndroidElement> driver;

//         public static void Main(string[] args)
//         {
//             try
//             {
//                 // Setup desired capabilities
//                 AppiumOptions capabilities = new AppiumOptions();
//                 capabilities.AddAdditionalCapability("appium:deviceName", "Galaxy A51");
//                 capabilities.AddAdditionalCapability("appium:udid", "R58NA5CK9ME");
//                 capabilities.AddAdditionalCapability("platformName", "Android");
//                 capabilities.AddAdditionalCapability("appium:appPackage", "com.androidsample.generalstore");
//                 capabilities.AddAdditionalCapability("appium:appActivity", ".SplashActivity");
//                 capabilities.AddAdditionalCapability("appium:automationName", "UIAutomator2");

//                 // Initialize driver
//                 driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), capabilities);

//                 string currentPackage = driver.CurrentPackage;
//                 if (currentPackage.Equals("com.androidsample.generalstore"))
//                 {
//                     Console.WriteLine("Application has loaded successfully and the package is available");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Application failed and the package is not available");
//                     driver.Quit();
//                     return;
//                 }

//                 try
//                 {
//                     AndroidElement bucket = driver.FindElement(By.Id("com.androidsample.generalstore:id/splashscreen"));
//                     Console.WriteLine("element with id 'com.androidsample.generalstore:id/splashscreen' is present");
//                 }
//                 catch (Exception e)
//                 {
//                     Console.WriteLine("element is not present");
//                 }

//                 // Finding all elements on the tab
//                 WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//                 AndroidElement title = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("com.androidsample.generalstore:id/toolbar_title")));
//                 AndroidElement selectCountryText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Select the country where you want to shop\"]"));
//                 AndroidElement yourNameText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Your Name\"]"));
//                 AndroidElement genderText = driver.FindElement(By.XPath("//android.widget.TextView[@text=\"Gender\"]"));
//                 AndroidElement country = driver.FindElement(By.Id("android:id/text1"));
//                 AndroidElement picture = driver.FindElement(By.XPath("//android.widget.ImageView"));
//                 AndroidElement spinnerCountry = driver.FindElement(By.XPath("//android.widget.Spinner[@resource-id=\"com.androidsample.generalstore:id/spinnerCountry\"]"));
//                 AndroidElement maleRadio = driver.FindElement(By.Id("com.androidsample.generalstore:id/radioMale"));
//                 AndroidElement femaleRadio = driver.FindElement(By.Id("com.androidsample.generalstore:id/radioFemale"));
//                 AndroidElement inputName = driver.FindElement(By.Id("com.androidsample.generalstore:id/nameField"));
//                 AndroidElement button = driver.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop"));
//                 AndroidElement albania = driver.FindElement(By.XPath("(//android.widget.TextView[@resource-id='android:id/text1'])[1]"));

//                 Console.WriteLine("Checking property of the element find by ID");

//                 // Creating methods for verification
//                 VerifyElementProperties(title);
//                 VerifyTextProperties(selectCountryText);
//                 VerifyYourNameProperties(yourNameText);
//                 VerifyGenderProperties(genderText);
//                 VerifyCountryProperties(country);
//                 VerifyPictureProperties(picture);
//                 VerifySpinnerCountryProperties(spinnerCountry);
//                 VerifyMaleRadioProperties(maleRadio);
//                 VerifyFemaleRadioProperties(femaleRadio);
//                 VerifyInputProperties(inputName);
//                 driver.HideKeyboard();
//                 VerifyButtonProperties(button);

//                 ScrollDown();
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Test execution failed: {ex.Message}");
//             }
//             finally
//             {
//                 driver?.Quit();
//             }
//         }

//         private static void VerifyElementProperties(AndroidElement title)
//         {
//             // Check if Title is displayed
//             if (title.Displayed)
//             {
//                 Console.WriteLine("Title 'General store' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Title 'General store' is absent!!! on page");
//             }

//             // Check if Title is enabled
//             if (title.Enabled)
//             {
//                 Console.WriteLine("Title 'General store' is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Title 'General store' is not enable!!!");
//             }

//             // Check if the Title is clickable
//             string clickableAttribute = title.GetAttribute("clickable");
//             if ("false".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("Element is not clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is clickable!!!");
//             }

//             // Check if the Title is displayed
//             string displayedAttribute = title.GetAttribute("displayed");
//             if ("true".Equals(displayedAttribute))
//             {
//                 Console.WriteLine("Element is displayed");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is not displayed!!!");
//             }

//             // Check if the Title is focusable
//             string focusableAttribute = title.GetAttribute("focusable");
//             if ("false".Equals(focusableAttribute))
//             {
//                 Console.WriteLine("Element is not focusable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Element is focusable!!!");
//             }

//             // Check if the Title is focused
//             string focusedAttribute = title.GetAttribute("focused");
//             if ("false".Equals(focusedAttribute))
//             {
//                 Console.WriteLine("title is not focused");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is focused!!!");
//             }

//             // Check if the Title is scrollable
//             string scrollableAttribute = title.GetAttribute("scrollable");
//             if ("false".Equals(scrollableAttribute))
//             {
//                 Console.WriteLine("title is not scrollable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is scrollable!!!");
//             }

//             // Check if the Title is selected
//             string selectedAttribute = title.GetAttribute("selected");
//             if ("false".Equals(selectedAttribute))
//             {
//                 Console.WriteLine("title is not selected");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! title is selected!!!");
//             }

//             // Check if the Title's text is "General Store"
//             string expectedResultTitleText = "General Store";
//             string actualResultTitleText = title.Text;
//             if (actualResultTitleText.Equals(expectedResultTitleText))
//             {
//                 Console.WriteLine("Text 'General Store' is correct");
//                 Console.WriteLine($"Element text: {title.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'General Store' is not correct!!!");
//                 Console.WriteLine($"Element text: {title.Text}");
//             }
//         }

//         private static void VerifyTextProperties(AndroidElement selectCountryText)
//         {
//             // Check if selectCountryText is displayed
//             if (selectCountryText.Displayed)
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is absent!!! on page");
//             }

//             // Check if selectCountryText has text "Select the country where you want to shop"
//             string textAttribute = selectCountryText.GetAttribute("text");
//             if ("Select the country where you want to shop".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not correct!!!");
//             }

//             // Check if selectCountryText is enabled
//             if (selectCountryText.Enabled)
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not enable!!!!");
//             }

//             // Check if the selectCountryText is clickable
//             string clickableAttribute = selectCountryText.GetAttribute("clickable");
//             if ("false".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is not clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is clickable!!!");
//             }

//             // Additional attribute checks...
//             PerformStandardAttributeChecks(selectCountryText, "Select the country where you want to shop");

//             // Check if the Text is "Select the country where you want to shop"
//             string expectedResultText = "Select the country where you want to shop";
//             string actualResultText = selectCountryText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text 'Select the country where you want to shop' is correct");
//                 Console.WriteLine($"Element text: {selectCountryText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Select the country where you want to shop' is not correct!!!");
//                 Console.WriteLine($"Element text: {selectCountryText.Text}");
//             }
//         }

//         private static void VerifyYourNameProperties(AndroidElement yourNameText)
//         {
//             if (yourNameText.Displayed)
//             {
//                 Console.WriteLine("Text 'Your Name' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Your Name' is absent!!! on page");
//             }

//             string textAttribute = yourNameText.GetAttribute("text");
//             if ("Your Name".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Your Name' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Your Name' is not correct!!!");
//             }

//             PerformStandardAttributeChecks(yourNameText, "Your Name");

//             string expectedResultText = "Your Name";
//             string actualResultText = yourNameText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text is correct");
//                 Console.WriteLine($"Element text: {yourNameText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text is not correct!!!");
//                 Console.WriteLine($"Element text: {yourNameText.Text}");
//             }
//         }

//         private static void VerifyGenderProperties(AndroidElement genderText)
//         {
//             if (genderText.Displayed)
//             {
//                 Console.WriteLine("Text 'Gender' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is absent!!! on page");
//             }

//             string textAttribute = genderText.GetAttribute("text");
//             if ("Gender".Equals(textAttribute))
//             {
//                 Console.WriteLine("Text 'Gender' is correct");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is not correct!!!");
//             }

//             PerformStandardAttributeChecks(genderText, "Gender");

//             string expectedResultText = "Gender";
//             string actualResultText = genderText.Text;
//             if (actualResultText.Equals(expectedResultText))
//             {
//                 Console.WriteLine("Text 'Gender' is correct");
//                 Console.WriteLine($"Element text: {genderText.Text}");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Text 'Gender' is not correct!!!");
//                 Console.WriteLine($"Element text: {genderText.Text}");
//             }
//         }

//         private static void VerifyCountryProperties(AndroidElement country)
//         {
//             string countryTextByDefault = "Afghanistan";
//             string actualCountryText = country.Text;

//             if (actualCountryText.Equals(countryTextByDefault))
//             {
//                 Console.WriteLine("Country text by default is correct and equal 'Afghanistan' ");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! Country text by default is not correct!!! and equal {country.Text}");
//             }

//             if (country.Displayed)
//             {
//                 Console.WriteLine("Country 'Afghanistan' is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Country 'Afghanistan' is absent!!! on page");
//             }

//             PerformStandardAttributeChecks(country, "Afghanistan");

//             string checkedAttribute = country.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("Country 'Afghanistan' is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Country 'Afghanistan' is checked!!!");
//             }
//         }

//         private static void VerifyPictureProperties(AndroidElement picture)
//         {
//             if (picture.Displayed)
//             {
//                 Console.WriteLine("Picture is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Picture is absent!!! on page");
//             }

//             if (picture.Enabled)
//             {
//                 Console.WriteLine("Picture is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! Picture is not enable!!!!");
//             }

//             PerformStandardAttributeChecks(picture, "picture");

//             string checkedAttribute = picture.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("picture is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! picture is checked!!!");
//             }
//         }

//         private static void VerifyMaleRadioProperties(AndroidElement maleRadio)
//         {
//             if (maleRadio.Displayed)
//             {
//                 Console.WriteLine("male is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is absent!!! on page");
//             }

//             if (maleRadio.Enabled)
//             {
//                 Console.WriteLine("male is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not enable!!!!");
//             }

//             string clickableAttribute = maleRadio.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("male is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not clickable!!!");
//             }

//             string focusableAttribute = maleRadio.GetAttribute("focusable");
//             if ("true".Equals(focusableAttribute))
//             {
//                 Console.WriteLine("male is focusable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not focusable!!!");
//             }

//             string checkedAttribute = maleRadio.GetAttribute("checked");
//             if ("true".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("male picture is checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not checked!!!");
//             }

//             string checkableAttribute = maleRadio.GetAttribute("checkable");
//             if ("true".Equals(checkableAttribute))
//             {
//                 Console.WriteLine("male picture is checkable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! male is not checkable!!!");
//             }
//         }

//         private static void VerifyFemaleRadioProperties(AndroidElement female)
//         {
//             string expectedFemaleRadioText = "Female";
//             string actualFemaleRadioText = female.Text;

//             if (actualFemaleRadioText.Equals(expectedFemaleRadioText))
//             {
//                 Console.WriteLine($"female text is correct and equal: {female.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! female text is not correct!!! and equal {female.Text}");
//             }

//             if (female.Displayed)
//             {
//                 Console.WriteLine("female is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is absent!!! on page");
//             }

//             string clickableAttribute = female.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("female is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is not clickable!!!");
//             }

//             string checkedAttribute = female.GetAttribute("checked");
//             if ("false".Equals(checkedAttribute))
//             {
//                 Console.WriteLine("female picture is not checked");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is checked!!!");
//             }

//             string checkableAttribute = female.GetAttribute("checkable");
//             if ("true".Equals(checkableAttribute))
//             {
//                 Console.WriteLine("female picture is checkable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is not checkable!!!");
//             }

//             female.Click();

//             string checkedAttributeAfterTapping = female.GetAttribute("checked");
//             if ("true".Equals(checkedAttributeAfterTapping))
//             {
//                 Console.WriteLine("female is checked after tapping");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! female is NOT checked after tapping!!!");
//             }
//         }

//         private static void VerifyInputProperties(AndroidElement inputName)
//         {
//             string expectedPlaceholderText = "Enter name here";
//             string actualPlaceholderText = inputName.Text;

//             if (actualPlaceholderText.Equals(expectedPlaceholderText))
//             {
//                 Console.WriteLine($"placeholder text is correct and equal {inputName.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! placeholder text is not correct!!! and equal {inputName.Text}");
//             }

//             if (inputName.Displayed)
//             {
//                 Console.WriteLine("input is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is absent!!! on page");
//             }

//             if (inputName.Enabled)
//             {
//                 Console.WriteLine("input is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not enable!!!!");
//             }

//             string clickableAttribute = inputName.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("input is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not clickable!!!");
//             }

//             inputName.Click();

//             string focusedAttributeAfterTapping = inputName.GetAttribute("focused");
//             if ("true".Equals(focusedAttributeAfterTapping))
//             {
//                 Console.WriteLine("input is focused after tapping");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! input is not focused after tapping!!!");
//             }

//             inputName.SendKeys("Ivan");

//             string expectedInputNameText = "Ivan";
//             string actualInputNameText = inputName.Text;

//             if (actualInputNameText.Equals(expectedInputNameText))
//             {
//                 Console.WriteLine($"name is correct and equal {inputName.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! name is not correct!!! and equal {inputName.Text}");
//             }
//         }

//         private static void VerifyButtonProperties(AndroidElement button)
//         {
//             string expectedButtonText = "Let's  Shop";
//             string actualButtonText = button.Text;

//             if (actualButtonText.Equals(expectedButtonText))
//             {
//                 Console.WriteLine($"button text is correct and equal {button.Text}");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! button text is not correct!!! and equal {button.Text}");
//             }

//             if (button.Displayed)
//             {
//                 Console.WriteLine("button is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is absent!!! on page");
//             }

//             if (button.Enabled)
//             {
//                 Console.WriteLine("button is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is not enable!!!");
//             }

//             string clickableAttribute = button.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("button is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! button is not clickable!!!");
//             }

//             PerformStandardAttributeChecks(button, "button");

//             button.Click();
//         }

//         private static void VerifySpinnerCountryProperties(AndroidElement spinnerCountry)
//         {
//             if (spinnerCountry.Enabled)
//             {
//                 Console.WriteLine("spinnerCountry is enable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not enable!!!!");
//             }

//             string clickableAttribute = spinnerCountry.GetAttribute("clickable");
//             if ("true".Equals(clickableAttribute))
//             {
//                 Console.WriteLine("spinnerCountry is clickable.");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not clickable!!!");
//             }

//             string scrollableAttribute = spinnerCountry.GetAttribute("scrollable");
//             if ("true".Equals(scrollableAttribute))
//             {
//                 Console.WriteLine("spinnerCountry is scrollable");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is not scrollable!!!");
//             }

//             if (spinnerCountry.Displayed)
//             {
//                 Console.WriteLine("spinnerCountry is present on page");
//             }
//             else
//             {
//                 Console.WriteLine("TEST FAILED! spinnerCountry is absent!!! on page");
//             }
//         }

//         private static void PerformStandardAttributeChecks(AndroidElement element, string elementName)
//         {
//             // Standard attribute checks that are repeated across methods
//             string displayedAttribute = element.GetAttribute("displayed");
//             if ("true".Equals(displayedAttribute))
//             {
//                 Console.WriteLine($"{elementName} is displayed");
//             }
//             else
//             {
//                 Console.WriteLine($"TEST FAILED! {elementName} is not displayed!!!");
//             }

//             string focusableAttribute = element.GetAttribute("focusable");
//             string focusedAttribute = element.GetAttribute("focused");
//             string scrollableAttribute = element.GetAttribute("scrollable");
//             string selectedAttribute = element.GetAttribute("selected");

//             // You can add more standard checks here as needed
//         }

//         private static void ScrollDown()
//         {
//             Size size = driver.Manage().Window.Size;
//             int startX = size.Width / 2;
//             int startY = (int)(size.Height * 0.80);
//             int endY = (int)(size.Height * 0.20);

//             Actions actions = new Actions(driver);
//             actions.ClickAndHold().MoveByOffset(0, startY - endY).Release().Perform();

//             // Alternative approach using TouchAction (if available in your Appium version)
//             /*
//             TouchAction touchAction = new TouchAction(driver);
//             touchAction.Press(startX, startY)
//                       .WaitAction(500)
//                       .MoveTo(startX, endY)
//                       .Release()
//                       .Perform();
//             */

//             Thread.Sleep(500);
//         }
//     }
// }

