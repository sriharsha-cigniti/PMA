using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandardUtilities;
using OpenQA.Selenium;
using System.Collections;
using System.Threading;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class SettingsPageTest : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string SettingsPageTitle { get; set; }
        public static string ClaimInquiryPageTitle { get; set; }
        public static string DefaultAccountvalue { get; set; }
        public static string DataSaveMessage { get; set; }
        #endregion

        public SettingsPageTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            SettingsPageTitle = readCSV("SettingsPageTitle");
            ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            DefaultAccountvalue = readCSV("DefaultAccountvalue");
            DataSaveMessage = readCSV("DataSaveMessage");

        }

        [TestMethod, Description("Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void Settings_01settingsPage()
        {

            this.TESTREPORT.InitTestCase("Settings_01", "Navigate to the Settings area and set a default account");
            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //Click on Setting tab            
            home.ClickSettings();
            //Verify Settings page title
            home.VerifyPageTitle(SettingsPageTitle);
            // Select Default value from DropDown        
            settingsPage.SelectDefaultAccount(DefaultAccountvalue);
            //Click on Save to save the modified settings  
            settingsPage.SaveSettings();
            //Verify the Confirmation message
            settingsPage.VerifyDataSaveMessage(DataSaveMessage);
            string accountDetails = settingsPage.GetAccountDetails();
            //Click on EXit to apply the changes
            home.ClickExit();
            this.TESTREPORT.LogInfo("Re-Login into application");
            //Re-Launch the browser to see the applied changes
            login.OpenBrowser();
            this.TESTREPORT.LogInfo("Verify Default Account details applied");
            //Verify applied changes
            settingsPage.VerifyDefaulAccountDetailsIsApplied(accountDetails);
            //Click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }


        [TestMethod, Description("Settings-Navigate to the Settings, set preferences and confirm settings"), TestCategory("Regression")]
        public void Settings_02settingsPage()
        {
            this.TESTREPORT.InitTestCase("Settings_02", "Navigate to the Settings, set preferences and confirm settings");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            //click on settings
            home.ClickSettings();
            //verify page title
            home.VerifyPageTitle(SettingsPageTitle);
            //click on ResetSettings in settings page
            settingsPage.ClickResetSettings();

            //need to ask hina about default account selected
            settingsPage.SelectDefaultAccount(DefaultAccountvalue);

            //click HideQuickCaimsearch checkbox
            settingsPage.ClickHideQuickCliamSearchCheckbox();
            //click hidemydiary checkbox
            settingsPage.ClickHideMyDiaryCheckbox();
            //select the dropdown value for the claimlist
            settingsPage.SelectClaimlist();
            //select the dropdown value for the Payments
            settingsPage.SelectPayments();
            //select the dropdown value for the Diary
            settingsPage.SelectDiary();
            //select the dropdown value for the LogNotes
            settingsPage.SelectLogNotes();
            //select the dropdown value for the OSHASummary
            settingsPage.SelectOSHASummary();
            //select the dropdown value for the Policy
            settingsPage.SelectPolicy();
            //select line of business
            settingsPage.SelectLineofBusiness();
            //select select claim status
            settingsPage.SelectClaimStatus();
            //Drag 3 items into the selected area 
            settingsPage.DragDesiredFieldsintoTableBelow();
            settingsPage.DragDesiredFieldsintoTableBelow1();
            settingsPage.DragDesiredFieldsintoTableBelow2();

            string ExpectedClaimListvalue = settingsPage.GetClaimListSelectedValue();
            string ExpectedPaymentvalue = settingsPage.GetPaymentsSelectedValue();
            string ExpectedDiaryvalue = settingsPage.GetDiarySelectedValue();
            string ExpectedLognotesvalue = settingsPage.GetLogNotesSelectedValue();
            string ExpectedOSHASummaryvalue = settingsPage.GetOSHASummarySelectedValue();
            string ExpectedPolicyvalue = settingsPage.GetPolicySelectedValue();
            string ExpectedLineofBusinessvalue = settingsPage.GetLineofBusinessSelectedValue();
            string ExpectedClaimStatusvalue = settingsPage.GetClaimStatusSelectedValue();

            //click on settings
            settingsPage.SaveSettings();
            settingsPage.VerifyDataSaveMessage(DataSaveMessage);
            //Get account details from the selected default account
            string accountDetails = settingsPage.GetAccountDetails();
            home.ClickExit();

            this.TESTREPORT.LogInfo("Re-Login into application");
            login.OpenBrowser();

            this.TESTREPORT.LogInfo("Verify Default Account details applied");
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            //click on settings again
            home.ClickSettings();
            //verify settings page Title
            home.VerifyPageTitle(SettingsPageTitle);

            settingsPage.VerifydefaultaccountDetailsonsettings(accountDetails);
            //Click on home
            diaryNotes.ClickHome();
            //VerifyMyDiaryinHomePage
            settingsPage.VerifyMyDiaryinHomePage();
            //VerifyQuickClaimSearchinHomePage
            settingsPage.VerifyQuickClaimSearchinHomePage();
            //CLick on ClaimInquiry
            home.ClickClaimInquiry();
            //Click on Search 
            home.ClickSearch();
            //Validate the number of claims populated for Claim Search
            settingsPage.VerifyClaimInquiryResultsPageSize(ExpectedClaimListvalue);
            // verify line of business
            settingsPage.VerifyLineofBusiness(ExpectedLineofBusinessvalue);
            // claim status
            settingsPage.VerifyClaimstatus(ExpectedClaimStatusvalue);
            //click on Random claim
            settingsPage.ClickonClaim();
            // home.ClickOnRandomClaim();
            //click on payments
            cInquiry.ClickPayments();

            //Validate the number of results populated for Payments Tab
            settingsPage.VerifyPaymentTabResultsPageSize(ExpectedPaymentvalue);

            //click on Diary
            cInquiry.ClickDiary();

            //Validate the number of results populated for Diary Tab
            settingsPage.VerifyDiaryTabResultsPageSize(ExpectedDiaryvalue);

            //click on lognotes
            cInquiry.ClickLogNotes();

            //Validate the number of results populated for logNotes Tab
            settingsPage.VerifyLogNotesTabResultsPageSize(ExpectedLognotesvalue);

            //click on OSHA summary
            osha.ClickOnOsha();
            //verify important information please read text in osha summary
            settingsPage.VerifyImportantInformationPleaseReadText();
            //click accept button in osha summary
            osha.ClickAcceptButton();
            //Validate the number of results populated for OSHA Tab
            settingsPage.VerifyOSHATabResultsPageSize(ExpectedOSHASummaryvalue);

            //click on policy
            settingsPage.ClickPolicyLinkinTableHeader();
            //Validate the number of results populated for policy Tab
            settingsPage.VerifyPolicyTabResultsPageSize(ExpectedPolicyvalue);


            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }


        [TestMethod, Description("Navigate to the Settings, Customize ClaimList Columns, confirm Settings and validate it in the claim inquiry tab"), TestCategory("Regression")]
        public void Settings_03settingsPage()
        {
            this.TESTREPORT.InitTestCase("Settings_03", "Navigate to the Settings, Customize ClaimList Columns, confirm Settings and validate it in the claim inquiry tab");

            //verify page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click on settings
            home.ClickSettings();
            //verify settings page title
            home.VerifyPageTitle(SettingsPageTitle);
            //click on ResetSettings in settings page
            settingsPage.ClickResetSettings();

            this.TESTREPORT.LogInfo("Verify Text Message- 'Data has been saved successfully'");
            //select an account from My Default Account dropdown
            settingsPage.SelectDefaultAccount(DefaultAccountvalue);
            //get the account name and number
            string accountDetails = settingsPage.GetAccountDetails();
            //Drag the required items into the selected area
            settingsPage.DragDesiredFieldsintoTableBelow();
            settingsPage.DragDesiredFieldsintoTableBelow1();
            settingsPage.DragDesiredFieldsintoTableBelow2();
            //get the dragged items
            ArrayList Dragitems = settingsPage.GetSelectedDraggeditems();
            //click on save in the settings page
            settingsPage.SaveSettings();
            //verify the message after save button is clicked
            settingsPage.VerifyDataSaveMessage(DataSaveMessage);


            home.ClickExit();

            this.TESTREPORT.LogInfo("Re-Login into application");
            login.OpenBrowser();

            //verify default account in home page
            settingsPage.VerifyDefaultAccountselectedinHomePage(accountDetails);
            //click on claiminquiry
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //check the table headers under the detailed claim list
            settingsPage.CheckClaimInquiryTableHeaders(Dragitems[0].ToString());
            settingsPage.CheckClaimInquiryTableHeaders(Dragitems[1].ToString());
            settingsPage.CheckClaimInquiryTableHeaders(Dragitems[2].ToString());


            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

    }
}