using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using System.Windows.Forms;
using StandardUtilities;

namespace AutomatedTest.FunctionalTests.PMA

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
            this.TESTREPORT.InitTestCase("HM_01", "Verify Default Account");
            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
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
            string HomePageTitle = readCSV("HomePageTitle");
            string UserName = readCSV("UserName");
            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();            
            home.VerifyWelcomeText("Welcome "+ UserName);            
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
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            //Verify that user lands on Cinch application         
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();            
            home.ClickMyAccount();
            string value=home.SelectAccountDropDown();
            home.VerifyAccountHeader(value);            
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);           
            home.ClickSearch();
            home.ClickOnRandomClaim();
            home.VerifyClaimNumber();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();         

        }
        [TestMethod, Description("My Account - search by providing name of account"), TestCategory("Regression")]
        public void HM_04HomePage()
        {

            String name = "";
            this.TESTREPORT.InitTestCase("HM_04", "My Account - search by providing name of account");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application           
            home.VerifyPageTitle(HomePageTitle);           
            home.VerifyCinchWelome();           
            home.ClickMyAccount();          
            home.SearchMyAccout(name,"Name");            
            home.VerifyAccountHeader(name);           
            home.ClickClaimInquiry();            
            home.VerifyPageTitle("ClaimInquiryPageTitle");           
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

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();            
            home.ClickMyAccount();         
            home.SearchMyAccout(number,"Number");          
            home.VerifyAccountHeader(number);           
            home.ClickClaimInquiry();           
            home.VerifyPageTitle("ClaimInquiryPageTitle");           
            home.ClickSearch();
            //need to implement grid [no data to implement this step]           
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
        [TestMethod, Description("Home Test- Verify the claim from the diary section on homepage"), TestCategory("Regression")]
        public void HM_06HomePage()
        {

           this.TESTREPORT.InitTestCase("HM_06", "Home Test - Verify the claim from the diary section on homepage");

            //Verify that user lands on Cinch application
            string HomePageTitle = readCSV("HomePageTitle");
            string UserName = readCSV("UserName");
            //Verify that user lands on Cinch application            
            home.VerifyPageTitle(HomePageTitle);           
            home.VerifyCinchWelome();           
            home.VerifyWelcomeText("Welcome " + UserName);            
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
            string HomePageTitle = readCSV("HomePageTitle");
            string UserName = readCSV("UserName");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome " + UserName);
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            home.DragColumns("My Diary");   
            
           //home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Home Test- Drag the columns in Quick Claim Search"), TestCategory("Regression")]
        public void HM_08HomePage()
        {

            this.TESTREPORT.InitTestCase("HM_08", "Home Test- Drag the columns in Quick Claim Search");
            string HomePageTitle = readCSV("HomePageTitle");
            string UserName = readCSV("UserName");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.VerifyWelcomeText("Welcome " + UserName);
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
            string HomePageTitle = readCSV("HomePageTitle");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
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
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string ToolsPageTitle = readCSV("ToolsPageTitle");
            string SettingsPageTitle = readCSV("SettingsPageTitle");
            string HelpPageTitle = readCSV("HelpPageTitle");
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
            home.ClickOsha();
            home.VerifyPageTitle(HomePageTitle);
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
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            home.VerifyRecentClaims();
            home.ClickOnRandomClaim();
            //Need to implement the script
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
    }
}

