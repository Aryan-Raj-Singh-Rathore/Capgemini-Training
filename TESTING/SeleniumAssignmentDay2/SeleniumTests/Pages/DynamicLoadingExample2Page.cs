//using OpenQA.Selenium;

//namespace SeleniumTests.Pages
//{
//    public class DynamicLoadingExample2Page : DynamicLoadingPage
//    {
//        public DynamicLoadingExample2Page(IWebDriver driver) : base(driver)
//        {
//            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
//        }
//    }
//}


using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTests.Pages
{
    public class DynamicLoadingExample2Page : DynamicLoadingPage
    {
        private readonly By LoadedElement = By.Id("finish"); // Adjust ID as needed
        private readonly WebDriverWait _wait;

        public DynamicLoadingExample2Page(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
        }

        public void WaitForLoadedElement()
        {
            try
            {
                WaitForLoadingToDisappear(); // Ensure loading indicator disappears

                _wait.Until(ExpectedConditions.ElementIsVisible(LoadedElement)); // Wait for loaded element
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error waiting for loaded element: {ex.Message}");
            }
        }
    }
}
