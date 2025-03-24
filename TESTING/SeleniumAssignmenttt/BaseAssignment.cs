using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAssignments
{
    public class BaseAssignment
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public void Setup()
        {
            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during WebDriver setup: " + e.Message);
            }
        }

        public void TearDown()
        {
            try
            {
                driver?.Quit();
                driver?.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during WebDriver teardown: " + e.Message);
            }
        }
    }
}
