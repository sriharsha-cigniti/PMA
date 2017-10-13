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
    public class NCEAutoPageTest : PMA.TestBaseTemplate
    {

        [TestMethod, Description("NCEAutoPage-Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void NA_01nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_01", "NCE Auto-Create a new Auto claim and cancel");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NA_02nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_02", "Create a new Auto claim, fill out only the required fields and submit");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify '!Required Field' error message");
            nceAuto.ClickSubmit();
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate(Date);
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }







    }
}