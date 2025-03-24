using OpenQA.Selenium;
using SeleniumTests.Base;
using System.Collections.Generic;

namespace SeleniumTests.Pages
{
    public class WindowsPage : BasePage
    {
        private readonly By ClickHereLink = By.LinkText("Click Here");
        private readonly By NewWindowText = By.TagName("h3");
        private string _originalWindowHandle; // Store the original window

        public WindowsPage(IWebDriver driver) : base(driver)
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            _originalWindowHandle = _driver.CurrentWindowHandle; // Store the original window handle
        }

        public void ClickNewWindowLink()
        {
            _driver.FindElement(ClickHereLink).Click();
        }

        public string GetNewWindowText()
        {
            SwitchToNewWindow(); // Switch to new window
            string text = _driver.FindElement(NewWindowText).Text;
            SwitchToOriginalWindow(); // Switch back
            return text;
        }

        public void CloseNewWindow()
        {
            SwitchToNewWindow(); // Switch to new window
            _driver.Close();
            SwitchToOriginalWindow(); // Return to main window
        }

        private void SwitchToNewWindow()
        {
            foreach (string handle in _driver.WindowHandles)
            {
                if (handle != _originalWindowHandle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        private void SwitchToOriginalWindow()
        {
            _driver.SwitchTo().Window(_originalWindowHandle);
        }
    }
}
