using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace LabSession.SeleniumC_
{
    internal class KeyboardEvents
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
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IWebElement password = driver.FindElement(By.Id("pass"));            
            new Actions(driver)
                .MoveToElement(password)
                .Click()
                .KeyDown(Keys.Shift)
                .SendKeys("soundarya")
                .Perform();
          
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
