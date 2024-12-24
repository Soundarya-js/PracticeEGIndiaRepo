using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;

namespace LabSession.SeleniumC_
{
    internal class Invokeedge
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch edge
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
