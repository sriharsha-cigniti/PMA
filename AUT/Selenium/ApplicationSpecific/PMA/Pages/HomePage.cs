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
        private By byAccountHeader = By.XPath("//span[@id='lblAccount1']");
        private By byUserName = By.XPath("//span[@id='lblusername']");
        private By byDate = By.XPath("//span[@id='lbldate']");
        private By byCinchWelcome = By.XPath("//span[text()='Welcome to PMA Cinch']");
        private By byMydiary = By.XPath("//label[text()='My Diary']");
        private By byQuickCliamSearch = By.CssSelector("div[id='MainContent_sppage_pnlQuickSearch']>table");
        private By byExit = By.LinkText("Exit");
        private By byMyAccountButton = By.Id("MainContent_sppage_gridaccount_B-1");
        private By byMyAccountTable = By.XPath("//table[@id='MainContent_sppage_gridaccount_DDD_gv_DXMainTable']/tbody/tr[contains(@id,'MainContent_sppage_gridaccount_DDD_gv_DXDataRow')]");
        private By byClaimInquiry = By.LinkText("Claim Inquiry");
        private By bySearchButton = By.XPath("//span[text()='S E A R C H']");
        private By bySearchName= By.Id("MainContent_sppage_gridaccount_DDD_gv_DXFREditorcol0_I");
        private By bySearchNumber = By.Id("MainContent_sppage_gridaccount_DDD_gv_DXFREditorcol1_I");
        private By byMyDairyColmns = By.XPath("//table[@id='MainContent_sppage_pnlDiary_griddiary_DXMainTable']//table");

        #endregion

        #region public methods

        public string GetMyAccount()
        {
            
            accountName = this.driver.GetElementAttribute(this.byMyAccount, "value");
            return accountName;
        }

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
            this.driver.AssertTextMatching(dateExpected, String.Format("{0:D}", DateTime.Now));
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
        public void VerifyDefaultUserAccount(string useraccount)
        {
            if (useraccount.Length>0)
            {
                this.TESTREPORT.LogSuccess("My Account", String.Format(" accountname - <Mark>{0}</Mark>", accountName),this.SCREENSHOTFILE);
            }
            else
            {
                this.TESTREPORT.LogFailure("My Account", String.Format( "No Account was selected by default"), this.SCREENSHOTFILE);
            }

        }
        //click on EXit link
        public void ClickExit()
        {
            this.driver.ClickElement(byExit, "Exit", 60);
        }

        public void VerifyAccountHeader(string myAccountValue)
        {
            this.driver.AssertTextEqual( byAccountHeader, myAccountValue);

        }

        //Verify CinchWelome text
        public void VerifyCinchWelome()
        {
            this.driver.IsElementPresent(byQuickCliamSearch);
        }
        
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
                this.TESTREPORT.LogSuccess("Select an Account from the Account dropdown", String.Format("An Account is selcted succesfully"));
            }
            catch
            {
                this.TESTREPORT.LogFailure("Select an Account from the Account dropdown", String.Format("Account not selected", this.SCREENSHOTFILE));
                    
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
        //
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

        public void DragMyDairyColumns()
        {
            IReadOnlyList<IWebElement> columns = this.driver.FindElements(byMyDairyColmns);
            //this.driver.Drag(columns[0].FindElement(By.XPath("")), columns[0].FindElement(By.XPath("")), 60);
        }

    }

    


    //public string UserName()
    //{
    //    string username = this.driver.GetElementText(this.byUserName);
    //    return username;
    //}

    //public string Date()
    //{
    //    string date = this.driver.GetElementText(this.bydate);
    //    return date;
    //}

    //public string MyDiary()
    //{
    //    string account = this.driver.GetElementText(this.byMydiary);
    //    return account;
    //}

    //public string QuickClaimSearch()
    //{
    //    string account = this.driver.GetElementText(this.byquickCliamsearch);
    //    return account;
    //}

    //public void VerifyLoggedUser(string userName)
    //{
    //    //this.driver.IsElementPresent(this.byUserName);
    //    string currentUser = this.driver.GetElementText(this.byUserName);
    //    //string currentDate = this.driver.GetElementText(this.bydate);
    //    ////string systemDate = String.Format("{0:D}", System.DateTime.Now);
    //    //List<string> date1 = currentDate.Split(',').ToList();
    //    //string year = System.DateTime.Now.Year.ToString();
    //    //string date = String.Format("{0:m}", System.DateTime.Now);
    //    //List<string> date2 = currentDate.Split(" ");
    //    //if (currentUser.Contains(userName) && date1[1].Equals(date) && date1[2].Equals(year))

    //    if (currentUser.Contains(userName))
    //    {
    //        TESTREPORT.LogSuccess("UserName should be displayed", String.Format("UserName is displayed on Home Page"));
    //    }
    //    else
    //    {
    //        TESTREPORT.LogFailure("UserName should be displayed", String.Format("UserName is not displayed on Home ssPage"));
    //    }
    //}





    #endregion

}

