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
        private By byBroker = By.LinkText("Brokers");
        private By byReportAttachment = By.LinkText("Report Attachment Opt out");
        private By byLoginID = By.XPath("//td/input[@id='MainContent_ASPxPageControl1_txtlogonid_I']");
        private By bySearchButtonUser = By.Id("MainContent_ASPxPageControl1_btnuser_CD");
        private By bySearchButtonReports = By.Id("MainContent_ASPxPageControl1_btnAcctSrch_CD");
        private By byTableCount = By.XPath("//table[@id='MainContent_gridaccounts_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byAddNewAccount = By.XPath("//input[@id='MainContent_acctText']");
        private By byClickAdd = By.XPath("//div[@id='MainContent_btnSubmit']");
        private By byConfirmationMsg = By.Id("MainContent_errLbl");
        private By byFunationalPermissionLabel = By.XPath("//span[text()='Functional Permissions']");
        private By byDataPermissionLabel = By.XPath("//span[text()='Data Permissions']");
        private By byPermissionLink = By.XPath("//tr[contains(@id,'MainContent_gridaccounts_DXDataRow')][2]//td[10]");
        private By byFunctionalCheckAll = By.Id("MainContent_fnPrmsnChkAllBtn_CD");
        private By byDataPermissionCheckAll = By.Id("MainContent_dtPrmsnChkAllBtn_CD");
        private By bySubmit = By.XPath("//span[text()='Submit']");
        private By byAccountsAssociationLabel = By.XPath("//span[text()='Accounts Association for User ID - ']");
        private By byFunctionalDefault = By.XPath("//table[@id='MainContent_fncPrmsnTbl']//input[@checked='checked']");
        private By byDataDefault = By.XPath("//table[@id='gridDataPermissions']//input[@checked='checked']");
        private By byDelete = By.XPath("//a[@id='MainContent_gridaccounts_DXCBtn7']");
        private By byLabelheader = By.Id("MainContent_lblheader");
        private By byAccountName = By.XPath("//tr[contains(@id,'MainContent_gridaccounts_DXDataRow')][2]//td[3]");
        private By byAccountNumberText = By.XPath("//tr[contains(@id,'MainContent_gridaccounts_DXDataRow')][2]//td[2]");
        private By byLabel = By.Id("MainContent_ASPxLabel9");
        private By bySearchBy = By.XPath("//span[text()='Search By: ']");
        private By byAttachmentLabel = By.Id("MainContent_ASPxPageControl1_ASPxLabel3");
        private By byAccountNameLabel = By.XPath("//span[text()='Account Number:']");
        private By byAccountNumber = By.XPath("//input[@id='MainContent_ASPxPageControl1_OptOutAcctNumTbx_I']");
        private By byAccntMsgLabel = By.Id("MainContent_AcctMsgLbl");
        private By byAccountHeaders = By.XPath("//table[@id='MainContent_gridaccounts']//th");
        private By byBrokerCodeInput = By.Id("MainContent_ASPxPageControl1_txtbrokercode_I");
        private By bySearchButtonBroker = By.Id("MainContent_ASPxPageControl1_btnbroker_CD");
        private By bySearchTableCount = By.XPath("//tr[contains(@id,'MainContent_ASPxPageControl1_gridbroker_DXDataRow')]");
        private By bySelectBroker = By.XPath("//tr[contains(@id,'MainContent_ASPxPageControl1_gridbroker_DXDataRow')][1]");
        private By byBrokerInformationHeader = By.XPath("//b[text()='Broker Detail Information']");
        private By byBrokerCode = By.XPath("//label[@id='MainContent_lblBrkCode']");
        private By byBrokerName = By.XPath("//label[@id='MainContent_lblBrkName']");
        private By byGetBrokerName = By.XPath("//tr[contains(@id,'MainContent_ASPxPageControl1_gridbroker_DXDataRow')][1]//td[1]");
        private By byGetBrokerCode = By.XPath("//tr[contains(@id,'MainContent_ASPxPageControl1_gridbroker_DXDataRow')][1]//td[2]");
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

        //Verify users Tab
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

        //Verify Brokers Tab
        public void VerifyAndClickBrokersTab()
        {
            this.TESTREPORT.LogInfo("Verify Broker Tab");
            bool flag = this.driver.IsWebElementDisplayed(byBroker);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Broker Link", String.Format("Succefully verified Link"));
                this.TESTREPORT.LogInfo("Click on Brokers Tab");
                this.driver.ClickElement(byBroker, "Broker", 60);
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Broker Link", String.Format(" failed to verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify Reports Attachment Opt out Tab
        public void VerifyAndClickReportsTab()
        {
            this.TESTREPORT.LogInfo("Verify Reports Attachment Opt out Tab");
            bool flag = this.driver.IsWebElementDisplayed(byReportAttachment);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Reports Attachment Opt out Link", String.Format("Succefully verified Link"));
                this.TESTREPORT.LogInfo("Click on Reports Attachment Opt out Tab");
                this.driver.ClickElement(byReportAttachment, "Reports Attachment Opt out", 60);
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Reports Attachment Opt out Link", String.Format(" failed to verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Enter Login ID 
        public void EnterLoginID(string LoginID)
        {
            this.TESTREPORT.LogInfo("Enter LoginID");
            this.driver.SendKeysToElementClearFirst(byLoginID, LoginID, "LoginID");
        }

        //click on Search in Users tab
        public void ClickSearch()
        {
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Search");
            this.driver.ClickElement(bySearchButtonUser, "Search", 60);
        }

        //Count ClaimInquiryResults Count
        public int ToolsResultsCount()
        {
            this.TESTREPORT.LogInfo("Verify ClaimInquiry Tablerow Count");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byTableCount);
            int BeforeCount = list.Count;
            if (BeforeCount != 0)
            {
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
            if (BeforeCount != Aftercount)
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
        //Verify User Functional Permission text
        public void VerifyFunctionalPermssionLabel()
        {
            this.TESTREPORT.LogInfo("Verify Functional Permission Label");
            this.driver.WaitUntilElementVisible(byFunationalPermissionLabel, 60);
            bool flag = this.driver.IsElementPresent(byFunationalPermissionLabel);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Functional Permission Label", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Functional Permission Label", String.Format(" Failed to verify label"), this.SCREENSHOTFILE);
            }
        }

        //Verify User Data Permission text
        public void VerifyDataPermssionLabel()
        {
            this.TESTREPORT.LogInfo("Verify Data Permission Label");
            this.driver.WaitUntilElementVisible(byDataPermissionLabel, 60);
            bool flag = this.driver.IsElementPresent(byDataPermissionLabel);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Data Permission Label", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Data Permission Label", String.Format(" Failed to verify label"), this.SCREENSHOTFILE);
            }
        }

        //Click on Permission link
        public void ClickPermission()
        {
            int RowCount = ToolsResultsCount();
            if (RowCount > 1)
            {
                Thread.Sleep(5000);
                this.TESTREPORT.LogInfo("Click on Permission");
                this.driver.ClickElement(byPermissionLink, "Permission", 60);
            }
            else
            {
                this.TESTREPORT.LogInfo("No Accounts associated with this User");
            }
        }

        //Click on Function Check All link
        public void ClickFunctionCheckAll()
        {
            Thread.Sleep(5000);
            this.driver.IsElementPresent(byFunctionalCheckAll);
            this.TESTREPORT.LogInfo("Click on CheckAll for function Permission");
            this.driver.ClickElement(byFunctionalCheckAll, "FunctionCheckAll", 60);
        }

        //Click on Permission link
        public void ClickDataCheckAll()
        {
            Thread.Sleep(5000);
            this.driver.IsElementPresent(byDataPermissionCheckAll);
            this.TESTREPORT.LogInfo("Click on CheckAll for Data Permission");
            this.driver.ClickElement(byDataPermissionCheckAll, "DataCheckAll", 60);
        }

        //Click on Submit

        public void ClickSubmit()
        {
            Thread.Sleep(5000);
            this.driver.IsElementPresent(bySubmit);
            this.TESTREPORT.LogInfo("Click on Submit");
            this.driver.ClickElement(bySubmit, "Submit", 60);
        }

        ////  Verify Default options

        //  public void VerifySelectedCheckboxCount(string PermissionChecked)
        //  {
        //      IReadOnlyList<IWebElement> listFunctional = this.driver.FindElements(byFunctionalDefault);
        //      IReadOnlyList<IWebElement> listData = this.driver.FindElements(byDataDefault);
        //      int BeforeCountFunctional = listFunctional.Count();
        //      int BeforeCountData = listData.Count();


        //      int AfterCountFunctional = listFunctional.Count();
        //      int AfterCountData = listData.Count();



        //  }

        //Click on Delete
        public void ClickDelete()
        {
            int BeforeDelteCount = ToolsResultsCount();
            Thread.Sleep(5000);
            if (BeforeDelteCount > 1)
            {
                string AccountName = this.driver.GetElementText(byAccountName, 60);
                this.driver.IsElementPresent(byDelete);
                this.TESTREPORT.LogInfo("Click on Delete");
                this.driver.ClickElement(byDelete, "Delete", 60);


                int AfterDeleteCount = ToolsResultsCount();

                if (BeforeDelteCount != AfterDeleteCount)
                {
                    this.TESTREPORT.LogSuccess("Verify Account deleted or not", String.Format("Account Deleted Succefully - <mark>{0}</mark>", AccountName));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Account deleted or not", String.Format(" Failed to Delete the Account"), this.SCREENSHOTFILE);
                }
            }
        }

        //Verify Header Label 
        public void VerifyHeaderLabel()
        {
            this.driver.WaitElementPresent(byLabelheader);
            string AccountName = this.driver.GetElementText(byAccountName, 60);
            string AccountNumber = this.driver.GetElementText(byAccountNumber, 60);
            string UserName = Environment.UserName;
            string ExpectedLabelHeader = "Permissions for " + UserName + " on Account " + AccountNumber + "-" + AccountName + "";
            ClickPermission();
            this.TESTREPORT.LogInfo("Verifying the Header Label");
            this.driver.AssertTextMatching(this.driver.GetElementText(byLabelheader).ToLower(), ExpectedLabelHeader.ToLower());
        }

        //Verify Label
        public void VerifyLabel()
        {
            string UserName = Environment.UserName;
            string ExpectedLabel = "Accounts Association for User ID -" + UserName + "";
            this.TESTREPORT.LogInfo("Verifying Label");
            string Label = this.driver.GetElementText(byLabel);
            string UserNameApplication = this.driver.GetElementText(By.Id("MainContent_lbluserid"));
            string ActualLabel = "" + Label + "" + UserNameApplication + "";
            this.driver.AssertTextMatching(ActualLabel.ToLower(), ExpectedLabel.ToLower());
        }

        //Verify Search by Label 
        public void VerifySearchByLabel()
        {
            this.TESTREPORT.LogInfo("Verify Search By Label");
            bool flag = this.driver.IsElementPresent(bySearchBy);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Search By Label", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Search By Label", String.Format(" Failed to verify label"), this.SCREENSHOTFILE);
            }
        }

        //Verify Account Level Opt Out  Label 
        public void VerifyAccountLevelAndNameLabel()
        {
            this.TESTREPORT.LogInfo("Verify Account Level Opt Out and Account Name Label");
            this.driver.IsElementPresent(byAccountNameLabel);
            bool flag = this.driver.IsElementPresent(byAttachmentLabel);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Account Level Opt Out and Account Name Label", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Account Level Opt Out and Account Name Label", String.Format(" Failed to verify label"), this.SCREENSHOTFILE);
            }
        }

        //Enter Account number and Search
        public void SearchAccount(string AccountNumber)
        {
            this.TESTREPORT.LogInfo("Enter AccountNumber");
            this.driver.SendKeysToElementClearFirst(byAccountNumber, AccountNumber, "AccountNumber");
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Search");
            this.driver.ClickElement(bySearchButtonReports, "Search", 60);
        }

        //Enter BrokerCode and Search
        public void SearchBrokerCode(string BrokerCode)
        {
            this.TESTREPORT.LogInfo("Enter BrokerCode");
            this.driver.SendKeysToElementClearFirst(byBrokerCodeInput, BrokerCode, "BrokerCode");
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Search");
            this.driver.ClickElement(bySearchButtonBroker, "Search", 60);
        }

        // verify Account Level Opt Out Rule(s) for search account

        public void VerifyAccntMsgLabel(string ExpectedLabel)
        {
            this.driver.WaitUntilElementVisible(byAccntMsgLabel, 60);
            this.TESTREPORT.LogInfo("Verifying the Header Label");
            this.driver.AssertTextEqual(byAccntMsgLabel, ExpectedLabel);
        }
        // Verify Account Table Headers
        public void VerifyAccountsTableHeaders(string value)
        {
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byAccountHeaders);
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in Table", string.Format("Header contains:<mark>{0}</mark>", item.Text));
                    break;
                }


            }
        }

        //Verify Search results

        public int VerifyBrokerSearchResults()
        {

            this.TESTREPORT.LogInfo("Verify Brokers Tablerow Count");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(bySearchTableCount);
            int TableCount = list.Count;
            if (TableCount > 0)
            {
                this.TESTREPORT.LogSuccess("Verify brokers associated for User ID", String.Format(" Brokers for User -<mark>{0}</mark> are displayed succesfully", "Associated Brokers"));
                string ExpectedBrokerName = this.driver.GetElementText(byGetBrokerName);
                string ExpectedBrokerCode = this.driver.GetElementText(byGetBrokerCode);
                this.driver.ClickElement(bySelectBroker, "ClickBroker", 60);
                this.driver.IsElementPresent(byBrokerInformationHeader);
                this.driver.AssertTextEqual(byBrokerName, ExpectedBrokerName);
                this.driver.AssertTextEqual(byBrokerCode, ExpectedBrokerCode);

            }
            else
            {
                this.TESTREPORT.LogInfo("Verify brokers associated for User ID", String.Format("No Brokers associated for this User ", this.SCREENSHOTFILE));
            }
            return TableCount;

        }


    }
}
