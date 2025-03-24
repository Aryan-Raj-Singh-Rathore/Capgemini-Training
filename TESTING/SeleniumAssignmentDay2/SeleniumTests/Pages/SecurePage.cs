using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class SecurePage
    {
        private readonly IWebDriver _driver;

        // Constructor
        public SecurePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Element Locators
        private IWebElement LogoutButton => _driver.FindElement(By.CssSelector("a.button.secondary.radius"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("flash"));

        // Methods
        public string GetSuccessMessage() => SuccessMessage.Text;
        public void Logout() => LogoutButton.Click();
    }
}
