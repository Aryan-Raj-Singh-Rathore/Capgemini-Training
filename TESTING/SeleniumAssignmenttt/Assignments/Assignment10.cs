using System;
using OpenQA.Selenium;

namespace SeleniumAssignments
{
    class Assignment10 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");

                IWebElement fileInput = driver.FindElement(By.Id("file-upload"));
                fileInput.SendKeys("C:\\path\\to\\your\\file.txt");

                driver.FindElement(By.Id("file-submit")).Click();

                IWebElement successMessage = driver.FindElement(By.Id("uploaded-files"));
                Console.WriteLine("File Uploaded: " + successMessage.Text);
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
