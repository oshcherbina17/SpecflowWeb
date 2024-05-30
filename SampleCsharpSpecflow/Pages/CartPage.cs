using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SampleCsharpSpecflow.Pages
{
    public class CartPage : BasePage
    {
        private By CartItemList => By.CssSelector(".cart_item");
        private By ItemName => By.ClassName("inventory_item_name");
        private By AddToCartButton => By.CssSelector(".btn_inventory");
        private By RemoveButton => By.CssSelector(".cart_button");
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsItemInCart(string itemName)
        {
            var cartItems = Driver.FindElements(CartItemList);
            return cartItems.Any(item => item.FindElement(ItemName).Text.Equals(itemName));
        }

        public void RemoveItemFromCart(string itemName)
        {
            var cartItems = Driver.FindElements(CartItemList);
            foreach (var item in cartItems)
            {
                if (item.FindElement(ItemName).Text.Equals(itemName))
                {
                    item.FindElement(RemoveButton).Click();
                    break;
                }
            }
        }
    }
}