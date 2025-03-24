//using OpenQA.Selenium;
//using SeleniumTests.Utilities;
//using System.Collections.Generic;
//using System.Linq;

//namespace SeleniumTests.Pages
//{
//    public class DataTablesPage
//    {
//        private readonly IWebDriver _driver;
//        private readonly By TableHeaders = By.CssSelector("#table1 thead th");
//        private readonly By TableRows = By.CssSelector("#table1 tbody tr");

//        public DataTablesPage(IWebDriver driver)
//        {
//            _driver = driver;
//            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
//        }

//        public List<List<string>> GetAllTableData()
//        {
//            var rows = _driver.FindElements(TableRows);
//            var tableData = new List<List<string>>();

//            foreach (var row in rows)
//            {
//                var cells = row.FindElements(By.TagName("td")).Select(cell => cell.Text).ToList();
//                tableData.Add(cells);
//            }
//            return tableData;
//        }

//        public void ClickColumnHeader(int columnIndex)
//        {
//            var headers = _driver.FindElements(TableHeaders);
//            headers[columnIndex].Click();
//        }

//        public List<string> GetColumnData(int columnIndex)
//        {
//            return _driver.FindElements(TableRows)
//                          .Select(row => row.FindElements(By.TagName("td"))[columnIndex].Text.Trim())
//                          .ToList();
//        }

//        public bool IsColumnSorted(int columnIndex, bool ascending = true)
//        {
//            var columnData = GetColumnData(columnIndex);
//            return SortingHelper.IsSorted(columnData, ascending);
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTests.Pages
{
    public class DataTablesPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
    
        private readonly By TableHeaders = By.CssSelector("#table1 thead th");
        private readonly By TableRows = By.CssSelector("#table1 tbody tr");

        public DataTablesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
        }

        public List<List<string>> GetAllTableData()
        {
            try
            {
                var rows = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(TableRows));
                var tableData = new List<List<string>>();

                foreach (var row in rows)
                {
                    var cells = row.FindElements(By.TagName("td")).Select(cell => cell.Text.Trim()).ToList();
                    tableData.Add(cells);
                }
                return tableData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving table data: {ex.Message}");
                return new List<List<string>>();
            }
        }

        public void ClickColumnHeader(int columnIndex)
        {
            try
            {
                var headers = _driver.FindElements(TableHeaders);
                if (columnIndex >= 0 && columnIndex < headers.Count)
                {
                    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    var clickableHeader = wait.Until(ExpectedConditions.ElementToBeClickable(headers[columnIndex]));
                    clickableHeader.Click();

                    // Wait briefly to allow sorting effect
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking column header: {ex.Message}");
            }
        }



        public List<string> GetColumnData(int columnIndex)
        {
            try
            {
                var rows = _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(TableRows));
                var columnData = new List<string>();

                foreach (var row in rows)
                {
                    var cells = row.FindElements(By.TagName("td"));
                    if (columnIndex >= 0 && columnIndex < cells.Count)
                    {
                        columnData.Add(cells[columnIndex].Text.Trim());
                    }
                }
                return columnData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving column data: {ex.Message}");
                return new List<string>();
            }
        }

        public bool IsColumnSorted(int columnIndex, bool ascending = true)
        {
            var columnData = GetColumnData(columnIndex);

            // Convert column data to lowercase for consistent comparison
            var sortedData = new List<string>(columnData);

            if (ascending)
                sortedData.Sort(StringComparer.OrdinalIgnoreCase);
            else
                sortedData.Sort(StringComparer.OrdinalIgnoreCase);
            sortedData.Reverse(); // Reverse for descending order

            // Print expected vs actual for debugging
            Console.WriteLine($"Expected Order: {string.Join(", ", sortedData)}");
            Console.WriteLine($"Actual Order: {string.Join(", ", columnData)}");

            return columnData.SequenceEqual(sortedData);
        }

    }
}
