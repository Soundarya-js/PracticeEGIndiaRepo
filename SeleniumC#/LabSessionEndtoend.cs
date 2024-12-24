using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace LabSession.SeleniumC_
{
    internal class LabSessionEndtoend
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            //launch chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //initialize the web driver
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void testcase1()
        {
            //launch application URL
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/index.html");
            //locators
            //ID
            Thread.Sleep(3000);
            IWebElement UserName = driver.FindElement(By.Id("user-name"));
            UserName.SendKeys("standard_user");
            Thread.Sleep(3000);
            IWebElement Password = driver.FindElement(By.Id("password"));
            Password.SendKeys("secret_sauce");
            Thread.Sleep(3000);
            IWebElement Login = driver.FindElement(By.Id("login-button"));
            Login.Click();
            Thread.Sleep(3);
            IWebElement Products = driver.FindElement(By.XPath("//div[@class='product_label']"));
            //Displayed validation
            if (Products.Displayed)
            {
                Console.WriteLine("User is on the homepage.");
            }
            else
            {
                Console.WriteLine("User is not on the homepage.");
            }
            Thread.Sleep(5000);
            //open bag
            IWebElement bagProduct = driver.FindElement(By.XPath("//div[normalize-space()='Sauce Labs Backpack']"));
            bagProduct.Click();
            Thread.Sleep(3000);

            IWebElement addCartButton = driver.FindElement(By.XPath("//button[normalize-space()='ADD TO CART']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(addCartButton)
                .Pause(TimeSpan.FromSeconds(5))
                   .Click()
                   .Perform();
            Thread.Sleep(3000);
            Console.WriteLine("added to cart");
            IWebElement cart = driver.FindElement(By.XPath("//a[@class='shopping_cart_link fa-layers fa-fw']//*[name()='svg']"));
            actions.MoveToElement(cart)
                .Pause(TimeSpan.FromSeconds(5))
                   .Click()
                   .Perform();
            Thread.Sleep(3000);
            Console.WriteLine("opened cart");


            IWebElement checkOut = driver.FindElement(By.XPath("//a[normalize-space()='CHECKOUT']"));
            checkOut.Click();
            Thread.Sleep(3000);
            IWebElement firstName = driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("Soundarya");
            Thread.Sleep(3000);
            IWebElement lastName = driver.FindElement(By.Id("last-name"));
            lastName.SendKeys("Suresh");
            Thread.Sleep(3000);
            IWebElement postalCode = driver.FindElement(By.Id("postal-code"));
            postalCode.SendKeys("573165");
            Thread.Sleep(3000);
            IWebElement continueButton = driver.FindElement(By.XPath("//input[@value='CONTINUE']"));
            continueButton.Click();
            Thread.Sleep(3000);
            IWebElement finishButton = driver.FindElement(By.XPath("//a[normalize-space()='FINISH']"));
            finishButton.Click();
            Thread.Sleep(3000);
            string expected = "THANK YOU FOR YOUR ORDER";
            IWebElement actualtext = driver.FindElement(By.XPath("//h2[normalize-space()='THANK YOU FOR YOUR ORDER']"));
            Assert.AreEqual(actualtext.Text, expected);
            Console.WriteLine($"{actualtext.Text} matches {expected}.");
            Thread.Sleep(3000);
        }

        [TearDown]
    public void closeBrowser()
    {
        driver.Close();
    }
    }
}
