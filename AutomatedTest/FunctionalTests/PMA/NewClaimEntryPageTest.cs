﻿using System;
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
    public  class NewClaimEntryPageTest : PMA.TestBaseTemplate
    {
        #region Parameters
        public static string HomePageTitle { get; set; }
        public static string SelectBusinessvalueDropDown { get; set; }
        public static string RequiredErrorMessageCount { get; set; }
        public static string ContactBusinessPhone { get; set; }
        public static string DataSaveMessage { get; set; }
        public static string StateofLoss { get; set; }
        public static string LocationLoss { get; set; }
        public static string NewClaimTabHighlightcolor { get; set; }
        public static string TableHeader1 { get; set; }
        public static string TableHeader2 { get; set; }
        public static string TableHeader3 { get; set; }
        public static string TableHeader4 { get; set; }
        public static string TableHeader5 { get; set; }
        
        #endregion
        public NewClaimEntryPageTest()
        {
            #region ReadCSV
             HomePageTitle = readCSV("HomePageTitle");
             SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
             RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
             ContactBusinessPhone = readCSV("ContactBusinessPhone");
             DataSaveMessage = readCSV("DataSaveMessage");
             StateofLoss = readCSV("StateOfLoss");
             LocationLoss = readCSV("LocationLoss");
             NewClaimTabHighlightcolor = readCSV("NewClaimTabHighlightcolor");
             TableHeader1 = readCSV("ClaimEntryHeader1");
             TableHeader2 = readCSV("ClaimEntryHeader2");
             TableHeader3 = readCSV("ClaimEntryHeader3");
             TableHeader4 = readCSV("ClaimEntryHeader4");
             TableHeader5 = readCSV("ClaimEntryHeader5");
            #endregion
        }
        [TestMethod, Description("Create a new Auto claim, save as draft, return to the saved claim page and see the results  displaying according to the selected page size "), TestCategory("Regression")]
        public void NCE_01ncePage()
        {
            this.TESTREPORT.InitTestCase("NCE_01", "NCE Create auto Claim,save and return and validate the saved changes ");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify 'Draft Saved Successfully' message");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nce.ClickSaveAsDraft();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify NewclaimEntry tab highlight");
            nce.VerifyNewClaimEntryTabHighLightColor(NewClaimTabHighlightcolor);

            this.TESTREPORT.LogInfo("Verify 'Saved Drafts' text on table ");
           
            nce.VerifySavedDraftsIsdisplayed();

            this.TESTREPORT.LogInfo("Verify TableHeaders in Payments tab");
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader1);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader2);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader3);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader4);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader5);

            this.TESTREPORT.LogInfo("Verify Page size item count with Claim entry table count");
            nce.SelectPageSizeAll();
            nce.ComparePageSizeItemCountWithClaimantEntryTableCount();

            nceAuto.SwitchToDefaultContent();

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Typing into the column heading field will filter the column rows"), TestCategory("Regression")]
        public void NCE_02ncePage()
        {
            this.TESTREPORT.InitTestCase("NCE_02", "Filtering coloumns on the basis of coloumn text entered in New CLaim inquiry Table ");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify 'Draft Saved Successfully' message");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nce.ClickSaveAsDraft();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify NewclaimEntry tab highlight");
            nce.VerifyNewClaimEntryTabHighLightColor(NewClaimTabHighlightcolor);

            this.TESTREPORT.LogInfo("Verify 'Saved Drafts' text on table ");

            nce.VerifySavedDraftsIsdisplayed();

            this.TESTREPORT.LogInfo("Verify TableHeaders in Payments tab");
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader1);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader2);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader3);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader4);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader5);

            this.TESTREPORT.LogInfo("Verify User should see the results in the table matching with the text entered in the column search field");
            nce.EnterLOB(SelectBusinessvalueDropDown);
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            
            nceAuto.SwitchToDefaultContent();

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Create 2 claim entries for any Line of Business and submit and check whether the Claim number generated is in the sequential order"), TestCategory("Regression")]
        public void NCE_03ncePage()
        {
           
            this.TESTREPORT.InitTestCase("NCE_03", "Verify Claim Number created in sequential order");
           

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceAuto.ClickSubmit();
            this.TESTREPORT.LogInfo("Verify 'Draft Saved Successfully' message");
            nceAuto.VerifyDataSaveMessage("The claim information you entered has been recorded and saved.");
            this.TESTREPORT.LogInfo("Verify claim number generated");
            string Claimno1 = nce.GetAndVerifyClaimNumber();
           
            this.TESTREPORT.LogInfo("Creating another claim ");
            nceAuto.ClickCancel();
            nceAuto.ClickOnNewClaimEntry();
            
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceAuto.ClickSubmit();
            this.TESTREPORT.LogInfo("Verify 'Draft Saved Successfully' message");
            nceAuto.VerifyDataSaveMessage("The claim information you entered has been recorded and saved.");
            this.TESTREPORT.LogInfo("Verify claim number generated");
            string Claimno2 = nce.GetAndVerifyClaimNumber();
            nce.VerifyClaimNoSequentialOrder(Claimno1,Claimno2);
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Create a claim for any Line of Business, save as draft, return to the saved claim page and drag the column headers in the saved drafts table to modify the order of the columns"), TestCategory("Regression")]
        public void NCE_04ncePage()
        {
            this.TESTREPORT.InitTestCase("NCE_04", "Create a claim for any Line of Business, save as draft, return to the saved claim page and drag the column headers in the saved drafts table to modify the order of the columns");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify 'Draft Saved Successfully' message");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nce.ClickSaveAsDraft();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();

            this.TESTREPORT.LogInfo("Verify NewclaimEntry tab highlight");
            nce.VerifyNewClaimEntryTabHighLightColor(NewClaimTabHighlightcolor);

            this.TESTREPORT.LogInfo("Verify 'Saved Drafts' text on table ");

            nce.VerifySavedDraftsIsdisplayed();

            this.TESTREPORT.LogInfo("Verify TableHeaders in Payments tab");
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader1);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader2);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader3);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader4);
            nce.VerifyNewClaimantEntryTableHeaders(TableHeader5);

            this.TESTREPORT.LogInfo("Verify Table modified after swapping cell");
           int prevPositionDescription= nce.getHeaderPosition("Description");
            nce.DragColumns("Location");
            int currentPositionDescription = nce.getHeaderPosition("Description");
            nce.VerifySwappingcellsposition("Description",prevPositionDescription, currentPositionDescription);
            nceAuto.SwitchToDefaultContent();

            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

    }
}
