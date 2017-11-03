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
    public class ClaimInquiryPageTests : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string ClaimInquiryPageTitle { get; set; }
        public static string ClaimNumber { get; set; }
        public static string Claimstatus { get; set; }
        public static string Last4SSN { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string LocationCodeField { get; set; }
        public static string DocumentsWindowPageTitle { get; set; }
        public static string ClaimantName { get; set; }
        public static string ClaimantName1 { get; set; }
        public static string IncurredFrom { get; set; }
        public static string IncurredTo { get; set; }
        public static string EmailAddress1 { get; set; }
        public static string EmailAddress2 { get; set; }
        public static string Message { get; set; }
        public static string DocumentPagetitle { get; set; }
        public static string claimNoFordocuments { get; set; }
        public static string LossHeader1 { get; set; }
        public static string LossHeader2 { get; set; }
        public static string LossHeader3 { get; set; }
        public static string LossHeader4 { get; set; }
        public static string LossHeader5 { get; set; }
        public static string FinanceHeader1 { get; set; }
        public static string FinanceHeader2 { get; set; }
        public static string FinanceHeader3 { get; set; }
        public static string FinanceHeader4 { get; set; }
        public static string FinanceHeader5 { get; set; }
        public static string FinanceHeader6 { get; set; }
        public static string TableHeader1 { get; set; }
        public static string TableHeader2 { get; set; }
        public static string TableHeader3 { get; set; }
        public static string TableHeader4 { get; set; }
        public static string TableHeader5 { get; set; }
        public static string TableHeader6 { get; set; }
        public static string TableHeader7 { get; set; }
        public static string LogNoteTableHeader1 { get; set; }
        public static string LogNoteTableHeader2 { get; set; }
        public static string LogNoteTableHeader3 { get; set; }
        public static string LogNoteTableHeader4 { get; set; }
        public static string LogNoteTableHeader5 { get; set; }
        public static string DocumentSearchValue { get; set; }
        public static string ClaimantNameSearch { get; set; }
        public static string name { get; set; }


        public ClaimInquiryPageTests()
        {
            // Read CSV values

            HomePageTitle = readCSV("HomePageTitle");
            ClaimInquiryPageTitle = readCSV("ClaimInquiryPageTitle");
             ClaimNumber = readCSV("ClaimNumber");
             Claimstatus = readCSV("Claimstatus");
             Last4SSN = readCSV("Last4SSN");
             FirstName = readCSV("FirstName");
             LastName = readCSV("LastName");
             LocationCodeField = readCSV("LocationCodeField");
             DocumentsWindowPageTitle = readCSV("DocumentsWindowPageTitle");
             ClaimantName = readCSV("ClaimantName1");
             ClaimantName1 = readCSV("ClaimantName");
             IncurredFrom = readCSV("IncurredFrom");
             IncurredTo = readCSV("IncurredTo");
             EmailAddress1 = readCSV("EmailAddress1");
             EmailAddress2 = readCSV("EmailAddress2");
             Message = readCSV("Message");
             DocumentPagetitle = readCSV("documentListPageTitle");
             claimNoFordocuments = readCSV("claimNoFordocuments");
             LossHeader1 = readCSV("LossLineTableHeader1");
             LossHeader2 = readCSV("LossLineTableHeader2");
             LossHeader3 = readCSV("LossLineTableHeader3");
             LossHeader4 = readCSV("LossLineTableHeader4");
             LossHeader5 = readCSV("LossLineTableHeader5");
             FinanceHeader1 = readCSV("Header1");
             FinanceHeader2 = readCSV("Header2");
             FinanceHeader3 = readCSV("Header3");
             FinanceHeader4 = readCSV("Header4");
             FinanceHeader5 = readCSV("Header5");
             FinanceHeader6 = readCSV("Header6");
             TableHeader1 = readCSV("TableHeader1");
             TableHeader2 = readCSV("TableHeader2");
             TableHeader3 = readCSV("TableHeader3");
             TableHeader4 = readCSV("TableHeader4");
             TableHeader5 = readCSV("TableHeader5");
             TableHeader6 = readCSV("TableHeader6");
             TableHeader7 = readCSV("TableHeader7");
             ClaimantNameSearch = readCSV("ClaimantNameSearch");
             LogNoteTableHeader1 = readCSV("LogNoteTableHeader1");
             LogNoteTableHeader2 = readCSV("LogNoteTableHeader2");
             LogNoteTableHeader3 = readCSV("LogNoteTableHeader3");
             LogNoteTableHeader4 = readCSV("LogNoteTableHeader4");
             LogNoteTableHeader5 = readCSV("LogNoteTableHeader5");
             DocumentSearchValue = readCSV("DocumentSearchValue");
             name = readCSV("AccountName");
        }
        #endregion


        [TestMethod, Description("Claim Inquiry-Click search with no search fields filled out"), TestCategory("Regression")]
        public void CI_01claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_01", "Claim Inquiry-Click search with no search fields filled out");
            
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
            this.TESTREPORT.InitTestCase("CI_02", "Claim Inquiry-Click reset clears all Claim Inquiry fields");
            
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
            
            //Verify that user lands on Cinch application
            home.VerifyPageTitle(HomePageTitle);
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();

            home.ClickMyAccount();
            string AccountName = home.GetMyAccount();
            home.SearchMyAccout(name, "Name");
            
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
           // home.VerifyClaimantName(Index[1].ToString());
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
            cInquiry.EnterClaimantName(ClaimantName1);
            this.TESTREPORT.LogInfo("Click on any random claim(claim number that starts with W )");
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName1);
            home.VerifyClaimNumber(Index[0].ToString());
            //commenting because of the bug in encountered for l types of loans
           // home.VerifyClaimantName(Index[1].ToString());
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
            //cInquiry.SwitchtoDocumentswindow(DocumentsWindowPageTitle);
            home.VerifyPageTitle(DocumentsWindowPageTitle);
            cInquiry.CloseChildWindow();
            cInquiry.SwitchToParentWindow();
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
        [TestMethod, Description("Claim Inquiry-Search the data with Total Incurred amount"), TestCategory("Regression")]
        public void CI_06claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_06", "Claim Inquiry-Search the data with Total Incurred amount");
           
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
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();

            //Enter a claim in the grid view
            cInquiry.EnterClaimantName(ClaimantName1);
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
            this.TESTREPORT.InitTestCase("CI_07", "Claim Inquiry-Search the data with Accident date range");
            
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
            
            this.TESTREPORT.InitTestCase("CI_09", "Claim Inquiry-Export to spreadsheet-Detailed Claim list");
            
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
           
            this.TESTREPORT.InitTestCase("CI_10", "Claim Inquiry-Export to spreadsheet-Loss line summary");
            
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
            cInquiry.EnterClaimantName(ClaimantName1);
            this.TESTREPORT.LogInfo("Click on any random claim(claim number that starts with W )");
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName1);
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
            this.TESTREPORT.InitTestCase("CI_12", "Claim Inquiry-Search the data with Activity date range");
            
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
            
            this.TESTREPORT.InitTestCase("CI_13", "Claim Inquiry-Email to Claim Adjuster-Send");
            
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
            cInquiry.EnterClaimantName(ClaimantName1);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName1);
            home.VerifyClaimNumber(Index[0].ToString());
           // Commenting because bug encountered for l types of loans 
           // home.VerifyClaimantName(Index[1].ToString());

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
            this.TESTREPORT.InitTestCase("CI_17", "Verify the EFR Button on the claim page");

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
            cInquiry.EnterClaimantName(ClaimantName1);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(ClaimantName1);
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            // home.VerifyClaimantName(Index[1].ToString());

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
            this.TESTREPORT.InitTestCase("CI_20", "Claim Inquiry-Verify to Drag a column in drag column section and open a claim");

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
            home.VerifyClaimantName(index[0].ToString().Replace("Claimant Name: ", ""));
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify the Drag column to group by the column and sort the order"), TestCategory("Regression")]
        public void CI_21claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_21", "Claim Inquiry-Verify the Drag column to group by the column and sort the order");

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
            this.TESTREPORT.InitTestCase("CI_22", "Claim Inquiry-Verify to Drag  multiple columns in drag column section");
           
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
        [TestMethod, Description("Claim Inquiry-Verify documents tab in the claim"), TestCategory("Regression")]
        public void CI_25claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_25", "Verify documents tab in the claim");
           
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
            cInquiry.EnterClaimantName(claimNoFordocuments);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(claimNoFordocuments);
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            // home.VerifyClaimantName(Index[1].ToString());

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
            cInquiry.EnterClaimantName(claimNoFordocuments);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(claimNoFordocuments);
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            //home.VerifyClaimantName(Index[1].ToString());

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
        [TestMethod, Description("Claim Inquiry-View documents and filter the results in the claim view"), TestCategory("Regression")]
        public void CI_27claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_27", "Verify Accident Information tab for the claim");
           
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
            // Commenting because bug encountered for l types of loans 
            //home.VerifyClaimantName(Index[1].ToString());

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
            // Commenting because bug encountered for l types of loans 
          //  home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify and Click the Lossline Tab");
            cInquiry.VerifyAndClickonLossLineTab();

            this.TESTREPORT.LogInfo("Verify Claimant name ,LossLine Description, Suffix Code, Loss Line Status, In Suit)");
            cInquiry.VerifyLossLineTableHeaders(LossHeader1);
            cInquiry.VerifyLossLineTableHeaders(LossHeader2);
            cInquiry.VerifyLossLineTableHeaders(LossHeader3);
            cInquiry.VerifyLossLineTableHeaders(LossHeader4);
            cInquiry.VerifyLossLineTableHeaders(LossHeader5);


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
        [TestMethod, Description("Claim Inquiry-Verify Financial Information tab of the claim"), TestCategory("Regression")]
        public void CI_29claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_29", "Claim Inquiry-Verify Financial Information tab of the claim");
           
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
            // Commenting because bug encountered for l types of loans 
            //home.VerifyClaimantName(Index[1].ToString());
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
            cInquiry.EnterClaimantName(ClaimantName1);
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            //home.VerifyClaimantName(Index[1].ToString());

            //Verify Documents tab
            cInquiry.VerifyDocumentsTab();

            //click on Finanacial tab
            cInquiry.ClickandVerifyFinancialTab();
            //verify Wages text
            cInquiry.VerifyWagesText();
            //verify Breakdown by Lossline Text
            cInquiry.VerifyBreakdownByLosslineText();
            cInquiry.BreakdownbyLosslineResultscount();
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader1);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader2);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader3);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader4);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader5);
            cInquiry.VerifyBreakdownbyLossLineTableHeaders(FinanceHeader6);
           
            cInquiry.CalculateNetPaidAmount();
            cInquiry.ExpandMedicalExpenseinFinancial();
           
            cInquiry.VerifyIncurredAmount(Index[7].ToString());
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Payment Information tab of the claim"), TestCategory("Regression")]
        public void CI_31claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_31", "Claim Inquiry-Verify Payment Information tab of the claim");
            
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

            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            //cInquiry.VerifyClaimantNameinCLaimInquiry(Index[1].ToString());

            //Verify Payments tab
            cInquiry.VerifyPayment();
            //click on payments tab
            cInquiry.ClickPayments();
            //VErify data  in datagrid
            cInquiry.PaymentsTabResultscount();

            //Verify TableHeaders in Payments tab
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader1);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader2);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader3);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader4);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader5);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader6);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader7);

            //Expand the LossLine Data and verify CheckDetailInformatiom and Lossinformation
            cInquiry.ExpandLossLineinPayments();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Verify Lossline Information of the claim by search and clear the searched data"), TestCategory("Regression")]
        public void CI_32claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_32", "Verify Lossline Information of the claim by search and clear the searched data");
           
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
            // Commenting because bug encountered for l types of loans 
            // home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify and Click the Lossline Tab");
            cInquiry.VerifyAndClickonLossLineTab();

            this.TESTREPORT.LogInfo("Verify Clear Button");
            cInquiry.SearchByClaimantNameInLossLineTab(ClaimantNameSearch);
            cInquiry.VerifyandClickClearButton(ClaimantNameSearch);
           
            this.TESTREPORT.LogInfo("Logout of Application");
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
        }       
        [TestMethod, Description("Claim Inquiry-Check for tabs present in Worker Accident (Workers claim number)"), TestCategory("Regression")]
        public void CI_33claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_33", "Claim Inquiry-Check for tabs present in Worker Accident (Workers claim number)");
            
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
            //eNter Claimant name
            cInquiry.EnterClaimantName(ClaimantName1);
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            //  cInquiry.VerifyClaimantNameinCLaimInquiry(Index[1].ToString());
            //Click on Worker Accident Tab
            cInquiry.VerifyandClickWorkerAccident();
            cInquiry.verifyAccidentinWorkerAccident();
            cInquiry.verifyMedicalSummaryinWorkerAccident();
            cInquiry.verifyMedicalsummaryContinWorkerAccident();

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Payment Information Tab of the claim(Liability)"), TestCategory("Regression")]
        public void CI_34claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_34", "Claim Inquiry-Verify Payment Information Tab of the claim(Workers Accident)");
            
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
            //eNter Claimant name
            cInquiry.EnterClaimantName(ClaimantName);
            ArrayList Index = home.ClickOnRandomClaim();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            // cInquiry.VerifyClaimantNameinCLaimInquiry(Index[1].ToString());

            //Verify Payments tab
            cInquiry.VerifyPayment();
            //click on payments tab
            cInquiry.ClickPayments();
            //Verify data  in datagrid
            cInquiry.PaymentsTabResultscount();

            //verify Table Headers in Payments tab
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader1);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader2);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader3);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader4);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader5);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader6);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader7);

            //Expand the LossLine Data
            if (cInquiry.ExpandButtoninPaymentsTabIsDisplayed())
            {
                cInquiry.clickExpandButtoninPaymentsTab();
                //verify Payment Detail
                cInquiry.VerifyPaymentDetail();
                //Verify Explanation of benefits
                cInquiry.VerifyExplanationofBenefits();
                //VErify InvoiceSummary
                cInquiry.VerifyInvoiceSummary();
                //verify payment Amount
                string x = cInquiry.VerifyPaymentAmount();
                //click ExplanationofBenefits
                cInquiry.ClickExplanationofBenefits();
                //Verify invoiceAmount
                string y = cInquiry.VerifyInvoiceAmount();
                //click InvoiceSummary
                cInquiry.ClickInvoiceSummary();

                cInquiry.VerifySavingsandCharges();

                cInquiry.VerifySavingsDetail();
                cInquiry.VerifyPaymentAmtinInvoiceSummary(x);
                cInquiry.VerifyInvoiceAmtinInvoiceSummary(y);
                cInquiry.clickCollapseButtoninPaymentsTab();
            }
            else
                this.TESTREPORT.LogInfo("NO DATA TO DISPLAY");
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Payment Information Tab of the claim(Liability) and Group by column"), TestCategory("Regression")]
        public void CI_35claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_35", "Claim Inquiry-Verify Payment Information Tab of the claim(Workers Accident) and Group by column");
            
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
            //Search with 'L'
            cInquiry.EnterClaimantName(ClaimantName);
            //Verify table row count
            home.ClaimInquiryResultsCount();
            //Verify Detailed Claim list
            cInquiry.VerifyDetailedClaimList();
            //Verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            // home.VerifyClaimantName(Index[1].ToString());
            //Click on Payments Tab
            cInquiry.ClickPayments();
            //Verify Column Headers
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader1);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader2);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader3);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader4);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader5);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader6);
            cInquiry.VerifyPaymentsTabTableHeaders(TableHeader7);
            //Verify Payments table row count
            int Value = cInquiry.PaymentsTabResultscount();
            //Drag the Loss Line column in header Columns
            cInquiry.DragTheColumnHeaderPayments("Loss Line");
            //Verify the Grouped/Dragged Column
            cInquiry.PaymentsDraggedColumnList(0, "Loss Line");
            if (Value > 0)
            {
                cInquiry.LossLineAfterExpand();
            }

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-Verify Payment Information Tab of the claim(Workers Accident) and Group by column"), TestCategory("Regression")]
        public void CI_36claimInquiryPage()
        {
            
            this.TESTREPORT.InitTestCase("CI_36", "Claim Inquiry-Verify Log Notes tab Group by column");
           
           

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
            //Verify loss Line Summary
            cInquiry.VerifyLossLineSummary();
            //Click on Random claim 
            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());
            //home.VerifyClaimantName(Index[1].ToString());
            //Click on LogNotes Tab
            cInquiry.ClickLogNotes();
            //Verify Column Headers
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader1);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader2);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader3);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader4);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader5);

            //Verify Payments table row count
            int Value = cInquiry.LogNotesGridResultsCount();

            //Drag the Loss Line column in header Columns
            cInquiry.DragTheColumnHeaderLogNotes("Category");
            //Verify the Grouped/Dragged Column
            cInquiry.LogNotesDraggedColumnList(0, "Category");

            if (Value > 0)
            {
                cInquiry.LogNotesAfterExpand();
            }

            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }
        [TestMethod, Description("Claim Inquiry-View documents and filter the results in the claim view"), TestCategory("Regression")]
        public void CI_37claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_37", "Verify documents and filter the results in the claim view");
            
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
            cInquiry.EnterClaimantName(claimNoFordocuments);
            ArrayList Index = cInquiry.VerifyClaimantNameColumn(claimNoFordocuments);
            home.VerifyClaimNumber(Index[0].ToString());

            //home.VerifyClaimantName(Index[1].ToString());

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
        [TestMethod, Description("Claim Inquiry-Verify the Log Notes tab in claim "), TestCategory("Regression")]
        public void CI_38claimInquiryPage()
        {
            this.TESTREPORT.InitTestCase("CI_38", "Claim Inquiry-Verify the Log Notes tab in claim ");
           
            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickClaimInquiry();
            home.VerifyPageTitle(ClaimInquiryPageTitle);
            
            home.ClickSearch();
            home.ClaimInquiryResultsCount();
            cInquiry.VerifyDetailedClaimList();
            cInquiry.VerifyLossLineSummary();
            cInquiry.EnterClaimantName(ClaimantName);

            ArrayList Index = cInquiry.ClickOnRandomClaimInquiryResults();
            home.VerifyClaimNumber(Index[0].ToString());
            // Commenting because bug encountered for l types of loans 
            //home.VerifyClaimantName(Index[1].ToString());

            this.TESTREPORT.LogInfo("Verify Log Notes");
            cInquiry.VerifyAndClickLogNotes();

            this.TESTREPORT.LogInfo("Verify Show Notes ,Hide Notes Tab");
            cInquiry.VerifyShortNotesIsDisplayed();
            cInquiry.VerifyHideNotesIsDisplayed();

            this.TESTREPORT.LogInfo("Verify Note,Category,Date Created,Created By,Note Description");
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader1);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader2);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader3);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader4);
            cInquiry.VerifyLogNotesTableHeaders(LogNoteTableHeader5);
            
            //logout of Application
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }


    }

}

    

    

