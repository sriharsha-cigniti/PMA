using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using System.Windows.Forms;
using StandardUtilities;

namespace AutomatedTest.FunctionalTests.PMA.HomeModule

{
    [TestClass]

    public class HomePageTests : PMA.TestBaseTemplate
    {
        //TestCase HM_1
        //TestCase Title : verify Default ACcountm        
        HomePage home = new HomePage();
        
        [TestMethod, Description("Verify Default Account"), TestCategory("Regression")]
        public void HM_01HomePage()
        {
            //string name = FileUtilities.GetCSVData("", "", 0);


            this.TESTREPORT.InitTestCase("HM_01", "Verify Default Account");

            string value = readCSV("AccountName");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
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

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
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
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            string value=home.SelectACcountDropDown();
            home.VerifyAccountHeader(value);
            home.ClickClaimInquiry();
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();
            //need to implement grid [no data to implement this step]
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
            


        }
        [TestMethod, Description("My Account - search by providing name of account  name"), TestCategory("Regression")]
        public void HM_04HomePage()
        {

            String name = "";
            this.TESTREPORT.InitTestCase("HM_04", "My Account - search by providing name of account  name");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            home.SearchMyAccout(name,"Name");
            home.VerifyAccountHeader(name);
            home.ClickClaimInquiry();
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();
            //need to implement grid [no data to implement this step]
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
            

        }
        [TestMethod, Description("My Account -Search Account by providing number of account"), TestCategory("Regression")]
        public void HM_05HomePage()
        {

            String number = "";
            this.TESTREPORT.InitTestCase("HM_05", "My Account -Search Account by providing number of account");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.ClickMyAccount();
            home.SearchMyAccout(number,"Number");
            home.VerifyAccountHeader(number);
            home.ClickClaimInquiry();
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();
            //need to implement grid [no data to implement this step]
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Home Test- Drag the columns in My Diary Section"), TestCategory("Regression")]
        public void HM_06HomePage()
        {

           this.TESTREPORT.InitTestCase("HM_06", "Home Test- Drag the columns in My Diary Section");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
            home.VerifyDate();
            home.VerifyMyDairyLabel();

            //need to implement grid [no data to implement this step]
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Home Test- Drag the columns in My Diary Section"), TestCategory("Regression")]
        public void HM_07HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_07", "Home Test- Drag the columns in My Diary Section");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            home.DragColumns("MyDairy");            
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Home Test- Drag the columns in Quick Claim Search"), TestCategory("Regression")]
        public void HM_08HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_08", "Home Test- Drag the columns in Quick Claim Search");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
            home.VerifyDate();
            home.VerifyQuickClaimSearchLabel();
            home.DragColumns("QuickClaimSearch");
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Quick Claim Search - Open and view an existing claim(Claimant number)"), TestCategory("Regression")]
        public void HM_09HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_09", "Quick Claim Search - Open and view an existing claim(Claimant number)");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
            home.SearchQuickCliamNumber("");
            home.ClickQuickClaimSearch();
            //need to implement the code           
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Quick Claim Search - Open and view an existing claim(Claimant name)"), TestCategory("Regression")]
        public void HM_10HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_10", "Quick Claim Search - Open and view an existing claim(Claimant name)");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome ESKODS");
            home.SearchQuickCliamantName("");
            home.ClickQuickClaimSearch();
            //need to implement the code           
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Quick Claim Search - Selecting an page size option from the drop down loads all claims"), TestCategory("Regression")]
        public void HM_11HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_11", "Quick Claim Search - Selecting an page size option from the drop down loads all claims");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.SearchQuickCliamantName("");
            home.ClickQuickClaimSearch();
            //need to implement the code           
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Quick Claim Search - Typing into any filter column heading and the grid view will automatically populate with related matches"), TestCategory("Regression")]
        public void HM_12HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_12", "Quick Claim Search - Typing into any filter column heading and the grid view will automatically populate with related matches");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.SearchQuickCliamantNameColumn("");
            //need to implement the code           
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Quick Claim Search - Clicking reset in the Quick Claim Search clears the search fields"), TestCategory("Regression")]
        public void HM_13HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_13", "Quick Claim Search - Clicking reset in the Quick Claim Search clears the search fields");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.SearchQuickCliamNumber("");
            home.SearchQuickCliamantName("");
            home.ClickQuickClaimSearch();
            home.ClickQuickClaimReset();                      
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Home Page Main Navigation - Click on each main menu item navigates the user to that section"), TestCategory("Regression")]
        public void HM_14HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_14", "Home Page Main Navigation - Click on each main menu item navigates the user to that section");
            //Verify that user lands on Cinch application

            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickReports();
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.ClickNewClaimEntry();
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifySelectLineOfBusinessLable();
            home.ClickOsha();
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.ClickTools();
            home.VerifyPageTitle("PMA Cinch");
            home.VerifyUserAdministratorLable();
            home.ClickSettings();
            home.VerifyPageTitle("Settings");
            home.VerifyDefaultAccountLable();
            home.ClickHelp();
            home.VerifyPageTitle("Cinch Help Page");
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
            

        }
        [TestMethod, Description("Home Page Main Navigation - Click on Recent Claims to see the claims details"), TestCategory("Regression")]
        public void HM_15HomePage()
        {
            this.TESTREPORT.InitTestCase("HM_15", "Home Page Main Navigation - Click on Recent Claims to see the claims details");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyRecentClaims();
            home.VerifyRecentClaimRowsCount();
            //Need to implement the script
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
    }
}

