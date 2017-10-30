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
    public  class OshaPageTest:PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string NewOshaTabHighlightcolor { get; set; }
        public static string OshaPageTitle { get; set; }
        public static string Year { get; set; }
        public static string OshaPageTitle2 { get; set; }
        public static string PageSize { get; set; }
       
        public OshaPageTest()
        {
            // Read CSV values
           
             HomePageTitle = readCSV("HomePageTitle");
             NewOshaTabHighlightcolor = readCSV("NewOshaTabHighlightcolor");
             OshaPageTitle = readCSV("OshaPageTitle");
             Year = readCSV("Year");
             OshaPageTitle2 = readCSV("OshaPageTitle2");
             PageSize = readCSV("Pagesize");
        }
        #endregion

        [TestMethod, Description("Osha-Log in and view an OSHA claim"), TestCategory("Regression")]
        public void Osha_01oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_01", "Log in and view an OSHA claim");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify Osha tab");
            osha.ClickOnOsha();

            this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
            osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

            this.TESTREPORT.LogInfo("Verify 'Important Information Please Read' text");
            osha.VerifyInformation();
            
            osha.ClickAcceptButton();
            this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
            osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);


            this.TESTREPORT.LogInfo("Verify Page Title");
            home.VerifyPageTitle(OshaPageTitle);

            if (osha.SelectYearFromDropdown(Year))
            {
                ArrayList claimdetails = osha.ClickOnClaimnumber();
                if (claimdetails.Count > 0)
                {
                    this.TESTREPORT.LogInfo("Verify Page Title");
                    home.VerifyPageTitle(OshaPageTitle2);

                    this.TESTREPORT.LogInfo("Verify Claim Number");
                    osha.VerifyOshaClaimDetail(claimdetails[0].ToString(), osha.GetClaimno());

                    this.TESTREPORT.LogInfo("Verify  Account number");
                    osha.VerifyOshaClaimDetail(osha.GetAccountNoFromPageHeader(), osha.GetClaimAccountNo());

                    this.TESTREPORT.LogInfo("Verify Name");
                    osha.VerifyOshaClaimDetail(claimdetails[2].ToString(), osha.GetEstablishmentName());

                    this.TESTREPORT.LogInfo("Verify Job Title ");
                    osha.VerifyOshaClaimDetail(claimdetails[1].ToString(), osha.GetJobtitle());
                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));

                    osha.ClickOnExitDetail();
                    this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                    osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

                    this.TESTREPORT.LogInfo("Verify  Default/Selected year from drop down");
                    osha.VerifyDropDownValue(Year);
                }
                else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

                home.ClickExit();
                this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Claim Inquiry-Click reset clears all Claim Inquiry fields"), TestCategory("Regression")]
        public void Osha_02oshaPage()
        {
            
            this.TESTREPORT.InitTestCase("Osha_02", "Click reset clears all Claim Inquiry fields");
          

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify Osha tab");
            osha.ClickOnOsha();

            this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
            osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

            this.TESTREPORT.LogInfo("Verify 'Important Information Please Read' text");
            osha.VerifyInformation();

            osha.ClickAcceptButton();
            this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
            osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

            //osha.ClickAcceptButton();

            this.TESTREPORT.LogInfo("Verify Page Title");
            home.VerifyPageTitle(OshaPageTitle);

            this.TESTREPORT.LogInfo("Verify results in the Injury date column");
            osha.SelectYearFromDropdown(Year);
            osha.SelectPageSizeAll(PageSize);
            osha.VerifyInjuryDateColoumn(Year);

            if (osha.SelectYearFromDropdown(Year))
            {
                ArrayList claimdetails = osha.ClickOnClaimnumber();
                if (claimdetails.Count > 0)
                {
                    this.TESTREPORT.LogInfo("Verify Page Title");
                    home.VerifyPageTitle(OshaPageTitle2);

                    this.TESTREPORT.LogInfo("Verify Claim Number");
                    osha.VerifyOshaClaimDetail(claimdetails[0].ToString(), osha.GetClaimno());

                    this.TESTREPORT.LogInfo("Verify  Account number");
                    osha.VerifyOshaClaimDetail(osha.GetAccountNoFromPageHeader(), osha.GetClaimAccountNo());

                    this.TESTREPORT.LogInfo("Verify Name");
                    osha.VerifyOshaClaimDetail(claimdetails[2].ToString(), osha.GetEstablishmentName());

                    this.TESTREPORT.LogInfo("Verify Job Title ");
                    osha.VerifyOshaClaimDetail(claimdetails[1].ToString(), osha.GetJobtitle());
                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));

                osha.ClickOnExitDetail();
                this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

                this.TESTREPORT.LogInfo("Verify  Default/Selected year from drop down");
                osha.VerifyDropDownValue(Year);
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }







    }
}
