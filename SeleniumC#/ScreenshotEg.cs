using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.Extensions;

namespace LabSession.SeleniumC_
{
    internal class ScreenshotEg
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

            Screenshot ss = driver.TakeScreenshot();
            ss.SaveAsFile("C:\\Users\\sousu\\Downloads\\SomeFile.txt");


        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
