using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment6 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

                // Submit without credentials
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                Console.WriteLine("Validation Message: " + driver.FindElement(By.Id("flash")).Text);

                // Enter invalid credentials
                driver.FindElement(By.Id("username")).SendKeys("invalid");
                driver.FindElement(By.Id("password")).SendKeys("invalid");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                // Capture and verify error message
                string errorMsg = driver.FindElement(By.Id("flash")).Text;
                Console.WriteLine("Error Message: " + errorMsg);
                if (errorMsg.Contains("invalid username"))
                {
                    Console.WriteLine("Error message verified successfully.");
                }
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
