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

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Property' text");
            nceProperty.VerifyPropertyForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify '!Required Field' error message");
            nceAuto.ClickSubmit();

            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
           
            nceAuto.EnterOccurenceDate();
            nceProperty.SelectLocationLoss(LocationLoss);
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