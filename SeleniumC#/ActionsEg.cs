using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class ActionsEg
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
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IWebElement primes = driver.FindElement(By.XPath("//span[starts-with(text(),'Prime')]"));
            primes.Click();
            Thread.Sleep(3000);
            //IWebElement latestmovies = driver.FindElement(By.XPath("//img[@id='multiasins-img-link']"));
            //latestmovies.Click();
            //new OpenQA.Selenium.Interactions.Actions(driver)
            //   .MoveToElement(primes)
            //   .ClickAndHold()
            //   .Pause(TimeSpan.FromSeconds(1))
            //   .MoveToElement(latestmovies)
            //   .Click().Perform();
            Thread.Sleep(1000);
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
