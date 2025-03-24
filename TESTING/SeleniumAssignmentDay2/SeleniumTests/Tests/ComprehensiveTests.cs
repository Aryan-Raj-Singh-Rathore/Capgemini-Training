using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Pages;
using System;
using System.IO;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class ComprehensiveTest : TestBase
    {
        [Test]
        public void VerifyFormAuthentication()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            // Enter valid credentials
            _driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            _driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verify login success message
            Assert.That(_driver.FindElement(By.Id("flash")).Text, Does.Contain("You logged into a secure area!"));
        }

        [Test]
        public void VerifyDropdownSelection()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

            // Select an option from dropdown
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("dropdown")));
            dropdown.SelectByText("Option 2");

            // Verify selected option
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 2"));
        }

        [Test]
        public void VerifyCheckboxSelection()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

            var checkboxes = _driver.FindElements(By.CssSelector("#checkboxes input"));

            // Ensure first checkbox is checked
            if (!checkboxes[0].Selected)
                checkboxes[0].Click();

            Assert.That(checkboxes[0].Selected, Is.True);
        }

        [Test]
        public void VerifyFileUpload()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");

            // Get test file path
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testfile.txt");

            // Create dummy file if not exists
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "Test file content.");

            // Upload file
            _driver.FindElement(By.Id("file-upload")).SendKeys(filePath);
            _driver.FindElement(By.Id("file-submit")).Click();

            // Verify uploaded file name appears
            Assert.That(_driver.FindElement(By.Id("uploaded-files")).Text, Does.Contain("testfile.txt"));
        }
    }
}
