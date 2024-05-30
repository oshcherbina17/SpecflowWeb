using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SampleCsharpSpecflow.Drivers;
using BoDi;


namespace SampleCsharpSpecflow.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer container;
        private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void RegisterWebDriver()
        {
            driver = new WebDriverManager().GetDriver();
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void CleanupWebDriver()
        {
           if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
