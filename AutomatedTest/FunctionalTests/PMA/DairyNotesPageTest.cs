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
            home.VerifyCinchWelome();
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
           // dairyNotes.SelectCategoryDropDown("Diary");
            dairyNotes.EnterSubjectText(SubjectText);
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            Thread.Sleep(3000);
            dairyNotes.ClickSave();
            dairyNotes.VerifyColumns(SubjectText, TextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickHome();
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
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
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            home.ClickSearch();
            cInquiry.EnterClaimantName(ClaimantName);
            home.ClaimInquiryResultsCount();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickOnDairy();
            //dairyNotes.VerifyNoEntriesText(NoEntriesText);
            dairyNotes.ClickOnCreateEntry();
            dairyNotes.ClickDropDown();
            dairyNotes.SelectCategoryDropDown("Diary");
            dairyNotes.EnterSubjectText(SubjectText);
            dairyNotes.EnterTextInTextArea(TextInTextArea);
            dairyNotes.ClickSave();           
            dairyNotes.ClickEdit();         
            dairyNotes.EnterSubjectText(SubjectEditText);
            dairyNotes.EnterTextInTextArea(EditTextInTextArea);
            dairyNotes.ClickStatusDropDown();
            dairyNotes.SelectStatusDropDown("Open");
            dairyNotes.DueDate();
            dairyNotes.ClickSave();
            dairyNotes.VerifyColumns(SubjectEditText, EditTextInTextArea);
            home.VerifyClaimNumber(Index[0].ToString());
            dairyNotes.VerifyClaimantName(Index[1].ToString());
            dairyNotes.ClickHome();
            dairyNotes.VerifyHomeDairyColumns(Index[0].ToString(), Index[1].ToString());
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
            home.VerifyCinchWelome();
            int value = home.VerifyandSelectMyDiary();
            
            if (value > 0)
            {
                diaryNotes.VerifyDiaryLable();                
                diaryNotes.ClickDelete();
                diaryNotes.VerifyNoEntriesText(NoEntriesText);                 
                diaryNotes.ClickHome();
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
