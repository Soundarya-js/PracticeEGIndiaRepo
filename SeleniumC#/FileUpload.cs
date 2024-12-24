using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.SeleniumC_
{
    internal class FileUpload
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //initialize the web driver
            driver = new FirefoxDriver();
        }
        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            IWebElement browse = driver.FindElement(By.Id("file-upload"));
            browse.SendKeys("C:\\Users\\sousu\\Pictures\\Screenshots\\Screenshot 2024-12-18 123551.png");
            Thread.Sleep(2000);
            IWebElement upload = driver.FindElement(By.Id("file-submit"));
            upload.Click();
            Thread.Sleep(2000);
            IWebElement fileuploadedmsg = driver.FindElement(By.XPath("//h3[normalize-space()='File Uploaded!']"));
            if (fileuploadedmsg.Displayed)
            {

                Console.WriteLine("The file is uploaded properly");
            }
            else
            {

                Console.WriteLine("\"The file is not  uploaded properly");
            }




        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
