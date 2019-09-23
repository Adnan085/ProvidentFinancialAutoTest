using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidentFinancialDemo
{
  public  class WebOps
    {
        public static IWebDriver driver = new ChromeDriver();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        public  void NavigateToSite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public  void AssertTextPresent(By identifier,string text)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(identifier));
            IWebElement element = driver.FindElement(identifier);
            string t = element.Text;
            Assert.AreEqual(element.Text, text.TrimStart());
        }


        public void ClickButton(By identifier)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(identifier));
            IWebElement element = driver.FindElement(identifier);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);

        }

        public void SelectElements(By identifier, string text)
        {
            IWebElement element = driver.FindElement(identifier);
            SelectElement select = new SelectElement(element);
            select.SelectByValue(text);
        }

       public void SendElementKey(By identifier, string text)
        {
            driver.FindElement(identifier).SendKeys(text);
        }

    }
}
