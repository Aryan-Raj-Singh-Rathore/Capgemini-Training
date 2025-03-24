//using OpenQA.Selenium;
//using SeleniumTests.Base;
//using System.Collections.Generic;

//namespace SeleniumTests.Pages
//{
//    public class CheckboxPage : BasePage
//    {
//        private readonly By Checkboxes = By.CssSelector("#checkboxes input");

//        public CheckboxPage(IWebDriver driver) : base(driver)
//        {
//            NavigateTo("https://the-internet.herokuapp.com/checkboxes");
//        }

//        public void ToggleCheckbox(int index)
//        {
//            var elements = _driver.FindElements(Checkboxes);
//            if (index >= 0 && index < elements.Count)
//            {
//                elements[index].Click();
//            }
//        }

//        public bool IsCheckboxSelected(int index)
//        {
//            var elements = _driver.FindElements(Checkboxes);
//            return elements[index].Selected;
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTests.Base;
using System;
using System.Collections.Generic;

namespace SeleniumTests.Pages
{
    public class CheckboxPage : BasePage
    {
        private readonly By Checkboxes = By.CssSelector("#checkboxes input");

        public CheckboxPage(IWebDriver driver) : base(driver)
        {
            NavigateTo("https://the-internet.herokuapp.com/checkboxes");
        }

        public void ToggleCheckbox(int index)
        {
            try
            {
                var elements = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Checkboxes));
                if (index >= 0 && index < elements.Count)
                {
                    elements[index].Click();
                }
                else
                {
                    Console.WriteLine($"Invalid checkbox index: {index}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error toggling checkbox: {ex.Message}");
            }
        }

        public bool IsCheckboxSelected(int index)
        {
            try
            {
                var elements = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Checkboxes));
                if (index >= 0 && index < elements.Count)
                {
                    return elements[index].Selected;
                }
                Console.WriteLine($"Invalid checkbox index: {index}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking checkbox selection: {ex.Message}");
            }
            return false;
        }
    }
}
