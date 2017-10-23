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
using AUT.Selenium.CommonReUsablePages;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class NCEPropertyPageTest : PMA.TestBaseTemplate
    {
        //Create Page Objectss
        HomePage home = new HomePage();
        ClaimInquiry cInquiry = new ClaimInquiry();


        [TestMethod, Description("Create a new Property claim and cancel"), TestCategory("Regression")]
        public void NCE_P1NCEProperty()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEPropertyPage nceProperty = new NCEPropertyPage();

            this.TESTREPORT.InitTestCase("NCE_P1", "Create a new Property claim and cancel");

            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("NCEPropertyPage-Create a new Property claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NCE_P2NCEProperty()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEPropertyPage nceProperty = new NCEPropertyPage();

            this.TESTREPORT.InitTestCase("NCE_P2", "Create a new Property claim, fill out only the required fields and submit");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text 
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            //Click on New claim Entry
            nceAuto.ClickOnNewClaimEntry();
            //Select 'Property' line of business from Loss Line Drop Down
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Without Entering the values click on submit
            this.TESTREPORT.LogInfo("Verify '!Required Field' error message");
            nceAuto.ClickSubmit();
            //Verify the error messages
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));
            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
           //Enter Values
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //Click on Submit
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEPropertyPage-Create a new Property claim and save as draft"), TestCategory("Regression")]
        public void NCE_P4NCEProperty()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEPropertyPage nceProperty = new NCEPropertyPage();

            this.TESTREPORT.InitTestCase("NCE_P4", "Create a new Property claim and save as draft");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text            
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click save Draft
            nceAuto.ClickSaveDraft();
            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();
            //To fill the required fields to save draft and save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceProperty.EnterDescriptionOfDamage(DescribeLoss);
            //Click save Draft again
            nceAuto.ClickSaveDraft();
            // Draft Saved Successfully text
            nceAuto.VerifyDraftSavedSuccessfullyText();
            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceProperty.GetLocationofLoss();
            string d = nceProperty.GetDescriptionOfDamage();
            //click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();
            //verify saved drafts text in table
            nceAuto.SavedDraftsText();            
            //verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }

    }
}