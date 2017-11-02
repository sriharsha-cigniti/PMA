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
    public class OshaPageTest : PMA.TestBaseTemplate
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


        [TestMethod, Description("Osha-Add a time period to the Lost days Calculator"), TestCategory("Regression")]
        public void Osha_03oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_03", "Add a time period to the Lost days Calculator");

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

                    osha.ClickOnNewLink();
                    this.TESTREPORT.LogInfo("'Cancel' link");
                    osha.VerifyCancel();
                    this.TESTREPORT.LogInfo("'Update' link");
                    osha.EnterBeginDate();
                    osha.EnterEndDate();
                    osha.VerifyAndClickUpdate();

                    this.TESTREPORT.LogInfo("Total Days(count of all the days in Days column)");
                    osha.VerifyTotalLostDays();

                    this.TESTREPORT.LogInfo("'Submit changes completed at given Time");
                    osha.ClickAndVerifySubmitChanges();
                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));

              

                osha.ClickOnExitDetail();
                this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Osha-Add a time period to the restricted days Calculator"), TestCategory("Regression")]
        public void Osha_04oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_04", "Add a time period to the restricted days Calculator");

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

                    osha.ClickOnRestrictedLink();
                    this.TESTREPORT.LogInfo("'Cancel' link");
                    osha.VerifyCancel();
                    this.TESTREPORT.LogInfo("'Update' link");
                    osha.EnterRestrictedBeginDate();
                    osha.EnterRestrictedEndDate();
                    osha.VerifyAndClickUpdate();

                    this.TESTREPORT.LogInfo("Total Days(count of all the days in Days column)");
                    osha.VerifyRestrictedDays();

                    this.TESTREPORT.LogInfo("'Submit changes completed at given Time");
                    osha.ClickAndVerifySubmitChanges();
                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));



                osha.ClickOnExitDetail();
                this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Osha-Log in and view an OSHA claim, make the changes in the claim and submit"), TestCategory("Regression")]
        public void Osha_05oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_05", "Log in and view an OSHA claim, make the changes in the claim and submit");

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
                osha.ClickOnModifySortLink();
                osha.ClickOnModifySortLink();
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

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Establishment Name ");
                    osha.VerifyEstablishmentName();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Location ");
                    osha.VerifyLocation("0000000RAD");

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Employee Name ");
                    osha.VerifyEmployeeName();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Job title ");
                    osha.VerifyEmployeeJobtitle();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Exclude");
                    osha.VerifyExclude();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Privacy");
                    osha.VerifyPrivacy();
                    
                    this.TESTREPORT.LogInfo("Modify and Verify changes in Injury/Illness");
                    osha.VerifyInjuryorIllness("Slipped on ice");

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Injury Date");
                    osha.VerifyInjuryDate();

                    this.TESTREPORT.LogInfo("'Submit changes completed at given Time");
                    osha.ClickAndVerifySubmitChanges();

                    ArrayList fields = osha.Getfieldstext();

                    osha.ClickOnExitDetail();
                    this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                    osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

                    osha.ClickOnModifySortLink();
                    osha.ClickOnModifySortLink();

                    this.TESTREPORT.LogInfo("Verify modified Employee name value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[0].ToString(),"Employee name");

                    this.TESTREPORT.LogInfo("Verify modified Job Title value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[1].ToString(), "Job Title");

                    this.TESTREPORT.LogInfo("Verify modified Injury Date value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[2].ToString(), "Injury Date");

                    this.TESTREPORT.LogInfo("Verify modified Establishment Name value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[3].ToString(), "Establishment Name");

                    this.TESTREPORT.LogInfo("Verify modified location value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[4].ToString(), "location");

                    this.TESTREPORT.LogInfo("Verify modified Injury/Illness value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[5].ToString(), "Injury/Illness");
                    
                    this.TESTREPORT.LogInfo("Verify Exclude checkbox value in osha claim details");
                    osha.VerifyModifiedExcludeValueOshaClaimDetails();

                    this.TESTREPORT.LogInfo("Verify Privacy date value in osha claim details");
                    osha.VerifyModifiedPrivacyValueOshaClaimDetails();
                    
                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));
                
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Osha-Log in and view an OSHA claim and submit"), TestCategory("Regression")]
        public void Osha_06oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_06", "Log in and view an OSHA claim, make the changes in the claim and submit");

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

                osha.ClickOnModifySortLink();
                osha.ClickOnModifySortLink();
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

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Establishment Name ");
                    osha.VerifyEstablishmentName();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Location ");
                    osha.VerifyLocation("0000000RAD");

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Employee Name ");
                    osha.VerifyEmployeeName();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Job title ");
                    osha.VerifyEmployeeJobtitle();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Exclude");
                    osha.VerifyExclude();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Privacy");
                    osha.VerifyPrivacy();

                   

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Injury/Illness");
                    osha.VerifyInjuryorIllness("Slipped on ice");

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Injury Date");
                    osha.VerifyInjuryDate();

                    this.TESTREPORT.LogInfo("'Submit changes completed at given Time");
                    osha.ClickAndVerifySubmitChanges();

                    ArrayList fields = osha.Getfieldstext();

                    osha.ClickOnExitDetail();
                    this.TESTREPORT.LogInfo("Verify OSHA Tab should be highlighted(focused) in the Main Menu");
                    osha.VerifyOshaTabHighLightColor(NewOshaTabHighlightcolor);

                    osha.ClickOnModifySortLink();
                    osha.ClickOnModifySortLink();

                    this.TESTREPORT.LogInfo("Verify modified Employee name value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[0].ToString(), "Employee name");

                    this.TESTREPORT.LogInfo("Verify modified Job Title value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[1].ToString(), "Job Title");

                    this.TESTREPORT.LogInfo("Verify modified Injury Date value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[2].ToString(), "Injury Date");

                    this.TESTREPORT.LogInfo("Verify modified Establishment Name value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[3].ToString(), "Establishment Name");

                    this.TESTREPORT.LogInfo("Verify modified location value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[4].ToString(), "location");

                    this.TESTREPORT.LogInfo("Verify modified Injury/Illness value in osha claim details");
                    osha.VerifyModifiedOshaClaimDetails(fields[5].ToString(), "Injury/Illness");

                    this.TESTREPORT.LogInfo("Verify Exclude checkbox value in osha claim details");
                    osha.VerifyModifiedExcludeValueOshaClaimDetails();

                    this.TESTREPORT.LogInfo("Verify Privacy date value in osha claim details");
                    osha.VerifyModifiedPrivacyValueOshaClaimDetails();

                     this.TESTREPORT.LogInfo("Verify Modified date value in osha claim details");
                    string ModifiedDate = DateTime.Now.ToString("MM/dd/yyyy");
                    osha.VerifyModifiedOshaClaimDetails(ModifiedDate, "Modified Date");

                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));

            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Osha-Log in and view an OSHA claim, check the Exclude and Privacy checkboxes and submit"), TestCategory("Regression")]
        public void Osha_07oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_07", "Log in and view an OSHA claim, check the Exclude and Privacy checkboxes and submit");

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
                osha.ClickOnModifySortLink();
                osha.ClickOnModifySortLink();

                if (osha.TableRowExists() > 0)
                {
                    this.TESTREPORT.LogInfo("Modify and Verify changes in Exclude");
                    osha.ModifyExcludeCheckboxinGridView();

                    this.TESTREPORT.LogInfo("Modify and Verify changes in Privacy");
                    osha.ModifyPrivacyCheckboxinGridView();

                    this.TESTREPORT.LogInfo("Click Submit Changes");
                    osha.ClickSubmitChangesOnReportClaims();

                    this.TESTREPORT.LogInfo("Verify Exclude checkbox value in osha claim details");
                    osha.VerifyModifiedExcludeValueOshaClaimDetails();

                    this.TESTREPORT.LogInfo("Verify Privacy date value in osha claim details");
                    osha.VerifyModifiedPrivacyValueOshaClaimDetails();

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

                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA TO DISPLAY </mark>"));
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }
        
        [TestMethod, Description("Osha-Log in and view an OSHA claim, Click Export to Spreadsheet"), TestCategory("Regression")]
        public void Osha_08oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_08", "Log in and view an OSHA claim, Click Export to Spreadsheet");

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
                osha.ClickOnExportSpreadsheet();
                cInquiry.GetExportFilePath("gridresult.csv");
                cInquiry.ExportFileExists();
                cInquiry.ExportFileDelete();
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("OSHA - Click on clear, clears the field values"), TestCategory("Regression")]
        public void Osha_09oshaPage()
        {
            this.TESTREPORT.InitTestCase("Osha_09", "Click on clear, clears the field values");

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
                osha.ClickOnModifySortLink();
                osha.ClickOnModifySortLink();

                ArrayList claimdetails = osha.ClickOnClaimnumber();
                if (claimdetails.Count > 0)
                {
                    osha.ClickOnExitDetail();
                    osha.SearchWithClaimNo(claimdetails[0].ToString());
                    osha.VerifyClaimNoSearchResult(claimdetails[0].ToString());
                    osha.ClickOnClear();
                    osha.VerifyClaimTextAfterClear(claimdetails[0].ToString());
                    osha.VerifySearchResultsAfterClear("1");




                }
                else
                    this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA FOUND</mark>"));
                
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<mark> NO DATA/YEAR FOUND</mark>"));

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }









    }
}
