//using OpenQA.Selenium;

//namespace SeleniumTests.Pages
//{
//    public class DynamicLoadingExample1Page : DynamicLoadingPage
//    {
//        public DynamicLoadingExample1Page(IWebDriver driver) : base(driver)
//        {
//            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
//        }

//        public void WaitForHiddenElementToAppear()
//        {
//            WaitForLoadingToDisappear();
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTests.Pages
{
    public class DynamicLoadingExample1Page : DynamicLoadingPage
    {
        private readonly By HiddenElement = By.Id("finish"); // Adjust ID as per actual element
        private readonly WebDriverWait _wait;

        public DynamicLoadingExample1Page(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
        }

        public void WaitForHiddenElementToAppear()
        {
            try
            {
                WaitForLoadingToDisappear(); // Ensure loading indicator disappears

                _wait.Until(ExpectedConditions.ElementIsVisible(HiddenElement)); // Wait for hidden element
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error waiting for hidden element: {ex.Message}");
            }
        }
    }
}
