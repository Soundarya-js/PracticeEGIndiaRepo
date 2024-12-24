using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;

namespace LabSession.SeleniumC_
{
    [Parallelizable(ParallelScope.All)]
    [Allure.NUnit.AllureNUnit]
    internal class TwoScreenParallelExecution
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()
        {
            // launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
        }

        [Test, Category("Regression")]
        public void testcase1()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            IWebElement browse = driver.FindElement(By.Id("file-upload"));
            browse.SendKeys("C:\\Users\\Harsha Patil\\Desktop\\manu\\data.png");
            Thread.Sleep(1000);
            IWebElement upload = driver.FindElement(By.Id("file-submit"));
            // fluent wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d =>
            {
                upload.Click();
                return true;
            });

            Thread.Sleep(1000);
            IWebElement fileuploadedmsg = driver.FindElement(By.XPath("//h3[normalize-space()='File Uploaded!']"));
            if (fileuploadedmsg.Displayed)
            {

                Console.WriteLine("The file is uploaded properly");
            }
            else
            {

                Console.WriteLine("\"The file is not  uploaded properly");
            }
        }


        [Test, Category("Regression")]
        public void testcase2()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();

            // checkboxes can be single select and multi select
            IReadOnlyList<IWebElement> checkboxlist = driver.FindElements(By.XPath("//input[@type = 'checkbox']"));
            foreach (IWebElement e in checkboxlist)
            {
                // Console.WriteLine(e.Text);
                e.Click();
                Thread.Sleep(1000);
            }


        }


        [TearDown]
        public void Closebrowser()
        {
            driver.Close();
        }
    }
}
