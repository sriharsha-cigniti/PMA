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
        [TestMethod, Description("NCEWorkersCompensation - Create a new Workers' Compensation claim and cancel"), TestCategory("Regression")]
        public void NCE_WC1_NCEWorkersCompensation()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();
            NCEWorkersCompensationPage nceWC = new NCEWorkersCompensationPage();

            this.TESTREPORT.InitTestCase("NCE_WC1", "Create a new Workers' Compensation claim and cancel");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string BusinessValueText = readCSV("BusinessValueText");
            string SelectState = readCSV("SelectState");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            #endregion

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
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();
            NCEGeneralLiability nceGE = new NCEGeneralLiability();
            NCEWorkersCompensationPage nceWC = new NCEWorkersCompensationPage();

            this.TESTREPORT.InitTestCase("NCE_WC2", "Create a new Workers' Compensation claim, fill out only the required fields and submit");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string BusinessValueText = readCSV("BusinessValueText");
            string SelectState = readCSV("SelectState");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string Location = readCSV("Location");
            string FirstName = readCSV("FirstName");
            string LastName = readCSV("LastName");
            string Address = readCSV("Address");
            string City = readCSV("City");
            string Zip = readCSV("Zip");
            string DOB = readCSV("DOB");
            string SSN = readCSV("SSN");
            string Occupation = readCSV("Occupation");
            string AccidentCause = readCSV("AccidentCause");
            string InjuryType = readCSV("InjuryType");
            string BodyPart = readCSV("BodyPart");
            string Description = readCSV("Description");
            string IsInjuredWorkerLosingTime = readCSV("IsInjuredWorkerLosingTime");
            string IsInjuredWorkerModifiedShift = readCSV("IsInjuredWorkerModifiedShift");
            string PreparerPhone = readCSV("PreparerPhone");
            string Date = DateTime.Now.AddDays(-1).ToString("MMddyyyy");
            string DataSaveMessage = readCSV("DataSaveMessage");
            #endregion

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
            nceWC.FillRequiredFieldsInWCForm(Location, FirstName, LastName, Address, City, Zip, DOB, SSN, Occupation, Date, AccidentCause, InjuryType, BodyPart, Description, IsInjuredWorkerLosingTime, IsInjuredWorkerModifiedShift, SelectState, PreparerPhone);
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