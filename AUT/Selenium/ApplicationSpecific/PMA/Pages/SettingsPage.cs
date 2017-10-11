using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
//using OpenQA.Selenium.Point;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using Engine.Factories;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class SettingsPage : AbstractTemplatePage
    {
        #region UI Objects
        private By bySettingsTab = By.XPath("//a[@id='CinchMenu_DXI7_T']/span[contains(text(),'Settings')]");
        private By byDefaultAccountDropDownspan = By.Id("MainContent_gridaccount_B-1Img");
        private By bySaveSettingsBtn = By.XPath("//span[contains(text(),'Save')]");
        private By byDefaultAccountInput = By.Id("MainContent_gridaccount_I");
        #endregion

        public void ClickOnSettings()
        {
            this.driver.ClickElement(bySettingsTab,"Settings Tab ");
        }
        public void VerifyDataSaveMessage(string saveMessage)
        {
            By DataSaveMessage = By.XPath(string.Format("//span[contains(text(),'{0}')]", saveMessage));
            this.driver.WaitElementPresent(DataSaveMessage);
            if (this.driver.IsElementPresent(DataSaveMessage))
                this.TESTREPORT.LogSuccess("Verify Data save Message",String.Format("Data Message - <mark>{0}</mark> appeared", saveMessage));
            else
                this.TESTREPORT.LogFailure("Verify Data save Message", String.Format("Data Message - <mark>{0}</mark> doesn't appeared", saveMessage),this.SCREENSHOTFILE);
            
        }
        public void SelectDefaultAccount(string defaultAccount)
        {
            this.driver.ClickElement(byDefaultAccountDropDownspan, "Default dropdown span");
            By DefaultDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", defaultAccount));
            this.driver.ClickElement(DefaultDropDown,"Default Account");
            
        }
        
        public void SaveSettings()
        {
            this.driver.ClickElement(bySaveSettingsBtn,"Savings Settings Button");
        }
        
        public string GetAccountDetails()
        {
           return (this.driver.GetElementAttribute(byDefaultAccountInput, "value"));
           
        }

        public void VerifyDefaulAccountDetailsIsApplied(string AccountDetails)
        {
            
            By AccountDetailsSpan = By.XPath(string.Format("//span[contains(text(),'{0}')]", AccountDetails));
            this.driver.WaitElementPresent(AccountDetailsSpan);
            if (this.driver.IsElementPresent(AccountDetailsSpan))
                this.TESTREPORT.LogSuccess("Verify Default Account Details Is Applied", String.Format("Default AccountDetails - <mark>{0}</mark> applied",AccountDetails));
            else
                this.TESTREPORT.LogFailure("Verify Default Account Details Is Applied", String.Format("Default AccountDetails - <mark>{0}</mark> applied",AccountDetails),this.SCREENSHOTFILE);

        }
    }
}
