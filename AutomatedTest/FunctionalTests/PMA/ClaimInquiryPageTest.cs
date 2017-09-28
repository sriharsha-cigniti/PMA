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


            this.TESTREPORT.InitTestCase("CI_02","Claim Inquiry-Click reset clears all Claim Inquiry fields");

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
            cInquiry.ClickFinancialTab();
            //Verify Claim Financial total for a claim
            cInquiry.VerifyClaimFinancialTotallink();
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
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName);
            home.VerifyClaimNumber(Index[0].ToString());
            home.VerifyClaimantName(Index[1].ToString());
            //Click on WorkerAccident tab
            cInquiry.ClickWorkerAccident();
            //Verify Employee information text
            cInquiry.VerifyEmployeeInformation();
           
            //click on Finanacial tab
            cInquiry.ClickFinancialTab();
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

            cInquiry.VerifyTotalIncurredTableValue(IncurredTo,IncurredFrom);
            //To select random Claim Number
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());

            //click on Finanacial tab
            cInquiry.ClickFinancialTab();
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


            this.TESTREPORT.InitTestCase("CI_07", "Claim Inquiry-Search the data with Accident date range");

            string HomePageTitle = readCSV("HomePageTitle");           
            string ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
            string AccidentDateRangeBegin = readCSV("AccidentDateRangeBegin");
            string AccidentDateRangeEnd = readCSV("AccidentDateRangeEnd");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            //Enter AccidentDateRange Begin
            cInquiry.EnterAccidentDateRangeBegin(AccidentDateRangeBegin);
            //Enter AccidentDateRange End
            cInquiry.EnterAccidentDateRangeEnd(AccidentDateRangeEnd);
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Need to implement-accident range Column
            cInquiry.VerifyAccidentDateTableValue(AccidentDateRangeBegin, AccidentDateRangeEnd);
            //NEed to implement-to select random Claim Number

            //need to implement- verify claim Number
            //Need to implement-To  Verify accident date from claim information

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Clear Data in Accident Date range Date picker"), TestCategory("Regression")]
        public void CI_08claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_08", "Claim Inquiry-Clear Data in Accident Date range Date picker");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Enter AccidentDateRange Begin
            cInquiry.EnterAccidentDateRangeBegin("");
            //click on Clear button in date picker 
            cInquiry.ClickAccidentDateRangeBeginClearBtn();
            
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Export to spreadsheet-Detailed Claim list"), TestCategory("Regression")]
        public void CI_09claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_09", "Claim Inquiry-Export to spreadsheet-Detailed Claim list");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
           //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Verify Export to Spreadsheet
            cInquiry.VerifyExporttoSpreadsheetlink();
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Export to spreadsheet-Loss line summary"), TestCategory("Regression")]
        public void CI_10claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_10", "Claim Inquiry-Export to spreadsheet-Loss line summary");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //click on Loss Line summary
            cInquiry.ClickLosslineSummary();
            //Verify Export to Spreadsheet
            cInquiry.VerifyExporttoSpreadsheetlink();
            //verify loss line Description
            cInquiry.VerifyLossLineDescriptionlink();
            //click on Exporttospreadsheet
            cInquiry.ClickExportToSpredsheetLink();
             //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Report date range"), TestCategory("Regression")]
        public void CI_11claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_11", "Claim Inquiry-Search the data with Report date range");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Enter ReportDateRange Begin
            cInquiry.EnterReportDateRangeBegin("");
            //Enter ReportDateRange End
            cInquiry.EnterReportDateRangeEnd("");

            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Need to implement-Report date range Column
            //Need to implement-to select random Claim Number

            //Need to implement- verify claim Number
            //Need to implement-To  Verify Report date from claim information

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Activity date range"), TestCategory("Regression")]
        public void CI_12claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_12", "Claim Inquiry-Search the data with Activity date range");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Enter ActivityDateRange Begin
            cInquiry.EnterActivityDateRangeBegin("");
            //Enter ActivityDateRange End
            cInquiry.EnterActivityDateRangeEnd("");

            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Need to implement-Activity date range Column
            //Need to implement-to select random Claim Number

            //need to implement- verify claim Number
           
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster-Send"), TestCategory("Regression")]
        public void CI_13claimInquiryPage()
        {

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
            
            this.TESTREPORT.InitTestCase("CI_16", "Verify the Claim List");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-to select random Claim Number
            //Need to implement-Click on Claim list button On the top of Claim Information page 

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the EFR Button on the claim page"), TestCategory("Regression")]
        public void CI_17claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_17", "Verify the EFR Button on the claim page");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-to select random Claim Number
            //Need to implement-Verify the slected claim number
            //Need to implement-Verify the View EFR button
            //Need to implement-Click on View EFR button of the claim page

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Selecting page size option from the drop down loads all claims"), TestCategory("Regression")]
        public void CI_18claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_18", "Claim Inquiry-Verify Selecting page size option from the drop down loads all claims");


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
            
            cInquiry.Dragthecolumnheaderinspace("Claimant Name");
            //Need to implement-Claim number in the section above columns

            //logout of Application
            home.ClickExit();
            
            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag a column in drag column section and open a claim"), TestCategory("Regression")]
        public void CI_20claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_20", "Claim Inquiry-Verify to Drag a column in drag column section and open a claim");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-Drag a column header here to group by that column
            //Need to implement-Click on any random claim number

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the Drag column to group by the column and sort the order"), TestCategory("Regression")]
        public void CI_21claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_21", "Claim Inquiry-Verify the Drag column to group by the column and sort the order");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-Drag a column header here to group by that column
            //Need to implement-Click on the triangle Image to sort the column in alphabetical order

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag  multiple columns in drag column section"), TestCategory("Regression")]
        public void CI_22claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_22", "Claim Inquiry-Verify to Drag  multiple columns in drag column section");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-Drag multiple columns(E.G. Claim Number, claimant name and accident date ) into the 'Drag a column header here to group by that column' appears
            //Need to implement-Expand the first selected Column header to see the detail

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag status column in drag column section"), TestCategory("Regression")]
        public void CI_23claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_22", "Claim Inquiry-Verify to Drag status column in drag column section");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-Select and Drag status column into the 'Drag a column header here to group by that column' appears
            //Need to implement-select random claim 

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
    }
}
