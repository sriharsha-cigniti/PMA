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
    public class NCEWorkersCompensationTest : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string BusinessValueText { get; set; }
        public static string SelectState { get; set; }
        public static string SelectBusinessvalueDropDown { get; set; }
        public static string Location { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Zip { get; set; }
        public static string DOB { get; set; }
        public static string SSN { get; set; }
        public static string Occupation { get; set; }
        public static string AccidentCause { get; set; }
        public static string InjuryType { get; set; }
        public static string BodyPart { get; set; }
        public static string Description { get; set; }
        public static string IsInjuredWorkerLosingTime { get; set; }
        public static string IsInjuredWorkerModifiedShift { get; set; }
        public static string PreparerPhone { get; set; }
        public static string Date { get; set; }
        public static string DateWSlash { get; set; }
        public static string DataSaveMessage { get; set; }
        public static string RequiredErrorMessageCount { get; set; }
        public static string InvalidFormatMessageCount { get; set; }
        public static string DraftSaveMessage { get; set; }
        public static string SaveDraftText { get; set; }
        public static string TextFromDeleteAlert { get; set; }
        #endregion

        public NCEWorkersCompensationTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            BusinessValueText = readCSV("BusinessValueText");
            SelectState = readCSV("SelectState");
            SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            Location = readCSV("Location");
            FirstName = readCSV("FirstName");
            LastName = readCSV("LastName");
            Address = readCSV("Address");
            City = readCSV("City");
            Zip = readCSV("Zip");
            DOB = readCSV("DOB");
            SSN = readCSV("SSN");
            Occupation = readCSV("Occupation");
            AccidentCause = readCSV("AccidentCause");
            InjuryType = readCSV("InjuryType");
            BodyPart = readCSV("BodyPart");
            Description = readCSV("Description");
            IsInjuredWorkerLosingTime = readCSV("IsInjuredWorkerLosingTime");
            IsInjuredWorkerModifiedShift = readCSV("IsInjuredWorkerModifiedShift");
            PreparerPhone = readCSV("PreparerPhone");
            DateWSlash = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
            DataSaveMessage = readCSV("DataSaveMessage");
            RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            InvalidFormatMessageCount = readCSV("InvalidFormatMessageCount");
            DraftSaveMessage = readCSV("DraftSaveMessage");
            SaveDraftText = readCSV("SaveTextOnTable");
            TextFromDeleteAlert = readCSV("TextFromDeleteAlert");
            Date = DateWSlash.Replace("/", "");
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim and cancel"), TestCategory("Regression")]
        public void NCE_WC1_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC1", "Create a new Workers' Compensation claim and cancel");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Worker's compensation page is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceWC.ClickOnEmployeeNotOnList();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Click on Cancel and Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NCE_WC2_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC2", "Create a new Workers' Compensation claim, fill out only the required fields and submit");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Worker's compensation page is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceWC.ClickOnEmployeeNotOnList();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(Location, FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a Workers' Compensation claim and save as draft"), TestCategory("Regression")]
        public void NCE_WC4_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC4", "Create a Workers' Compensation claim and save as draft");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Worker's compensation page is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceWC.ClickOnEmployeeNotOnList();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Click on Save Draft Button and Verify Required error message");
            nceAuto.ClickSaveDraft();
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Save Draft Button");
            nceWC.FillRequiredFieldsForSaveDraftInWCForm(Location, FirstName, LastName, Date, Description);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            nceGE.VerifyGridView();
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a Workers' Compensation claim, save claim as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NCE_WC5_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC5", "Create a Workers' Compensation claim, save claim as draft, return to the saved claim page and delete");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Worker's compensation page is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceWC.ClickOnEmployeeNotOnList();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Click on Save Draft Button and Verify Required error message");
            nceAuto.ClickSaveDraft();
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Save Draft Button");
            nceWC.FillAllRequiredFieldsInWCForm(Location, FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceWC.VerifySavedGridText(SaveDraftText);
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);
            nceGE.VerifyRowDataingGrid(3, Location);
            nceGE.VerifyRowDataingGrid(4, Description);

            this.TESTREPORT.LogInfo("Click on Delete button");
            nceGE.ClickOnDelete();

            this.TESTREPORT.LogInfo("Click on Delete Popup and verify text");
            nceGE.HandleDeleteLiabilityAlert(TextFromDeleteAlert);

            this.TESTREPORT.LogInfo("Verify GRid row is deleted after record is deleted");
            nceGE.VerifyGridRowIsExistsAfterDeletion(rowCOUntBeforeDelete - 1);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
        public void NCE_WC6_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC6", "Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with only required fields");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Worker's compensation page is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceWC.ClickOnEmployeeNotOnList();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Click on Save Draft Button and Verify Required error message");
            nceAuto.ClickSaveDraft();
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Save Draft Button");
            nceWC.FillRequiredFieldsForSaveDraftInWCForm(Location, FirstName, LastName, Date, Description);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceWC.VerifySavedGridText(SaveDraftText);
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);
            nceGE.VerifyRowDataingGrid(3, Location);
            nceGE.VerifyRowDataingGrid(4, Description);

            string columnValue = nceGE.GetColumnDataFromRowGrid(1);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();

            nceWC.VerifyDate(columnValue);

            this.TESTREPORT.LogInfo("Click on submit button");
            nceAuto.ClickSubmit();

            nceWC.VerifyInvalidFormatErrorMessage(Convert.ToInt32(InvalidFormatMessageCount));

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(Location, FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, "", AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}