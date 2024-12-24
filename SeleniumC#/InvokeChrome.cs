using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.SeleniumC_
{
    internal class InvokeChrome
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
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/auth/login");
        }
        [TearDown]
        public void closebrowser()
        {
            driver.Close();
        }
    }
}
