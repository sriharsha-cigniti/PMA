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
        
        private By byResetSettings = By.XPath("//div[@id='MainContent_btnreset_CD']");      
        private By byDefaultAccountDropDownspan = By.Id("MainContent_gridaccount_B-1Img");
        private By bySaveSettingsBtn = By.XPath("//span[contains(text(),'Save')]");
        private By byDefaultAccountInput = By.XPath("//input[@id='MainContent_gridaccount_I']");
        //customize HomePage
        private By byHideQuickCliamSearchCheckbox = By.XPath("//input[@id='chksearch2']");
        private By byHideMyDiaryCheckbox = By.XPath("//input[@id='chkdiary2']");
        //Default Page size(Items per page)
        private By byClaimlistDropdownBtn = By.Id("MainContent_cbclaimlist_B-1Img");
        private By byPaymentsDropdownBtn = By.Id("MainContent_cbpaymentspagesize_B-1Img");
        private By byDiaryDropdownBtn = By.Id("MainContent_cbdiarypagesize_B-1Img");
        private By byLogNotesDropdownBtn = By.Id("MainContent_cblognotespagesize_B-1Img");
        private By byOSHASummaryDropdownBtn = By.Id("MainContent_cboshapagesize_B-1Img");
        private By byPolicyDropdownBtn = By.Id("MainContent_cbpolicypagesize_B-1Img");
        private By byClaimListField = By.XPath("//input[@id='MainContent_cbclaimlist_I']");
        private By byPaymentsField = By.XPath("//input[@id='MainContent_cbpaymentspagesize_I']");
        private By byDiaryField = By.XPath("//input[@id='MainContent_cbdiarypagesize_I']");
        private By byLogNotesField = By.XPath("//input[@id='MainContent_cblognotespagesize_I']");
        private By byOSHASummaryField = By.XPath("//input[@id='MainContent_cboshapagesize_I']");
        private By byPolicyField = By.XPath("//input[@id='MainContent_cbpolicypagesize_I']");
        private By byLineofBusinessField = By.XPath("//input[@id='MainContent_ddlob_I']");
        private By byClaimStatusField = By.XPath("//input[@id='MainContent_ddstatus_I']");
        //Default Search Criteria
        private By byLineofBusinessDropdownBtn = By.Id("MainContent_ddlob_B-1Img");
        private By byCliamstatusDropdownBtn = By.Id("MainContent_ddstatus_B-1Img");
        //Customize Claim List Columns (click and drag desired fields into table below)
        private By byAdjusterNameDrag = By.XPath("//td[text()='Adjuster Name']");
        private By byClaimNumberDrag = By.XPath("//table[@id='MainContent_cbPanel_GridFrom_DXMainTable']//tr[contains(@class,'dxgvDataRow draggableRow left ui-draggable ui-droppable')]//td[text()='Claim Number']");
        private By byClaimTypeDrag = By.XPath("//td[text()='Claim Type']");
        private By byEmptyspaceDrag = By.Id("MainContent_cbPanel_GridTo_DXEmptyRow");
        //home page validation
        private By byMyDiary = By.XPath("//div[@id='MainContent_sppage_pnlDiary']//label[text()='My Diary']");
        private By byQuickClaimSearch = By.XPath("//div[@id='MainContent_sppage_pnlQuickSearch']//label[text()='Quick Claim Search']");
        //claimInquiry Page Validation
        private By byClaimInquirypageSizeField = By.XPath("//input[@id='MainContent_ASPxPageControl1_gridresult_DXPagerTop_PSI']");
        private By bylineofBusinessinclaimField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_ddlob_I']");
        private By byClaimStatusinclaimField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_ddstatus_I']");
        //payments tab validation
        private By byPaymentTabResultsPageSize = By.XPath("//input[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXPagerTop_PSI']");
        private By byPaymentsTabResultsBlankData = By.XPath("//div[contains(text(),'No data to display')]");
        //diary tab validation
        private By byDiaryTabResultsBlankData = By.XPath("//div[contains(text(),'There are no diary / note entries for this claim')]");
        //**unable to identify the results for the Diary tab for any selected claim
        private By byDiaryTabResultsPageSize = By.XPath("");
        //lognotes tab validation
        private By byLogNotesTabResultsPageSize = By.XPath("//input[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXPagerTop_PSI']");
        private By byLogNotesTabResultsBlankData = By.XPath("//div[contains(text(),'There are no available log notes for this claim')]");

        //OSHA Main Link
        private By byOSHALink = By.Id("CinchMenu_DXI4_T");
        private By byImportantInformationPleaseReadtext = By.Id("MainContent_ASPxRoundPanel1_RPHT");
        private By byClickAcceptinOSHA = By.Id("MainContent_ASPxRoundPanel1_btnAccept_CD");
        private By byOSHATabResultsPageSize = By.XPath("//input[@id='MainContent_gridresult_DXPagerTop_PSI']");
        private By byOSHATabResultsBlankData = By.XPath("//div[contains(text(),'No data to display')]");

        //Policy Link
        private By byPolicyLink = By.LinkText("Policy");
        private By byPolicyTabResultsPageSize = By.XPath("//input[@id='MainContent_gridpolicy_DXPagerTop_PSI']");
        


        #endregion

        
        public void VerifyDataSaveMessage(string saveMessage)
        {
            this.TESTREPORT.LogInfo("verify the message after save button is clicked");
            By DataSaveMessage = By.XPath(string.Format("//span[contains(text(),'{0}')]", saveMessage));
            this.driver.WaitElementPresent(DataSaveMessage);
            if (this.driver.IsElementPresent(DataSaveMessage))
                this.TESTREPORT.LogSuccess("Verify Data save Message", String.Format("Data Message - <mark>{0}</mark> appeared", saveMessage));
            else
                this.TESTREPORT.LogFailure("Verify Data save Message", String.Format("Data Message - <mark>{0}</mark> doesn't appeared", saveMessage), this.SCREENSHOTFILE);

        }
        public void SelectDefaultAccount(string defaultAccount)
        {
            this.TESTREPORT.LogInfo("select an account from My Default Account dropdown");
            this.driver.ClickElement(byDefaultAccountDropDownspan, "Default dropdown span");
            By DefaultDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", defaultAccount));
            this.driver.ClickElement(DefaultDropDown, "Default Account");

        }

        public void SaveSettings()
        {
            this.TESTREPORT.LogInfo("click on save in the settings page");
            this.driver.ClickElement(bySaveSettingsBtn, "Savings Settings Button");
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
                this.TESTREPORT.LogSuccess("Verify Default Account Details Is Applied", String.Format("Default AccountDetails - <mark>{0}</mark> applied", AccountDetails));
            else
                this.TESTREPORT.LogFailure("Verify Default Account Details Is Applied", String.Format("Default AccountDetails - <mark>{0}</mark> applied", AccountDetails), this.SCREENSHOTFILE);

        }

        public void ClickHideQuickCliamSearchCheckbox()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("ClickHideQuickCliamSearch");

            this.driver.ClickElement(byHideQuickCliamSearchCheckbox, "HideQuickCliamSearchCheckbox");

            Thread.Sleep(2000);
        }

        public void ClickHideMyDiaryCheckbox()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("ClickHideMyDiary");

            this.driver.ClickElement(byHideMyDiaryCheckbox, "HideMyDiaryCheckbox");
            Thread.Sleep(2000);
        }

        public void SelectClaimlist()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the claimlist");
            this.driver.ClickElement(byClaimlistDropdownBtn, "Claimlist");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cbclaimlist_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectPayments()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the Payments");
            this.driver.ClickElement(byPaymentsDropdownBtn, "Payments");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cbpaymentspagesize_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectDiary()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the Diary");
            this.driver.ClickElement(byDiaryDropdownBtn, "Diary");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cbdiarypagesize_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectLogNotes()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the LogNotes");
            this.driver.ClickElement(byLogNotesDropdownBtn, "LogNotes");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cblognotespagesize_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectOSHASummary()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the OSHASummary");
            this.driver.ClickElement(byOSHASummaryDropdownBtn, "OSHA Summary");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cboshapagesize_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectPolicy()
        {
            this.TESTREPORT.LogInfo("select the dropdown value for the Policy");
            this.driver.ClickElement(byPolicyDropdownBtn, "Policy");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_cbpolicypagesize_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();
        }

        public void SelectLineofBusiness()
        {
            this.TESTREPORT.LogInfo("select line of business");
            this.driver.ClickElement(byLineofBusinessDropdownBtn, "LineofBusiness");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_ddlob_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[2].Click();

        }

        public void SelectClaimStatus()
        {
            this.TESTREPORT.LogInfo("select claim status");
            this.driver.ClickElement(byCliamstatusDropdownBtn, "Cliamstatus");
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_ddstatus_DDD_L_LBT']//tr[contains(@class,'dxeListBoxItem')]"));
            list[1].Click();

        }

        public void DragDesiredFieldsintoTableBelow()
        {
            IWebElement e1 = this.driver.FindElement(byAdjusterNameDrag);
            IWebElement e2 = this.driver.FindElement(byEmptyspaceDrag);
            this.driver.DragDrop(e1, e2);
            Thread.Sleep(2000);
        }

        public void DragDesiredFieldsintoTableBelow1()
        {
            IWebElement e1 = this.driver.FindElement(byClaimTypeDrag);
            IWebElement e2 = this.driver.FindElement(byAdjusterNameDrag);
            this.driver.DragDrop(e1, e2);
            Thread.Sleep(2000);
        }

        public void DragDesiredFieldsintoTableBelow2()
        {
            IWebElement e1 = this.driver.FindElement(byClaimNumberDrag);
            IWebElement e2 = this.driver.FindElement(byAdjusterNameDrag);
            this.driver.DragDrop(e1, e2);
            Thread.Sleep(2000);
        }

        public string GetClaimListSelectedValue()
        {
            string x = this.driver.GetElementAttribute(byClaimListField, "value");
            return x;
        }

        public string GetPaymentsSelectedValue()
        {
            string x = this.driver.GetElementAttribute(byPaymentsField, "value");
            return x;
        }

        public string GetDiarySelectedValue()
        {
            string x = this.driver.GetElementAttribute(byDiaryField, "value");
            return x;
        }

        public string GetLogNotesSelectedValue()
        {
            string x = this.driver.GetElementAttribute(byLogNotesField, "value");
            return x;
        }

        public string GetOSHASummarySelectedValue()
        {
            string x = this.driver.GetElementAttribute(byOSHASummaryField, "value");
            return x;
        }

        public string GetPolicySelectedValue()
        {
            string x = this.driver.GetElementAttribute(byPolicyField, "value");
            return x;
        }

        public string GetLineofBusinessSelectedValue()
        {
            string x = this.driver.GetElementAttribute(byLineofBusinessField, "value");
            return x;
        }

        public string GetClaimStatusSelectedValue()
        {
            string x = this.driver.GetElementAttribute(byClaimStatusField, "value");
            return x;
        }

        public void VerifydefaultaccountDetailsonsettings(string Expected)
        {
            string Actual = GetAccountDetails();
            this.driver.AssertTextMatching(Actual, Expected);
        }

        public void VerifyMyDiaryinHomePage()
        {
            this.TESTREPORT.LogInfo("VerifyMyDiaryinHomePage");
            if (!this.driver.IsElementPresent(byMyDiary))
            {

                this.TESTREPORT.LogFailure("Verify Mydiary on home page", "Element is displayed", this.SCREENSHOTFILE);

            }
            else
            {

                this.TESTREPORT.LogSuccess("Verify Mydiary on home page", string.Format("Element:<mark>{0}</mark> not present", "MyDiary"));
            }
        }

        public void VerifyQuickClaimSearchinHomePage()
        {
            this.TESTREPORT.LogInfo("VerifyQuickClaimSearchinHomePage");
            if (!this.driver.IsElementPresent(byQuickClaimSearch))
            {
                this.TESTREPORT.LogFailure("Verify QuickClaimSearch in home page", "Element is displayed", this.SCREENSHOTFILE);
            }
            else
            {
                this.TESTREPORT.LogSuccess("Verify QuickClaimSearch in home page", string.Format("Element:<mark>{0}</mark> not present", "QuickClaimSearch"));

            }
        }

        public void VerifyClaimInquiryResultsPageSize(string ExpectedPageSizevalue)
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("Validate the number of claims populated for Claim Search");
            string ActualpageSizevalue = this.driver.GetElementAttribute(byClaimInquirypageSizeField, "value");
            this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);

        }

        public void VerifyPaymentTabResultsPageSize(string ExpectedPageSizevalue)
        {
            this.TESTREPORT.LogInfo("Validate the number of results populated for Payments Tab");
            Thread.Sleep(2000);

            if (this.driver.IsElementPresent(byPaymentsTabResultsBlankData))
            {
                this.TESTREPORT.LogInfo("No data to display");
            }
            else
            {
                string ActualpageSizevalue = this.driver.GetElementAttribute(byPaymentTabResultsPageSize, "value");
                this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);
            }

        }

        public void VerifyDiaryTabResultsPageSize(string ExpectedPageSizevalue)
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("Validate the number of results populated for Diary Tab");

            if (this.driver.IsElementPresent(byDiaryTabResultsBlankData))
            {
                this.TESTREPORT.LogInfo("There are no diary / note entries for this claim");
            }
            else
            {
                string ActualpageSizevalue = this.driver.GetElementAttribute(byDiaryTabResultsPageSize, "value");
                this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);
            }

        }

        public void VerifyLogNotesTabResultsPageSize(string ExpectedPageSizevalue)
        {
            this.TESTREPORT.LogInfo("Validate the number of results populated for logNotes Tab");
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byLogNotesTabResultsBlankData))
            {
                this.TESTREPORT.LogInfo("There are no available log notes for this claim");
            }
            else
            {
                string ActualpageSizevalue = this.driver.GetElementAttribute(byLogNotesTabResultsPageSize, "value");
                this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);
            }

        }

        public void VerifyLineofBusiness(string ExpectedLineofBusinessvalue)
        {
            this.TESTREPORT.LogInfo("Validate the Line of Business");
            string ActualLineofBusinessvalue = this.driver.GetElementAttribute(bylineofBusinessinclaimField, "value");
            this.driver.AssertTextMatching(ActualLineofBusinessvalue, ExpectedLineofBusinessvalue);
        }

        public void ClickonClaim()
        {
            By byClaimInquiryDraggedResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
            this.driver.ClickRandomCliamNumber(byClaimInquiryDraggedResultsTable, 3);
        }

        public void VerifyClaimstatus(string ExpectedClaimStatusvalue)
        {
            this.TESTREPORT.LogInfo("Validate the Line of Business");
            string ActualClaimstatusvalue = this.driver.GetElementAttribute(byClaimStatusinclaimField, "value");
            this.driver.AssertTextMatching(ActualClaimstatusvalue, ExpectedClaimStatusvalue);

        }


        public void VerifyImportantInformationPleaseReadText()
        {
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byImportantInformationPleaseReadtext))
            {
                this.TESTREPORT.LogSuccess("Verify Important Information Please Read text", string.Format("Successfully verified<mark>{0}</mark>", "Important Information Please Read"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Important Information Please Read text", "Element not present");
            }
        }


        public void VerifyOSHATabResultsPageSize(string ExpectedPageSizevalue)
        {
            this.TESTREPORT.LogInfo("Validate the number of results populated for OSHA Tab");
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byOSHATabResultsBlankData))
            {
                this.TESTREPORT.LogInfo("There are no available log notes for this claim");
            }
            else
            {
                string ActualpageSizevalue = this.driver.GetElementAttribute(byOSHATabResultsPageSize, "value");
                this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);
            }

        }

        public void ClickPolicyLinkinTableHeader()
        {
            this.driver.ClickElement(byPolicyLink, "CLick on policy link");
            Thread.Sleep(2000);
        }

        public void VerifyPolicyTabResultsPageSize(string ExpectedPageSizevalue)
        {
            this.TESTREPORT.LogInfo("Validate the number of results populated for policy Tab");
            string ActualpageSizevalue = this.driver.GetElementAttribute(byPolicyTabResultsPageSize, "value");

            this.driver.AssertTextMatching(ActualpageSizevalue, ExpectedPageSizevalue);


        }

        public ArrayList GetSelectedDraggeditems()
        {
            ArrayList a = new ArrayList();
            IReadOnlyList<IWebElement> DraggedItems = this.driver.FindElements(By.XPath("//table[@id='MainContent_cbPanel_GridTo_DXMainTable']//tr[contains(@class,'dxgvDataRow')]"));
            foreach (var item in DraggedItems)
            {
                a.Add(item.Text);
            }
            return a;
        }

        public void CheckClaimInquiryTableHeaders(string ExpectedTableHeader)
        {
            this.TESTREPORT.LogInfo("Check the Column headers under the Detailed Claim List");
            By byTableHeaders = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//th[contains(@class,'dxgvHeader')]//a[@onmousedown='event.cancelBubble = true']");
            IReadOnlyList<IWebElement> tableheaders = this.driver.FindElements(byTableHeaders);
            foreach (var item in tableheaders)

            {
                if (item.Text.Equals(ExpectedTableHeader))
                {
                    this.TESTREPORT.LogSuccess("Verify Table Header in ClaimInquiryPage", string.Format("successfully verified :<mark>{0}</mark>", item.Text));
                    break;
                }
            }

        }

        public void VerifyDefaultAccountselectedinHomePage(string Expectedvalue)
        {
            this.TESTREPORT.LogInfo("verify default account in home page");
            By byDefaultAccountinHomePage = By.XPath("//input[@id='MainContent_sppage_gridaccount_I']");
            string Actualvalue = this.driver.GetElementAttribute(byDefaultAccountinHomePage, "value");
            this.driver.AssertTextMatching(Actualvalue, Expectedvalue);
        }

        public void ClickResetSettings()
        {
            this.driver.ClickElement(byResetSettings, "CLick on Reset Settings");
            Thread.Sleep(4000);
        }

    }
}
