using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleCsharpSpecflow.Drivers
{
    public class WebDriverManager
    {
        private readonly IWebDriver driver;

        public WebDriverManager()
        {
            driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize(); 
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void Dispose()
        {
            driver.Quit();
        } 
    }
}