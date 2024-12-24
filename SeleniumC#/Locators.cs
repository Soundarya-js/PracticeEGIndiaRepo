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
    internal class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch chrome
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            driver = new EdgeDriver();

        }
        [Test]
        public void testcase1()
        //launch the application url
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/auth/login");
            //locators
            // Id
            IWebElement FirstName = driver.FindElement(By.Id("firstname"));
            FirstName.SendKeys("Sounds");

            // name 
            IWebElement LastName = driver.FindElement(By.Name("lastname"));
            LastName.SendKeys("Suresh");

            // xpath 
            IWebElement UserName = driver.FindElement(By.XPath("//input[@id = 'username']"));
            UserName.SendKeys("SS");

            // xpath
            IWebElement Password = driver.FindElement(By.XPath("//input[@name= 'password']"));
            Password.SendKeys("SS123");

            // Link text 
            IWebElement Backtologin = driver.FindElement(By.LinkText("Back to Login"));
            Backtologin.Click();

            // Partial link text
            IWebElement Register = driver.FindElement(By.PartialLinkText("Back to Log"));
            Register.Click();

            //  Css selectorr
            IWebElement Elements = driver.FindElement(By.CssSelector("button[data-bs-target='#collapseOne']"));
            Elements.Click();

            // tag name 
            IWebElement input = driver.FindElement(By.TagName("(//input)[1]"));
            input.SendKeys("jkkj");

            // class name 
            IWebElement classname = driver.FindElement(By.ClassName("(//input[@class = 'form-control'])[1]"));
            classname.SendKeys("jkkj");

        }
        [TearDown]
        public void closebrowser()
        {
            driver.Close();   // it will close the opened browser session

            //driver.Quit();      it will close all the browser sessions
        }
    }
}
