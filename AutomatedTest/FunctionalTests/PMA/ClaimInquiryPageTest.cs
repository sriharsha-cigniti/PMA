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
using AUT.Selenium.CommonReUsablePages;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class ClaimInquiryPageTests : PMA.TestBaseTemplate
    {
        //Create Page Objectss
        HomePage home = new HomePage();
        ClaimInquiry cInquiry = new ClaimInquiry();


        [TestMethod, Description("Claim Inquiry-Click search with no search fields filled out"), TestCategory("Regression")]
        public void CI_01claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_01", "Claim Inquiry-Click search with no search fields filled out");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch Welcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Click on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Click on Loss line Summary
            cInquiry.ClickLosslineSummary();
            //Loss Line summary CLaim records
            cInquiry.VerifyLossLineSummaryResultsCount();
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Click reset clears all Claim Inquiry fields"), TestCategory("Regression")]
        public void CI_02claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_02", "Claim Inquiry-Click reset clears all Claim Inquiry fields");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string ClaimNumber = readCSV("ClaimNumber");
            string Claimstatus = readCSV("Claimstatus");
            string Last4SSN = readCSV("Last4SSN");
            string FirstName = readCSV("FirstName");
            string LastName = readCSV("LastName");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Fill all the fields by  CSV
            string value = cInquiry.EnterClaimNumber(ClaimNumber);
            string value1 = cInquiry.EnterClaimstatus(Claimstatus);
            string value2 = cInquiry.EnterLast4SSN(Last4SSN);
            string value3 = cInquiry.EnterFirstName(FirstName);
            string value4 = cInquiry.EnterLastName(LastName);
            //CLick on search button
            home.ClickSearch();

            //Verify Loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Click on Loss line Summary
            cInquiry.ClickReset();
            //Need to include the assertion to clear the fields
            cInquiry.VerifyClaimNumber(value);
            cInquiry.VerifyClaimstatus(value1);
            cInquiry.VerifyLast4SSN(value2);
            cInquiry.VerifyFirstName(value3);
            cInquiry.VerifyLastName(value4);

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Location Code Modal - clicking on a row selects the location"), TestCategory("Regression")]
        public void CI_03claimInquiryPage()
        {

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_03", "Claim Inquiry-Location Code Modal - clicking on a row selects the location");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string LocationCodeField = readCSV("LocationCodeField");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Verify Location Icon
            cInquiry.VerifyLocationIcon();
            //Click on Location search Icon
            cInquiry.ClickLocationSearchIcon();

            //Enter the data into the filter columns
            cInquiry.EnterLocationCodeField(LocationCodeField);
            //Given characters in search field
            cInquiry.VerifyLocationCodeFieldTableValue(LocationCodeField);
            //Verify table row count
            //cInquiry.ClickLocationCode();
            //click on any row
            cInquiry.ClickRandomLocationCode();
            //Verify pageTitle
            cInquiry.VerifyPageTitle(ClaimInquiryPageTitle);
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-View all tabs in the claim view(Liability)"), TestCategory("Regression")]
        public void CI_04claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_04", "Claim Inquiry-View all tabs in the claim view(Liability)");
                        
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Need to implement a claim in the grid view
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            //Click on accident tab
            cInquiry.ClickAccidentTab();
            //Verify Accident information text
            cInquiry.VerifyAccidentInformationlink();
            //click on LOsslinetab
            cInquiry.ClickLossLineTab();
            //verify LossLineDescription
            cInquiry.VerifyLossLineDescriptionlink();
            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //Verify Claim Financial total for a claim
            cInquiry.VerifyClaimFinancialTotalText();
            //click on payments tab
            cInquiry.ClickPayments();
            //Verify Payment status
            cInquiry.VerifyPaymentStatuslink();
            //click on Diary tab
            cInquiry.ClickDiary();
            //Verify CReate Entry
            cInquiry.VerifyCreateEntryLink();
            //click on LogNotes tab
            cInquiry.ClickLogNotes();
            //Verify Note
            cInquiry.VerifyNotelink();
            //click on Documents tab
            cInquiry.ClickDocuments();
            //Verify New window 'PMA CINCH document List' title
            cInquiry.SwitchtoDocumentswindow(DocumentsWindowPageTitle);
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Claim Inquiry-View all tabs in the claim view (Workers compensation)"), TestCategory("Regression")]
        public void CI_05claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_05", "Claim Inquiry-View all tabs in the claim view (Workers compensation)");

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            // string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Enter a claim in the grid view
            cInquiry.EnterClaimantName(ClaimantName);
            this.TESTREPORT.LogInfo("Click on any random claim(claim number that starts with W )");
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            //Click on WorkerAccident tab
            cInquiry.ClickWorkerAccident();
            //Verify Employee information text
            cInquiry.VerifyEmployeeInformation();

            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //Verify WagesText
            cInquiry.VerifyWagesText();
            cInquiry.VerifyBreakdownByLosslineText();
            //click on payments tab
            cInquiry.ClickPayments();
            //Verify Payment text
            cInquiry.VerifyPayment();
            //click on Diary tab
            cInquiry.ClickDiary();
            //verify diary text
            cInquiry.VerifyDiary();
            //Verify CReate Entry
            cInquiry.VerifyCreateEntryLink();
            //click on LogNotes tab
            cInquiry.ClickLogNotes();
            //Verify Note
            cInquiry.VerifyNotelink();
            cInquiry.VerifyHideNoteslink();
            cInquiry.VerifyShowNoteslink();
            //click on Documents tab
            cInquiry.ClickDocuments();
            //Verify New window 'PMA CINCH document List' title
            cInquiry.SwitchtoDocumentswindow(DocumentsWindowPageTitle);
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Total Incurred amount"), TestCategory("Regression")]
        public void CI_06claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_06", "Claim Inquiry-Search the data with Total Incurred amount");

            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string IncurredFrom = readCSV("IncurredFrom");
            string IncurredTo = readCSV("IncurredTo");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Enter Incurred Amount from
            cInquiry.EnterIncurredfrom(IncurredFrom);
            //Enter Incurred Amount to
            cInquiry.EnterIncurredTo(IncurredTo);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Total Incurred column

            cInquiry.VerifyTotalIncurredTableValue(IncurredTo, IncurredFrom);
            //To select random Claim Number
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());

            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //Need to implement-Assertion on claim number present in the FInancial 
            home.VerifyClaimNumber(Index[0].ToString());
            //Verify the Incurred column in Breakdown by loss Line
            cInquiry.VerifyTotalIncurredAmount(Index[7].ToString());
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Accident date range"), TestCategory("Regression")]
        public void CI_07claimInquiryPage()
        {

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_07", "Claim Inquiry-Search the data with Accident date range");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");           

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            this.TESTREPORT.LogInfo("Enter AccidentDateRange Begin");
            cInquiry.EnterAccidentDateRangeBegin();
            this.TESTREPORT.LogInfo("Enter AccidentDateRange End");
            cInquiry.EnterAccidentDateRangeEnd();
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();

            cInquiry.VerifyAccidentDateTableValue();
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            cInquiry.VerifyClaimInfoAccidentDate(Index[2].ToString());

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Clear Data in Accident Date range Date picker"), TestCategory("Regression")]
        public void CI_08claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_08", "Claim Inquiry-Clear Data in Accident Date range Date picker");

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Enter AccidentDateRange Begin
            cInquiry.EnterAccidentDateRangeBegin();
            //click on Clear button in date picker 
            cInquiry.ClickAccidentDateRangeBeginClearBtn();

            cInquiry.VerifyAccidentDateField();
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Export to spreadsheet-Detailed Claim list"), TestCategory("Regression")]
        public void CI_09claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_09", "Claim Inquiry-Export to spreadsheet-Detailed Claim list");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");

            this.TESTREPORT.LogInfo("Verify Cinch Welcome Text");
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click on Claiminquiry");
            home.ClickClaimInquiry();

            this.TESTREPORT.LogInfo("Verify page Title for Claim Inquiry");
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();
            this.TESTREPORT.LogInfo("Verify Loss line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify Export to Spreadsheet");
            cInquiry.VerifyExporttoSpreadsheetlink();
            cInquiry.ClickExportToSpredsheetLink();

            this.TESTREPORT.LogInfo("Verify File exists");
            cInquiry.GetExportFilePath("gridresult.csv");
            cInquiry.ExportFileExists();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Export to spreadsheet-Loss line summary"), TestCategory("Regression")]

        public void CI_10claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_10", "Claim Inquiry-Export to spreadsheet-Loss line summary");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");

            this.TESTREPORT.LogInfo("Verify Cinch Welcome Text");
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click on Claiminquiry");
            home.ClickClaimInquiry();

            this.TESTREPORT.LogInfo("Verify page Title for Claim Inquiry");
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();
            this.TESTREPORT.LogInfo("Verify Loss line Summary");
            cInquiry.VerifyLossLineSummary();

            //clicking Loss line description
            cInquiry.ClickLossLineDescriptionlink();

            this.TESTREPORT.LogInfo("Verify Export to Spreadsheet");
            cInquiry.ClickandVerifyExporttoSpreadsheetOnLoanSummarylink();
            cInquiry.GetExportFilePath("gridlossline.csv");
            cInquiry.ExportFileExists();
            cInquiry.ExportFileDelete();

            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }


        [TestMethod, Description("Claim Inquiry-Search the data with Report date range"), TestCategory("Regression")]
        public void CI_11claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_11", "Claim Inquiry-Search the data with Report date range");

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string ClaimantName = readCSV("ClaimantName");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            this.TESTREPORT.LogInfo("Enter ReportDateRange Begin");
            string value=cInquiry.EnterReportDateRangeBegin();
            this.TESTREPORT.LogInfo("Enter ReportDateRange End");
            string value1= cInquiry.EnterReportDateRangeEnd();

            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //To select random Claim Number
            cInquiry.EnterClaimantName(ClaimantName);
            this.TESTREPORT.LogInfo("Click on any random claim(claim number that starts with W )");
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());


            //To  Verify Report date from claim information
            cInquiry.VerifyClaimInfoReportDate(value,value1);

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Activity date range"), TestCategory("Regression")]
        public void CI_12claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_12", "Claim Inquiry-Search the data with Activity date range");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            this.TESTREPORT.LogInfo("Enter ActivityDateRange Begin");
            cInquiry.EnterActivityDateRangeBegin();
            this.TESTREPORT.LogInfo("Enter ActivityDateRange End");
            cInquiry.EnterActivityDateRangeEnd();

            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //To select random Claim Number 
            ArrayList Index = home.ClickOnRandomClaim();

            // verify claim Number
            home.VerifyClaimNumber(Index[0].ToString());
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster-Send"), TestCategory("Regression")]
        public void CI_13claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_13", "Claim Inquiry-Email to Claim Adjuster-Send");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string EmailAddress1 = readCSV("EmailAddress1");
            string EmailAddress2 = readCSV("EmailAddress2");
            string Message = readCSV("Message");
            string MultipleEMailAddress = EmailAddress1 + "," + EmailAddress2;
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count 
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //To select random Claim Number
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());

            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();
            //Click on the checkbox Email copy to sender
            cInquiry.ClickCheckBoxinEmailAdjuster();
            //Enter Multiple Email address separated by comma
            cInquiry.EnterEmailAddress(MultipleEMailAddress, Message);

            //click on send button
            cInquiry.ClickSendButton();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster Reset"), TestCategory("Regression")]
        public void CI_14claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_14", "Claim Inquiry-Email to Claim Adjuster Reset");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string EmailAddress1 = readCSV("EmailAddress1");
            string EmailAddress2 = readCSV("EmailAddress2");
            string Message = readCSV("Message");
            string MultipleEMailAddress = EmailAddress1 + "," + EmailAddress2;


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //To select random Claim Number
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());

            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();

            //Click on the checkbox Email copy to sender
            cInquiry.ClickCheckBoxinEmailAdjuster();
            //Enter Multiple Email address separated by comma
            cInquiry.EnterEmailAddress(MultipleEMailAddress, Message);
            //Need to implement-click on Reset button
            cInquiry.clickResetButtoninEmailAdjuster();
            cInquiry.ClickCancelButtoninEmailAdjuster();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster -cancel"), TestCategory("Regression")]
        public void CI_15claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_15", "Claim Inquiry-Email to Claim Adjuster -cancel");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string EmailAddress1 = readCSV("EmailAddress1");
            string EmailAddress2 = readCSV("EmailAddress2");
            string Message = readCSV("Message");
            string MultipleEMailAddress = EmailAddress1 + "," + EmailAddress2;


            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //To select random Claim Number
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());

            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();

            //Click on the checkbox Email copy to sender
            cInquiry.ClickCheckBoxinEmailAdjuster();
            //Enter Multiple Email address separated by comma
            cInquiry.EnterEmailAddress(MultipleEMailAddress, Message);

            //Click on  Cancel button
            cInquiry.ClickCancelButtoninEmailAdjuster();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the Claim List"), TestCategory("Regression")]
        public void CI_16claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            
            this.TESTREPORT.InitTestCase("CI_16", "Verify the Claim List");

            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");


            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");

            this.TESTREPORT.LogInfo("Verify Cinch Welcome Text");
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Click on Claiminquiry");
            home.ClickClaimInquiry();

            this.TESTREPORT.LogInfo("Verify page Title for Claim Inquiry");
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();

            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify Claim list Button");
            cInquiry.ClickClaimListbutton();
            home.VerifyPageTitle("Claim Inquiry");
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the EFR Button on the claim page"), TestCategory("Regression")]
        public void CI_17claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_17", "Verify the EFR Button on the claim page");


            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");

            //this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");

            //this.TESTREPORT.LogInfo("Verify Cinch Welcome Text");
            home.VerifyCinchWelome();

            //this.TESTREPORT.LogInfo("Click on Claiminquiry");
            home.ClickClaimInquiry();

            this.TESTREPORT.LogInfo("Verify page Title for Claim Inquiry");
            home.VerifyPageTitle("Claim Inquiry");
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify the View EFR button");
            this.TESTREPORT.LogInfo("Click on View EFR button of the claim page");
            cInquiry.ClickAndVerifyEFRButton();
            cInquiry.SwitchToChildWindow();
            string PageTitle = "PMA CINCH EFR " + "- " + Index[0].ToString();
            home.VerifyPageTitle(PageTitle);
            cInquiry.CloseChildWindow();
            cInquiry.SwitchToParentWindow();

            this.TESTREPORT.LogInfo("Logout from Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Selecting page size option from the drop down loads all claims"), TestCategory("Regression")]
        public void CI_18claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_18", "Claim Inquiry-Verify Selecting page size option from the drop down loads all claims");

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();


            //In the Detailed claim list, select a page size from the drop down menu in the bottom right side(E.g. ALL )
            cInquiry.SelectPageSizefromtheClaimInquiryResults();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag a column in drag column section"), TestCategory("Regression")]
        public void CI_19claimInquiryPage()
        {
            //Create Page Objectss
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_19", "Claim Inquiry-Verify to Drag a column in drag column section");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Drag a column header here to group by that column             
            cInquiry.DragTheColumnHeaderInSpace("Claimant Name");
            Thread.Sleep(6000);
            cInquiry.DraggedColumnList(0, "Claimant Name");

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag a column in drag column section and open a claim"), TestCategory("Regression")]
        public void CI_20claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_20", "Claim Inquiry-Verify to Drag a column in drag column section and open a claim");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch Welcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            cInquiry.DragTheColumnHeaderInSpace("Claimant Name");
            Thread.Sleep(3000);
            cInquiry.DraggedColumnList(0, "Claimant Name");
            ArrayList index = cInquiry.ClickOnRandomGroupClaim();
            //cInquiry.VerifyGroupClaimNumber(index[0].ToString().Replace("Claimant Name: ", ""));
            home.VerifyClaimantName(index[0].ToString());
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the Drag column to group by the column and sort the order"), TestCategory("Regression")]
        public void CI_21claimInquiryPage()

        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_21", "Claim Inquiry-Verify the Drag column to group by the column and sort the order");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch Welcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Click on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Verify loss Line Summary
            cInquiry.VerifyLossLineSummary();           
            //Drag the column in header Columns
            cInquiry.DragTheColumnHeaderInSpace("Claimant Name");
            //Verify the Grouped/Dragged Column
            cInquiry.DraggedColumnList(0, "Claimant Name");
            //Verify the Sorting for Grouped columns
            cInquiry.VerifySortingOnGroupedColumn();     
            //Logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag  multiple columns in drag column section"), TestCategory("Regression")]
        public void CI_22claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_22", "Claim Inquiry-Verify to Drag  multiple columns in drag column section");
            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");

            
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch Welcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Drag Claimant Name column into the dragged column space
            cInquiry.DragTheColumnHeaderInSpace("Claimant Name");
            Thread.Sleep(3000);
            //Verify the dragged columns
            cInquiry.DraggedColumnList(0, "Claimant Name");
            //Drag Claimant Name column into the dragged column space
            cInquiry.DragTheColumnHeaderInSpace("Location");
            Thread.Sleep(3000);
            //Verify the dragged columns
            cInquiry.DraggedColumnList(1, "Location");
            //Click on the Expand and Verify the name and location       
            string detailedCliamDetails = cInquiry.ClaimantNameAndLocationAfterExpand();
            //Verify Claimant Name
            home.VerifyClaimantName(detailedCliamDetails.Split('@')[0].Replace("Claimant Name: ", ""));
            //Verify Location
            cInquiry.VerifyAccidentLocation(detailedCliamDetails.Split('@')[1].Replace("Location: ", ""));
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag status column in drag column section"), TestCategory("Regression")]
        public void CI_23claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_23", "Claim Inquiry-Verify to Drag status column in drag column section");

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch Welcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            cInquiry.DragTheColumnHeaderInSpace("Status");
            Thread.Sleep(3000);
            cInquiry.DraggedColumnList(0, "Status");

          //  ArrayList index = cInquiry.ClickOnRandomGroupClaimExpandImage();

            //Need to implement-select random claim 

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }


        [TestMethod, Description("Claim Inquiry-Verify documents tab in the claim"), TestCategory("Regression")]
        public void CI_25claimInquiryPage()
        {
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            this.TESTREPORT.InitTestCase("CI_25", "Verify documents tab in the claim");
           
            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("claimNoFordocuments");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify the Documents Tab");
            cInquiry.VerifyDocumentsTab();
            cInquiry.ClickDocuments();
            cInquiry.SwitchToChildWindow();

            this.TESTREPORT.LogInfo("Verify the Open,DeselectAll,CLoseWindow buttons");
            cInquiry.VerifyOpenButton();
            cInquiry.VerifyDeselectallButton();
            cInquiry.VerifyCloseWindow();

            this.TESTREPORT.LogInfo("Verify Downloaded .JSP file/ Window ");
            cInquiry.SelectDocuments();
            cInquiry.CloseChildWindow();
            cInquiry.SwitchToParentWindow();
            cInquiry.GetExportFilePath("jnlpModified.jsp");
            cInquiry.ExportFileExists();
            cInquiry.ExportFileDelete();

            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Claim Inquiry-Verify Sorting in documents tab in the claim"), TestCategory("Regression")]
        public void CI_26claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_26", "Verify Sorting in documents tab in the claim");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("claimNoFordocuments");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");

            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify the Documents Tab");
            cInquiry.VerifyDocumentsTab();
            cInquiry.ClickDocuments();
            

            this.TESTREPORT.LogInfo("Verify the Open,DeselectAll,CLoseWindow buttons");
            cInquiry.VerifyOpenButton();
            cInquiry.VerifyDeselectallButton();
            cInquiry.VerifyCloseWindow();

            this.TESTREPORT.LogInfo("Verify Entry Number Sorting ");

            cInquiry.VerifySortingOnDocumentlist();

            cInquiry.CloseChildWindow();
            cInquiry.SwitchToParentWindow();
           

            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        
        [TestMethod, Description("Claim Inquiry-Verify Financial Information tab of the claim"), TestCategory("Regression")]
        public void CI_29claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_29", "Claim Inquiry-Verify Financial Information tab of the claim");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");

            

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Enter a ClaimNumber-starts with 'L or 'W' in the grid view
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            //Verify Documents tab
            cInquiry.VerifyDocumentsTab();
            
            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //Verify Claim Financial total in Financial tab
            cInquiry.VerifyClaimFinancialTotalText();
            //Verify FinancialTotalByLossLine Text
            cInquiry.VerifyFinancialTotalsbyLossLineText();
            //Data grid in FinancialTotalByLossLine
            cInquiry.FinancialtabResultscount();
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }


        [TestMethod, Description("Claim Inquiry-Verify Financial Information tab of the claim(Workers claim number)"), TestCategory("Regression")]
        public void CI_30claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_30", "Claim Inquiry-Verify Financial Information tab of the claim(Workers claim number)");

            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string HomePageTitle = readCSV("HomePageTitle");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("ClaimantName");
            string Header1 = readCSV("Header1");
            string Header2 = readCSV("Header2");
            string Header3 = readCSV("Header3");
            string Header4 = readCSV("Header4");
            string Header5 = readCSV("Header5");
            string Header6 = readCSV("Header6");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Enter a ClaimNumber-starts with 'L or 'W' in the grid view
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            //Verify Documents tab
            cInquiry.VerifyDocumentsTab();

            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //verify Wages text
            cInquiry.VerifyWagesText();
            //verify Breakdown by Lossline Text
            cInquiry.VerifyBreakdownByLosslineText();
            cInquiry.BreakdownbyLosslineResultscount();
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header1);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header2);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header3);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header4);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header5);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(Header6);
           
            cInquiry.CalculateNetPaidAmount();
            cInquiry.ExpandMedicalExpenseinFinancial();
           
            cInquiry.VerifyIncurredAmount(Index[7].ToString());
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Claim Inquiry-View documents and filter the results in the claim view"), TestCategory("Regression")]
        public void CI_37claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_37", "Verify documents and filter the results in the claim view");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();

            string DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
            string ClaimantName = readCSV("claimNoFordocuments");
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");
            string DocumentSearchValue=readCSV("DocumentSearchValue");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle(HomePageTitle);

            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify the Documents Tab");
            cInquiry.VerifyDocumentsTab();
            cInquiry.ClickDocuments();
            
            this.TESTREPORT.LogInfo("Verify Count of the results ");
            cInquiry.EnterDocumentSearchText(DocumentSearchValue);
            cInquiry.VerifyDocumentsCountOnSearch(DocumentSearchValue);
            cInquiry.CloseChildWindow();
            cInquiry.SwitchToParentWindow();
            
            this.TESTREPORT.LogInfo("Verify CLaim Inquiry Page Title ");
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);

            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Claim Inquiry-View documents and filter the results in the claim view"), TestCategory("Regression")]
        public void CI_27claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_27", "Verify Accident Information tab for the claim");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");
            string ClaimantName = readCSV("ClaimantName1");

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle(HomePageTitle);

            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify and Click the Accident Tab");
            cInquiry.VerifyAndClickonAccidentTab();
            
            this.TESTREPORT.LogInfo("Verify Accident Information,Description ,Vehicle List");
            cInquiry.VerifyAccidentInformationIsDisplayed();
            cInquiry.VerifyAccidentDescriptionIsDisplayed();
            cInquiry.VerifyVehicleListIsDisplayed();

            this.TESTREPORT.LogInfo("Verify Data in VehicleList");
            cInquiry.VerifyDataInVehicleList();

            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }
    
        [TestMethod, Description("Verify LossLine Information tab of the claim"), TestCategory("Regression")]
        public void CI_28claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_28", "Verify LossLine Information tab of the claim");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
           #region Reading DAta from CSV 
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");
            string ClaimantName = readCSV("ClaimantName1");
            string Header1 = readCSV("LossLineTableHeader1");
            string Header2 = readCSV("LossLineTableHeader2");
            string Header3 = readCSV("LossLineTableHeader3");
            string Header4 = readCSV("LossLineTableHeader4");
            string Header5 = readCSV("LossLineTableHeader5");
            
            #endregion

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle(HomePageTitle);

            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify and Click the Lossline Tab");
            cInquiry.VerifyAndClickonLossLineTab();
            
            this.TESTREPORT.LogInfo("Verify Claimant name ,LossLine Description, Suffix Code, Loss Line Status, In Suit)");
            cInquiry.VerifyLossLineTableHeaders(Header1);
            cInquiry.VerifyLossLineTableHeaders(Header2);
            cInquiry.VerifyLossLineTableHeaders(Header3);
            cInquiry.VerifyLossLineTableHeaders(Header4);
            cInquiry.VerifyLossLineTableHeaders(Header5);
            

            this.TESTREPORT.LogInfo("Verify LossLine Detail Information Text,Claimant Detail Information,Other loss line information");
            cInquiry.CLickLossLineExpand();
            cInquiry.VerifyLosslineInformationIsDisplayed();
             cInquiry.VerifyClaimantInformationIsDisplayed();
             cInquiry.VerifyOtherLossLineIsDisplayed();
             cInquiry.VerifyOtherClaimantNameIsDisplayed();
           
            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }


        [TestMethod, Description("Verify Lossline Information of the claim by search and clear the searched data"), TestCategory("Regression")]
        public void CI_32claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_32", "Verify Lossline Information of the claim by search and clear the searched data");
            HomePage home = new HomePage();
            ClaimInquiry cInquiry = new ClaimInquiry();
            #region Reading Data from CSV 
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string HomePageTitle = readCSV("HomePageTitle");
            string DocumentPagetitle = readCSV("documentListPageTitle");
            string ClaimantName = readCSV("ClaimantName1");
            string ClaimantNameSearch = readCSV("ClaimantNameSearch");
            #endregion

            this.TESTREPORT.LogInfo("Verify that user lands on Cinch application");
            home.VerifyPageTitle(HomePageTitle);

            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.ClickSearch();

            this.TESTREPORT.LogInfo("Verify table row count");
            home.ClaimInquiryResultsCount();


            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            cInquiry.VerifyDetailedClaimList();

            this.TESTREPORT.LogInfo("Verify loss Line Summary");
            cInquiry.VerifyLossLineSummary();

            this.TESTREPORT.LogInfo("Click on any random claim");
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify and Click the Lossline Tab");
            cInquiry.VerifyAndClickonLossLineTab();

            this.TESTREPORT.LogInfo("Verify Clear Button");
            cInquiry.SearchByClaimantNameInLossLineTab(ClaimantNameSearch);
            cInquiry.VerifyandClickClearButton(ClaimantNameSearch);
           
            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }










        }

    }

    

    }

