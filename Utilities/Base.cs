using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabSession.SeleniumC_;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace LabSession.Utilities
{
    internal class Base
    {
        public IWebDriver driver;
        public DropDown(IWebDriver driver)
        {
            this.driver = driver;
        }

        }
        [SetUp]
        public void StartBrowser()
        {
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
           // driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/auth/login");
          //driver.Manage().Window.Maximize();

        }
        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    //launch chrome browser
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    DropDown obj = new DropDown(driver);
                    break;
                case "Chrome":
                    //launch chrome browser
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Edge":
                    //launch chrome browser
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void TearDownBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

    }
}
