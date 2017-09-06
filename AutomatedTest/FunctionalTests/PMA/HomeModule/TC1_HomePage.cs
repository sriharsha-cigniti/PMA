using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using System.Windows.Forms;

namespace AutomatedTest.FunctionalTests.HomeModule

{
    [TestClass]

    public class AddProject : PMA.TestBaseTemplate
    {
        //TestCase HM_1
        //TestCase Title : verify Default ACcountm        
        HomePage home = new HomePage();
        
        [TestMethod, Description("Verify Default Account"), TestCategory("Regression")]
        public void HM01_HomePage()
        {

            
            this.TESTREPORT.InitTestCase("HM_01", "Verify Default Account");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            home.VerifyCinchWelome();
            string myAccountName = home.GetMyAccount();

            //verify Default User account field
            home.VerifyDefaultUserAccount(myAccountName);
            
            //verify Account header
            home.VerifyAccountHeader("");

            this.TESTREPORT.UpdateTestCaseStatus();
            


        }
        [TestMethod, Description("Verify My Diary and Quick Claim search"), TestCategory("Regression")]
        public void HM02_HomePage()
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
            home.VerifyDate();
            home.VerifyMyDairyLabel();
            home.DragMyDairyColumns();

            //need to implement grid [no data to implement this step]
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }
    }
}

