using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using System.Windows.Forms;
using StandardUtilities;
using System.Collections.Generic;
using System.Collections;

namespace AutomatedTest.FunctionalTests.PMA

{
    //Home Page Tests
    [TestClass]

    public class HomePageTests : PMA.TestBaseTemplate
    {      
         
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string ClaimInquiryPageTitle { get; set; }
        public static string name { get; set; }
        public static string AccountNumber { get; set; }
        public static string ClaimNumber { get; set; }
        public static string ClaimantName { get; set; }
        public static string PageSize { get; set; }
        public static string ClaimType { get; set; }
        public static string ToolsPageTitle { get; set; }
        public static string SettingsPageTitle { get; set; }
        public static string HelpPageTitle { get; set; }
        #endregion

        public HomePageTests()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            name = readCSV("AccountName");
            AccountNumber = readCSV("AccountNumber");
            ClaimNumber = readCSV("ClaimNumber");
            ClaimantName = readCSV("ClaimantName");
            PageSize = readCSV("PageSize");
            ClaimType = readCSV("ClaimType");
            ToolsPageTitle = readCSV("ToolsPageTitle");
            SettingsPageTitle = readCSV("SettingsPageTitle");
            HelpPageTitle = readCSV("HelpPageTitle");
        }

        [TestMethod, Description("Verify Default Account"), TestCategory("Regression")]
        public void HM_01HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_01", "Verify Default Account");
            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            string myAccountName = home.GetMyAccount();
            //verify Default User account field
            home.VerifyDefaultUserAccount(myAccountName);
            //verify Account header
            home.VerifyAccountHeader(myAccountName);
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Verify My Diary and Quick Claim search"), TestCategory("Regression")]
        public void HM_02HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_02", "Verify My Diary and Quick Claim search");
            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            home.VerifyQuickClaimSearchLabel();
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("My Account - Select account from the my accounts pane"), TestCategory("Regression")]
        public void HM_03HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_03", "My Account - Select account from the my accounts pane");

            //Verify that user lands on Cinch application         
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            string AccountName = home.GetMyAccount();
            string value = home.SelectAccountDropDown();
            home.VerifyAccountHeader(value);
            if (home.ClickClaimInquiry())
            {
                home.VerifyPageTitle(ClaimInquiryPageTitle);
                home.ClickSearch();
                int count = home.ClaimInquiryResultsCount();
                if (count != 0)
                {
                    ArrayList Index = home.ClickOnRandomClaim();
                    home.VerifyClaimNumber(Index[0].ToString());
                    home.VerifyAccountName(AccountName);
                }
            }
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("My Account - search by providing name of account"), TestCategory("Regression")]
        public void HM_04HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_04", "My Account - search by providing name of account");

            //Verify that user lands on Cinch application           
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            string AccountName = home.GetMyAccount();
            home.SearchMyAccout(name, "Name");
            home.VerifyAccountHeader(name);
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyAccountName(AccountName);
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("My Account -Search Account by providing number of account"), TestCategory("Regression")]
        public void HM_05HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_05", "My Account -Search Account by providing number of account");

            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            home.SearchMyAccout(AccountNumber, "Number");
            string myAccountName = home.GetMyAccount();
            home.VerifyAccountHeader(myAccountName);
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
           // home.VerifyClaimantName(Index[1].ToString());
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Home Test- Verify the claim from the diary section on homepage"), TestCategory("Regression")]
        public void HM_06HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_06", "Home Test - Verify the claim from the diary section on homepage");

            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            home.VerifyandSelectMyDiary();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Home Test- Drag the columns in My Diary Section"), TestCategory("Regression")]
        public void HM_07HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_07", "Home Test- Drag the columns in My Diary Section");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            int columnPositionBeforeDrag = home.getColumnPositionInMYDiary("Account Name");
            home.DragAccountNameInMyDiary();
            int columnPositionAfterDrag = home.getColumnPositionInMYDiary("Account Name");
            nce.VerifySwappingcellsposition("Account Name", columnPositionBeforeDrag, columnPositionAfterDrag);

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Home Test- Drag the columns in Quick Claim Search"), TestCategory("Regression")]
        public void HM_08HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_08", "Home Test- Drag the columns in Quick Claim Search");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);
            home.VerifyDate();
            home.VerifyQuickClaimSearchLabel();
            int columnPositionBeforeDrag = home.getColumnPositionInClaimSearch("Account Name");
            home.DragAccountNameToClaimNumberInQCS();
            int columnPositionAfterDrag = home.getColumnPositionInClaimSearch("Account Name");
            nce.VerifySwappingcellsposition("Account Name", columnPositionBeforeDrag, columnPositionAfterDrag);

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Quick Claim Search - Open and view an existing claim(Claimant number)"), TestCategory("Regression")]
        public void HM_09HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_09", "Quick Claim Search - Open and view an existing claim(Claimant number)");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);

            home.EnterQuickClaimNumber(ClaimNumber);
            home.ClickQuickClaimSearch();
            ArrayList Index = home.ClickOnRandomQuickClaim();
            home.VerifyQuickClaimNumber(Index[0].ToString());
            // home.VerifyQuickClaimAccountName(Index[2].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Quick Claim Search - Open and view an existing claim(Claimant name)"), TestCategory("Regression")]
        public void HM_10HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_10", "Quick Claim Search - Open and view an existing claim(Claimant name)");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            this.TESTREPORT.LogInfo(string.Format("UserName : {0}", Environment.UserName));
            home.VerifyWelcomeText("Welcome " + Environment.UserName);
            home.SearchQuickCliamantName(ClaimantName);
            home.ClickQuickClaimSearch();
            ArrayList Index = home.ClickOnRandomQuickClaim();
            home.VerifyQuickClaimNumber(Index[0].ToString());
            home.VerifyRecentClaimantName(Index[1].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Quick Claim Search - Selecting an page size option from the drop down loads all claims"), TestCategory("Regression")]
        public void HM_11HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_11", "Quick Claim Search - Selecting an page size option from the drop down loads all claims");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.SearchQuickCliamantName(ClaimantName);
            home.ClickQuickClaimSearch();
            home.ClickQuickClaimPagesizeBtn();
            string value = home.SelectQuickClaimPageSizeDropDownvalue();
            home.QuickClaimResultsCount(value);
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Quick Claim Search - Typing into any filter column heading and the grid view will automatically populate with related matches"), TestCategory("Regression")]
        public void HM_12HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_12", "Quick Claim Search - Typing into any filter column heading and the grid view will automatically populate with related matches");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.EnterQuickClaimType(ClaimType);
            ArrayList Type = home.ClickOnRandomQuickClaim();
            home.VerifyQuickClaimType(Type[3].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Quick Claim Search - Clicking reset in the Quick Claim Search clears the search fields"), TestCategory("Regression")]
        public void HM_13HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_13", "Quick Claim Search - Clicking reset in the Quick Claim Search clears the search fields");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.EnterQuickClaimNumber(ClaimNumber);
            home.SearchQuickCliamantName(ClaimantName);
            home.ClickQuickClaimSearch();
            home.ClickQuickClaimReset();
            home.VerifyFieldsAfterReset();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Home Page Main Navigation - Click on each main menu item navigates the user to that section"), TestCategory("Regression")]
        public void HM_14HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_14", "Home Page Main Navigation - Click on each main menu item navigates the user to that section");

            //Verify that user lands on Cinch application

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //home.ClickReports();
            //home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.ClickNewClaimEntry();

            home.VerifyPageTitle(HomePageTitle);
            System.Threading.Thread.Sleep(3000);

            home.VerifySelectLineOfBusinessLable();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            home.VerifyUserAdministratorLable();
            home.ClickSettings();
            home.VerifyPageTitle(SettingsPageTitle);
            home.VerifyDefaultAccountLable();
            home.ClickHelp();
            home.VerifyPageTitle(HelpPageTitle);
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Home Page Main Navigation - Click on Recent Claims to see the claims details"), TestCategory("Regression")]
        public void HM_15HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_15", "Home Page Main Navigation - Click on Recent Claims to see the claims details");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            home.VerifyRecentClaimsLable();
            home.RecentClaimsTableCount();
            ArrayList value = home.ClickOnRandomRecentClaim();
            // home.VerifyRecentClaimNumber(value[1].ToString());
            home.VerifyRecentClaimantName(value[0].ToString());
            home.VerifyRecentAccidentDate(value[1].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
    }
}

