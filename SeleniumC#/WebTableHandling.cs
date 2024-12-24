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
    internal class WebTableHandling
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
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            driver.Manage().Window.Maximize();
            // fetch the table
            IWebElement table = driver.FindElement(By.XPath("//table[@id = 'table1']"));
            Thread.Sleep(2000);
            // fecth the rows 
            List<IWebElement> trrow = new List<IWebElement>(table.FindElements(By.XPath("//table[@id = 'table1']/tbody/tr")));
            int rowcount = trrow.Count();
            Thread.Sleep(2000);
            Console.WriteLine(rowcount);
            // fecth the columns 
            List<IWebElement> tdcol = new List<IWebElement>(table.FindElements(By.XPath("//table[@id = 'table1']/tbody/tr[1]/td")));
            int colcount = tdcol.Count();
            Thread.Sleep(2000);
            Console.WriteLine(colcount);
            // cell data text
            IWebElement celldata = driver.FindElement(By.XPath("//table[@id = 'table1']/tbody/tr[1]/td[2]"));
            string text = celldata.Text;
            Thread.Sleep(2000);
            Console.WriteLine(text);
            Assert.AreEqual("John", text);


        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
