using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using AUT.Selenium.CommonReUsablePages;
namespace AUT.Selenium.ApplicationSpecific.EdgeNet.Pages
{
    public class LoginPage : AbstractTemplatePage
    {
        private By byUserNameTextBox = By.Id("UserName");
        private By byPasswordTextBox = By.Id("Password");
        private By bySubmitButton = By.XPath("//input[@type='submit' and @value='Log On']");
        public void Login(string userName, string password)
        {
            this.driver.SendKeysToElementClearFirst(byUserNameTextBox, userName, byUserNameTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(byPasswordTextBox, password, byPasswordTextBox.ToString());
            this.driver.ClickElement(bySubmitButton, bySubmitButton.ToString());
        }
    }
}
