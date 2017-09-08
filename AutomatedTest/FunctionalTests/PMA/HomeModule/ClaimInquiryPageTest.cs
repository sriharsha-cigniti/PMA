using System;
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


            this.TESTREPORT.InitTestCase("CI.1", "Claim Inquiry-Click search with no search fields filled out");

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


            this.TESTREPORT.InitTestCase("CI.2","Claim Inquiry-Click reset clears all Claim Inquiry fields");

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


            this.TESTREPORT.InitTestCase("CI.3", "Claim Inquiry-Location Code Modal - clicking on a row selects the location");

            //Verify that user lands on Cinch application
            home.VerifyPageTitle("The PMA Group - Risk Management Information System");
            //Verify  Cinch WElcome Text
            home.VerifyCinchWelome();
            //Click on Claiminquiry
            home.ClickClaimInquiry();
            //Verify page Title for Claim Inquiry
            home.VerifyPageTitle("Claim Inquiry");
            //Click on Location search Icon
            cInquiry.ClickLocationSearchIcon();
            //Enter the data into the filter columns
           
            
            //Verify table row count- Need to implement
          
            //Need to implement - Loss Line summary CLaim records
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }

        [TestMethod, Description("Claim Inquiry-View all tabs in the claim view(Liability)"), TestCategory("Regression")]
        public void CI_05claimInquiryPage()
        {
           
            
            this.TESTREPORT.InitTestCase("CI.5", "Claim Inquiry-View all tabs in the claim view(Liability)");

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
            cInquiry.ClickWorkerAccident();
            //Need to implement the Accident information
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
        public void CI_06claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI.6", "Claim Inquiry-View all tabs in the claim view (Workers compensation)");

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
            //NEed to implement-Assertion on Claim Number
            //need to implemnt ASsertion on Claim Name
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
        public void CI_07claimInquiryPage()
        {


            this.TESTREPORT.InitTestCase("CI.6", "Claim Inquiry-Search the data with Total Incurred amount");

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
            //NEed to implement-to select random Claim Number
            
            //click on Finanacial tab
            cInquiry.ClickFinancial();
            //Need to implement-Assertion on claim number present in the FInancial tab
            //Verify the Incurred column in Breakdown by loss Line 
            //logout of Application
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }
    }
}
