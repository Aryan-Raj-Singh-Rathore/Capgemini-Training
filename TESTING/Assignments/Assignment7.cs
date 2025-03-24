using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment7 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

                // JS Alert
                driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();
                Console.WriteLine("Alert Message: " + driver.SwitchTo().Alert().Text);
                driver.SwitchTo().Alert().Accept();

                // JS Confirm
                driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']")).Click();
                driver.SwitchTo().Alert().Dismiss();
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
