//using OpenQA.Selenium;
//using SeleniumTests.Utilities;

//namespace SeleniumTests.Pages
//{
//    public class DynamicLoadingPage
//    {
//        protected readonly IWebDriver? _driver;

//        protected readonly WaitHelper _waitHelper;

//        protected By StartButton = By.CssSelector("#start button");
//        protected By LoadingIndicator = By.Id("loading");
//        protected By ResultText = By.Id("finish");

//        public DynamicLoadingPage(IWebDriver driver)
//        {
//            _driver = driver;
//            _waitHelper = new WaitHelper(_driver);
//        }

//        public void ClickStartButton()
//        {
//            _waitHelper.WaitForElementToBeClickable(StartButton).Click();
//        }

//        public void WaitForLoadingToDisappear()
//        {
//            _waitHelper.WaitForElementToDisappear(LoadingIndicator);
//        }

//        public string GetLoadedText()
//        {
//            return _waitHelper.WaitForElementToBeVisible(ResultText).Text;
//        }
//    }
//}


using OpenQA.Selenium;
using SeleniumTests.Utilities;
using System;

namespace SeleniumTests.Pages
{
    public class DynamicLoadingPage
    {
        protected readonly IWebDriver _driver;
        protected readonly WaitHelper _waitHelper;

        protected readonly By StartButton = By.CssSelector("#start button");
        protected readonly By LoadingIndicator = By.Id("loading");
        protected readonly By ResultText = By.Id("finish");

        public DynamicLoadingPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver), "WebDriver instance cannot be null.");
            _waitHelper = new WaitHelper(_driver);
        }

        public void ClickStartButton()
        {
            try
            {
                Console.WriteLine("Waiting for the Start button to be clickable...");
                _waitHelper.WaitForElementToBeClickable(StartButton).Click();
                Console.WriteLine("Clicked Start button.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking Start button: {ex.Message}");
            }
        }

        public void WaitForLoadingToDisappear()
        {
            try
            {
                Console.WriteLine("Waiting for loading indicator to disappear...");
                _waitHelper.WaitForElementToDisappear(LoadingIndicator);
                Console.WriteLine("Loading indicator disappeared.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error waiting for loading indicator: {ex.Message}");
            }
        }

        public string GetLoadedText()
        {
            try
            {
                Console.WriteLine("Waiting for loaded text to appear...");
                var element = _waitHelper.WaitForElementToBeVisible(ResultText);
                Console.WriteLine($"Loaded text found: {element.Text}");
                return element.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving loaded text: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
