using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;



namespace LabSession.SeleniumC_
{
    internal class ScrollingEg
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

            driver.Navigate().GoToUrl("https://www.amazon.in/");

            driver.Manage().Window.Maximize();


            IWebElement amazonScience = driver.FindElement(By.XPath("//a[normalize-space()='Amazon Science']"));

            new OpenQA.Selenium.Interactions.Actions(driver)

                .ScrollToElement(amazonScience)
                .Click(amazonScience)
                .Perform();

            Thread.Sleep(5000);


        }

        [TearDown]

        public void closeBrowser()

        {

            driver.Close();

        }

    }
}
