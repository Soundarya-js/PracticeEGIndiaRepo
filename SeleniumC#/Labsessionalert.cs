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
    internal class Labsessionalert
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
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            IWebElement AlertMessage = driver.FindElement(By.Id("name"));
            AlertMessage.SendKeys("Soundarya");
            Thread.Sleep(5000);
            IWebElement AlertButton = driver.FindElement(By.Id("alertbtn"));
            AlertButton.Click();
            IAlert alt = driver.SwitchTo().Alert();
            Thread.Sleep(3000);

            Console.WriteLine("Alert button clicked");
            //clicking OK button
            alt.Accept();
            Console.WriteLine("OK button clicked");
            Thread.Sleep(3000);

            AlertMessage.SendKeys("Soundarya");
            Thread.Sleep(5000);
            IWebElement ConfirmButton = driver.FindElement(By.Id("confirmbtn"));
            ConfirmButton.Click();
            Console.WriteLine("Confirm button clicked");
            Thread.Sleep(3000);
            alt.Dismiss();
            Console.WriteLine("cancel button clicked");



        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
