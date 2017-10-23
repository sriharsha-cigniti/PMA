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

            this.TESTREPORT.InitTestCase("NCE_GL1", "Create a new General Liability claim and cancel");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("NCEGeneralLiabilityTests");
            #endregion

            
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'New claim Entry/' Tab. Verify New Claim Entry Page is displayed and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }


    }
}