using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;

namespace LabSession.SeleniumC_
{
    internal class InvokeFirefox
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch firefox
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new FirefoxDriver();

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
