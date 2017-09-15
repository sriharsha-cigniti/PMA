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
using OpenQA.Selenium.Interactions;
using System.Threading;

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
        private By byQuickAccountColumn = By.XPath("//table[@id='MainContent_sppage_pnlQuickSearch_gridresult_DXMainTable']//tr//th[@id='MainContent_sppage_pnlQuickSearch_gridresult_col1']");
        private By byQuickClaimNumberColumn = By.XPath("//table[@id='MainContent_sppage_pnlQuickSearch_gridresult_DXMainTable']//tr//th[@id='MainContent_sppage_pnlQuickSearch_gridresult_col4']");
        private By byQuickClaimNumberSearch = By.Name("ctl00$MainContent$sppage$pnlQuickSearch$txtclaimnumber");
        private By byQuickClaimantNameSearch = By.Name("ctl00$MainContent$sppage$pnlQuickSearch$txtclaimantname");
        private By byQuickClaimantNameColumnSearch = By.CssSelector("input[aria-label^='Filter for Claimant Name column.']");
        private By byQuickClaimSearchBtn = By.Id("MainContent_sppage_pnlQuickSearch_btnSearch_CD");
        private By byQuickClaimResetBtn = By.Id("MainContent_sppage_pnlQuickSearch_btnreset");
        private By byRecentClaims = By.Id("MainContent_sppage_pnlRecentClaims_lblRecentClaims");
        private By byQuickClaimSearchTable = By.XPath("//table[@id='MainContent_sppage_pnlQuickSearch_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byClaimNumberinformation = By.XPath("//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_Label7_0']");
        private By byClaimNameinformation = By.XPath("//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxLabel1_0']");
        private By byClaimInquirySearchResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        
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
        private By bySelectLineOfBusinessLable = By.XPath("//label[contains(text(),'Select Line of Business:')]");
        private By byUserAdministratorLable = By.XPath("//span[contains(text(),'User Administration')]");
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
            this.TESTREPORT.LogInfo("Verify home page");
            this.driver.AssertTextMatching(this.driver.GetPageTitle(), title);
        }
        //Welcome text verification
        public void VerifyWelcomeText(string welcomeText)
        {
            this.TESTREPORT.LogInfo("Verify Welcome Text");
            string welcomeTextExpected = this.driver.GetElementText(byUserName, 60);
            this.driver.AssertTextMatching(welcomeTextExpected, welcomeText);
            
        }
        //Date verification
        public void VerifyDate()
        {
            this.TESTREPORT.LogInfo("Verify Date");
            string dateExpected = this.driver.GetElementText(byDate, 60);
            string value = DateTime.Now.ToString("dddd, MMMM dd, yyyy");            
            this.driver.AssertTextMatching(dateExpected, value);
        }
        //Verify MyDairyLabel
        public void VerifyMyDairyLabel()
        {
            this.TESTREPORT.LogInfo("Verify My Dairy Label");
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
            this.TESTREPORT.LogInfo("Verify Qick Claim Search Label");
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
            this.TESTREPORT.LogInfo("Verify default user account");
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
            this.TESTREPORT.LogInfo("Click on Exit to close the application");
            this.driver.ClickElement(byExit, "Exit", 60);
        }
       
        //Verify Account Header
        public void VerifyAccountHeader(string myAccountValue)
        {
            this.TESTREPORT.LogInfo("Verify account header");
            this.driver.AssertTextEqual(byAccountHeader, myAccountValue);

        }
        //Verify CinchWelome text
        public void VerifyCinchWelome()
        {
            this.TESTREPORT.LogInfo("Verify Welcome text ");
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
        public string SelectAccountDropDown()
        {
            this.TESTREPORT.LogInfo("Select account from dropdown");
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
            this.TESTREPORT.LogInfo("Click on Search");
            this.driver.ClickElement(bySearchButton, "Search", 60);
        }
        //click on Claim Inquiry link
        public void ClickClaimInquiry()
        {
            this.TESTREPORT.LogInfo("Click on claim inquiry");
            this.driver.ClickElement(byClaimInquiry, "Claim Inquiry", 60);
        }
        //click on my account dropdown
        public void ClickMyAccount()
        {
            this.TESTREPORT.LogInfo("Click on MyAccount");
            this.driver.ClickElement(byMyAccountButton, "My Account", 60);
        }
        //Search Account Name from Dropdown
        public void SearchMyAccout(string searchValue, string option)
        {
            this.TESTREPORT.LogInfo("Search My Account with "+searchValue);
            if (option.ToLower() =="Name".ToLower())
            {
                this.driver.SendKeysToElement(bySearchName, searchValue, "Search Name");
            }
            else
            {
                this.driver.SendKeysToElement(bySearchNumber, searchValue, "Search Number");
            }

        }
        //Drag Coulmns Headers
        public void DragColumns(string option)
        {
            this.TESTREPORT.LogInfo("Drag the columns of " + option);
            if (option=="MyDairy")
            {
                IWebElement e1 = driver.FindElement(byMyDairyAccountColumn);
                IWebElement e2 = driver.FindElement(byMyDairyDueDateColumn);
                this.driver.DragDrop(e1, e2, 60);
               
            }
            else
            {
                IWebElement e3 = driver.FindElement(byQuickAccountColumn);
                IWebElement e4 = driver.FindElement(byQuickClaimNumberColumn);
                Actions a = new Actions(driver);
                a.DragAndDrop(e3, e4).Build().Perform();


                // a.ClickAndHold(e3).MoveToElement(e4).Click(e3).Release().Build().Perform();
                //Thread.Sleep(5000);
                //a.ClickAndHold(e3).Build().Perform();
                //Thread.Sleep(5000);
                //a.Click(e4).Build().Perform();
                //a.Release(e4).Build().Perform();
                //Thread.Sleep(5000);
                //a.ClickAndHold(e3).Release(e4).Build().Perform();







              //  //String xto = integer.toString(LocatorTo.getLocation().x);
              //  //String yto = Integer.toString(LocatorTo.getLocation().y);
              //  ((IJavaScriptExecutor)driver).ExecuteScript("function simulate(f,c,d,e){var b,a=null;for(b in eventMatchers)if(eventMatchers[b].test(c)){a=b;break}if(!a)return!1;document.createEvent?(b=document.createEvent(a),a==\"HTMLEvents\"?b.initEvent(c,!0,!0):b.initMouseEvent(c,!0,!0,document.defaultView,0,d,e,d,e,!1,!1,!1,!1,0,null),f.dispatchEvent(b)):(a=document.createEventObject(),a.detail=0,a.screenX=d,a.screenY=e,a.clientX=d,a.clientY=e,a.ctrlKey=!1,a.altKey=!1,a.shiftKey=!1,a.metaKey=!1,a.button=1,f.fireEvent(\"on\"+c,a));return!0} var eventMatchers={HTMLEvents:/^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,MouseEvents:/^(?:click|dblclick|mouse(?:down|up|over|move|out))$/}; " +
              //  "simulate(arguments[0],\"mousedown\",0,0); simulate(arguments[0],\"mousemove\",arguments[1],arguments[2]); simulate(arguments[0],\"mouseup\",arguments[1],arguments[2]); "
              //, e3, e4); 


                // a.ClickAndHold(e3).MoveToElement(e4).Release(e4).Build().Perform();
                Thread.Sleep(8000);
                //this.driver.DragDrop(e3, e4, 60);
            }
        }

        public void SearchQuickCliamNumber(string cliamNumber)
        {
            this.TESTREPORT.LogInfo("Search Quick Claim Number");
            this.driver.SendKeysToElement(byQuickClaimNumberSearch, cliamNumber, "CliamNumber");
        }
        public void SearchQuickCliamantName(string cliamantName)
        {
            this.TESTREPORT.LogInfo("Search Quick Claimant Name");
            this.driver.SendKeysToElement(byQuickClaimantNameSearch, cliamantName, "cliamantName");
        }
        public void SearchQuickCliamantNameColumn(string cliamantName)
        {
            this.TESTREPORT.LogInfo("Filter Quick Claimant name coulmn");
            this.driver.SendKeysToElement(byQuickClaimantNameColumnSearch, cliamantName, "cliamantName");
        }
        public void ClickQuickClaimSearch()
        {
            this.TESTREPORT.LogInfo("Click on Quick cliam search button");
            this.driver.ClickElement(byQuickClaimSearchBtn, "Search");
        }
        public void ClickQuickClaimReset()
        {
            this.TESTREPORT.LogInfo("Click on Reset to clear the values in Quick Claim Number");
            this.driver.ClickElement(byQuickClaimResetBtn, "Reset");
        }
        public void ClickReports()
        {
            this.TESTREPORT.LogInfo("Click on Reports menu");
            this.driver.ClickElement(byReports, "Reports", 60);
        }
        public void ClickNewClaimEntry()
        {
            this.TESTREPORT.LogInfo("Click on New Claim Entry menu");
            this.driver.ClickElement(byNewClaimEntry, "New Claim Entry", 60);
        }

        public void ClickOsha()
        {
            this.TESTREPORT.LogInfo("Click on OSHA menu");
            this.driver.ClickElement(byOsha, "OSHA", 60);
        }
        public void ClickTools()
        {
            this.TESTREPORT.LogInfo("Click on Tools menu");
            this.driver.ClickElement(byTools, "Tools", 60);
        }
        public void ClickSettings()
        {
            this.TESTREPORT.LogInfo("Click on Settings menu");
            this.driver.ClickElement(bySettings, "Settings", 60);
        }
        public void ClickHelp()
        {
            this.TESTREPORT.LogInfo("Click on Help menu");
            this.driver.ClickElement(byHelp, "Help", 60);
        }

        public void VerifySelectLineOfBusinessLable()
        {
            try
            {
                this.TESTREPORT.LogInfo(" Verifying Select Line of Business Lable");
                this.driver.SwitchTo().Frame("MainContent_ASPxSplitter1_0_CC");
                bool flag = this.driver.IsElementPresent(bySelectLineOfBusinessLable);
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify Select Line of Business Label", String.Format(" Successfully verified - <Mark>{0}</Mark>",""));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Select Line of Business Label", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
                }
                this.driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            { }
        }

        public void VerifyUserAdministratorLable()
        {
            this.TESTREPORT.LogInfo(" Verifying User Administrator Lable");
            bool flag = this.driver.IsElementPresent(byUserAdministratorLable);
            try
            {
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify User Administrator Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>",""));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify User Administrator Lable", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            { }
        }
        public void VerifyDefaultAccountLable()
        {
            this.TESTREPORT.LogInfo(" Verifying Default Account Lable");
            bool flag = this.driver.IsElementPresent(byDefaultAccountLable);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Default Account Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>",""));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Default Account Lable", String.Format("Failed to Verify Label"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyRecentClaims()
        {
            this.TESTREPORT.LogInfo(" Verifying Recent Claim Lable");
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

        public string ClickOnRandomClaim()
        {
          
            return this.driver.clickRandomCliamNumber(byClaimInquirySearchResultsTable);
        }

        public void VerifyClaimNumber()
        {
            string claimnumber = this.driver.GetElementText(byClaimNameinformation);
            this.driver.AssertTextMatching(ClickOnRandomClaim(), claimnumber);
           
        }
    }
    
    #endregion

}

