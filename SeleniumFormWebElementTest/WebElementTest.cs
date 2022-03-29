using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumFormWebElementTest
{
    [TestClass]
    public class WebElementTest
    {
        IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            // arrange phase
            driver = new FirefoxDriver("C:\\");
            driver.Url = "http://demo.guru99.com/test/login.html";
            driver.Manage().Window.FullScreen();

            // act phase
            IWebElement email = driver.FindElement(By.Id("email"));
            IWebElement password = driver.FindElement(By.Name("passwd"));

            email.SendKeys("abcd@gmail.com");
            password.SendKeys("abcdefghlkjl");

            email.Clear();
            password.Clear();

            IWebElement login = driver.FindElement(By.Id("SubmitLogin"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); // GDPR Consent accept
            wait.Until(drv => driver.FindElement(By.Id("gdpr-consent-tool-wrapper")));
            driver.SwitchTo().Frame("gdpr-consent-notice");
            wait.Until(drv => driver.FindElement(By.Id("save")));
            driver.FindElement(By.Id("save")).Click();
            driver.SwitchTo().DefaultContent();

            login.Click();
            Console.WriteLine("Login done with Click");

            // assert phase
            string currentUrl = driver.Url;
            Assert.AreEqual("https://demo.guru99.com/test/success.html", currentUrl);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // arrange phase
            driver = new FirefoxDriver("C:\\");
            driver.Url = "http://demo.guru99.com/test/login.html";
            driver.Manage().Window.FullScreen();

            // act phase
            IWebElement email = driver.FindElement(By.Id("email"));
            IWebElement password = driver.FindElement(By.Name("passwd"));
            IWebElement login = driver.FindElement(By.Id("SubmitLogin"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); // GDPR Consent accept
            wait.Until(drv => driver.FindElement(By.Id("gdpr-consent-tool-wrapper")));
            driver.SwitchTo().Frame("gdpr-consent-notice");
            wait.Until(drv => driver.FindElement(By.Id("save")));
            driver.FindElement(By.Id("save")).Click();
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.Id("email")).SendKeys("abcd@gmail.com");
            driver.FindElement(By.Name("passwd")).SendKeys("abcdefghlkjl");
            driver.FindElement(By.Id("SubmitLogin")).Submit();
            Console.WriteLine("Login done with Submit");

            // assert phase
            string currentUrl = driver.Url;
            Assert.AreEqual("https://demo.guru99.com/test/success.html", currentUrl);
        }

        [TestCleanup]
        public void Close()
        {
            driver.Close();
        }
    }
}