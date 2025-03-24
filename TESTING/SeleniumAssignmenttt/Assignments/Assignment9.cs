using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumAssignments
{
    class Assignment9 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");

                IWebElement boxA = driver.FindElement(By.Id("column-a"));
                IWebElement boxB = driver.FindElement(By.Id("column-b"));

                Actions actions = new Actions(driver);
                actions.DragAndDrop(boxA, boxB).Perform();

                Console.WriteLine("Drag and Drop performed successfully.");
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
