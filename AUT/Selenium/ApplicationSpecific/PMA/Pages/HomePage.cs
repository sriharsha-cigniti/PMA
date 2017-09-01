using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class HomePage : AbstractTemplatePage
    {

        #region UI Objects

        private By byMyAccount = By.XPath("//input[@id='MainContent_sppage_gridaccount_I']");


        #endregion

        #region public methods

        public string GetMyAccount()
        {
            string accountName = null;
            accountName = this.driver.GetElementAttribute(this.byMyAccount, "value");
            return accountName;
        }

        #endregion


    }
}
