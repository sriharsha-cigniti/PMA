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
    public class NCEGeneralLiabilityTests : PMA.TestBaseTemplate
    {
        #region parameters

        public static string HomePageTitle { get; set; }
        public static string SelectBusinessvalueDropDown { get; set; }
        public static string RequiredErrorMessageCount { get; set; }
        public static string ContactBusinessPhone { get; set; }
        public static string DataSaveMessage { get; set; }
        public static string StateofLoss { get; set; }
        public static string LocationLoss { get; set; }
        public static string zipcode { get; set; }
        public static string InvalidDataFormatcount { get; set; }
        public static string InvalidData { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Authority { get; set; }
        public static string DescribeLoss { get; set; }
        public static string RequiredErrorMessageForDraftSave { get; set; }
        public static string name { get; set; }
        public static string Organization { get; set; }
        public static string DraftSaveMessage { get; set; }
        public static string DescribeProperty { get; set; }
        public static string WhenProperty { get; set; }
        public static string Whereproperty { get; set; }
        public static string DescriptionOfInJury { get; set; }
        public static string whereInjuryTaken { get; set; }
        public static string InjuredPriorToInjury { get; set; }
        public static string EstimatedAmount { get; set; }
        public static string OtherRemarks { get; set; }
        public static string EMailAdress { get; set; }
        public static string TextFromDeleteAlert { get; set; }
        public static string ErrorCount { get; set; }
        public static string LossInformationText { get; set; }
        public static string InjuredPropertyDamageInformationText { get; set; }
        public static string WitnessInformationText { get; set; }
        public static string ClaimSubmissionText { get; set; }

        #endregion

        public NCEGeneralLiabilityTests()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            ContactBusinessPhone = readCSV("ContactBusinessPhone");
            StateofLoss = readCSV("StateOfLoss");
            LocationLoss = readCSV("LocationLoss");
            zipcode = readCSV("ZipCode");
            InvalidDataFormatcount = readCSV("InvalidFormatCount");
            InvalidData = readCSV("Invaliddata");
            Address = readCSV("Address");
            City = readCSV("city");
            Authority = readCSV("Authority");
            DescribeLoss = readCSV("DescribeLoss");
            RequiredErrorMessageForDraftSave = readCSV("RequiredErrorMessageForDraftSave");
            DataSaveMessage = readCSV("DataSaveMessage");
            name = readCSV("Name");
            Organization = readCSV("Organization");
            DescribeProperty = readCSV("DescribeProperty");
            WhenProperty = readCSV("WhenProperty");
            Whereproperty = readCSV("Whereproperty");
            DescriptionOfInJury = readCSV("DescriptionOfInJury");
            whereInjuryTaken = readCSV("whereInjuryTaken");
            InjuredPriorToInjury = readCSV("InjuredPriorToInjury");
            EstimatedAmount = readCSV("EstimatedAmount");
            OtherRemarks = readCSV("OtherRemarks");
            EMailAdress = readCSV("EMailAdress");
            TextFromDeleteAlert = readCSV("TextFromDeleteAlert");
            InvalidDataFormatcount = readCSV("InvalidFormatCount");
            InvalidData = readCSV("Invaliddata");
            ErrorCount = readCSV("ErrorCount");
            LossInformationText = readCSV("LossInformationText");
            InjuredPropertyDamageInformationText = readCSV("InjuredPropertyDamageInformationText");
            WitnessInformationText = readCSV("WitnessInformationText");
            ClaimSubmissionText = readCSV("ClaimSubmissionText");
            DraftSaveMessage = readCSV("DraftSaveMessage");
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim and cancel"), TestCategory("Regression")]
        public void NCE_GL1_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL1", "Create a new General Liability claim and cancel");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on Cancel and Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NCE_GL2_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL2", "Create a new General Liability claim, fill out only the required fields and submit");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on submit button and Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickSubmit();

            this.TESTREPORT.LogInfo("Verify Loss Information(Colour change) and Required Field, Invalid Format error message");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));
            nceGE.VerifyColorChange();
            nceGE.VerifyErrorMessage(Convert.ToInt32(InvalidDataFormatcount), InvalidData);

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.EnterZipCode(zipcode);
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, fill out all fields and submit"), TestCategory("Regression")]
        public void NCE_GL3_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL3", "Create a new General Liability claim, fill out only the required fields and submit");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Fill out all fields");
            string time = DateTime.Now.ToString("HH:mm tt");

            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.EnterAddress(Address);
            nceGE.EnterCity(City);
            nceGE.EnterAuthoritycontacted(Authority);
            nceGE.EnterDescribeLoss(DescribeLoss);
            nceGE.EntertimeOccurence(time);
            nceGE.EnterZipCode(zipcode);

            this.TESTREPORT.LogInfo("Entering the InjuredDamagedPropertyInformation Section");
            nceGE.EnterInjuredDamagedPropertyInformation(name, Organization, Address, City, StateofLoss, zipcode, ContactBusinessPhone, DescriptionOfInJury, whereInjuryTaken, InjuredPriorToInjury, DescribeProperty, Convert.ToInt32(EstimatedAmount), Whereproperty, WhenProperty);

            this.TESTREPORT.LogInfo("Entering the WitnessInformation Section");
            nceGE.EnterWitnessInformation(name, Organization, Address, City, StateofLoss, zipcode, ContactBusinessPhone, OtherRemarks);

            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);

            this.TESTREPORT.LogInfo("Click on Submit button and Verify 'The claim information you entered has been recorded and saved' as message");
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim and save as draft"), TestCategory("Regression")]
        public void NCE_GL4_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL4", "Create a new General Liability claim and save as draft");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on save Draft button");
            nceGE.ClickOnSavedraft();

            this.TESTREPORT.LogInfo("Verify Loss Information(Colour change) and Required Field");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageForDraftSave));
            nceGE.VerifyColorChange();

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' as Draft message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.ClickOnSavedraft();
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            nceGE.VerifyGridView();
            nceGE.VerifyRowDataingGrid(0, "LIAB");
            nceGE.VerifyRowDataingGrid(1, Date);
            nceGE.VerifyRowDataingGrid(3, LocationLoss);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, save as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NCE_GL5_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL5", "Create a new General Liability claim, save as draft, return to the saved claim page and deletes");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on save Draft button");
            nceGE.ClickOnSavedraft();

            this.TESTREPORT.LogInfo("Verify Loss Information(Colour change) and Required Field");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageForDraftSave));
            nceGE.VerifyColorChange();

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' as Draft message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.ClickOnSavedraft();
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();
            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCountBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceGE.VerifyRowDataingGrid(0, "LIAB");
            nceGE.VerifyRowDataingGrid(1, Date);
            nceGE.VerifyRowDataingGrid(3, LocationLoss);

            this.TESTREPORT.LogInfo("Click on Delete button");
            nceGE.ClickOnDelete();

            this.TESTREPORT.LogInfo("Click on Delete Popup and verify text");
            nceGE.HandleDeleteLiabilityAlert(TextFromDeleteAlert);

            this.TESTREPORT.LogInfo("Verify Grid row count after record is deleted");
            nceGE.VerifyGridRowIsExistsAfterDeletion(rowCountBeforeDelete - 1);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
        public void NCE_GL6_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL6", "Create a new General Liability claim, save as draft, navigate back to draft and submit claim with only required fields");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on save Draft button");
            nceGE.ClickOnSavedraft();

            this.TESTREPORT.LogInfo("Verify Loss Information(Colour change) and Required Field");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageForDraftSave));

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' as Draft message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);

            nceGE.ClickOnSavedraft();
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();

            this.TESTREPORT.LogInfo("Verify Accident Date and Location of loss value in Liability Form ");
            nceGE.VerifyRowDataingGrid(1, Date);
            nceGE.VerifyRowDataingGrid(3, LocationLoss);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();

            nceAuto.ClickSubmit();

            this.TESTREPORT.LogInfo("Verify Required Field, Invalid Format error message");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(ErrorCount));
            nceGE.VerifyErrorMessage(Convert.ToInt32(InvalidDataFormatcount), InvalidData);

            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.EnterZipCode(zipcode);

            nceAuto.ClickSubmit();

            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NCE_GL7_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL7", "Create a new General Liability claim, save as draft, navigate back to draft and submit claim with all fields");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Click on save Draft button");
            nceGE.ClickOnSavedraft();

            this.TESTREPORT.LogInfo("Verify Loss Information(Colour change) and Required Field");
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageForDraftSave));
            nceGE.VerifyColorChange();

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' as Draft message");

            string time = DateTime.Now.ToString("HH:mm tt");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceGE.ClickOnSavedraft();
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            nceGE.ClickOnSavedClaiminGrid();
            nceGE.VerifyTextOnPage(SelectBusinessvalueDropDown);

            nceGE.EnterAddress(Address);
            nceGE.EnterCity(City);
            nceGE.EnterAuthoritycontacted(Authority);
            nceGE.EnterDescribeLoss(DescribeLoss);
            nceGE.EntertimeOccurence(time);

            this.TESTREPORT.LogInfo("Click on Submit button and Verify 'The claim information you entered has been recorded and saved' as message");
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Verify the Tabs/sections present in the General Liability Claim"), TestCategory("Regression")]
        public void NCE_GL8_NCEGeneralLiability()
        {
            this.TESTREPORT.InitTestCase("NCE_GL8", "Verify the Tabs/sections present in the General Liability Claim");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify General Liability Page is displayed and Text");
            nceGE.VerifyGeneralLIabilityForm(SelectBusinessvalueDropDown);

            nceGE.VerifyTextOnPage(LossInformationText);
            nceGE.VerifyTextOnPage(InjuredPropertyDamageInformationText);
            nceGE.VerifyTextOnPage(WitnessInformationText);
            nceGE.VerifyTextOnPage(ClaimSubmissionText);

            nceAuto.SwitchToDefaultContent();
            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}