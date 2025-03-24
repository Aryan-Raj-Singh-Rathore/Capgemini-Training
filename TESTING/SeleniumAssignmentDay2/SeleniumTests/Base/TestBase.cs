//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace SeleniumTests.Base
//{
//    public class TestBase
//    {
//        protected IWebDriver _driver;

//        [SetUp]
//        public void Setup()
//        {
//            _driver = new ChromeDriver();
//            _driver.Manage().Window.Maximize();
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            if (_driver != null)
//            {
//                _driver.Quit();
//                _driver.Dispose();
//            }
//        }
//    }
//}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.Base
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Implicit wait

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Explicit wait instance
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                _driver?.Quit();
                _driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during driver teardown: {ex.Message}");
            }
        }
    }
}
