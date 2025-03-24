//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace SeleniumTests.Base
//{
//    public class BasePage
//    {
//        protected IWebDriver _driver;
//        protected WebDriverWait _wait;

//        public BasePage(IWebDriver driver)
//        {
//            _driver = driver ?? throw new ArgumentNullException(nameof(driver), "WebDriver instance is null.");
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
//        }

//        public void NavigateTo(string url)
//        {
//            if (!string.IsNullOrEmpty(url))
//            {
//                _driver.Navigate().GoToUrl(url);
//            }
//            else
//            {
//                throw new ArgumentException("URL cannot be null or empty", nameof(url));
//            }
//        }

//        public void TakeScreenshot(string testName)
//        {
//            try
//            {
//                if (_driver is ITakesScreenshot screenshotDriver)
//                {
//                    Screenshot screenshot = screenshotDriver.GetScreenshot();
//                    string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
//                    Directory.CreateDirectory(dir); // Ensure directory exists
//                    string filePath = Path.Combine(dir, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

//                    // Fix: Save screenshot using File.WriteAllBytes
//                    File.WriteAllBytes(filePath, screenshot.AsByteArray);

//                    Console.WriteLine($"Screenshot saved at: {filePath}");
//                }
//                else
//                {
//                    Console.WriteLine("Driver does not support taking screenshots.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Screenshot capture failed: {ex.Message}");
//            }
//        }


//        public void WaitForElementToBeVisible(By locator, int timeout = 10)
//        {
//            try
//            {
//                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
//                wait.Until(ExpectedConditions.ElementIsVisible(locator));
//            }
//            catch (WebDriverTimeoutException)
//            {
//                Console.WriteLine($"Timeout: Element {locator} not visible after {timeout} seconds.");
//            }
//        }

//        public void SwitchToWindow(int index)
//        {
//            try
//            {
//                var windowHandles = new List<string>(_driver.WindowHandles);
//                if (index >= 0 && index < windowHandles.Count)
//                {
//                    _driver.SwitchTo().Window(windowHandles[index]);
//                }
//                else
//                {
//                    Console.WriteLine($"Invalid window index: {index}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Failed to switch window: {ex.Message}");
//            }
//        }

//        public void SwitchToOriginalWindow()
//        {
//            try
//            {
//                if (_driver.WindowHandles.Count > 0)
//                {
//                    _driver.SwitchTo().Window(_driver.WindowHandles[0]);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Failed to switch to original window: {ex.Message}");
//            }
//        }

//        public void SwitchToFrame(string frameNameOrId)
//        {
//            try
//            {
//                if (!string.IsNullOrEmpty(frameNameOrId))
//                {
//                    _driver.SwitchTo().Frame(frameNameOrId);
//                }
//                else
//                {
//                    Console.WriteLine("Frame name or ID is null or empty.");
//                }
//            }
//            catch (NoSuchFrameException)
//            {
//                Console.WriteLine($"No such frame found: {frameNameOrId}");
//            }
//        }

//        public void SwitchToDefaultContent()
//        {
//            try
//            {
//                _driver.SwitchTo().DefaultContent();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Failed to switch to default content: {ex.Message}");
//            }
//        }
//    }
//}


using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace SeleniumTests.Base
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver), "WebDriver instance is null.");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                _driver.Navigate().GoToUrl(url);
            }
            else
            {
                throw new ArgumentException("URL cannot be null or empty", nameof(url));
            }
        }

        public void TakeScreenshot(string testName)
        {
            try
            {
                if (_driver is ITakesScreenshot screenshotDriver)
                {
                    Screenshot screenshot = screenshotDriver.GetScreenshot();

                    // Define screenshot directory
                    string screenshotDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                    Directory.CreateDirectory(screenshotDir); // Ensure directory exists

                    // Generate unique filename
                    string filePath = Path.Combine(screenshotDir, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                    // Save the screenshot (Fix: Use string format explicitly)
                    File.WriteAllBytes(filePath, screenshot.AsByteArray);


                    Console.WriteLine($"Screenshot saved at: {filePath}");
                }
                else
                {
                    Console.WriteLine("Error: WebDriver does not support screenshots.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Screenshot capture failed: {ex.Message}");
            }
        }


        public void WaitForElementToBeVisible(By locator, int timeout = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout: Element {locator} not visible after {timeout} seconds.");
            }
        }

        public void WaitForElementToBeClickable(By locator, int timeout = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout: Element {locator} not clickable after {timeout} seconds.");
            }
        }

        public void SwitchToWindow(int index)
        {
            try
            {
                var windowHandles = new List<string>(_driver.WindowHandles);
                if (index >= 0 && index < windowHandles.Count)
                {
                    _driver.SwitchTo().Window(windowHandles[index]);
                }
                else
                {
                    Console.WriteLine($"Invalid window index: {index}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to switch window: {ex.Message}");
            }
        }

        public void SwitchToOriginalWindow()
        {
            try
            {
                if (_driver.WindowHandles.Count > 0)
                {
                    _driver.SwitchTo().Window(_driver.WindowHandles[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to switch to original window: {ex.Message}");
            }
        }

        public void SwitchToFrame(string frameNameOrId)
        {
            try
            {
                if (!string.IsNullOrEmpty(frameNameOrId))
                {
                    _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameNameOrId));
                }
                else
                {
                    Console.WriteLine("Frame name or ID is null or empty.");
                }
            }
            catch (NoSuchFrameException)
            {
                Console.WriteLine($"No such frame found: {frameNameOrId}");
            }
        }

        public void SwitchToDefaultContent()
        {
            try
            {
                _driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to switch to default content: {ex.Message}");
            }
        }
    }
}