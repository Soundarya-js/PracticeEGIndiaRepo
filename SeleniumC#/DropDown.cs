using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using LabSession.Utilities;

namespace LabSession.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class DropDown : Utilities.Base 
    {
        public DropDown(IWebDriver driver) : base(driver) 
        {
            
        }

        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            IWebElement dropdown = driver.FindElement(By.Id("dropdown-class-example"));
            Assert.IsNotNull(dropdown);
            var select = new SelectElement(dropdown);
            Thread.Sleep(1000);
            select.SelectByText("Option1");
            Thread.Sleep(1000);
            select.SelectByIndex(2);
            Thread.Sleep(1000);
            select.SelectByValue("option3");

            //Checkbox list

            IReadOnlyList<IWebElement> CheckBoxList = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            //CheckBoxList.Click();
            foreach (IWebElement checkbox in CheckBoxList)
            {
                checkbox.Click();
                Thread.Sleep(3000);
            }
        }
       
    }
}
