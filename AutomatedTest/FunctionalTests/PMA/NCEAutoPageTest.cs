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

        [TestMethod, Description("Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void NA_01nceAutoPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("NA_01", "NCE Auto-Create a new Auto claim and cancel");

            string HomePageTitle = readCSV("HomePageTitle");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
    }
}