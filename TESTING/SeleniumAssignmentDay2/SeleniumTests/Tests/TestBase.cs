using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.IO;

namespace SeleniumTests
{
    public class TestBase
    {
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            string browser = TestContext.Parameters.Get("browser", "chrome"); // Default to Chrome

            _driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException("Unsupported browser")
            };

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
