using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAssignments
{
    class Assignment5 : BaseAssignment
    {
        public void Run()
        {
            Setup();

            try
            {
                TestDynamicLoading("https://the-internet.herokuapp.com/dynamic_loading/1");
                TestDynamicLoading("https://the-internet.herokuapp.com/dynamic_loading/2");
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

        private void TestDynamicLoading(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.TagName("button")).Click();

            IWebElement helloWorld = wait.Until(d => d.FindElement(By.Id("finish")));
            Console.WriteLine("Loaded Text: " + helloWorld.Text);
        }
    }
}
