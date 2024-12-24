using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace LabSession.SeleniumC_
{
    internal class Labsessiondraganddrop
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //initialize the web driver
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(5000);

            IWebElement bestSellers = driver.FindElement(By.XPath("//a[@href='/gp/bestsellers/?ref_=nav_cs_bestsellers']"));
            IWebElement todaysDeals = driver.FindElement(By.XPath("//a[@href='/deals?ref_=nav_cs_gb']"));


            Actions actions = new Actions(driver);

            new Actions(driver)
                .ContextClick(todaysDeals)
                .Pause(TimeSpan.FromSeconds(5))
                .DoubleClick(bestSellers)
                .Pause(TimeSpan.FromSeconds(5))

                .Perform();


            Console.WriteLine("working");
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
