using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System.Collections.Generic;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class DataTablesTests
    {
        private IWebDriver? _driver;
        private DataTablesPage _dataTablesPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _dataTablesPage = new DataTablesPage(_driver);
        }

        [Test]
        public void VerifyInitialTableState()
        {
            List<List<string>> initialData = _dataTablesPage.GetAllTableData();
            Assert.IsNotEmpty(initialData, "Table data should not be empty initially.");
        }

        [Test]
        [TestCase(0, true)]  // First Name - Ascending
        [TestCase(0, false)] // First Name - Descending
        [TestCase(1, true)]  // Last Name - Ascending
        [TestCase(1, false)] // Last Name - Descending
        [TestCase(3, true)]  // Due Amount - Ascending
        [TestCase(3, false)] // Due Amount - Descending
        public void VerifySortingFunctionality(int columnIndex, bool ascending)
        {
            var dataTablesPage = new DataTablesPage(_driver);

            // Get initial column data (before sorting)
            var initialData = dataTablesPage.GetColumnData(columnIndex);
            Console.WriteLine("Before Sorting: " + string.Join(", ", initialData));

            // Click on the column header to sort
            dataTablesPage.ClickColumnHeader(columnIndex);

            // Get column data after clicking (sorted order)
            var sortedData = dataTablesPage.GetColumnData(columnIndex);
            Console.WriteLine("After Sorting: " + string.Join(", ", sortedData));

            // Validate sorting
            bool isSorted = dataTablesPage.IsColumnSorted(columnIndex, ascending);
            Assert.That(isSorted, Is.True, $"Column {columnIndex} was not sorted correctly in {(ascending ? "ascending" : "descending")} order.");
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
