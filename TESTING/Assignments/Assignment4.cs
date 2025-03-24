using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment4 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://admin:admin@the-internet.herokuapp.com/basic_auth");
                IWebElement successMessage = driver.FindElement(By.TagName("p"));
                Console.WriteLine("Authentication Successful: " + successMessage.Text);
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
