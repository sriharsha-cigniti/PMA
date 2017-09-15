﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandardUtilities;
using OpenQA.Selenium;

namespace AutomatedTest.FunctionalTests.HomeModule
{
    [TestClass]
    public class ClaimInquiryTest : PMA.TestBaseTemplate
    {

        HomePage home = new HomePage();
        ClaimInquiry cInquiry = new ClaimInquiry();

        [TestMethod, Description("Claim Inquiry-Click search with no search fields filled out"), TestCategory("Regression")]
        public void CI_01claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_01", "Claim Inquiry-Click search with no search fields filled out");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch Welcome Text
             home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");

            //Click on search button
            home.ClickSearch();
            //Verify table row count- Need to implement

            //Verify Loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Click on Loss line Summary
            cInquiry.ClickLosslineSummary();
            //Need to implement - Loss Line summary CLaim records
            //logout of Application
             home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Click reset clears all Claim Inquiry fields"), TestCategory("Regression")]
        public void CI_02claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_02","Claim Inquiry-Click reset clears all Claim Inquiry fields");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //To fill all the fields by  CSV
            cInquiry.EnterClaimNumber("");
            cInquiry.EnterClaimstatus("");
            cInquiry.EnterLast4SSN("");
            cInquiry.EnterFirstName("");
            cInquiry.EnterLastName("");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
             //Verify Loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Click on Loss line Summary
            cInquiry.ClickReset();
            //Need to include the assertion to clear the fields
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Location Code Modal - clicking on a row selects the location"), TestCategory("Regression")]
        public void CI_03claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_03", "Claim Inquiry-Location Code Modal - clicking on a row selects the location");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Verify Location Icon
            cInquiry.VerifyLocationIcon();
            //Click on Location search Icon
            cInquiry.ClickLocationSearchIcon();
            //go to frame
            cInquiry.NavigatetoFrame(0);
            //Enter the data into the filter columns
            cInquiry.EnterLocationCodeField("0000000018");

            //Verify table row count
            cInquiry.ClickLocationCode();
            //switch to parentframe
            cInquiry.NavigatetoParentFrame();

          
            
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-View all tabs in the claim view(Liability)"), TestCategory("Regression")]
        public void CI_04claimInquiryPage()
        {
           
            
            this.TESTREPORT.InitTestCase("CI_04", "Claim Inquiry-View all tabs in the claim view(Liability)");

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
            //Need to implement a claim in the grid view

            //Click on accident tab
            //Need to implement the Accident Tab

            //Need to implement the Accident information text
            //Need to implement the loss line Information

            //click on Finanacial tab
            cInquiry.ClickFinancial();
            //Need to implement the Claim Financial total for a claim
            //click on payments tab
            cInquiry.ClickPayments();
            //Need to implement - Payment status
            //click on Diary tab
            cInquiry.ClickDiary();
            //Verify CReate Entry
            cInquiry.VerifyCreateEntryLink();
            //click on LogNotes tab
            cInquiry.ClickLogNotes();
            //click on Documents tab
            cInquiry.ClickDocuments();
            //Verify New window 'PMA CINCH document List' title
            cInquiry.SwitchtoDocumentswindow("PMA CINCH document List");


            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-View all tabs in the claim view (Workers compensation)"), TestCategory("Regression")]
        public void CI_05claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_05", "Claim Inquiry-View all tabs in the claim view (Workers compensation)");

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
            //Need to implement-To open a claim that starts with M
            //Need to implement-Assertion on Claim Number
            //Need to implemnt ASsertion on Claim Name
            //Click on Worker-accident tab
            cInquiry.ClickWorkerAccident();

            //click on Finanacial tab
            cInquiry.ClickFinancial();
            //verify Wages Text
            cInquiry.VerifyWagesText();
            //verify BreakDown By Loss Line Text
            cInquiry.VerifyBreakdownByLosslineText();
            //click on payments tab
            cInquiry.ClickPayments();
            //Need to implement Payments text
            //click on Diary tab
            cInquiry.ClickDiary();
            //Verify CReate Entry
            cInquiry.VerifyCreateEntryLink();
            //click on LogNotes tab
            cInquiry.ClickLogNotes();
            //verify ShowNotes
            cInquiry.VerifyShowNoteslink();
            //verify Hide Notes
            cInquiry.VerifyHideNoteslink();
            //click on Documents tab
            cInquiry.ClickDocuments();
            //Need to implement to verify the list of documents
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Total Incurred amount"), TestCategory("Regression")]
        public void CI_06claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_06", "Claim Inquiry-Search the data with Total Incurred amount");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Enter Incurred Amount from
            cInquiry.EnterIncurredfrom("");
            //Enter Incurred Amount to
            cInquiry.EnterIncurredTo("");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Need to implement-Total Incurred column
            //Need to implement-to select random Claim Number
            
            //click on Finanacial tab
            cInquiry.ClickFinancial();
            //Need to implement-Assertion on claim number present in the FInancial tab
            //Verify the Incurred column in Breakdown by loss Line 
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Accident date range"), TestCategory("Regression")]
        public void CI_07claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI_07", "Claim Inquiry-Search the data with Accident date range");

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
            //Enter AccidentDateRange End
            cInquiry.EnterAccidentDateRangeEnd("");
            //CLick on search button
            home.ClickSearch();
            //Verify table row count- Need to implement
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Need to implement-accident range Column
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
            //Verify table row count - Need to implement
            
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();

            //Need to implement-to select random Claim Number
            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();
            //Need to implement-Click on the checkbox Email copy to sender
            //Need to implement-Enter Multiple Email address separated by comma
            //Need to implement-click on send button

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster Reset"), TestCategory("Regression")]
        public void CI_14claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_14", "Claim Inquiry-Email to Claim Adjuster Reset");

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
            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();
            
            //Need to implement-Click on the checkbox Email copy to sender
            //Need to implement-Enter Multiple Email address separated by comma
            //Need to implement-click on Reset button

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Email to Claim Adjuster -cancel"), TestCategory("Regression")]
        public void CI_15claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_15", "Claim Inquiry-Email to Claim Adjuster -cancel");

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
            //click on EmailAdjuster
            cInquiry.ClickEmailAdjuster();
            //verify EmailAdjuster on the popup
            cInquiry.VerifyEmailAdjuster();

            //Need to implement-Click on the checkbox Email copy to sender
            //Need to implement-Enter Multiple Email address separated by comma
            //Need to implement-click on  Cancel button

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

            //Need to implement-In the Detailed claim list, select a page size from the drop down menu in the bottom right side(E.g. ALL )
            //Need to implement-Validate the data grid with all the entries
           
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify to Drag a column in drag column section"), TestCategory("Regression")]
        public void CI_19claimInquiryPage()
        {

            this.TESTREPORT.InitTestCase("CI_19", "Claim Inquiry-Verify to Drag a column in drag column section");

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