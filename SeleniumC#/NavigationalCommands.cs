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
    internal class NavigationalCommands
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch chrome
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            driver = new EdgeDriver();

        }
        [Test]
        public void testcase1()
        //launch the application url
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
           //navigate back
           driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.Navigate().Forward();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);

        }
        [TearDown]
        public void closebrowser()
        {
            driver.Close();   // it will close the opened browser session

            //driver.Quit();      it will close all the browser sessions
        }
    }
}
