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
        string accountName , strAccount = null;

        #region UI Objects

        private By byMyAccount = By.XPath("//input[@id='MainContent_sppage_gridaccount_I']");
        private By byAccountHeader = By.Id("lblAccount1");
        private By byUserName = By.Id("lblusername");
        private By byDate = By.Id("lbldate");
        private By byCinchWelcome = By.XPath("//span[text()='Welcome to PMA Cinch']");
        private By byMydiary = By.XPath("//label[text()='My Diary']");
        private By byQuickCliamSearch = By.CssSelector("div[id='MainContent_sppage_pnlQuickSearch']>table");
        
        private By byMyAccountButton = By.Id("MainContent_sppage_gridaccount_B-1");
        private By byMyAccountTable = By.XPath("//table[@id='MainContent_sppage_gridaccount_DDD_gv_DXMainTable']/tbody/tr[contains(@id,'MainContent_sppage_gridaccount_DDD_gv_DXDataRow')]");
       
        private By bySearchButton = By.XPath("//span[text()='S E A R C H']");
        private By bySearchName= By.Id("MainContent_sppage_gridaccount_DDD_gv_DXFREditorcol0_I");
        private By bySearchNumber = By.Id("MainContent_sppage_gridaccount_DDD_gv_DXFREditorcol1_I");
        private By byMyDairyAccountColumn = By.XPath("//tr[@id='MainContent_sppage_pnlDiary_griddiary_DXHeadersRow0']//a[text()='Account Name']");
        private By byMyDairyDueDateColumn = By.XPath("//tr[@id='MainContent_sppage_pnlDiary_griddiary_DXHeadersRow0']//a[text()='Due Date']");
        private By byQuickAccountColumn = By.XPath("//tr[@id='MainContent_sppage_pnlQuickSearch_gridresult_DXHeadersRow0']//a[text()='Account Name']");
        private By byQuickClaimNumberColumn = By.XPath("//tr[@id='MainContent_sppage_pnlQuickSearch_gridresult_DXHeadersRow0']//a[text()='Claim Number']");
        private By byQuickClaimNumberSearch = By.Name("ctl00$MainContent$sppage$pnlQuickSearch$txtclaimnumber");
        private By byQuickClaimantNameSearch = By.Name("ctl00$MainContent$sppage$pnlQuickSearch$txtclaimantname");
        private By byQuickClaimantNameColumnSearch = By.CssSelector("input[aria-label^='Filter for Claimant Name column.']");
        private By byQuickClaimSearchBtn = By.Id("MainContent_sppage_pnlQuickSearch_btnSearch_CD");
        private By byQuickClaimResetBtn = By.Id("MainContent_sppage_pnlQuickSearch_btnreset");
        private By byRecentClaims = By.Id("MainContent_sppage_pnlRecentClaims_lblRecentClaims");

        //header links
        private By byClaimInquiry = By.LinkText("Claim Inquiry");
        private By byReports = By.LinkText("Reports");
        private By byNewClaimEntry = By.LinkText("New Claim Entry");
        private By byOsha = By.LinkText("OSHA");
        private By byPolicy = By.LinkText("Policy");
        private By byTools = By.LinkText("Tools");
        private By bySettings = By.LinkText("Settings");
        private By byHelp = By.LinkText("Help");
        private By byExit = By.LinkText("Exit");
        private By bySelectLineOfBusinessLable = By.Id("MainContent_ASPxLabel13");
        private By byUserAdministratorLable = By.Id("MainContent_ASPxLabel1");
        private By byDefaultAccountLable = By.Id("MainContent_lblgridaccount");
        private By byRecentClaimRows = By.XPath("//table[@id='MainContent_sppage_pnlRecentClaims_gridRecentClaims']//tr[contains(@class,'dxgvDataRow')]");



        #endregion

        #region public methods
        //Get the Account Value from dropdown
        public string GetMyAccount()
        {
            accountName = this.driver.GetElementAttribute(this.byMyAccount, "value");
            return accountName;
        }
        //Verify Page Title
        public void VerifyPageTitle(string title)
        {
            this.driver.AssertTextMatching(this.driver.GetPageTitle(), title);
        }
        //Welcome text verification
        public void VerifyWelcomeText(string welcomeText)
        {
            string welcomeTextExpected = this.driver.GetElementText(byUserName, 60);
            this.driver.AssertTextMatching(welcomeTextExpected, welcomeText);
            
        }
        //Date verification
        public void VerifyDate()
        {
            string dateExpected = this.driver.GetElementText(byDate, 60);
            string value = DateTime.Now.ToString("dddd, MMMM dd, yyyy");            
            this.driver.AssertTextMatching(dateExpected, value);
        }
        //Verify MyDairyLabel
        public void VerifyMyDairyLabel()
        {
           bool flag= this.driver.IsElementPresent(byMydiary);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify MyDairyLabel", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify MyDairyLabel", String.Format(" failed to verify label"), this.SCREENSHOTFILE);
            }
        }
        //Verify QuickClaimSearchLabel
        public void VerifyQuickClaimSearchLabel()
        {
            bool flag=this.driver.IsElementPresent(byQuickCliamSearch);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify QuickClaim SearchLabel", String.Format("Succefully verified label"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify QuickClaim SearchLabel", String.Format(" failed to verify label"), this.SCREENSHOTFILE);
            }
        }
        //Verify Default Account in DropDown
        public void VerifyDefaultUserAccount(string useraccount)
        {
            if (useraccount.Length>0)
            {
                this.TESTREPORT.LogSuccess("My Account", String.Format(" accountname - <Mark>{0}</Mark>", accountName));
            }
            else
            {
                this.TESTREPORT.LogFailure("My Account", String.Format( "No Account was selected by default"), this.SCREENSHOTFILE);
            }

        }
        //click on Exit link
        public void ClickExit()
        {
            this.driver.ClickElement(byExit, "Exit", 60);
        }
       
        //Verify Account Header
        public void VerifyAccountHeader(string myAccountValue)
        {
            this.driver.AssertTextEqual(byAccountHeader, myAccountValue);

        }
        //Verify CinchWelome text
        public void VerifyCinchWelome()
        {
            bool flag=this.driver.IsElementPresent(byCinchWelcome);
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify Cinch welcome text ", String.Format("Succefully verified"));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Cinch welcome text", String.Format("Failed to verify text"), this.SCREENSHOTFILE);
                }
        }
        //Select Random value from Drop down
        public string SelectACcountDropDown()
        {
            string selectedValue = null;
            try
            {
                Random rnd = new Random();

                IReadOnlyList<IWebElement> list = this.driver.FindElements(byMyAccountTable);
                int value = rnd.Next(0, list.Count);
                list[value].Click();
                selectedValue = this.driver.GetElementText(byAccountHeader);
                this.TESTREPORT.LogSuccess("Select Random Account from the Account dropdown", String.Format(" Account - {0} is selcted succesfully",list[value]));
            }
            catch
            {
                this.TESTREPORT.LogFailure("Select Random Account from the Account dropdown", String.Format("Account not selected", this.SCREENSHOTFILE));
                    
            }
            return selectedValue;
        }
        //click on Search
        public void ClickSearch()
        {
            this.driver.ClickElement(bySearchButton, "Search", 60);
        }
        //click on Claim Inquiry link
        public void ClickClaimInquiry()
        {
            this.driver.ClickElement(byClaimInquiry, "Claim Inquiry", 60);
        }
        //click on my account dropdown
        public void ClickMyAccount()
        {
            this.driver.ClickElement(byMyAccountButton, "My Account", 60);
        }
        //Search Account Name from Dropdown
        public void SearchMyAccout(string searchValue, string option)
        {
            if (option.ToLower() =="Name".ToLower())
            {
                this.driver.SendKeysToElement(bySearchName, searchValue, "Search Name");
            }
            else
            {
                this.driver.SendKeysToElement(bySearchNumber, searchValue, "Search Name");
            }

        }
        //Drag Coulmns Headers
        public void DragColumns(string option)
        {   if(option=="MyDairy")
            {
                this.driver.Drag(byMyDairyAccountColumn, byMyDairyDueDateColumn, 60);
            }
            else
            {
                this.driver.Drag(byQuickAccountColumn, byQuickClaimNumberColumn, 60);
            }
        }

        public void SearchQuickCliamNumber(string cliamNumber)
        {
            this.driver.SendKeysToElement(byQuickClaimNumberSearch, cliamNumber, "CliamNumber");
        }
        public void SearchQuickCliamantName(string cliamantName)
        {
            this.driver.SendKeysToElement(byQuickClaimantNameSearch, cliamantName, "cliamantName");
        }
        public void SearchQuickCliamantNameColumn(string cliamantName)
        {
            this.driver.SendKeysToElement(byQuickClaimantNameColumnSearch, cliamantName, "cliamantName");
        }
        public void ClickQuickClaimSearch()
        {
            this.driver.ClickElement(byQuickClaimSearchBtn, "Search");
        }
        public void ClickQuickClaimReset()
        {
            this.driver.ClickElement(byQuickClaimResetBtn, "Reset");
        }
        public void ClickReports()
        {
            this.driver.ClickElement(byReports, "Reports", 60);
        }
        public void ClickNewClaimEntry()
        {
            this.driver.ClickElement(byNewClaimEntry, "New Claim Entry", 60);
        }

        public void ClickOsha()
        {
            this.driver.ClickElement(byOsha, "OSHA", 60);
        }
        public void ClickTools()
        {
            this.driver.ClickElement(byTools, "Tools", 60);
        }
        public void ClickSettings()
        {
            this.driver.ClickElement(bySettings, "Settings", 60);
        }
        public void ClickHelp()
        {
            this.driver.ClickElement(byHelp, "Help", 60);
        }

        public void VerifySelectLineOfBusinessLable()
        {
           bool flag = this.driver.IsElementPresent(bySelectLineOfBusinessLable);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Select Line of Business Label", String.Format(" Successfully verified - <Mark>{0}</Mark>"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Select Line of Business Label", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyUserAdministratorLable()
        {
            bool flag = this.driver.IsElementPresent(byUserAdministratorLable);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify User Administrator Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify User Administrator Lable", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
            }
        }
        public void VerifyDefaultAccountLable()
        {
            bool flag = this.driver.IsElementPresent(byDefaultAccountLable);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Default Account Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Default Account Lable", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyRecentClaims()
        {
            bool flag = this.driver.IsElementPresent(byRecentClaims);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Recent Claim Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Recent Claim Lable", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
            }
        }

        public string VerifyRecentClaimRowsCount()
        {
            IReadOnlyList < IWebElement> rows= this.driver.FindElements(byRecentClaimRows); 
            Random rd = new Random();
            int value=rd.Next(0, rows.Count);
            string rowvalue = null;

            if(rows[value].Displayed)
            {
                rowvalue = rows[value].FindElement(By.XPath("//td[0]")).Text;
                rows[value].Click();

                this.TESTREPORT.LogSuccess("Click on Recent Claim Random Number", String.Format(" Successfully Clicked on - <Mark>{0}</Mark> ", rowvalue));
            }
            else
            {
                this.TESTREPORT.LogFailure("Click on Recent Claim Random Number", String.Format("NO Recent Claims Available "), this.SCREENSHOTFILE);
            }
            return rowvalue;
        }
    }
    
    #endregion

}

