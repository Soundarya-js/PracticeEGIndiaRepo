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
    internal class WindowTabhandling
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
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.Manage().Window.Maximize();
            // fecth the parent window handle 
            string parenthandle = driver.CurrentWindowHandle;
            Console.WriteLine(parenthandle);
            Thread.Sleep(1000);
            IWebElement clickhere = driver.FindElement(By.XPath("//a[normalize-space()='Click Here']"));
            clickhere.Click();
            Thread.Sleep(1000);

            // fecth the window handles of all the windows - two windows are opened
            IList<string> windowhandles = new List<string>(driver.WindowHandles);
            // move the control to child window
            driver.SwitchTo().Window(windowhandles[1]);
            string title = driver.Title;
            Console.WriteLine(title);
            driver.Close();

            Thread.Sleep(1000);
            driver.SwitchTo().Window(windowhandles[0]);
            //driver.SwitchTo().DefaultContent(); //instead of above line we use this default one
            string parenttitle = driver.Title;
            Console.WriteLine(parenttitle);
            Assert.AreEqual("The Internet", parenttitle);




            Thread.Sleep(5000);


        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
