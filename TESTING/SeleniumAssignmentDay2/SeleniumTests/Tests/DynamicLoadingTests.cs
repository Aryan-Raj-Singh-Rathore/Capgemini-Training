using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class DynamicLoadingTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestDynamicLoadingExample1()
        {
            var page = new DynamicLoadingExample1Page(_driver);
            page.ClickStartButton();
            page.WaitForHiddenElementToAppear();
            string text = page.GetLoadedText();
            Assert.That(text, Is.EqualTo("Hello World!"), "Loaded text does not match expected output.");
        }

        [Test]
        public void TestDynamicLoadingExample2()
        {
            var page = new DynamicLoadingExample2Page(_driver);
            page.ClickStartButton();
            page.WaitForLoadingToDisappear();
            string text = page.GetLoadedText();
            Assert.That(text, Is.EqualTo("Hello World!"), "Loaded text does not match expected output.");
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void TestWithDifferentTimeouts(int timeout)
        {
            var page = new DynamicLoadingExample1Page(_driver);
            page.ClickStartButton();
            System.Threading.Thread.Sleep(timeout * 1000); // Simulating different timeout behavior
            string text = page.GetLoadedText();
            Assert.That(text, Is.EqualTo("Hello World!"), $"Test failed with {timeout} seconds timeout.");
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
