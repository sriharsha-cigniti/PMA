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
        public static string Suffix { get; set; }
        public static string Gender { get; set; }
        public static string MaritalStatus { get; set; }
        public static string NumberOfDependents { get; set; }
        public static string SideOfBody { get; set; }
        public static string NoOfWorkedPerDay { get; set; }
        public static string PaymentFrequency { get; set; }
        public static string DaysPerWeek { get; set; }
        public static string EmployeeStatus { get; set; }
        public static string MiddleName { get; set; }
        public static string Selectdate { get; set; }
        public static string OtherRemarks { get; set; }
        public static string EmployeeInformationText { get; set; }
        public static string OccurrenceInformationText { get; set; }
        public static string ContactInformationText { get; set; }
        public static string ClaimSubmissionText { get; set; }
        public static string EMailAdress { get; set; }
        public static string EmployeeSearchText { get; set; }
        public static string LastNameSearch { get; set; }
        public static string IDSearch { get; set; }
        public static string AccountName { get; set; }
        public static string LocationSearch { get; set; }
        public static string LocationNumber { get; set; }
        public static string LocationName { get; set; }
        public static string DefaultAccount { get; set; }

        #endregion

        public NCEWorkersCompensationTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            BusinessValueText = readCSV("BusinessValueText");
            SelectState = readCSV("SelectState");
            SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            Location = readCSV("Location");
            LocationSearch = readCSV("LocationSearch");
            LocationNumber = readCSV("LocationNumber");
            LocationName = readCSV("LocationName");
            DefaultAccount = readCSV("DefaultAccount");
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
            Suffix = readCSV("Suffix");
            Gender = readCSV("Gender");
            MaritalStatus = readCSV("MaritalStatus");
            NumberOfDependents = readCSV("NumberOfDependents");
            SideOfBody = readCSV("SideOfBody");
            NoOfWorkedPerDay = readCSV("NoOfWorkedPerDay");
            PaymentFrequency = readCSV("PaymentFrequency");
            DaysPerWeek = readCSV("DaysPerWeek");
            EmployeeStatus = readCSV("EmployeeStatus");
            MiddleName = readCSV("MiddleName");
            Selectdate = readCSV("Selectdate");
            OtherRemarks = readCSV("OtherRemarks");
            EMailAdress = readCSV("EMailAdress");
            EmployeeInformationText = readCSV("EmployeeInformationText");
            OccurrenceInformationText = readCSV("OccurrenceInformationText");
            ContactInformationText = readCSV("ContactInformationText");
            ClaimSubmissionText = readCSV("ClaimSubmissionText");
            EmployeeSearchText = readCSV("EmployeeSearchText");
            LastNameSearch = readCSV("LastNameSearch");
            IDSearch = readCSV("IDSearch");
            AccountName = readCSV("AccountName");
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
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim, fill out all fields and submit"), TestCategory("Regression")]
        public void NCE_WC3_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC3", "Create a new Workers' Compensation claim, fill out all fields and submit");

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

            this.TESTREPORT.LogInfo("Fill the all fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.FillAllNonRequiredFieldsInWCForm(MiddleName, Suffix, Gender, PreparerPhone, Selectdate, MaritalStatus, EmployeeStatus, NumberOfDependents, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName);
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
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
            nceWC.FillRequiredFieldsForSaveDraftInWCForm(FirstName, LastName, Date, Description);
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
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);
            string LocationL = nceWC.GetLocationText();

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceWC.VerifySavedGridText(SaveDraftText);
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);
            nceGE.VerifyRowDataingGrid(3, LocationL);
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

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
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
            nceWC.FillRequiredFieldsForSaveDraftInWCForm(FirstName, LastName, Date, Description);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);
            string LocationL = nceWC.GetLocationText();

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceWC.VerifySavedGridText(SaveDraftText);
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);
            nceGE.VerifyRowDataingGrid(3, LocationL);
            nceGE.VerifyRowDataingGrid(4, Description);

            string columnValue = nceGE.GetColumnDataFromRowGrid(1);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();

            nceWC.VerifyDate(columnValue);

            this.TESTREPORT.LogInfo("Click on submit button");
            nceAuto.ClickSubmit();

            nceWC.VerifyInvalidFormatErrorMessage(Convert.ToInt32(InvalidFormatMessageCount));

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, "", AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NCE_WC7_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC7", "Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with all fields");

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
            nceWC.FillRequiredFieldsForSaveDraftInWCForm(FirstName, LastName, Date, Description);
            nceAuto.ClickSaveDraft();

            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully. message is displayed");
            nceAuto.VerifyDataSaveMessage(DraftSaveMessage);
            string LocationL = nceWC.GetLocationText();

            this.TESTREPORT.LogInfo("Click on cancel button");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify Data Grid row and row values ");
            nceGE.VerifyGridView();
            nceWC.VerifySavedGridText(SaveDraftText);
            nceGE.VerifyRowDataingGrid(0, "WC");
            nceGE.VerifyRowDataingGrid(1, DateWSlash);
            nceGE.VerifyRowDataingGrid(2, FirstName + " " + LastName);
            nceGE.VerifyRowDataingGrid(3, LocationL);
            nceGE.VerifyRowDataingGrid(4, Description);

            string columnValue = nceGE.GetColumnDataFromRowGrid(1);

            this.TESTREPORT.LogInfo("Click on Saved claim");
            nceGE.ClickOnSavedClaiminGrid();

            nceWC.VerifyDate(columnValue);

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, "", AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date);
            nceWC.FillAllNonRequiredFieldsInWCForm(MiddleName, Suffix, Gender, PreparerPhone, Selectdate, MaritalStatus, EmployeeStatus, NumberOfDependents, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName);
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Verify the Tabs/sections present in the Workers' Compensation Claim"), TestCategory("Regression")]
        public void NCE_WC8_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC8", "ack to draft and submit claim with all fields");

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

            nceGE.VerifyTextOnPage(EmployeeInformationText);
            nceGE.VerifyTextOnPage(OccurrenceInformationText);
            nceGE.VerifyTextOnPage(ContactInformationText);
            nceGE.VerifyTextOnPage(ClaimSubmissionText);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NCE_WC9_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC9", "Create a new Workers' Compensation claim, save as draft, navigate back to draft and submit claim with all fields");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Employee Search is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceGE.VerifyTextOnPage(EmployeeSearchText);

            this.TESTREPORT.LogInfo("Enter at least three characters of the employees last name into the Last Name field and click on search");
            nceWC.EnterLastNameInField(LastNameSearch);
            nceWC.ClickOnSearchButton();

            this.TESTREPORT.LogInfo("Verify list of employees appears in the gridview");
            nceGE.VerifyGridView();

            this.TESTREPORT.LogInfo("Verify Results under the Name column in the table and Click on the employees name from the list");
            nceWC.ValidateColumnDataFromRow(LastNameSearch);
            string Name = nceGE.GetColumnDataFromRowGrid(1);
            nceGE.ClickOnSavedClaiminGrid();

            this.TESTREPORT.LogInfo("Verify Name in WC Form");
            nceWC.VerifyName(Name);

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.EnterOccuranceInformation(Selectdate, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName, Date, AccidentCause, InjuryType, BodyPart, Description);
            nceWC.EnterContactInformation(PreparerPhone, Address, City, SelectState, Zip, FirstName, LastName);

            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim from an Account with an HR feed - Employee in the HR feed via the employee ID"), TestCategory("Regression")]
        public void NCE_WC10_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC10", "Create a new Workers' Compensation claim from an Account with an HR feed - Employee in the HR feed via the employee ID");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Employee Search is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceGE.VerifyTextOnPage(EmployeeSearchText);

            this.TESTREPORT.LogInfo("Enter at least three characters of the employees last name into the Last Name field and click on search");
            nceWC.EnterEmployeeIdInField(IDSearch);
            nceWC.ClickOnSearchButton();

            this.TESTREPORT.LogInfo("Verify list of employees appears in the gridview");
            nceGE.VerifyGridView();

            this.TESTREPORT.LogInfo("Verify Results under the ID column in the table and Click on the employees name from the list");
            nceWC.ValidateColumnDataFromRow(IDSearch);
            string Name = nceGE.GetColumnDataFromRowGrid(1);
            nceGE.ClickOnSavedClaiminGrid();

            this.TESTREPORT.LogInfo("Verify Name in WC Form");
            Name = Name.Replace(",", "");
            nceWC.VerifyName(Name.Trim());

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.EnterOccuranceInformation(Selectdate, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName, Date, AccidentCause, InjuryType, BodyPart, Description);
            nceWC.EnterContactInformation(PreparerPhone, Address, City, SelectState, Zip, FirstName, LastName);

            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim from an Account with a Location Search - enter location number"), TestCategory("Regression")]
        public void NCE_WC11_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC11", "Create a new Workers' Compensation claim from an Account with a Location Search - enter location number");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("'AGRISURANCE INC. DP&C' account should be selected which contains an HR feed");
            home.ClickMyAccount();
            string value = home.SelectAccountDropDownWithValue(AccountName);
            home.VerifyAccountHeader(value);

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Location Search is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceGE.VerifyTextOnPage(LocationSearch);

            this.TESTREPORT.LogInfo("Enter the location number and select");
            nceWC.EnterLocationNumberInField(LocationNumber);
            nceWC.ClickOnSearchButton();
            nceWC.ValidateText(BusinessValueText);

            this.TESTREPORT.LogInfo("Verify Location in WC Form");
            nceWC.VerifyLocation(LocationNumber);

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date, false);
            nceWC.FillAllNonRequiredFieldsInWCForm(MiddleName, Suffix, Gender, PreparerPhone, Selectdate, MaritalStatus, EmployeeStatus, NumberOfDependents, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName);
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
            nceWC.EnterCustomerSpecialDialog();
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo(string.Format("Set to Default account", DefaultAccount));
            diaryNotes.ClickHome();
            home.ClickMyAccount();
            string defaultAccount = home.SelectAccountDropDownWithValue(DefaultAccount);
            home.VerifyAccountHeader(defaultAccount);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim from an Account with a Location Search - enter location addres"), TestCategory("Regression")]
        public void NCE_WC12_NCEWorkersCompensation()
        {
            this.TESTREPORT.InitTestCase("NCE_WC12", "Create a new Workers' Compensation claim from an Account with a Location Search - enter location address");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("'AGRISURANCE INC. DP&C' account should be selected which contains an HR feed");
            home.ClickMyAccount();
            string value = home.SelectAccountDropDownWithValue(AccountName);
            home.VerifyAccountHeader(value);

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Select Worker's compensation dropdown and Verify State is displayed");
            nceWC.SelectWorkersCompensationAndVerifyState(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Select State from dropdown and Verify Location Search is displayed");
            nceWC.SelectStateFromDropDown(SelectState);
            nceGE.VerifyTextOnPage(LocationSearch);

            this.TESTREPORT.LogInfo("Enter the location number and select");
            nceWC.EnterLocationNameInField(LocationName);
            nceWC.ClickOnSearchButton();
            nceWC.ValidateText(BusinessValueText);

            //this.TESTREPORT.LogInfo("Verify Location in WC Form");
            //nceWC.VerifyLocation(LocationName);

            this.TESTREPORT.LogInfo("Fill the required fields and Click on Submit Button");
            nceWC.FillAllRequiredFieldsInWCForm(FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone, Date, false);
            nceWC.FillAllNonRequiredFieldsInWCForm(MiddleName, Suffix, Gender, PreparerPhone, Selectdate, MaritalStatus, EmployeeStatus, NumberOfDependents, SideOfBody, NoOfWorkedPerDay, Date, PaymentFrequency, DaysPerWeek, Address, City, SelectState, Zip, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, FirstName, LastName);
            this.TESTREPORT.LogInfo("Entering the claimSubmission Section");
            nceGE.EnterclaimSubmission(OtherRemarks, EMailAdress);
            nceWC.EnterCustomerSpecialDialog();
            nceWC.ClickOnSubmitButton();

            this.TESTREPORT.LogInfo("Verify The claim information you entered has been recorded and saved. message is displayed");
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            nceAuto.SwitchToDefaultContent();

            this.TESTREPORT.LogInfo(string.Format("Set to Default account", DefaultAccount));
            diaryNotes.ClickHome();
            home.ClickMyAccount();
            string defaultAccount = home.SelectAccountDropDownWithValue(DefaultAccount);
            home.VerifyAccountHeader(defaultAccount);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}