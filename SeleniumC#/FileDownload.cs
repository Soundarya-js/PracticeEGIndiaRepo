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
    [Allure.NUnit.AllureNUnit]
    internal class FileDownload
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
        [Test, Category("Regression")]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IWebElement file1 = driver.FindElement(By.XPath("//a[.='SomeFile.txt']"));
            file1.Click();
            string downloaded = @"C:\\Users\\sousu\\Downloads\\SomeFile.txt";
            if (File.Exists(downloaded))
            {
                Console.WriteLine(downloaded);
            }
            else
            {
                Console.WriteLine("Not downlaoded");


            }



        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
