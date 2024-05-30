using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SampleCsharpSpecflow.Pages;
using System;
using System.Threading;

namespace SampleCsharpSpecflow.Steps
{
    [Binding]
    public class CartSteps
    {
    private readonly InventoryPage inventoryPage;
    private readonly CartPage cartPage;
    private readonly LoginPage loginPage;

 public CartSteps(IWebDriver driver)
    {
        loginPage = new LoginPage(driver);
        inventoryPage = new InventoryPage(driver);
        cartPage = new CartPage(driver);
    }

        

[Given(@"I am logged in as a standard user")]
public void GivenIAmLoggedInAsAStandardUser()
{
	loginPage.NavigateTo();
    loginPage.EnterCredentials("standard_user", "secret_sauce");
    loginPage.PressLoginButton();
}
 [When(@"I press the add to cart button for ""(.*)""")]
    public void WhenIPressTheAddToCartButtonFor(string item)
    {
        inventoryPage.AddItemToCart(item);
    }

    [Then(@"the ""(.*)"" is correctly added to the cart")]
    public void ThenTheIsCorrectlyAddedToTheCart(string item)
    {
        inventoryPage.NavigateToCartPage();
        Assert.IsTrue(cartPage.IsItemInCart(item));
    }

    [When(@"I press the remove button for ""(.*)""")]
    public void WhenIPressTheRemoveButtonFor(string item)
    {
        cartPage.RemoveItemFromCart(item);
    }

    [Then(@"the ""(.*)"" is correctly removed from the cart")]
    public void ThenTheIsCorrectlyRemovedFromTheCart(string item)
    {
        Assert.IsFalse(cartPage.IsItemInCart(item));
    }

    }
}