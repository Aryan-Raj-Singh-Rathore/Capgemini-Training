//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using SeleniumTests.Base;
//using System;

//namespace SeleniumTests.Pages
//{
//    public class DropdownPage : BasePage
//    {
//        private readonly By Dropdown = By.Id("dropdown");

//        public DropdownPage(IWebDriver driver) : base(driver)
//        {
//            NavigateTo("https://the-internet.herokuapp.com/dropdown");
//        }

//        public void SelectOption(string option)
//        {
//            new SelectElement(_driver.FindElement(Dropdown)).SelectByText(option);
//        }

//        public string GetSelectedOption()
//        {
//            return new SelectElement(_driver.FindElement(Dropdown)).SelectedOption.Text;
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTests.Base;
using System;

namespace SeleniumTests.Pages
{
    public class DropdownPage : BasePage
    {
        private readonly By Dropdown = By.Id("dropdown");
        private readonly WebDriverWait _wait;

        public DropdownPage(IWebDriver driver) : base(driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            NavigateTo("https://the-internet.herokuapp.com/dropdown");
        }

        public void SelectOption(string option)
        {
            try
            {
                var dropdownElement = _wait.Until(ExpectedConditions.ElementIsVisible(Dropdown));
                var select = new SelectElement(dropdownElement);
                select.SelectByText(option);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting dropdown option '{option}': {ex.Message}");
            }
        }

        public string GetSelectedOption()
        {
            try
            {
                var dropdownElement = _wait.Until(ExpectedConditions.ElementIsVisible(Dropdown));
                var select = new SelectElement(dropdownElement);
                return select.SelectedOption.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting selected option: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
