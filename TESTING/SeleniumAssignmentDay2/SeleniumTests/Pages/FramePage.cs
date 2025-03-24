//using OpenQA.Selenium;
//using SeleniumTests.Base;

//namespace SeleniumTests.Pages
//{
//    public class FramePage : BasePage
//    {
//        private readonly By IFrameLocator = By.Id("mce_0_ifr");
//        private readonly By EditorBody = By.TagName("body"); // Inside iframe, only body is editable

//        public FramePage(IWebDriver driver) : base(driver)
//        {
//            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
//        }

//        public void SwitchToEditorFrame()
//        {
//            IWebElement frameElement = _driver.FindElement(IFrameLocator);
//            _driver.SwitchTo().Frame(frameElement);
//        }

//        public void EnterTextInEditor(string text)
//        {
//            SwitchToEditorFrame();
//            var editor = _driver.FindElement(EditorBody);
//            editor.Clear();
//            editor.SendKeys(text);
//            _driver.SwitchTo().DefaultContent(); // Switch back to main page
//        }

//        public string GetEditorText()
//        {
//            SwitchToEditorFrame();
//            string text = _driver.FindElement(EditorBody).Text;
//            _driver.SwitchTo().DefaultContent(); // Switch back to main page
//            return text;
//        }
//    }
//}

using OpenQA.Selenium;
using SeleniumTests.Base;
using SeleniumTests.Utilities;

namespace SeleniumTests.Pages
{
    public class FramePage : BasePage
    {
        private readonly By IFrameLocator = By.Id("mce_0_ifr");
        private readonly By EditorBody = By.TagName("body"); // Inside iframe, only body is editable
        private readonly WaitHelper _waitHelper;

        public FramePage(IWebDriver driver) : base(driver)
        {
            _waitHelper = new WaitHelper(driver);
            NavigateTo("https://the-internet.herokuapp.com/iframe");
        }

        public void SwitchToEditorFrame()
        {
            try
            {
                IWebElement frameElement = _waitHelper.WaitForElementToBeVisible(IFrameLocator);
                _driver.SwitchTo().Frame(frameElement);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error: IFrame not found.");
            }
        }

        public void SwitchToMainContent()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void EnterTextInEditor(string text)
        {
            SwitchToEditorFrame();
            try
            {
                var editor = _waitHelper.WaitForElementToBeVisible(EditorBody);
                editor.Clear();
                editor.SendKeys(text);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error: Editor body not found.");
            }
            SwitchToMainContent();
        }

        public string GetEditorText()
        {
            SwitchToEditorFrame();
            string text = string.Empty;
            try
            {
                text = _waitHelper.WaitForElementToBeVisible(EditorBody).Text;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error: Unable to retrieve text from the editor.");
            }
            SwitchToMainContent();
            return text;
        }
    }
}

