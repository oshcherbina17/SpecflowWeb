using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SampleCsharpSpecflow.Pages;
using System;

namespace SampleCsharpSpecflow.Steps
{
    [Binding]
   public class LoginSteps
    {
        private readonly LoginPage loginPage;
        private readonly InventoryPage inventoryPage;

        public LoginSteps(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
        }

        [Given(@"I am on the SauceDemo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            loginPage.NavigateTo();
        }

        [When(@"I enter valid credentials '(.*)' and '(.*)'")]
        public void WhenIEnterValidCredentials(string username, string password)
        {
            loginPage.EnterCredentials(username, password);
            loginPage.PressLoginButton();
        }

        [Then(@"I should be redirected to the product page")]
        public void ThenIShouldBeRedirectedToTheProductPage()
        {
            Assert.IsTrue(inventoryPage.IsOnThePage());
        }
    }
      

    
}
