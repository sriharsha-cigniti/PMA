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
    public class HelpTest : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string HelpPageTitle { get; set; }
        public static string PMACinchSupportText { get; set; }
        public static string ClaimInquiryUserGuideText { get; set; }
        public static string ClaimInquiryTextInPdf { get; set; }
        public static string HelpLinkHighLightColor { get; set; }
        public static string ReportsUserGuideText { get; set; }
        public static string ReportsUserGuideTextInPdf { get; set; }
        public static string ReportsQuickReferenceGuideText { get; set; }
        public static string ReportsQuickReferenceGuideTextInPdf { get; set; }
        public static string AnalysisToolUserGuideText { get; set; }
        public static string AnalysisToolUserGuideTextInPdf { get; set; }
        public static string AMPSUserGuideText { get; set; }
        public static string AMPSUserGuideTextInPdf { get; set; }
        public static string OSHAUserGuideText { get; set; }
        public static string OSHALink { get; set; }
        public static string OSHAUserGuideTextInPdf { get; set; }
        public static string OSHAPrinttoLetterSizeText { get; set; }
        public static string SettingsQuickReferenceGuideText { get; set; }
        public static string SettingsQuickReferenceGuideTextInPdf { get; set; }
        public static string NewClaimEntryWorkersCompensationText { get; set; }
        public static string NewClaimEntryPropertyText { get; set; }
        public static string NewClaimEntryPropertyTextInPdf { get; set; }
        public static string NewClaimEntryGeneralLiabilityText { get; set; }
        public static string NewClaimEntryGeneralLiabilityTextInPdf { get; set; }
        public static string NewClaimEntryAutomobileText { get; set; }
        public static string NewClaimEntryAutomobileTextInPdf { get; set; }

        #endregion

        public HelpTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            HelpPageTitle = readCSV("HelpPageTitle");
            PMACinchSupportText = readCSV("PMACinchSupportText");
            ClaimInquiryUserGuideText = readCSV("ClaimInquiryUserGuideText");
            ClaimInquiryTextInPdf = readCSV("ClaimInquiryTextInPdf");
            HelpLinkHighLightColor = readCSV("HelpLinkHighLightColor");
            ReportsUserGuideText = readCSV("ReportsUserGuideText");
            ReportsUserGuideTextInPdf = readCSV("ReportsUserGuideTextInPdf");
            ReportsQuickReferenceGuideText = readCSV("ReportsQuickReferenceGuideText");
            ReportsQuickReferenceGuideTextInPdf = readCSV("ReportsQuickReferenceGuideTextInPdf");
            AnalysisToolUserGuideText = readCSV("AnalysisToolUserGuideText");
            AnalysisToolUserGuideTextInPdf = readCSV("AnalysisToolUserGuideTextInPdf");
            AMPSUserGuideText = readCSV("AMPSUserGuideText");
            AMPSUserGuideTextInPdf = readCSV("AMPSUserGuideTextInPdf");
            OSHAUserGuideText = readCSV("OSHAUserGuideText");
            OSHALink = readCSV("OSHALink");
            OSHAUserGuideTextInPdf = readCSV("OSHAUserGuideTextInPdf");
            OSHAPrinttoLetterSizeText = readCSV("OSHAPrinttoLetterSizeText");
            SettingsQuickReferenceGuideText = readCSV("SettingsQuickReferenceGuideText");
            SettingsQuickReferenceGuideTextInPdf = readCSV("SettingsQuickReferenceGuideTextInPdf");
            NewClaimEntryWorkersCompensationText = readCSV("NewClaimEntryWorkersCompensationText");
            NewClaimEntryPropertyText = readCSV("NewClaimEntryPropertyText");
            NewClaimEntryPropertyTextInPdf = readCSV("NewClaimEntryPropertyTextInPdf");
            SettingsQuickReferenceGuideText = readCSV("SettingsQuickReferenceGuideText");
            SettingsQuickReferenceGuideTextInPdf = readCSV("SettingsQuickReferenceGuideTextInPdf");
            NewClaimEntryGeneralLiabilityText = readCSV("NewClaimEntryGeneralLiabilityText");
            NewClaimEntryGeneralLiabilityTextInPdf = readCSV("NewClaimEntryGeneralLiabilityTextInPdf");
            NewClaimEntryAutomobileText = readCSV("NewClaimEntryAutomobileText");
            NewClaimEntryAutomobileTextInPdf = readCSV("NewClaimEntryAutomobileTextInPdf");
        }

        [TestMethod, Description("Help - User should be navigated to the Cinch support page inside Cinch"), TestCategory("Regression")]
        public void Help_01HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_01", "User should be navigated to the Cinch support page inside Cinch");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the Claim Inquiry User Guide"), TestCategory("Regression")]
        public void Help_02HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_02", "Navigate to the Cinch help section and download the Claim Inquiry User Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click Claim Inquiry User Guide");
            help.ClickOnLink(ClaimInquiryUserGuideText);

            this.TESTREPORT.LogInfo("Verify ClaimInquiryUserGuide.pdf should download in new tab, Page Title and 'Claim Inquiry' text");
            help.VerifyPdfFile(ClaimInquiryUserGuideText);
            help.VerifyTextInPDFFile(1, ClaimInquiryTextInPdf);

            this.TESTREPORT.LogInfo("Close ClaimInquiryUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the Reports User Guide"), TestCategory("Regression")]
        public void Help_03HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_03", "Navigate to the Cinch help section and download the Reports User Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click Claim Inquiry User Guide");
            help.ClickOnLink(ReportsUserGuideText);

            this.TESTREPORT.LogInfo("Verify ReportsUserGuide.pdf should download in new tab, Page Title and 'Reports' text");
            help.VerifyPdfFile(ReportsUserGuideText);
            help.VerifyTextInPDFFile(1, ReportsUserGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close ReportsUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the Reports Quick Reference Guide"), TestCategory("Regression")]
        public void Help_04HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_04", "Navigate to the Cinch help section and download the Reports Quick Reference Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click Claim Inquiry User Guide");
            help.ClickOnLink(ReportsQuickReferenceGuideText);

            this.TESTREPORT.LogInfo("Verify ReportsUserGuide.pdf should download in new tab, Page Title and 'Reports' text");
            help.VerifyPdfFile(ReportsQuickReferenceGuideText);
            help.VerifyTextInPDFFile(1, ReportsQuickReferenceGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close ReportsUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the Analysis Tool User Guide"), TestCategory("Regression")]
        public void Help_05HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_05", "Navigate to the Cinch help section and download the Analysis Tool User Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click Analysis Tool User Guide");
            help.ClickOnLink(AnalysisToolUserGuideText);

            this.TESTREPORT.LogInfo("Verify AnalysisToolUserGuide.pdf should download in new tab, Page Title and 'PMA Cinch Analysis Tool' text");
            help.VerifyPdfFile(AnalysisToolUserGuideText);
            help.VerifyTextInPDFFile(1, AnalysisToolUserGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close AnalysisToolUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the AMPS User Guide"), TestCategory("Regression")]
        public void Help_06HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_06", "Navigate to the Cinch help section and download the AMPS User Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click AMPS User Guide");
            help.ClickOnLink(AMPSUserGuideText);

            this.TESTREPORT.LogInfo("Verify AMPSUserGuide.pdf should download in new tab, Page Title and 'Welcome to PMA AMPS Online Billing System' text");
            help.VerifyPdfFile(AMPSUserGuideText);
            help.VerifyTextInPDFFile(1, AMPSUserGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close AMPSUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the OSHA User Guide"), TestCategory("Regression")]
        public void Help_07HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_07", "Navigate to the Cinch help section and download the OSHA User Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click OSHA User Guide");
            help.ClickOnLink(OSHALink);

            this.TESTREPORT.LogInfo("Verify OSHAUserGuide.pdf should download in new tab, Page Title and 'OSHA TRACKING' text");
            help.VerifyPdfFile(OSHAUserGuideText);
            help.VerifyTextInPDFFile(1, OSHAUserGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close OSHAUserGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the OSHA Print to Letter Size"), TestCategory("Regression")]
        public void Help_08HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_08", "Navigate to the Cinch help section and download the OSHA Print to Letter Size");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click OSHA Print to Letter Size");
            help.ClickOnLink(OSHAPrinttoLetterSizeText);

            this.TESTREPORT.LogInfo("Verify OSHA-PrintToLetterSize.pdf should download in new tab, Page Title");
            help.VerifyPdfFile(OSHAPrinttoLetterSizeText);

            this.TESTREPORT.LogInfo("Close OSHA-PrintToLetterSize.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the Settings Quick Reference Guide"), TestCategory("Regression")]
        public void Help_09HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_09", "Navigate to the Cinch help section and download the Settings Quick Reference Guide");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click Settings Quick Reference Guide");
            help.ClickOnLink(SettingsQuickReferenceGuideText);

            this.TESTREPORT.LogInfo("Verify SettingsQuickReferenceGuide.pdf should download in new tab, Page Title and 'SETTINGS' text");
            help.VerifyPdfFile(SettingsQuickReferenceGuideText);
            help.VerifyTextInPDFFile(1, SettingsQuickReferenceGuideTextInPdf);

            this.TESTREPORT.LogInfo("Close SettingsQuickReferenceGuide.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the document for New Claim Entry - Automobile"), TestCategory("Regression")]
        public void Help_10HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_10", "Navigate to the Cinch help section and download the document for New Claim Entry - Automobile");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click New Claim Entry - Automobile");
            help.ClickOnLink(NewClaimEntryAutomobileText);

            this.TESTREPORT.LogInfo("Verify New Claim Entry - Automobile.pdf should download in new tab, Page Title and 'AUTOMOBILE' text");
            help.VerifyPdfFile(NewClaimEntryAutomobileText);
            help.VerifyTextInPDFFile(1, NewClaimEntryAutomobileTextInPdf);

            this.TESTREPORT.LogInfo("Close New Claim Entry - Automobile.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the document for New Claim Entry - Property"), TestCategory("Regression")]
        public void Help_11HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_11", "Navigate to the Cinch help section and download the document for New Claim Entry - Property");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click New Claim Entry - Property");
            help.ClickOnLink(NewClaimEntryPropertyText);

            this.TESTREPORT.LogInfo("Verify New Claim Entry - Property.pdf should download in new tab, Page Title and 'PROPERTY' text");
            help.VerifyPdfFile(NewClaimEntryPropertyText);
            help.VerifyTextInPDFFile(1, NewClaimEntryPropertyTextInPdf);

            this.TESTREPORT.LogInfo("Close New Claim Entry - Property.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the document for New Claim Entry - General Liability"), TestCategory("Regression")]
        public void Help_12HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_12", "Navigate to the Cinch help section and download the document for New Claim Entry - General Liability");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click New Claim Entry - General Liability");
            help.ClickOnLink(NewClaimEntryGeneralLiabilityText);

            this.TESTREPORT.LogInfo("Verify New Claim Entry - General Liability.pdf should download in new tab, Page Title and 'GENERAL LIABILITY' text");
            help.VerifyPdfFile(NewClaimEntryGeneralLiabilityText);
            help.VerifyTextInPDFFile(1, NewClaimEntryGeneralLiabilityTextInPdf);

            this.TESTREPORT.LogInfo("Close New Claim Entry - General Liability.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Help - Navigate to the Cinch help section and download the document for New Claim Entry - Workers' Compensation"), TestCategory("Regression")]
        public void Help_13HelpTest()
        {
            this.TESTREPORT.InitTestCase("Help_13", "Navigate to the Cinch help section and download the document for New Claim Entry - Workers' Compensation");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click /'Help/' Tab. Verify Help Page is displayed and PMA Cinch® Support text");
            help.ClickOnHelpTab();
            home.VerifyPageTitle(HelpPageTitle);
            help.VerifyPMACinchText();

            this.TESTREPORT.LogInfo("Click New Claim Entry - Workers' Compensation");
            help.ClickOnLink(NewClaimEntryWorkersCompensationText);

            this.TESTREPORT.LogInfo("Verify New Claim Entry - Workers' Compensation.pdf should download in new tab, Page Title");
            help.VerifyPdfFile(NewClaimEntryWorkersCompensationText);

            this.TESTREPORT.LogInfo("Close New Claim Entry - Workers' Compensation.pdf ,Verify pdf is closed and Cinch application is diaplayed");
            cInquiry.CloseChildWindow();
            help.VerifyPdfClose();
            cInquiry.SwitchToParentWindow();
            help.VerifyHelpTabIsFocus(HelpLinkHighLightColor);

            this.TESTREPORT.LogInfo("Click on Exit and Verify User should logout Successfully");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}