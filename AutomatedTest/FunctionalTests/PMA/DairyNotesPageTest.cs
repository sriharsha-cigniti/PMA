using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
     public class DairyNotesPageTest : PMA.TestBaseTemplate
    {
        HomePage home = new HomePage();
        ClaimInquiry cInquiry = new ClaimInquiry();
        DairyNotesPage dairyNotes = new DairyNotesPage();

        [TestMethod, Description("Create a diary entry"), TestCategory("Regression")]

        public void CI_D1DairyNotes()
        {
            this.TESTREPORT.InitTestCase("CI_D1", "Create a diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string SubjectText = readCSV("SubjectText");
            string TextInTextArea = readCSV("TextInTextArea");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickOnDairy();
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            dairyNotes.ClickOnCreateEntry();
            dairyNotes.ClickDropDown();
            dairyNotes.SelectCategoryDropDown();
            dairyNotes.EnterSubjectText(SubjectText);
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            dairyNotes.ClickSave();
            dairyNotes.VerifyColumns(SubjectText,TextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickHome();
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(),Index[1].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Create a diary entry"), TestCategory("Regression")]

        public void CI_D2DairyNotes()
        {
            this.TESTREPORT.InitTestCase("CI_D1", "Create a diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string SubjectText = readCSV("SubjectText");
            string TextInTextArea = readCSV("TextInTextArea");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickOnDairy();
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            dairyNotes.ClickOnCreateEntry();
            dairyNotes.ClickDropDown();
            dairyNotes.SelectCategoryDropDown();
            dairyNotes.EnterSubjectText(SubjectText);
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            dairyNotes.VerifyColumns(SubjectText, TextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickHome();
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}
