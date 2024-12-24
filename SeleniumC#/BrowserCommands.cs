using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class BrowserCommands
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch chrome
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            driver = new EdgeDriver();

        }
        [Test, Category("Regression")]
        public void testcase1()
            //launch the application url
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/auth/login");
            //get the title of the web page
            string title = driver.Title;
            Console.WriteLine(title);
            //Get the current url
            string currenturl = driver.Url;
            Console.WriteLine(currenturl);
            //get the page source or the html code
            string pagesource = driver.PageSource;
            Console.WriteLine(pagesource);
        }
        [TearDown]
        public void closebrowser()
        {
            driver.Close();   // it will close the opened browser session

            //driver.Quit();      it will close all the browser sessions
        }
    }
}
