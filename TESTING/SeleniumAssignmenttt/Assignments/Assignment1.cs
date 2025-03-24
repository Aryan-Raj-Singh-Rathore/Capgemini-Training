using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment1 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");

                Console.WriteLine("Page Title: " + driver.Title);

                IWebElement heading = driver.FindElement(By.TagName("h1"));
                Console.WriteLine("Heading Text: " + heading.Text);

                var links = driver.FindElements(By.TagName("a"));
                Console.WriteLine("Total example links: " + links.Count);
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
