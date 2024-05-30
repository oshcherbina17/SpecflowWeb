using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleCsharpSpecflow.Drivers
{
    public static class WebDriverHelper
    {
        public static IWebDriver InitializeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
