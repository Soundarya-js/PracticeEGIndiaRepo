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
    internal class MultiSelectCheckbox
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //initialize the web driver
            driver = new EdgeDriver();
        }
        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(6000);
            // checkboxes can be single select and multi select
            IReadOnlyList<IWebElement> checkboxlist = driver.FindElements(By.XPath("//input[@type = 'checkbox']"));
            foreach (IWebElement e in checkboxlist)
            {
                // Console.WriteLine(e.Text);
                e.Click();
                Thread.Sleep(1000);
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
