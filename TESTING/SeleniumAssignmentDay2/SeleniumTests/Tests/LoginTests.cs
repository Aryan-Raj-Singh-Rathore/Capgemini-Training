using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class LoginTests : IDisposable
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        [TestCase("tomsmith", "SuperSecretPassword!", true, TestName = "Valid Login Test")]
        [TestCase("invalidUser", "SuperSecretPassword!", false, TestName = "Invalid Username Test")]
        [TestCase("tomsmith", "wrongpassword", false, TestName = "Invalid Password Test")]
        [TestCase("", "", false, TestName = "Empty Credentials Test")]
        public void TestLogin(string username, string password, bool isSuccessExpected)
        {
            if (_driver == null) Assert.Fail("WebDriver is not initialized.");

            _loginPage.Login(username, password);
            string message = _loginPage.GetStatusMessage();

            if (isSuccessExpected)
            {
                Assert.That(message, Does.Contain("You logged into a secure area!"), "Success message not displayed");
            }
            else
            {
                Assert.That(message, Does.Contain("Your username is invalid").Or.Contain("Your password is invalid"),
                    "Error message not displayed for invalid credentials");
            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        public void Dispose()
        {
            TearDown();
        }
    }
}
