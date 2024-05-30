using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SampleCsharpSpecflow.Pages
{
    public class LoginPage : BasePage
    {
        private By UsernameInput => By.Id("user-name");
        private By PasswordInput => By.Id("password");
        private By LoginButton => By.CssSelector("input.btn_action");
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
          NavigateTo("https://www.saucedemo.com");
        }

        public void EnterCredentials(string username, string password)
        {
           EnterText(UsernameInput, username);
           EnterText(PasswordInput, password);
        }

        public void PressLoginButton()
        {
           Click(LoginButton);
        }
    }
}