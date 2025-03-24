using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAssignments
{
    class Assignment3 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

                IWebElement dropdownElement = driver.FindElement(By.Id("dropdown"));
                SelectElement dropdown = new SelectElement(dropdownElement);

                Console.WriteLine("Initially Selected: " + dropdown.SelectedOption.Text);

                dropdown.SelectByText("Option 1");
                Console.WriteLine("Selected: " + dropdown.SelectedOption.Text);

                dropdown.SelectByValue("2");
                Console.WriteLine("Selected: " + dropdown.SelectedOption.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                TearDown();
            }
        }
    }
}
