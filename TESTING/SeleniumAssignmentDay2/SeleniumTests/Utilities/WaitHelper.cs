using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public IWebElement WaitForElementToBeVisible(By locator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitForElementToDisappear(By locator)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
