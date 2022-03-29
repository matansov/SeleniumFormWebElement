using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFormWebElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new FirefoxDriver("C:\\");
            driver.Url = "http://demo.guru99.com/test/login.html";
            driver.Manage().Window.FullScreen();

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
            driver.FindElement(By.Id("save")).Click(); 
            driver.SwitchTo().DefaultContent();

            login.Click();
            Console.WriteLine("Login done with Click");

            driver.Url = "http://demo.guru99.com/test/login.html";

            driver.FindElement(By.Id("email")).SendKeys("abcd@gmail.com");
            driver.FindElement(By.Name("passwd")).SendKeys("abcdefghlkjl");
            driver.FindElement(By.Id("SubmitLogin")).Submit();
            Console.WriteLine("Login done with Submit");
        }
    }
}
