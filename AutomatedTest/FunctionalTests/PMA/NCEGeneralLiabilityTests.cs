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

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim and cancel"), TestCategory("Regression")]
        public void NCE_GL1_NCEGeneralLiability()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL1", "Create a new General Liability claim and cancel");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            #endregion

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
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL2", "Create a new General Liability claim, fill out only the required fields and submit");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string zipcode = readCSV("ZipCode");
            string InvalidDataFormatcount = readCSV("InvalidFormatCount");
            string InvalidData = readCSV("Invaliddata");
            #endregion

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
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL3", "Create a new General Liability claim, fill out only the required fields and submit");
            #region ReadCS
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DraftSaveMessage = readCSV("DraftSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string Address = readCSV("Address");
            string City = readCSV("city");
            string Authority = readCSV("Authority");
            string DescribeLoss = readCSV("DescribeLoss");
            string RequiredErrorMessageForDraftSave = readCSV("RequiredErrorMessageForDraftSave");
            string DataSaveMessage = readCSV("DataSaveMessage");
            #endregion

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

            this.TESTREPORT.LogInfo("Click on SUbmit button and Verify 'The claim information you entered has been recorded and saved' as message");
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
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL4", "Create a new General Liability claim and save as draft");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DraftSaveMessage = readCSV("DraftSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string RequiredErrorMessageForDraftSave = readCSV("RequiredErrorMessageForDraftSave");
            #endregion

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
            //home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, save as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NCE_GL5_NCEGeneralLiability()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL5", "Create a new General Liability claim, save as draft, return to the saved claim page and deletes");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DraftSaveMessage = readCSV("DraftSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string RequiredErrorMessageForDraftSave = readCSV("RequiredErrorMessageForDraftSave");
            string TextFromDeleteAlert = readCSV("TextFromDeleteAlert");
            #endregion

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
            int rowCOUntBeforeDelete = nceGE.GetGridRowCount();
            nceGE.VerifyGridView();
            nceGE.VerifyRowDataingGrid(0, "LIAB");
            nceGE.VerifyRowDataingGrid(1, Date);
            nceGE.VerifyRowDataingGrid(3, LocationLoss);

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

        [TestMethod, Description("NCEGeneralLiability - Create a new General Liability claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NCE_GL7_NCEGeneralLiability()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL7", "Create a new General Liability claim, save as draft, navigate back to draft and submit claim with all fields");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DraftSaveMessage = readCSV("DraftSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string Address = readCSV("Address");
            string City = readCSV("city");
            string Authority = readCSV("Authority");
            string DescribeLoss = readCSV("DescribeLoss");
            string RequiredErrorMessageForDraftSave = readCSV("RequiredErrorMessageForDraftSave");
            string DataSaveMessage = readCSV("DataSaveMessage");
            #endregion

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
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();

            this.TESTREPORT.InitTestCase("NCE_GL8", "Verify the Tabs/sections present in the General Liability Claim");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string LossInformationText = readCSV("LossInformationText");
            string InjuredPropertyDamageInformationText = readCSV("InjuredPropertyDamageInformationText");
            string WitnessInformationText = readCSV("WitnessInformationText");
            string ClaimSubmissionText = readCSV("ClaimSubmissionText");
            #endregion

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