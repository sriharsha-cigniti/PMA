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
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            DairyNotesPage dairyNotes = new DairyNotesPage();

            this.TESTREPORT.InitTestCase("CI_D1", "Create a diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string SubjectText = readCSV("SubjectText");
            string TextInTextArea = readCSV("TextInTextArea");
            string ClaimantName = readCSV("ClaimantName");


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch welcome text 
            home.VerifyCinchWelome();
            //Click  on ClaimInquiry tab
            home.ClickClaimInquiry();
            //Verify Claim Inquiry Page Title
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Click on Search
            home.ClickSearch();
            //Enter Claimant Name 'L'
            cInquiry.EnterClaimantName(ClaimantName);
            //Table Results count
            home.ClaimInquiryResultsCount();
            //Click on random CLaim
            ArrayList Index = home.ClickOnRandomClaim();
            //Verify Claim Number 
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify claimant Name
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Diary 
            dairyNotes.ClickOnDairy();
            //Verify No entries text
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            //Click on Create Entry
            dairyNotes.ClickOnCreateEntry();
            //Clikck on Dropdown
            dairyNotes.ClickDropDown();
            // dairyNotes.SelectCategoryDropDown("Diary");
            string SubjectTextValue = SubjectText + dairyNotes.GenerateRandomNumber();
            //Enter Subject text
            dairyNotes.EnterSubjectText(SubjectTextValue);
            //Enter Text in text area
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            //Click on Save
            dairyNotes.ClickSave();
            //Verify Subject and Text area text
            dairyNotes.VerifyColumns(SubjectTextValue, TextInTextArea);
            //Verify Claim Number
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify Claimant Name
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Home
            dairyNotes.ClickHome();
            //Verify Home DIary Columns
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
            //Click on Exit 
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Update existing diary entry"), TestCategory("Regression")]

        public void CI_D2DairyNotes()
        {

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            DairyNotesPage dairyNotes = new DairyNotesPage();

            this.TESTREPORT.InitTestCase("CI_D2", "Update existing diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string SubjectText = readCSV("SubjectText");
            string TextInTextArea = readCSV("TextInTextArea");
            string SubjectEditText = readCSV("SubjectEditText");
            string EditTextInTextArea = readCSV("EditTextInTextArea");
            string ClaimantName = readCSV("ClaimantName");


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch welcome text 
            home.VerifyCinchWelome();
            //Click  on ClaimInquiry tab
            home.ClickClaimInquiry();
            //Verify Claim Inquiry Page Title
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Click on Search
            home.ClickSearch();
            //Enter Claimant Name 'L'
            cInquiry.EnterClaimantName(ClaimantName);
            //Table Results count
            home.ClaimInquiryResultsCount();
            //Click on random CLaim
            ArrayList Index = home.ClickOnRandomClaim();
            //Verify Claim Number 
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify claimant Name
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Diary 
            dairyNotes.ClickOnDairy();
            //Verify No entries text
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            //Click on Create Entry
            dairyNotes.ClickOnCreateEntry();
            //Click on Dropdown
            dairyNotes.ClickDropDown();
            //Select Diary value from dropdown
            dairyNotes.SelectCategoryDropDown("Diary");
            string SubjectTextValue = SubjectText + dairyNotes.GenerateRandomNumber();
            //Enter Subject text
            dairyNotes.EnterSubjectText(SubjectTextValue);
            //Enter Text in text area
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            //Click on Save
            dairyNotes.ClickSave();
            //Click on Edit
            dairyNotes.ClickEdit();
            string SubjectEditTextvalue = SubjectEditText + dairyNotes.GenerateRandomNumber();
            //Edit Subject Text
            dairyNotes.EnterSubjectText(SubjectEditTextvalue);
            //Edit Text in Text area
            dairyNotes.EnterTextInTextArea(EditTextInTextArea);
            //Click on status dropdown
            dairyNotes.ClickStatusDropDown();
            //Select value from status dropdwon
            dairyNotes.SelectStatusDropDown("Open");
            //Select due date
            dairyNotes.DueDate();
            //Click on Save
            dairyNotes.ClickSave();
            //Verify Subject text and Edit text columns
            dairyNotes.VerifyColumns(SubjectEditTextvalue, EditTextInTextArea);
            //Verify Claim Number
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify Claimant Name
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Home
            dairyNotes.ClickHome();
            //Verify Columns in Home Page
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
            //click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Delete the existing diary entry"), TestCategory("Regression")]

        public void CI_D3DairyNotes()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            DairyNotesPage diaryNotes = new DairyNotesPage();

            this.TESTREPORT.InitTestCase("CI_D3", "Delete the existing diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            string HomePageTitle = readCSV("HomePageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch welcome text
            home.VerifyCinchWelome();
            //Select my diary from Home page
            int value = home.VerifyandSelectMyDiary();
            
            if (value > 0)
            {
                //Verify Diary Lable
                diaryNotes.VerifyDiaryLable(); 
                //Click on Delete for Diary
                diaryNotes.ClickDelete();
                //Verify No entries text
                diaryNotes.VerifyNoEntriesText(NoEntriesText); 
                //Click on Home
                diaryNotes.ClickHome();
                //Verify Dairy Count
                diaryNotes.VerifyDiaryCount(value);
            }
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Deleting the existing diary entry from Claim information page"), TestCategory("Regression")]

        public void CI_D4DairyNotes()
        {

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            DairyNotesPage dairyNotes = new DairyNotesPage();
            this.TESTREPORT.InitTestCase("CI_D4", "Deleting the existing diary entry from Claim information page");
            
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string NoEntriesText = readCSV("NoEntriesText");
            string SubjectText = readCSV("SubjectText");
            string TextInTextArea = readCSV("TextInTextArea");
            string ClaimantName = readCSV("ClaimantName");


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            int beforeCount = dairyNotes.GetDiaryCount();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            cInquiry.EnterClaimantName(ClaimantName);
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickOnDairy();
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            dairyNotes.ClickOnCreateEntry();
            dairyNotes.ClickDropDown();
            dairyNotes.SelectCategoryDropDown("Diary");
            dairyNotes.EnterSubjectText(SubjectText);
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            dairyNotes.ClickSave();
            dairyNotes.VerifyColumns(SubjectText, TextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickDelete();
            dairyNotes.VerifyNoEntriesText(NoEntriesText);
            dairyNotes.ClickHome();
            dairyNotes.VerifyDiaryCount(beforeCount);            
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}
