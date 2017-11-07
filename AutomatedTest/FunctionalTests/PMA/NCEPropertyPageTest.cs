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
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string SelectBusinessvalueDropDown { get; set; }
        public static string RequiredErrorMessageCount { get; set; }
        public static string ContactBusinessPhone { get; set; }
        public static string DataSaveMessage { get; set; }
        public static string StateofLoss { get; set; }
        public static string LocationLoss { get; set; }
        public static string DescriptionOfDamage { get; set; }
        public static string DescribeLoss { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string ZipCode { get; set; }
        public static string KindOfLoss { get; set; }
        public static string EstimatedLossAmount { get; set; }
        public static string OtherRemarks { get; set; }
        public static string EMailAdress { get; set; }
        public static string TextFromDeleteAlert { get; set; }
        public static string ErrorCount { get; set; }
        public static string LossInformationText { get; set; }
        public static string ClaimSubmissionText { get; set; }
        #endregion

        public NCEPropertyPageTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            ContactBusinessPhone = readCSV("ContactBusinessPhone");
            DataSaveMessage = readCSV("DataSaveMessage");
            StateofLoss = readCSV("StateOfLoss");
            LocationLoss = readCSV("LocationLoss");
            DescriptionOfDamage = readCSV("DescriptionOfDamage");
            DescribeLoss = readCSV("DescribeLoss");
            Address = readCSV("Address");
            City = readCSV("city");
            ZipCode = readCSV("ZipCode");
            KindOfLoss = readCSV("KindOfLoss");
            EstimatedLossAmount = readCSV("EstimatedLossAmount");
            OtherRemarks = readCSV("OtherRemarks");
            EMailAdress = readCSV("EMailAdress");
            TextFromDeleteAlert = readCSV("TextFromDeleteAlert");
            ErrorCount = readCSV("ErrorCount");
            LossInformationText = readCSV("LossInformationText");
            ClaimSubmissionText = readCSV("ClaimSubmissionText");
        }

        [TestMethod, Description("Create a new Property claim and cancel"), TestCategory("Regression")]
        public void NCE_P1NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P1", "Create a new Property claim and cancel");
            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select line of business
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();            
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click on Cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            //Click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("NCEPropertyPage-Create a new Property claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NCE_P2NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P2", "Create a new Property claim, fill out only the required fields and submit");

            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");            
            nceAuto.ClickOnNewClaimEntry();            
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
            nceProperty.SelectLocationLoss();
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //Click on Submit and verify the confirmation message
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            //Click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEPropertyPage-Create a new Property claim, fill out all fields and submit"), TestCategory("Regression")]
        public void NCE_P3NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P3", "Create a new Property claim, fill out all fields and submit");

            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();            
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            #region Enter all values in Loss Information
            //Fill the fields for LossInformation
            this.TESTREPORT.LogInfo("Enter the data for LossInformation Section");
            nceAuto.EnterOccurenceDate();
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceProperty.SelectLocationLoss();
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceGE.EnterAddress(Address);
            nceGE.EnterCity(City);
            nceGE.EnterZipCode(ZipCode);
            nceProperty.EnterKindOfloss(KindOfLoss);
            nceProperty.EstimatedLossAmount(EstimatedLossAmount);
            nceProperty.EnterDescriptionOfDamage(DescribeLoss);
            string time = DateTime.Now.ToString("HH:mm tt");
            nceGE.EntertimeOccurence(time);
            #endregion
            #region Fill Claim Submission  
            //Fill the values for Claim Submission
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceProperty.EnterclaimSubmission(OtherRemarks, EMailAdress);
            #endregion
            //Click on submit and validate the Confirmation message
            this.TESTREPORT.LogInfo("Click on Submit button and Verify 'The claim information you entered has been recorded and saved' as message");
            nceAuto.ClickSubmit();
            nceProperty.GetClaimNumber();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.ClickSubmit();
            nceAuto.SwitchToDefaultContent();
            //Click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("NCEPropertyPage-Create a new Property claim and save as draft"), TestCategory("Regression")]
        public void NCE_P4NCEProperty()
        {

            this.TESTREPORT.InitTestCase("NCE_P4", "Create a new Property claim and save as draft");
            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business            
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click save Draft and verify the required field error message count
            nceAuto.ClickSaveDraft();            
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft and save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss();
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceProperty.EnterDescriptionOfDamage(DescriptionOfDamage);
            //Click on save Draft again and verify the confirmation message 
            nceAuto.ClickSaveDraft();           
            nceAuto.VerifyDraftSavedSuccessfullyText();
            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceProperty.GetLocationofLoss();
            string d = nceProperty.GetDescriptionOfDamage();
            
            this.TESTREPORT.LogInfo("Verify Cancel");
            //Click Cancel and Verify saved draft text in table
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();            
            nceAuto.SavedDraftsText();
            //Verify Accident date,location,Description in table
            nceAuto.VerifyAccidentDateinTable(a);            
            nceAuto.VerifyLocationinTable(b);            
            nceAuto.VerifyDescriptioninTable(d);
            nceAuto.SwitchToDefaultContent();
            //click Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("NCEPropertyPage-Create a new Property claim, save as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NCE_P5NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P5", "Create a new Property claim, save as draft, return to the saved claim page and delete");
            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);            
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business          
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify 'property' text
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click save Draft and Verify RequiredField Error message
            nceAuto.ClickSaveDraft();            
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft and save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss();
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceProperty.EnterDescriptionOfDamage(DescriptionOfDamage);
            //Click save Draft again and Verify the confirmation message
            nceAuto.ClickSaveDraft();            
            nceAuto.VerifyDraftSavedSuccessfullyText();
            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceProperty.GetLocationofLoss();
            string d = nceProperty.GetDescriptionOfDamage();            
            this.TESTREPORT.LogInfo("Verify Cancel");
            //Click on Cancel Button
            nceAuto.ClickCancel();
            //Select All page size and get the Table count
            nceGE.SelectPageSizeAll();           
            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCountBeforeDelete = nceGE.GetGridRowCount();
            nceAuto.SwitchToDefaultContent();
            //Verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //Verify Accident date,location,description  in table
            nceAuto.VerifyAccidentDateinTable(a);            
            nceAuto.VerifyLocationinTable(b);           
            nceAuto.VerifyDescriptioninTable(d);

            //Click on Delete to delete the saved draft
            this.TESTREPORT.LogInfo("Click on Delete button");
            nceGE.ClickOnDelete();            
            this.TESTREPORT.LogInfo("Click on Delete Popup and verify text");
            nceGE.HandleDeleteLiabilityAlert(TextFromDeleteAlert);
            //Verify grid results count after delete
            this.TESTREPORT.LogInfo("Verify Grid row count after record is deleted");
            nceGE.VerifyGridRowIsExistsAfterDeletion(rowCountBeforeDelete - 1);
            nceAuto.SwitchToDefaultContent();
            //Click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("NCEPropertyPage - Create a new Property claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
        public void NCE_P6NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P6", "Create a new Property claim, save as draft, navigate back to draft and submit claim with only required fields");
            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business          
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify 'Property' Text
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click save Draft and verify RequiredField Error message
            nceAuto.ClickSaveDraft();            
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss();
            //Click save Draft again and verify the confirmation message
            nceAuto.ClickSaveDraft();           
            nceAuto.VerifyDraftSavedSuccessfullyText();
            //Get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceProperty.GetLocationofLoss();
            this.TESTREPORT.LogInfo("Verify Cancel");
            //Click on Cancel Button
            nceAuto.ClickCancel();
            //Verify Data in grid after delete
            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCountBeforeDelete = nceGE.GetGridRowCount();
            nceAuto.SwitchToDefaultContent();
            //verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //verify Accident date, location,   in table
            nceAuto.VerifyAccidentDateinTable(a);       
            nceAuto.VerifyLocationinTable(b);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();
            //Click on Submit
            nceAuto.ClickSubmit();
            this.TESTREPORT.LogInfo("Verify Required Field error message");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(ErrorCount));
            //Provide state and business phone
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //Click on Submit and verify the confirmation message
            nceAuto.ClickSubmit();           
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            //Get claim number
            nceProperty.GetClaimNumber();

            nceAuto.SwitchToDefaultContent();
            //Click on Exit to close the application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
        [TestMethod, Description("NCEPropertyPage - Create a new Property claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NCE_P7NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P7", "Create a new Property claim, save as draft, navigate back to draft and submit claim with all fields");
            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business             
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify Property Text
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Click save Draft and Verify RequiredField Error message
            nceAuto.ClickSaveDraft();           
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss();
            //Click save Draft again and verify the confirmation message
            nceAuto.ClickSaveDraft();            
            nceAuto.VerifyDraftSavedSuccessfullyText();

            //Get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceProperty.GetLocationofLoss();
            //Click on Cancel Button
            this.TESTREPORT.LogInfo("Verify Cancel");            
            nceAuto.ClickCancel();
            //get the Table Count
            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCountBeforeDelete = nceGE.GetGridRowCount();
            nceAuto.SwitchToDefaultContent();
            //verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //verify Accident date, location in table
            nceAuto.VerifyAccidentDateinTable(a);            
            nceAuto.VerifyLocationinTable(b);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();
            //Provide all fields to fill the form
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.EnterAddress(Address);
            nceGE.EnterCity(City);
            nceGE.EnterZipCode(ZipCode);
            nceProperty.EnterKindOfloss(KindOfLoss);
            nceProperty.EstimatedLossAmount(EstimatedLossAmount);
            nceProperty.EnterDescriptionOfDamage(DescribeLoss);
            string time = DateTime.Now.ToString("HH:mm tt");
            nceGE.EntertimeOccurence(time);
            #region Fill Claim Submission            
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceProperty.EnterclaimSubmission(OtherRemarks, EMailAdress);
            #endregion
            //Click on Submit and verify the confirmation message
            nceAuto.ClickSubmit();            
            this.TESTREPORT.LogInfo("Click on Submit button and Verify 'The claim information you entered has been recorded and saved' as message");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            //Get claim number
            nceProperty.GetClaimNumber();            
            nceAuto.SwitchToDefaultContent();
            //Click on Exit to close the application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
        [TestMethod, Description("NCEPropertyPage - Verify the Tabs/sections present in the Property Claim"), TestCategory("Regression")]
        public void NCE_P8NCEProperty()
        {
            this.TESTREPORT.InitTestCase("NCE_P8", "Verify the Tabs/sections present in the Property Claim");

            //Verify Page title and welcome text
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            //Click on NewClaim Entry and select 'Property' as line of business            
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify Property Text
            this.TESTREPORT.LogInfo("Verify 'Property' text");
            //Select line of business from dropdown
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);
            //Verify Text on Page
            nceGE.VerifyTextOnPage(LossInformationText);
            nceGE.VerifyTextOnPage(ClaimSubmissionText);
            //Switch to Default Frame
            nceAuto.SwitchToDefaultContent();
            //Click on exit to close the application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

    }
}