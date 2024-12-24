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
    internal class Labsessiondeselect
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //initialize the web driver
            driver = new EdgeDriver();
        }
        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            //locators
            //ID
            Thread.Sleep(5000);
            IWebElement CheckBox2 = driver.FindElement(By.XPath("//input[2]"));
            if (CheckBox2.Selected)
            {
                CheckBox2.Click();
                Thread.Sleep(5000);
            }

            //Checkbox list

            IReadOnlyList<IWebElement> CheckBoxList = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            //CheckBoxList.Click();
            foreach (IWebElement checkbox in CheckBoxList)
            {
                checkbox.Click();
                Thread.Sleep(3000);
            }
        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
