using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.SeleniumC_
{
    internal class labsessionorange
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch chrome
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new FirefoxDriver();

        }
        [Test]
        public void testcase1()
        
        {
            //launch the application url
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/auth/login");
            IWebElement UserName = driver.FindElement(By.XPath("username"));
            UserName.SendKeys("Soundarya");
            Thread.Sleep(2000);

            IWebElement Password = driver.FindElement(By.XPath("//input[@type='password']"));
            Password.SendKeys("suresh");
            Thread.Sleep(2000);



            //login
            IWebElement Login = driver.FindElement(By.LinkText("//button[.=' Login ']"));
            Login.Click();
            Thread.Sleep(2000);


        }
        [TearDown]
        public void closebrowser()
        {
            driver.Close();   // it will close the opened browser session

            //driver.Quit();      it will close all the browser sessions
        }
    }
}
