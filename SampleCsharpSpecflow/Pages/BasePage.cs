using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SampleCsharpSpecflow.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); 
        }

        protected void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected IWebElement FindElement(By by)
        {
            Wait.Until(drv => drv.FindElement(by).Displayed);
            return Driver.FindElement(by);
        }

        protected void Click(By by)
        {
            Wait.Until(drv => drv.FindElement(by).Enabled);
            Driver.FindElement(by).Click();
        }

        protected void EnterText(By by, string text)
        {
            Wait.Until(drv => drv.FindElement(by).Displayed);
            var element = Driver.FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                Wait.Until(drv => drv.FindElement(by).Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        protected string GetElementText(By by)
        {
            Wait.Until(drv => drv.FindElement(by).Displayed);
            return Driver.FindElement(by).Text;
        }

         public void WaitForElementToBeVisible(By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}