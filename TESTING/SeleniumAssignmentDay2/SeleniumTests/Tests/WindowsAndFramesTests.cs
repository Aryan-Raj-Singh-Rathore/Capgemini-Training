using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class WindowsAndFramesTests
    {
        private IWebDriver _driver;
        private WindowsPage _windowsPage;
        private FramePage _framePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Initialize Page Objects
            _windowsPage = new WindowsPage(_driver);
            _framePage = new FramePage(_driver);
        }

        [Test]
        public void VerifyNewWindowOpensAndContainsText()
        {
            _windowsPage.ClickNewWindowLink();
            string windowText = _windowsPage.GetNewWindowText();

            Assert.That(windowText, Is.EqualTo("New Window"), "New window text is incorrect.");

            _windowsPage.CloseNewWindow();
        }

        [Test]
        public void VerifyTextEntryInIframe()
        {
            _framePage.SwitchToEditorFrame();
            _framePage.EnterTextInEditor("Hello, Selenium!");

            string editorText = _framePage.GetEditorText();
            Assert.That(editorText, Is.EqualTo("Hello, Selenium!"), "Text was not entered correctly.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
