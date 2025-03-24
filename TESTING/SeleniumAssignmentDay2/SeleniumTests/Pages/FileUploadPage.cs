//using OpenQA.Selenium;
//using SeleniumTests.Base;
//using System.IO;
//using System.Reflection;

//namespace SeleniumTests.Pages
//{
//    public class FileUploadPage : BasePage
//    {
//        private readonly By FileInput = By.Id("file-upload");
//        private readonly By UploadButton = By.Id("file-submit");
//        private readonly By UploadedFiles = By.Id("uploaded-files");

//        public FileUploadPage(IWebDriver driver) : base(driver)
//        {
//            NavigateTo("https://the-internet.herokuapp.com/upload");
//        }

//        public void UploadFile(string fileName)
//        {
//            string filePath = Path.Combine(Environment.CurrentDirectory, "TestFiles", "testfile.txt");
//            _driver.FindElement(FileInput).SendKeys(filePath);
//            _driver.FindElement(UploadButton).Click();
//        }

//        public string GetUploadedFileName()
//        {
//            return _driver.FindElement(UploadedFiles).Text;
//        }
//    }
//}


using OpenQA.Selenium;
using SeleniumTests.Base;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumTests.Pages
{
    public class FileUploadPage : BasePage
    {
        private readonly By FileInput = By.Id("file-upload");
        private readonly By UploadButton = By.Id("file-submit");
        private readonly By UploadedFiles = By.Id("uploaded-files");

        public FileUploadPage(IWebDriver driver) : base(driver)
        {
            NavigateTo("https://the-internet.herokuapp.com/upload");
        }

        public void UploadFile(string fileName)
        {
            try
            {
                string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(basePath, "TestFiles", fileName);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Error: File '{filePath}' not found.");
                    return;
                }

                Console.WriteLine($"Uploading file: {filePath}");
                _driver.FindElement(FileInput).SendKeys(filePath);
                _driver.FindElement(UploadButton).Click();
                Console.WriteLine("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
            }
        }

        public string GetUploadedFileName()
        {
            try
            {
                return _driver.FindElement(UploadedFiles).Text;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Error: Uploaded file name element not found.");
                return string.Empty;
            }
        }
    }
}
