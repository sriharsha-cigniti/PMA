using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
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
    public class ToolsPage : AbstractTemplatePage
    {
        #region UI Objects
        //New ClaimInquiry and auto Form
        private By byAdministrationText = By.XPath("//td/span[text()='User Administration']");
        private By byUsers = By.LinkText("Users");
        private By byLoginID = By.XPath("//td/input[@id='MainContent_ASPxPageControl1_txtlogonid_I']");
        private By bySearchButton = By.XPath("//span[text()='Search']");
        private By byTableCount = By.XPath("//table[@id='MainContent_gridaccounts_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byAddNewAccount = By.XPath("//input[@id='MainContent_acctText']");
        private By byClickAdd = By.XPath("//div[@id='MainContent_btnSubmit']");
        private By byConfirmationMsg = By.XPath("//span[@id='MainContent_errLbl']");

        #endregion

        //Verify User administration text
        public void VerifyAdministrationLabel()
        {
            this.TESTREPORT.LogInfo("Verify User Administration Label");
            bool flag = this.driver.IsElementPresent(byAdministrationText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify User Administration Label", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify User Administration Label", String.Format(" failed to verify label"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyUserTab()
        {
            this.TESTREPORT.LogInfo("Verify Users Tab");
            bool flag = this.driver.IsWebElementDisplayed(byUsers);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Users Link", String.Format("Succefully verified Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Users Link", String.Format(" failed to verify Link"), this.SCREENSHOTFILE);
            }
        }

        public void EnterLoginID(string LoginID)
        {
            this.TESTREPORT.LogInfo("Enter LoginID");
            this.driver.SendKeysToElementClearFirst(byLoginID,LoginID,"LoginID");
        }

        //click on Search
        public void ClickSearch()
        {
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Search");
            this.driver.ClickElement(bySearchButton, "Search", 60);
        }

        //Count ClaimInquiryResults Count
        public int ToolsResultsCount()
        {
            this.TESTREPORT.LogInfo("Verify ClaimInquiry Tablerow COunt");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byTableCount);
            int BeforeCount = list.Count;
            if (BeforeCount != 0)
            {
               // list[1].Click();
                this.TESTREPORT.LogSuccess("Verify accounts association for User ID", String.Format(" Accounts for User -<mark>{0}</mark> are displayed succesfully", "Associated Accounts"));
            }
            else
            {
                this.TESTREPORT.LogInfo("Verify accounts association for User ID", String.Format("No accounts associated for this User ", this.SCREENSHOTFILE));
            }
            return BeforeCount;

        }
        //Add New Account
        public void AddAccount(string AccountNumber)
        {
            this.TESTREPORT.LogInfo("Enter AccountNumber");
            this.driver.SendKeysToElementClearFirst(byAddNewAccount, AccountNumber, "AccountNumber");
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Add");
            this.driver.ClickElement(byClickAdd, "Add", 60);
        }

        
        //Verify Confirmation Message
        public void ConfirmationMsg(int BeforeCount, string ActualValue, string AccountExistsMsg)
        {
            int Aftercount = ToolsResultsCount();
            Thread.Sleep(4000);
            //IReadOnlyList<IWebElement> list = this.driver.FindElements(byTableCount);
            //int rows = list.Count;
            if (BeforeCount!=Aftercount)
            {
                this.TESTREPORT.LogInfo("Account Added successfully");
               this.driver.AssertTextEqual(byConfirmationMsg, ActualValue);
            }
            else
            {
                this.TESTREPORT.LogInfo("Account already exixts for the user");
                this.driver.AssertTextEqual(byConfirmationMsg, AccountExistsMsg);
            }
        }

       
    }
}
    