using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SampleCsharpSpecflow.Pages
{
    public class InventoryPage : BasePage
    {
        private By InventoryContainer => By.Id("inventory_container");
        private By ItemName => By.ClassName("inventory_item_name");
        private By AddToCartButton => By.CssSelector(".btn_inventory");
        private By CartIcon => By.Id("shopping_cart_container");


        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsOnThePage()
        {
            return  IsElementPresent(InventoryContainer);
        }

          public string GetFirstProductName()
        {
            By firstProductNameLocator = By.CssSelector(".inventory_item_name");
            return GetElementText(firstProductNameLocator);
        }

        public void AddFirstItemToCart()
        {
            By firstAddToCartButton = By.CssSelector(".inventory_item button");
            Click(firstAddToCartButton);
        }

        public void AddItemToCart(string itemName)
        {
            WaitForElementToBeVisible((CartIcon), 10);
            var items = Driver.FindElements(By.ClassName("inventory_item"));
            foreach (var item in items)
            {
                if (item.FindElement(ItemName).Text.Equals(itemName))
                {
                    item.FindElement(AddToCartButton).Click();
                    break;
                }
            }
        }

         public CartPage NavigateToCartPage()
        {
            WaitForElementToBeVisible((CartIcon), 10);
            Click(CartIcon);
            return new CartPage(Driver);
        }
    }
}