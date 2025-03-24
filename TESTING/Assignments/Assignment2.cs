using System;
using OpenQA.Selenium;
namespace SeleniumAssignments
{
    class Assignment2 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

                var checkboxes = driver.FindElements(By.CssSelector("input[type='checkbox']"));

                for (int i = 0; i < checkboxes.Count; i++)
                {
                    bool isChecked = checkboxes[i].Selected;
                    Console.WriteLine($"Checkbox {i + 1} is initially {(isChecked ? "checked" : "unchecked")}");

                    checkboxes[i].Click(); // Toggle state

                    Console.WriteLine($"Checkbox {i + 1} is now {(checkboxes[i].Selected ? "checked" : "unchecked")}");
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
