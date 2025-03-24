using OpenQA.Selenium;
using SeleniumTests.Base;

namespace SeleniumTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By UsernameField = By.Id("username");
        private readonly By PasswordField = By.Id("password");
        private readonly By LoginButton = By.CssSelector("button[type='submit']");
        private readonly By FlashMessage = By.Id("flash");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            NavigateTo("https://the-internet.herokuapp.com/login");
        }

        public void Login(string username, string password)
        {
            _driver.FindElement(UsernameField).SendKeys(username);
            _driver.FindElement(PasswordField).SendKeys(password);
            _driver.FindElement(LoginButton).Click();
        }

        public string GetFlashMessage()
        {
            return _driver.FindElement(FlashMessage).Text;
        }

        public string GetStatusMessage()
        {
            try
            {
                var statusElement = _driver.FindElement(By.Id("flash"));
                return statusElement.Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return "Status message not found";
            }
        }

    }
}

//using OpenQA.Selenium;

//namespace SeleniumTests.Pages
//{
//    public class LoginPage
//    {
//        private readonly IWebDriver _driver;
//        private readonly By UsernameField = By.Id("username");
//        private readonly By PasswordField = By.Id("password");
//        private readonly By LoginButton = By.CssSelector("button[type='submit']");
//        private readonly By StatusMessage = By.Id("flash"); // Status message locator

//        public LoginPage(IWebDriver driver)
//        {
//            _driver = driver;
//        }

//        public void Login(string username, string password)
//        {
//            _driver.FindElement(UsernameField).SendKeys(username);
//            _driver.FindElement(PasswordField).SendKeys(password);
//            _driver.FindElement(LoginButton).Click();
//        }

//        public string GetStatusMessage()
//        {
//            try
//            {
//                var statusElement = _driver.FindElement(StatusMessage);
//                return statusElement.Text.Trim();
//            }
//            catch (NoSuchElementException)
//            {
//                return "Status message not found";
//            }
//        }
//    }
//}
