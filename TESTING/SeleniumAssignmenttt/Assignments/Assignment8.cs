using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment8 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");

                driver.SwitchTo().Frame("mce_0_ifr");
                IWebElement editor = driver.FindElement(By.Id("tinymce"));
                editor.Clear();
                editor.SendKeys("This text was entered by Selenium automation");

                driver.SwitchTo().DefaultContent();
                Console.WriteLine("Switched back to main content.");
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
