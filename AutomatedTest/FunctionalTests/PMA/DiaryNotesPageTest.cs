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
    public class DiaryNotesPageTest : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string ClaimInquiryPageTitle { get; set; }
        public static string NoEntriesText { get; set; }
        public static string SubjectText { get; set; }
        public static string TextInTextArea { get; set; }
        public static string ClaimantName { get; set; }
        public static string SubjectEditText { get; set; }
        public static string EditTextInTextArea { get; set; }
        public static string ToolsPageTitle { get; set; }
        public static string SettingsPageTitle { get; set; }
        public static string HelpPageTitle { get; set; }
        #endregion

        public DiaryNotesPageTest()
        {

             HomePageTitle = readCSV("HomePageTitle");
             ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
             NoEntriesText = readCSV("NoEntriesText");
             SubjectText = readCSV("SubjectText");
             TextInTextArea = readCSV("TextInTextArea");
             SubjectEditText = readCSV("SubjectEditText");
             EditTextInTextArea = readCSV("EditTextInTextArea");
             ClaimantName = readCSV("ClaimantName");
        }

        [TestMethod, Description("Create a diary entry"), TestCategory("Regression")]

        public void CI_D1diaryNotes()
        {
           this.TESTREPORT.InitTestCase("CI_D1", "Create a diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            
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
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Diary 
            diaryNotes.ClickOnDairy();
            //Verify No entries text
            diaryNotes.VerifyNoEntriesText(NoEntriesText);
            //Click on Create Entry
            diaryNotes.ClickOnCreateEntry();
            //Clikck on Dropdown
            diaryNotes.ClickDropDown();
            // diaryNotes.SelectCategoryDropDown("Diary");
            string SubjectTextValue = SubjectText + diaryNotes.GenerateRandomNumber();
            //Enter Subject text
            diaryNotes.EnterSubjectText(SubjectTextValue);
            //Enter Text in text area
            diaryNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            //Click on Save
            diaryNotes.ClickSave();
            //Verify Subject and Text area text
            diaryNotes.VerifyColumns(SubjectTextValue, TextInTextArea);
            //Verify Claim Number
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify Claimant Name
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Home
            diaryNotes.ClickHome();
            //Verify Home DIary Columns
            diaryNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
            //Click on Exit 
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Update existing diary entry"), TestCategory("Regression")]

        public void CI_D2diaryNotes()
        {

            this.TESTREPORT.InitTestCase("CI_D2", "Update existing diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
           
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
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Diary 
            diaryNotes.ClickOnDairy();
            //Verify No entries text
            diaryNotes.VerifyNoEntriesText(NoEntriesText);
            //Click on Create Entry
            diaryNotes.ClickOnCreateEntry();
            //Click on Dropdown
            diaryNotes.ClickDropDown();
            //Select Diary value from dropdown
            diaryNotes.SelectCategoryDropDown("Diary");
            string SubjectTextValue = SubjectText + diaryNotes.GenerateRandomNumber();
            //Enter Subject text
            diaryNotes.EnterSubjectText(SubjectTextValue);
            //Enter Text in text area
            diaryNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            //Click on Save
            diaryNotes.ClickSave();
            //Click on Edit
            diaryNotes.ClickEdit();
            string SubjectEditTextvalue = SubjectEditText + diaryNotes.GenerateRandomNumber();
            //Edit Subject Text
            diaryNotes.EnterSubjectText(SubjectEditTextvalue);
            //Edit Text in Text area
            diaryNotes.EnterTextInTextArea(EditTextInTextArea);
            //Click on status dropdown
            diaryNotes.ClickStatusDropDown();
            //Select value from status dropdwon
            diaryNotes.SelectStatusDropDown("Open");
            //Select due date
            diaryNotes.DueDate();
            //Click on Save
            diaryNotes.ClickSave();
            //Verify Subject text and Edit text columns
            diaryNotes.VerifyColumns(SubjectEditTextvalue, EditTextInTextArea);
            //Verify Claim Number
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify Claimant Name
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            //Click on Home
            diaryNotes.ClickHome();
            //Verify Columns in Home Page
            diaryNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
            //click on Exit to close the application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Delete the existing diary entry"), TestCategory("Regression")]

        public void CI_D3diaryNotes()
        {

            this.TESTREPORT.InitTestCase("CI_D3", "Delete the existing diary entry");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            
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

        public void CI_D4diaryNotes()
        {
           
            this.TESTREPORT.InitTestCase("CI_D4", "Deleting the existing diary entry from Claim information page");
            
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            int beforeCount = diaryNotes.GetDiaryCount();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            cInquiry.EnterClaimantName(ClaimantName);
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            diaryNotes.ClickOnDairy();
            diaryNotes.VerifyNoEntriesText(NoEntriesText);
            diaryNotes.ClickOnCreateEntry();
            diaryNotes.ClickDropDown();
            diaryNotes.SelectCategoryDropDown("Diary");
            diaryNotes.EnterSubjectText(SubjectText);
            diaryNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            diaryNotes.ClickSave();
            diaryNotes.VerifyColumns(SubjectText, TextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            diaryNotes.VerifyClaimantName(Index[1].ToString());
            diaryNotes.ClickDelete();
            diaryNotes.VerifyNoEntriesText(NoEntriesText);
            diaryNotes.ClickHome();
            diaryNotes.VerifyDiaryCount(beforeCount);            
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}
