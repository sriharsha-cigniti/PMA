﻿using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
//using OpenQA.Selenium.Point;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using Engine.Factories;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class ClaimInquiry : AbstractTemplatePage
    {
        HomePage home = new HomePage();

        #region UI Objects
        private By byClaimInformationClaimantName = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_lblClaimantName_0");
        private By byLossLineSummary = By.Id("MainContent_ASPxPageControl1_T1T");
        private By byDetailedClaimList = By.Id("MainContent_ASPxPageControl1_T0T");
        private By byResetButton = By.Id("MainContent_ASPxRoundPanel1_pnlContent_btnReset");
        private By byClaimNumber = By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtclaimnumber_I");
        private By byLast4SSN = By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtssnumber_I");
        private By byClaimstatus = By.Id("MainContent_ASPxRoundPanel1_pnlContent_ddstatus_I");
        private By byLastName = By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtclaimantname_I");
        private By byFirstName = By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtclaimantfirstname_I");
        private By byLocationIcon = By.Id("MainContent_ASPxRoundPanel1_pnlContent_btnlocationlookupImg");
        private By bylocationCodeTable = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@id,'gridlocation_DXDataRow')]");
        private By byGeneralTab = By.LinkText("General");
        private By byWorkerAccidentTab = By.LinkText("Worker-Accident");
        private By byEmployeeInformation = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usraccident1_0_pageControl_0_FormView1_0_Label6");
        private By byFinancialTab = By.LinkText("Financial");
        private By byPaymentsTab = By.LinkText("Payments");
        private By byDiaryTab = By.LinkText("Diary");
        private By byLogNotesTab = By.LinkText("Log Notes");
        private By byDocumentsTab = By.LinkText("Documents");
        private By byWagesText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_Label34_0");
        private By byBreakdownByLosslineText = By.XPath("//span[text()='Breakdown by Loss Line']");
        private By byCreateEntryLink = By.XPath("//span[text()='Create Entry']");
        private By byShowNotesLink = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_btnShow_0_CD");
        private By byHideNotesLink = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_btnHide_0_CD");
        private By byExportToSpredsheetLink = By.Id("MainContent_ASPxPageControl1_btncsv_CD");
        private By byIncurredfrom = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_txtincurretamount_I']");
        private By byIncurredto = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_txtincurretamountto_I']");
        private By byAccidentDateRangeBeginField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_I']");
        private By byAccidentDateRangeBeginArrow = By.XPath("//input[@id='sMainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_B - 1Img']");
        private By byAccidentDateRangeEndField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_I']");
        private By byAccidentDateRangeEndArrow = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_B-1']");
        private By byLossLineDescriptionLink = By.LinkText("Loss Line Description");
        private By byReportDateRangeBeginField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_I']");
        private By byReportDateRangeEndField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_I']");
        private By byActivityDateRangeBeginField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_I']");
        private By byActivityDateRangeEndField = By.XPath("//input[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_I']");
        private By byEmailAdjusterBtn = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_btnEmailAdjuster_0_CD']");
        private By byEmailAdjuster = By.XPath("//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_pcemail_0_PWH-1T']");
        private By byLocationCodeField = By.XPath("//input[@id='gridlocation_DXFREditorcol0_I']");
        private By byAccidentDateRangeBeginClearBtn = By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_BC']");
        private By byDragColoumnheaderSpace = By.Id("MainContent_ASPxPageControl1_gridresult_grouppanel");        
        private By byClaimInquiryResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byColumnHeaders = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@id,'MainContent_ASPxPageControl1_gridresult_DXHeadersRow0')]/th");
        private By byLossLineSummaryResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridlossline_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byLocationIconResultsTable = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byClaimInquirySearchResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byClaimTotalIncurred = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[@class='dxgvFooter']/td[3]");
        private By byClaimInquirypageSize = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult']//input[@id='MainContent_ASPxPageControl1_gridresult_DXPagerTop_PSI']");
        private By byClaimInquiryPagesizeDropdown = By.XPath("//ul[@id='MainContent_ASPxPageControl1_gridresult_DXPagerTop_DXMCC']/li[contains(@class,'dxm-item')]");
        private By byClaimInquiryPagesizeDRopdownBtn = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult']//span[@id='MainContent_ASPxPageControl1_gridresult_DXPagerTop_DDBImg']");
        private By byDraggedColumnList = By.XPath("//th[contains(@id,'MainContent_ASPxPageControl1_gridresult_groupcol')]//a");
        private By byGroupColumnsData = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvGroupRow')]");
        private By byAccidentLocation = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrgeneral1_0_FormView1_0_lbllocation");        
        private By byColumnHeadersPayments = By.XPath("//tr[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_DXHeadersRow0')]/th");
        private By byDraggedColumnListInSpacePayments = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_grouppanel");
        private By byDraggedColumnListPayments = By.XPath("//th[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_groupcol')]");
        private By byGroupColumnsList = By.XPath("//tr[contains(@id,'MainContent_ASPxPageControl1_gridresult_DXGroupRow')]/td[2]");
        //log notes

        private By byLogNotesGridCount = By.XPath("//tr[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXDataRow')]");
        private By byDraggedColumnListInSpaceLogNotes = By.XPath("//div[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_grouppanel')]");
        private By byDraggedColumnListLogNotes = By.XPath("//th[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_groupcol')]");

        private By byLocationField = By.XPath("//label[contains(text(),'Location : ')]/../..//input[@type='text']");
        private By byLocationCodeFieldColumn = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[1]");
        private By byClaimantNameResultcolumn = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[2]");
        private By byAccidentTab = By.LinkText("Accident");
        private By byAccidentInformationText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalaccident1_0_ASPxLabel1_0");
        private By byLossLineTab = By.LinkText("Loss Line");
        private By byLossLineDescriptionText = By.LinkText("Loss Line Description");
        private By byClaimFinancialTotalsText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalfinancial1_0_Label1_0");
        private By byGroupColumnForSort = By.XPath("//th[contains(@id,'MainContent_ASPxPageControl1_gridresult_groupcol')]");
        private By byPaymentGridCount = By.XPath("//tr[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_DXDataRow')]");
        private By byPaymentLossLine = By.XPath("//td/span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_dxdt1_0_ASPxLabel12_1']");
        private By byPaymentsRowCount = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_DXMainTable']//tr[contains(@class,'dxgvGroupRow')]/td[2]");

        private By byFinancialTotalsbyLossLineText = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_C5']//span[contains(text(),'Financial Totals by Loss Line')]");
        private By byPaymentStatusText = By.LinkText("Payment Status");
        private By byNote = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXMainTable']//th[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_col0']");
        private By byClaimantName = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXFREditorcol1']//input[@id='MainContent_ASPxPageControl1_gridresult_DXFREditorcol1_I']");
        private By byFinancialtabResults = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byBreakdownbylossLineReslts = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byExpandMedicalExpenseBtn = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[3]//td[1]");
        private By byReserveWorksheetsMedicalText = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//span[contains(text(),'Reserve Worksheets Medical')]");
        private By byExpandMedicalExpenseBtnAbsence = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[3]//td[1]//span");
        //Payments tab
        private By byPaymentsTabResultsCount = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byCheckDetailInformationText = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_DXMainTable']//span[text()='Check Detail Information']");
        private By byLossInformationText = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_DXMainTable']//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalpayment1_0_gridpayments_0_dxdt0_0_ASPxLabel2_0']");
        private By byExpandLossLineBtn = By.XPath("//span[@class='dx-acc dxGridView_gvDetailCollapsedButton dx-acc-s']");
        private By byExpandLossLineBtnAbsence = By.XPath("//span[@class='dx-acc dxGridView_gvDetailExpandedButton dx-acc-s']");
        private By byPaymentDetailTab = By.XPath("//a[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_T0T']/span[contains(text(),'Payment Detail')]");
        private By byExplanationofBenefitsTab = By.XPath("//a[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_T1T']/span[contains(text(),'Explanation of Benefits')]");
        private By byInvoiceSummaryTab = By.XPath("//a[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_T2T']/span[contains(text(),'Invoice Summary')]");
        private By byPaymentAmountinPaymentDetail = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C0']//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_ASPxLabel38_0']");
        private By byinvoiceAmountinExplanationofBenefits = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C1']//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_ASPxLabel74_0']");
        private By bySavingsandChargesText = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C2']//span[text()='Savings and Charges']");
        private By bySavingsDetailText = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C2']//span[text()='Savings Detail']");
        private By byPaymentAmtinInvoiceSummary = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C2']//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_ASPxLabel16_0']");
        private By byInvoiceAmtinInvoiceSummary = By.XPath("//div[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_C2']//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_dxdt0_0_pageControl_0_ASPxLabel12_0']");
        //Worker Accident
        private By byAccidentTabinWorkerAccident = By.XPath("//a[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usraccident1_0_pageControl_0_AT0T']");
        private By byMedicalsummaryinWorkerAccident = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usraccident1_0_pageControl_0_T1T");
        private By byMedicalsummaryContinWorkerAccident = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usraccident1_0_pageControl_0_T2T");

        //EmailAdjuster
        private By byCheckboxEmailAdjuster = By.Id("chkEmail_S_D");
        private By byEmailAddressField = By.XPath("//table[@id='mememailcc']//textarea[@id='mememailcc_I']");
        private By byMessageField = By.XPath("//table[@id='memessage']//textarea[@id='memessage_I']");
        private By bySendButton = By.XPath("//div[@id='btnSend']");
        private By byResetBtn = By.XPath("//div[@id='ASPxButton1']//span[contains(text(),'Reset')]");
        private By byCancelButton = By.XPath("//div[@id='btncancel']");
        //Export spreadsheet
        private By byLossSumaarylink = By.XPath(" //span[contains(text(),'Loss Line Summary')]");
        private By byClaimListButton = By.XPath("//span[contains(text(),'Claim List')]");
        private By byEFRButton = By.XPath("//span[contains(text(),'View EFR')]");
        private By byExportToSpredsheetOnLossummaryLink = By.XPath("//div[@id='MainContent_ASPxPageControl1_btnExportLossline']//span[contains(text(),'Export to Spreadsheet')]");
        // Document LIst
        private By byDeSelectallButton = By.XPath("//button[contains(text(),'Deselect All')]");
        private By byOpenButton = By.XPath("//button[contains(text(),'Open')]");
        private By byCloseWIndowButton = By.XPath("//button[contains(text(),'Close Window')]");
        private By byDocumentsListTable = By.XPath("//table[@class='table table-striped table-hover']");
        private By byEntryNumber = By.XPath("//a[contains(text(),'Entry Number')]");
        private By byEntryNameResultcolumn = By.XPath("//table[@class='table table-striped table-hover']//tr[contains(@class,'ng-scope')]//td[3]");
        //Accident Tab
        //private By byAccidentTab=By.XPath("//button[contains(text(),'Deselect All')]");
        private By byAccidentinformationLbl = By.XPath("//span[contains(text(),'Accident Information')]");
        private By byAccidentDescriptionLbl = By.XPath("//span[contains(text(),'Accident Description')]");
        private By byAccidentVehicleListLbl = By.XPath("//span[contains(text(),'Vehicle List')]");
        private By byVehiclelisttable = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalaccident1_0_gridvehicle_0");
        private By byDocumentSearchText = By.Id("filterInput");
        // LossLine tab
        private By bylosslineDataTable = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_lossline1_0_gridlossline_0");
        private By byExpand = By.XPath("//span[@class='dx-acc dxGridView_gvDetailCollapsedButton dx-acc-s']");
        private By byLossLineDetailinformationLbl = By.XPath("//span[contains(text(),'Lossline Detail Information')]");
        private By byClaimantDetailInformationLbl = By.XPath("//span[contains(text(),'Claimant Detail Information')]");
        private By byOtherLosslineLbl = By.XPath("//span[contains(text(),'Other Lossline Information')]");
        private By byOtherClaimantLbl = By.XPath("//span[contains(text(),'Other Claimant Information')]");
        private By byClaimantNameText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_lossline1_0_gridlossline_0_DXFREditorcol1_I");
        private By byClearButton = By.XPath("//span[contains(text(),'Clear')]");
        // LogNotes tab
        private By byHideNotesTab = By.XPath("//span[contains(text(),'Hide Notes')]");
        private By byShortNotesTab = By.XPath("//span[contains(text(),'Show Notes')]");
        private By bylogNotesDataTable = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXMainTable");
        #endregion

        #region Path

        string FilePath = "";
        string FileName = "";

        #endregion

        #region Public Methods

        //Click Resetbutton in EmailAdjuster
        public void clickResetButtoninEmailAdjuster()
        {
            this.TESTREPORT.LogInfo("Click Resetbutton in EmailAdjuster");
            this.driver.ClickElement(byResetBtn, "ResetButtoninEmailAdjuster");
            if (this.driver.GetElementText(byMessageField).Length == 0 || this.driver.GetElementText(byMessageField) == "")
            {
                this.TESTREPORT.LogSuccess("Verify Message field after clicking Reset", string.Format("Field <mark>{0}</mark> is set to empty", byMessageField));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Message field after clicking Reset", "Field is not empty", this.SCREENSHOTFILE);
            }
            Thread.Sleep(2000);
            // By close = By.XPath("//div[@class='dxpc-closeBtn']//span");
            //this.driver.ClickElement(close,"Close button in EMailAdjuster");
            //this.driver.SwitchTo().DefaultContent();
        }

        //Click cancelbutton in EmailAdjuster
        public void ClickCancelButtoninEmailAdjuster()
        {
            this.TESTREPORT.LogInfo("Click Cancelbutton in EmailAdjuster");
            this.driver.IsElementPresent(byCancelButton);
            this.driver.ClickElement(byCancelButton, "CancelButton in EmailAdjuster");
            Thread.Sleep(2000);
            this.driver.SwitchTo().DefaultContent();

        }

        //Select PageSize in the ClaimInquiryResults table
        public void SelectPageSizefromtheClaimInquiryResults()
        {
            this.TESTREPORT.LogInfo("Select PageSize from ClaimInquiryResults dropdown");
            // string selectedValue = null;

            this.driver.ClickElement(byClaimInquiryPagesizeDRopdownBtn, "ClaimInquiryPageSize DropdownButton");

            //int value = rnd.Next(0, list.Count);
            IReadOnlyList<IWebElement> dropdown = this.driver.FindElements(byClaimInquiryPagesizeDropdown);
            dropdown[1].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> rows = this.driver.FindElements(byClaimInquirySearchResultsTable);
            string selectedValue = this.driver.GetElementAttribute(byClaimInquirypageSize, "value");

            int x = Convert.ToInt32(selectedValue);
            if (rows.Count == x)
            {
                this.TESTREPORT.LogSuccess("Verify the count of the results displayed against the pagesize selected in the ClaimInquiry", String.Format("count <mark>{0}</mark> matches", selectedValue));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify the count of the results displayed against the pagesize selected in the ClaimInquiry", String.Format("Count not matching", this.SCREENSHOTFILE));

            }

        }



        //Click AccidentDateRange Begin ClearBtn in Calendar
        public void ClickAccidentDateRangeBeginClearBtn()

        {
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar dRopDOwn");
            Thread.Sleep(2000);
            this.driver.ClickElement(byAccidentDateRangeBeginClearBtn, "AccidentDateRangeBeginClearBtn");
            Thread.Sleep(5000);
            Actions a = new Actions(driver);
            a.SendKeys(OpenQA.Selenium.Keys.Tab).Build().Perform();
        }


        //Click AccidentTab in claimInformation
        public void ClickAccidentTab()

        {
            this.driver.ClickElement(byAccidentTab, "AccidentTab");
        }

        //Check the chaeckbox in EMailAdjuster
        public void ClickCheckBoxinEmailAdjuster()

        {
            this.TESTREPORT.LogInfo("Click CheckBox in EmailAdjuster");
            this.driver.SwitchTo().Frame("MainContent_dvclaims_IT0_usrdetail1_0_pcemail_0_CIF-1");
            this.driver.IsElementPresent(byCheckboxEmailAdjuster);
            Thread.Sleep(2000);
            this.driver.ClickElement(byCheckboxEmailAdjuster, "Checkbox - EmailAdjuster");
        }

        //Click LossLineTab in claimInformation
        public void ClickLossLineTab()

        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byLossLineTab, "LossLineTab");
        }

        //Click FinancialTab in claimInformation
        public void ClickandVerifyFinancialTab()

        {
            if (this.driver.IsElementPresent(byFinancialTab))
            {
                this.TESTREPORT.LogInfo("click on Finanacial tab");
                Thread.Sleep(2000);
                this.driver.ClickElement(byFinancialTab, "FinancialTab");
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Financial tab", string.Format("Tab is not displayed", this.SCREENSHOTFILE));
            }
        }



        //click on LossLine summary
        public void ClickLosslineSummary()

        {
            this.TESTREPORT.LogInfo("click on LossLineSummary");
            this.driver.ClickElement(byLossLineSummary, "LosslineSummary");
        }

        //click on EmailAdjuster
        public void ClickEmailAdjuster()

        {
            this.TESTREPORT.LogInfo("Click EmailAdjuster");
            this.driver.ClickElement(byEmailAdjusterBtn, "EmailAdjuster");
        }

        //Verify EmailAdjuster
        public void VerifyEmailAdjuster()
        {
            bool flag = this.driver.IsElementPresent(byEmailAdjuster);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify EmailAdjuster", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Email Adjuster"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify EmailAdjuster", String.Format("Failed to Verify text"), this.SCREENSHOTFILE);
            }
        }

        //verify LossLineSummary in the Claiminquiry Page
        public void VerifyLossLineSummary()
        {
            this.TESTREPORT.LogInfo("verify loss Line Summary");
            bool flag = this.driver.IsElementPresent(byLossLineSummary);
            try
            {
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify Loss Line Summary link", String.Format(" Successfully verified - <Mark>{0}</Mark>", "Loss Line Summary"));
                    //this.TESTREPORT.LogSuccess("Verify Default Account Lable", String.Format(" Successfully verified - <Mark>{0}</Mark>"));
                }

                else
                {
                    this.TESTREPORT.LogFailure("Verify Loss Line Summary Link", String.Format("Failed to Verify "), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            {
                //e.stackTrace();
            }
        }

        //Verify DetailedClaimList
        public void VerifyDetailedClaimList()
        {
            this.TESTREPORT.LogInfo("Verify Detailed Claim list");
            bool flag = this.driver.IsElementPresent(byDetailedClaimList);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Detailed Claim List", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Detailed claim list"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Detailed Claim List", String.Format("Failed to Verify link"), this.SCREENSHOTFILE);
            }
        }

        //Verify CreateEntry Link in the
        public void VerifyCreateEntryLink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byCreateEntryLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Create Entry link", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "CreateEntry link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Create Entry link", String.Format("Failed to Verify link"), this.SCREENSHOTFILE);
            }
        }

        //Verify Employeeinformation in the WorkerAccident
        public void VerifyEmployeeInformation()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byEmployeeInformation);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Text", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "EmployeeInformation"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Text", String.Format("Failed to Verify"), this.SCREENSHOTFILE);
            }
        }

        //Verify PaymentText in the Payments tab
        public void VerifyPayment()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byPaymentsTab);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Text", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Payment"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Text", String.Format("Failed to Verify"), this.SCREENSHOTFILE);
            }
        }

        //Verify DiaryText in the Diary tab
        public void VerifyDiary()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byDiaryTab);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Text", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Diary"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Text", String.Format("Failed to Verify"), this.SCREENSHOTFILE);
            }
        }


        //Verify Wages text
        public void VerifyWagesText()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byWagesText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Wages", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Wages Text"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Wages", String.Format("Failed to Verify Text"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyBreakdownByLosslineText()
        {
            bool flag = this.driver.IsElementPresent(byBreakdownByLosslineText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify BreakdownByLossline", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "BreakdownByLossline Text"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify BreakdownByLossline", String.Format("Failed to Verify Text"), this.SCREENSHOTFILE);
            }
        }

        //Verify ShowNotes link in the logNotes
        public void VerifyShowNoteslink()
        {
            bool flag = this.driver.IsElementPresent(byShowNotesLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify ShowNotes", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "ShowNotes Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ShowNotes", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }


        //Verify HideNotes link in the logNotes
        public void VerifyHideNoteslink()
        {
            bool flag = this.driver.IsElementPresent(byHideNotesLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify HideNotes", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "HideNotes Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify HideNotes", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify ExporttoSpreadsheet link in the ClaimInquiry Page
        public void VerifyExporttoSpreadsheetlink()
        {
            bool flag = this.driver.IsElementPresent(byExportToSpredsheetLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify ExportToSpredsheet", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "ExportToSpredsheet Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ExportToSpredsheet", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify LosslineDescription link in the 
        public void VerifyLossLineDescriptionlink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byLossLineDescriptionLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify LossLineDescription", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "LossLineDescription Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify LossLineDescription", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify AccidentInformation TExt in the accident Tab
        public void VerifyAccidentInformationlink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byAccidentInformationText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify AccidentInformation", String.Format(" Successfully verified -  - <Mark>{0}</Mark> ", "AccidentInformation link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify AccidentInformation", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }


        //Verify Claim FinancialTotal in the Financial Tab
        public void VerifyClaimFinancialTotalText()
        {
            this.TESTREPORT.LogInfo("Verify Claim FinancialTotal in Financial tab");
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byClaimFinancialTotalsText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify ClaimFinancialTotal", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "ClaimFinancialTotal Text"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ClaimFinancialTotal", String.Format("Failed to Verify Text"), this.SCREENSHOTFILE);
            }
        }


        //Verify Claim FinancialTotalbyLossLine in the Financial Tab
        public void VerifyFinancialTotalsbyLossLineText()
        {
            this.TESTREPORT.LogInfo("Verify FinancialTotalsbyLossLine in Financial tab");
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byFinancialTotalsbyLossLineText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify FinancialTotalsbyLossLine", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "FinancialTotalsbyLossLine Text"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify FinancialTotalsbyLossLine", String.Format("Failed to Verify Text"), this.SCREENSHOTFILE);
            }
        }

        //Verify PaymentStatus in the Payments Tab
        public void VerifyPaymentStatuslink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byPaymentStatusText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify PaymentStatus", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "PaymentStatus Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify PaymentStatus", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify Note in the LogNotes Tab
        public void VerifyNotelink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byNote);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Note", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Note Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Note", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }

        //Verify Location search Icon in the CliamInquiry page
        public void VerifyLocationIcon()
        {
            bool flag = this.driver.IsElementPresent(byLocationIcon);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Location Icon", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Location Icon"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Location Icon", String.Format("Failed to Verify Icon"), this.SCREENSHOTFILE);
            }
        }


        public void ClickReset()
        {
            this.driver.ClickElement(byResetButton, "Reset Button");

        }

        public void ClickSendButton()
        {
            this.TESTREPORT.LogInfo("Click Send button in EmailAdjuster");
            this.driver.ClickElement(bySendButton, "Send Button");
            this.driver.SwitchTo().DefaultContent();
        }

        public string EnterClaimNumber(String ClaimNumbervalue)

        {
            this.driver.SendKeysToElement(byClaimNumber, ClaimNumbervalue, "Claim Number");
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byClaimNumber, "value");
            return str;
        }

        public void EnterEmailAddress(String EMailAddressFieldvalue, string MessageFieldValue)

        {
            this.TESTREPORT.LogInfo("Enter Multiple Email address and message in the Text box provided");
            this.driver.IsElementPresent(byEmailAddressField);
            Thread.Sleep(2000);
            this.driver.SendKeysToElement(byEmailAddressField, EMailAddressFieldvalue, "EMailAddress");
            Thread.Sleep(2000);
            this.driver.SendKeysToElement(byMessageField, MessageFieldValue, "MessageField");


        }

        public void VerifyClaimNumber(string value1)
        {
            string value = this.driver.GetElementAttribute(byClaimNumber, "value");
            if (value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the ClaimNumber field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the ClaimNumber field after Reset", "Field notset to empty");
            }
        }

        public void VerifyAccidentDateField()
        {
            Thread.Sleep(10000);


            string value = this.driver.GetElementAttribute(byAccidentDateRangeBeginField, "value");



            if (value.Length == 0)
            {
                this.TESTREPORT.LogSuccess("To verify the AccidentDate field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the AccidentDate field after Reset", "Field notset to empty");
            }
        }

        public string EnterLast4SSN(String Last4SSNvalue)

        {
            this.driver.SendKeysToElement(byLast4SSN, Last4SSNvalue, "Last4SSN");
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byLast4SSN, "value");
            return str;
        }

        public void VerifyLast4SSN(string value1)
        {
            string value = this.driver.GetElementAttribute(byLast4SSN, "value");
            if (value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the Last4SSN field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the Last4SSN field after Reset", "Field notset to empty");
            }
        }

        public string EnterClaimstatus(String Claimstatusvalue)

        {
            Thread.Sleep(2000);
            this.driver.SendKeysToElementWithJavascript(byClaimstatus, Claimstatusvalue, "Claimstatus");
            Actions a = new Actions(driver);
            a.SendKeys(OpenQA.Selenium.Keys.Down).Build().Perform();
            a.SendKeys(OpenQA.Selenium.Keys.Down).Build().Perform();
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byClaimstatus, "value");
            return str;
        }

        public void VerifyClaimstatus(string value1)
        {
            string value = this.driver.GetElementAttribute(byClaimstatus, "value");
            if (value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the Claimstatus field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the Claimstatus field after Reset", "Field notset to empty");
            }
        }

        public string EnterLastName(String LastNamevalue)

        {
            this.driver.SendKeysToElement(byLastName, LastNamevalue, "LastName");
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byLastName, "value");
            return str;
        }

        public void VerifyLastName(string value1)
        {
            string value = this.driver.GetElementAttribute(byLastName, "value");
            if (value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the LastName field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the LastName field after Reset", "Field notset to empty");
            }
        }


        public string EnterFirstName(String FirstNamevalue)

        {
            this.driver.SendKeysToElement(byFirstName, FirstNamevalue, "FirstName");
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byFirstName, "value");
            return str;
        }

        public void VerifyFirstName(string value1)
        {
            string value = this.driver.GetElementAttribute(byFirstName, "value");
            if (value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the FirstName field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure("To verify the FirstName field after Reset", "Field notset to empty");
            }
        }


        public void EnterIncurredfrom(String Incurredfromvalue)

        {
            this.driver.SendKeysToElement(byIncurredfrom, Incurredfromvalue, "Incurred from");
        }

        public void EnterIncurredTo(String IncurredTovalue)

        {
            this.driver.SendKeysToElement(byIncurredto, IncurredTovalue, "Incurred to");
        }

        public void EnterAccidentDateRangeBegin()
        {
            //string date = "";
            //string datetemp = AccidentDateRangeBeginFieldvalue.Split('/')[0];
            //if (datetemp.Contains("0"))
            //    date=datetemp.Replace("0","");

            //this.driver.SendKeysToElementWithJavascript(byAccidentDateRangeBeginField, AccidentDateRangeBeginFieldvalue, "AccidentDateRangeBeginField");
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar DropDown");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[2].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[2].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td"));
            Thread.Sleep(2000);
            foreach (var item in dates)
            {
                Thread.Sleep(2000);
                if (item.Text.Equals("2"))
                {

                    item.Click();
                    Thread.Sleep(1000);
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);
            //this.driver.ClickElement(selectDAte, "select date");


            //Thread.Sleep(5000);
        }

        public void EnterAccidentDateRangeEnd()

        { //string date = "";
          //string datetemp = AccidentDateRangeBeginFieldvalue.Split('/')[0];
          //if (datetemp.Contains("0"))
          //    date=datetemp.Replace("0","");

            //this.driver.SendKeysToElementWithJavascript(byAccidentDateRangeBeginField, AccidentDateRangeBeginFieldvalue, "AccidentDateRangeBeginField");
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar dRopDOwn");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[10].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[5].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentend_DDD_C_mt']//td"));

            foreach (var item in dates)
            {
                if (item.Enabled && item.Text.Contains("26"))
                {
                    item.Click();
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);
            //this.driver.ClickElement(selectDAte, "select date");


            //Thread.Sleep(5000);
        }

        public string EnterReportDateRangeBegin()

        {
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar DropDOwn");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[2].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[2].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportbegin_DDD_C_mt']//td"));
            Thread.Sleep(2000);
            foreach (var item in dates)
            {
                Thread.Sleep(2000);
                if (item.Text.Equals("2"))
                {

                    item.Click();
                    Thread.Sleep(1000);
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);

            string value = this.driver.GetElementAttribute(byReportDateRangeBeginField, "value");
            return value;
        }

        public string EnterReportDateRangeEnd()

        {
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtreportend_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar DropDown");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_PW-1']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[10].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[5].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtreportend_DDD_C_mt']//td"));

            foreach (var item in dates)
            {
                if (item.Enabled && item.Text.Contains("26"))
                {
                    item.Click();
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);
            string value1 = this.driver.GetElementAttribute(byReportDateRangeEndField, "value");
            return value1;
        }

        public void EnterActivityDateRangeBegin()

        {
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar dRopDOwn");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[2].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[2].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivitybegin_DDD_C_mt']//td"));
            Thread.Sleep(2000);
            foreach (var item in dates)
            {
                Thread.Sleep(2000);
                if (item.Text.Equals("2"))
                {

                    item.Click();
                    Thread.Sleep(1000);
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);
        }

        public void EnterActivityDateRangeEnd()

        {
            Thread.Sleep(2000);
            By calendarDRopdown = By.Id("MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_B-1Img");
            this.driver.ClickElement(calendarDRopdown, "Calendar dRopDOwn");
            // By selectDAte = By.XPath(string.Format("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(text(),'{0}')]", date));
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C']//span[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_T']"), "Button to select month and year");
            IReadOnlyList<IWebElement> months = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_FNP_m']//td[contains(@class,'dxeCalendarFastNavMonth')]"));
            months[10].Click();
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> years = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_FNP_y']//td[contains(@class,'dxeCalendarFastNavYear')]"));
            years[5].Click();
            Thread.Sleep(2000);
            this.driver.ClickElement(By.XPath("//div[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_FNP_PW-1']//td[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_FNP_BO']"), "OK button in month and year");

            IReadOnlyList<IWebElement> dates = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtactivityend_DDD_C_mt']//td"));

            foreach (var item in dates)
            {
                if (item.Enabled && item.Text.Contains("26"))
                {
                    item.Click();
                    break;
                }
                //break;
            }

            Thread.Sleep(5000);
        }

        public void EnterLocationCodeField(String LocationCodeFieldvalue)

        {
            this.driver.SwitchTo().Frame("MainContent_pcLocation_CIF-1");
            this.driver.SendKeysToElement(byLocationCodeField, LocationCodeFieldvalue, "LocationCodeField");
            Thread.Sleep(2000);
        }


        public void ClickLocationSearchIcon()
        {
            this.driver.ClickElement(byLocationIcon, "Location Icon");

        }

        public void ClickWorkerAccident()
        {
            this.driver.ClickElement(byWorkerAccidentTab, "Worker Accident");

        }



        public void ClickPayments()
        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byPaymentsTab, "Payments");

        }

        public void ClickDiary()
        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byDiaryTab, "Diary");

        }

        public void ClickLogNotes()
        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byLogNotesTab, "LogNotes");

        }

        public void ClickDocuments()
        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byDocumentsTab, "Documents");
            Thread.Sleep(2000);
            SwitchToChildWindow();
            if (this.driver.IsElementPresent(byOpenButton))
                this.TESTREPORT.LogSuccess("Verify Documents Navigation ", string.Format("<Mark>Navigated to documentlistTab </Mark>"), this.SCREENSHOTFILE);

        }

        public void ClickShowNotesLink()
        {
            this.driver.ClickElement(byShowNotesLink, "ShowNotes");

        }

        public void ClickHideNotesLink()
        {
            this.driver.ClickElement(byHideNotesLink, "HideNotes");

        }

        public void ClickExportToSpredsheetLink()
        {
            this.driver.ClickElement(byExportToSpredsheetLink, "ExportToSpreadSheet");

        }

        public void SwitchtoDocumentswindow(String value)
        {
            Thread.Sleep(2000);
           // SwitchToChildWindow();
           
            //Verify the Page title for the Documents 
            VerifyPageTitle(value);
            CloseChildWindow();
            SwitchToParentWindow();
           
            
        }

        public void VerifyPageTitle(string title)
        {
            this.driver.AssertTextMatching(this.driver.GetPageTitle(), title);
        }

        public void Pickdays(String datevalue)
        {
            IList<IWebElement> columns = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_mt']//td[contains(@class,'dxeCalendarDay')]"));
            for (int i = 0; i <= columns.Count; i++)
            {
                if (columns[i].Enabled && columns[i].Text == datevalue)
                {
                    columns[i].Click();
                }
            }


        }

        public void Pickmonths(String monthvalue)
        {
            IList<IWebElement> columns = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxRoundPanel1_pnlContent_dtaccidentbegin_DDD_C_FNP_m']//td"));
            for (int j = 0; j <= columns.Count; j++)
            {
                if (columns[j].Displayed && columns[j].Text == monthvalue)
                {
                    columns[j].Click();
                }
            }


        }




        public void ClickLocationCode()

        {
            //string LocationCodeFieldvalue = this.driver.GetElementText(byLocationCodeField);

            IList<IWebElement> rows = this.driver.FindElements(By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@id,'gridlocation_DXDataRow')]/td[1]"));
            foreach (var row in rows)
            {
                row.Click();
                break;
            }
        }



        public void NavigatetoParentFrame()
        {
            this.driver.SwitchTo().DefaultContent();
        }

        public void Dragthecolumnheaderinspace(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byColumnHeaders);
            IWebElement e2 = this.driver.FindElement(byDragColoumnheaderSpace);
            foreach (var WebItem in list)
            {
                if (WebItem.Text.ToLower().Equals(value.ToLower()))
                {
                    this.driver.DragDrop(WebItem, e2);
                    break;
                }

            }


        }

        public void VerifyLossLineSummaryResultsCount()
        {
            IReadOnlyList<IWebElement> rows = this.driver.FindElements(byLossLineSummaryResultsTable);
            if (rows.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify losslineSummary results", String.Format(" Table - {0} is displayed succesfully", "LosslineSummaryResults"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify losslineSummary results", String.Format(" Table - {0} is not displayed ", this.SCREENSHOTFILE));
            }

        }

        public void ClickRandomLocationCode()
        {
            Thread.Sleep(6000);

            this.TESTREPORT.LogInfo(" Click on any random claim number");
            ArrayList listName = new ArrayList();
            Random rnd = new Random();
            int value = rnd.Next(0, 9);
            int j = 0;
            IReadOnlyList<IWebElement> rows = driver.FindElements(byLocationIconResultsTable);

            try
            {
                foreach (var item in rows)
                {
                    if (value == j)
                    {
                        IReadOnlyList<IWebElement> data = item.FindElements(By.TagName("td"));
                        for (int i = 0; i <= 2; i++)
                        {
                            listName.Add(data[i].Text);
                        }

                        IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
                        ex.ExecuteScript("arguments[0].click();", item);
                        //item.Click();
                        this.TESTREPORT.LogSuccess("Click on Recent Random ClaimNumber", String.Format(" Successfully Clicked on - <Mark>{0}</Mark> ", listName));
                        break;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            catch (Exception)
            {
                this.TESTREPORT.LogFailure("Click on Recent Random ClaimNumber", String.Format("NO Recent Claims Available "), this.SCREENSHOTFILE);
                throw;
            }
            //string Titlevalue=this.driver.GetPageTitle();
            //return Titlevalue;
            this.driver.SwitchTo().DefaultContent();

            // return listName;
        }



        //Verify ClaimNumber in ClaimInformation Page
        public void VerifyLocationCodeField(string LocationCodeField)
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.IsElementPresent(byLocationField);
            // this.driver.ClickElement(By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtlocation"), "TAble ck");
            Thread.Sleep(2000);
            this.driver.IsElementPresent(byLocationField);
            string ActualLocationCodeField = this.driver.GetElementText(byLocationField);
            this.driver.AssertTextMatching(ActualLocationCodeField, LocationCodeField);

        }

        public void VerifyLocationCodeFieldTableValue(string value)
        {
            //string value1 = this.driver.GetElementText(byLocationCodeField);
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> column = this.driver.FindElements(byLocationCodeFieldColumn);

            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    //string value = this.driver.GetElementText(item);                    
                    if (item.Text.Contains(value))
                    {
                        this.TESTREPORT.LogSuccess("Verify LocationCode Entered value", string.Format("Entered value matches with the Table Results"));
                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify LocationCode Entered value", string.Format("Entered value didn't match with the Table Results"), this.SCREENSHOTFILE);
                    }
                    Thread.Sleep(2000);
                }
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify filtered results", string.Format("There is no data to display"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyTotalIncurredTableValue(string value, string value2)
        {
            //string value1 = this.driver.GetElementText(byLocationCodeField);
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> column = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[9]"));

            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    //string value = this.driver.GetElementText(item); 
                    double actualvalue = Convert.ToDouble(item.Text);
                    double value1 = Convert.ToDouble(value);
                    double value3 = Convert.ToDouble(value2);
                    if (actualvalue <= value1 && actualvalue >= value3)
                    {
                        this.TESTREPORT.LogSuccess("Verify TotalIncurred Result value", string.Format("value - <mark>{0}</mark> is less than MaxIncurredAmount Entered", item.Text));
                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify TotalIncurred Result value", string.Format("value is not less than MaxIncurredAmount Entered"), this.SCREENSHOTFILE);
                    }
                    Thread.Sleep(2000);
                }
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify filtered results", string.Format("There is no data to display"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyAccidentDateTableValue()
        {
            string value = this.driver.GetElementAttribute(byAccidentDateRangeBeginField, "value");
            Thread.Sleep(2000);
            string value1 = this.driver.GetElementAttribute(byAccidentDateRangeEndField, "value");
            Thread.Sleep(2000);
            //string value1 = this.driver.GetElementText(byLocationCodeField);
            Thread.Sleep(3000);
            string iDate = value;
            DateTime oDate = Convert.ToDateTime(iDate);
            string iDate1 = value1;
            DateTime oDate1 = Convert.ToDateTime(iDate1);
            IReadOnlyList<IWebElement> column = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[4]"));

            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    //DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
                    //String.Format("{0:MM/dd/yyyy}", dt); 


                    string iDate2 = item.Text;
                    DateTime actualvalue = Convert.ToDateTime(iDate2);

                    if (actualvalue <= oDate1 && actualvalue >= oDate)
                    {
                        this.TESTREPORT.LogSuccess("Verify AccidentDate Result value", string.Format("Date - <mark>{0}</mark> is within the AccidentDate Range", actualvalue));
                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify AccidentDate Result value", string.Format("Date is not within the AccidentDate Range"), this.SCREENSHOTFILE);
                    }
                    Thread.Sleep(2000);
                }
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify filtered results", string.Format("There is no data to display"), this.SCREENSHOTFILE);
            }
        }

        public ArrayList ClickOnRandomClaimInquiryResults()
        {
            Thread.Sleep(6000);
            return this.driver.ClickRandomCliamNumber(byClaimInquirySearchResultsTable, 9);
        }

        public void VerifyTotalIncurredAmount(string IncurredAmount)
        {
            this.driver.WaitElementPresent(byClaimTotalIncurred);
            string ActualIncurredAmount = this.driver.GetElementText(byClaimTotalIncurred);
            if (ActualIncurredAmount.Contains(IncurredAmount))
            {
                this.TESTREPORT.LogSuccess("Verify Total incurred Amount", String.Format("Incurred Amount -<mark>{0}</mark> matches", ActualIncurredAmount));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Total incurred Amount", "Incurred Amount not matching");
            }

        }

        public void EnterClaimantName(string ClaimantName)
        {
            Thread.Sleep(4000);
            ClaimantName = ClaimantName.ToLower();
            this.TESTREPORT.LogInfo("Enter a ClaimNumber-starts with 'L or 'W' in the grid view");
            if (ClaimantName.Contains("l"))
            {
                this.driver.SendKeysToElementClearFirst(byClaimantName, ClaimantName, "ClaimantName");
            }
            else
            {
                this.driver.SendKeysToElementClearFirst(byClaimantName, "w", "ClaimantName");
            }
            Thread.Sleep(5000);
        }


        public ArrayList VerifyClaimantNameColumn(string value)
        {
            Thread.Sleep(5000);
            int count = 0;
            this.driver.WaitElementPresent(byClaimantNameResultcolumn);
            IReadOnlyList<IWebElement> column = this.driver.FindElements(byClaimantNameResultcolumn);
            ArrayList a = new ArrayList();
            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    //string value = this.driver.GetElementText(item);                    
                    if (item.Text.ToLower().Contains(value.ToLower()))
                    {

                        //string XPathrow = "MainContent_ASPxPageControl1_gridresult_DXDataRow" + count.ToString(); 
                        IWebElement ele = this.driver.FindElement(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[@id='MainContent_ASPxPageControl1_gridresult_DXDataRow0']/td[2]"));
                        string text = ele.Text;
                        IWebElement ele1 = this.driver.FindElement(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[@id='MainContent_ASPxPageControl1_gridresult_DXDataRow0']/td[3]"));
                        string text1 = ele1.Text;

                        IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
                        ex.ExecuteScript("arguments[0].click();", ele);

                       // ele.Click();
                        a.Add(text);
                        a.Add(text1);

                        this.TESTREPORT.LogSuccess("Verify ClaimantName Entered value", string.Format("Entered value matches with the Table Results"));
                        break;


                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify ClaimantName Entered value", string.Format("Entered value didn't match with the Table Results"), this.SCREENSHOTFILE);
                    }
                    //count ++;
                    Thread.Sleep(2000);
                }
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify filtered results", string.Format("There is no data to display"), this.SCREENSHOTFILE);
            }
            return a;
        }

        public void GetExportFilePath(string Filename1)
        {
            string lFilePath = WebDriverFactory.GetDownloadPath();
            string lFileName = Filename1;
            FilePath = lFilePath;
            FileName = lFileName;

        }

        public void ExportFileExists()
        {
            bool exists = false;
            ExportSpreadsheet file = new ExportSpreadsheet(FileName, FilePath);
            exists = file.FileExists();
            if (exists)
            {
                this.TESTREPORT.LogSuccess("Exported File", String.Format("File:<Mark>{0}</Mark> found and is successfully exported", FileName));
            }
            else
            {
                this.TESTREPORT.LogFailure("Exported xml doesn't contains", String.Format("File:<Mark>{0}</Mark> not found and is not exported", FileName));
            }
        }

        public void ClickLossLineDescriptionlink()
        {
            Thread.Sleep(2000);
            this.driver.IsElementPresent(byLossSumaarylink);
            this.driver.ClickElement(byLossSumaarylink, "Loss Summary Tab");
            this.driver.IsElementPresent(byLossLineDescriptionLink);

        }

        public void ExportFileDelete()
        {
            bool exists = false;
            Thread.Sleep(10000);
            ExportSpreadsheet file = new ExportSpreadsheet(FileName, FilePath);
            exists = file.FileDelete();
            if (exists)
                this.TESTREPORT.LogInfo(String.Format("File:<Mark>{0}</Mark> Deleted", FileName));
        }

        public void ClickClaimListbutton()
        {
            this.driver.IsElementPresent(byClaimListButton);
            this.driver.ClickElement(byClaimListButton, "CLaim LiSt BUtton");

        }

        public void ClickAndVerifyEFRButton()
        {
            this.driver.IsElementPresent(byEFRButton);
            this.driver.ClickElement(byEFRButton, "EFR Button");

        }

        public void ClickandVerifyExporttoSpreadsheetOnLoanSummarylink()
        {
            Thread.Sleep(2000);
            this.driver.WaitElementPresent(byExportToSpredsheetOnLossummaryLink);
            this.driver.IsElementPresent(byExportToSpredsheetOnLossummaryLink);
            this.driver.ClickElement(byExportToSpredsheetOnLossummaryLink, "CLaim LiSt BUtton");
        }

        public void SwitchToChildWindow()
        {
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }
        public void SwitchToParentWindow()
        {
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.First());

        }

        public void CloseChildWindow()
        {
            Thread.Sleep(3000);
            this.driver.CloseChildWindow();
        }

        public void VerifyClaimInfoAccidentDate(string AccidentDate)
        {
            //By accidentdate = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrgeneral1_0_FormView1_0_ASPxLabel18");
            //string accidentDate = this.driver.GetElementText(accidentdate);
            //if (!string.IsNullOrEmpty(accidentDate))

            //    this.TESTREPORT.LogSuccess("Verify Claim Info Accident Date", String.Format("Accident Date:<Mark>{0}</Mark>", accidentDate));

            //else
            //    this.TESTREPORT.LogFailure("Verify Claim Info Accident Date", String.Format("Accident Date:<Mark>{0}</Mark>", accidentDate));


            string ActualClaimAccidentDate = this.driver.GetElementText(By.XPath("//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_lblAccident_0']"));
            this.driver.AssertTextMatching(ActualClaimAccidentDate, AccidentDate);
        }
        
        public void VerifyCloseButton()
        {

        }

        public void VerifyOpenAllButton()
        {

        }

        public void VerifyClaimInfoReportDate(string value, string value1)
        {

            string iDate = value;
            DateTime oDate = Convert.ToDateTime(iDate);
            string iDate1 = value1;
            DateTime oDate1 = Convert.ToDateTime(iDate1);

            string ActualClaimReportDate = this.driver.GetElementText(By.XPath("//span[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrgeneral1_0_FormView1_0_ASPxLabel8']"));
            string iDate2 = ActualClaimReportDate;
            DateTime actualvalue = Convert.ToDateTime(iDate2);

            if (actualvalue <= oDate1 && actualvalue >= oDate)
            {
                this.TESTREPORT.LogSuccess("Verify ReportDate Result value", string.Format("Date - <mark>{0}</mark> is within the ReportDate Range", actualvalue));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ReportDate Result value", string.Format("Date is not within the ReportDate Range"), this.SCREENSHOTFILE);
            }
            Thread.Sleep(2000);

        }

        public void DragTheColumnHeaderInSpace(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byColumnHeaders);
            IWebElement e2 = this.driver.FindElement(byDragColoumnheaderSpace);
            foreach (var WebItem in list)
            {

                if (WebItem.Text.ToLower().Trim().Equals(value.ToLower().Trim()))
                {
                    this.driver.DragDrop(WebItem, e2);
                    break;
                }

            }
        }

      //Verify the Dragged Column List
        public void DraggedColumnList(int number, string value)
        {
            Thread.Sleep(6000);
           try
            {
                 IReadOnlyList<IWebElement> list = this.driver.FindElements(byDraggedColumnList);
                //IReadOnlyList<IWebElement> list = this.driver.FindElements(byDraggedColumnListPayments);
                if (list[number].Text.Trim().ToLower() == value.Trim().ToLower())
                {
                    this.TESTREPORT.LogSuccess("Verify Dragged column", string.Format("Column -<mark>{0}</mark> Dragged successfully", list[number].Text));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            {
                this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
            }


        }

        public ArrayList ClickOnRandomGroupClaim()
        {
            Thread.Sleep(6000);
            return this.driver.ClickRandomCliamNumber(byGroupColumnsData, 1);
        }


        //public void ClickExpandRandomClaim()
        //{
        //    Random rnd = new Random();
        //    int value = rnd.Next(0, 9);

        //    By byexpandClick = By.XPath("(//a/img[@class='dxGridView_gvCollapsedButton'])[" + value + "]");

        //    this.driver.ClickElementWithJavascript(byexpandClick, " Expand Claim" + value);
        //}


// Expand the Claimant Name and Location Columns after grouping
        public string ClaimantNameAndLocationAfterExpand()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 9);

            By byClaimName = By.XPath("(//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvGroupRow')]/td[2])[" + value + "]");
            string ClaimName = this.driver.GetElementText(byClaimName);
            string name = ClaimName.Split(',')[1];
            By byexpandClick = By.XPath("(//a/img[@class='dxGridView_gvCollapsedButton'])[" + value + "]");
            this.driver.ClickElementWithJavascript(byexpandClick, " Expand Claim" + value);
            Thread.Sleep(3000);
            By byLocation = By.XPath("//td[contains(text(),'Location')]");
            string Location = this.driver.GetElementText(byLocation);
            string locationName = Location.Split(':')[1];
            this.driver.ClickElementWithJavascript(byLocation, "Click on location");    
            return ClaimName + "@" + Location;

        }
        // Verify Accident Location in Claimant Information Page
        public void VerifyAccidentLocation(string AccidentLocation)
        {
            string ActualAccidentLocation = this.driver.GetElementText(byAccidentLocation);
            this.driver.AssertTextMatching(ActualAccidentLocation, AccidentLocation);

        }

        //Verify Sorting for Grouped Columns
        public void VerifySortingOnGroupedColumn()
        {
            //Select 'All' from dropdown list to get all the values 
            IReadOnlyList<IWebElement> list = null;
            this.driver.ClickElement(byClaimInquiryPagesizeDRopdownBtn, "ClaimInquiryPageSize DropdownButton");
            IReadOnlyList<IWebElement> dropdown = this.driver.FindElements(byClaimInquiryPagesizeDropdown);
            dropdown[5].Click();
            Thread.Sleep(6000);
            //Get first 100 count to verify the sorting
            list = driver.FindElements(byGroupColumnsList);

            List<string> data = new List<string>();
            if (list.Count > 1)
            {
                int j = 1;
                int k = 1;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    data.Add(list[i].Text);
                    if (j == 100)
                    {
                        break;
                    }
                    else
                    {
                        j++;
                    }

                }
                data.Sort();
                data.Reverse();
                //Click on Claimant Name Grouped column to sort.                
                this.TESTREPORT.LogInfo("Click on Claimant Name Group Column to Sort");
                this.driver.ClickElement(byGroupColumnForSort, "Sort", 60);
                Thread.Sleep(6000);
                //Get Last 100 count to comapre the sorted data
                list = driver.FindElements(byGroupColumnsList);
                List<string> SortedData = new List<string>();

                for (int i = 0; i <= list.Count; i++)
                {
                    SortedData.Add(list[i].Text);
                    if (k == 100)
                    {
                        break;
                    }
                    else
                    {
                        k++;
                    }
                }

                if (data.SequenceEqual(SortedData))
                {
                    this.TESTREPORT.LogSuccess("Sorting is successfull on Claimant Name Column", String.Format("Climant Names are in sorted order <Mark>{0},{1}</Mark>", data.Count, SortedData.Count));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Sorting is successfull on Claimant Name Column", String.Format("Climant Names are not in sorted order <Mark>{0},{1}</Mark>", data.Count, SortedData.Count));
                }

            }
            else
            {
                this.TESTREPORT.LogInfo("No Records found ");
            }
        }
        public void VerifyDocumentsTab()
        {
            this.TESTREPORT.LogInfo("Verify Documents tab");
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byDocumentsTab))
                this.TESTREPORT.LogSuccess("Verify Documents tab", "Document tab is present");
            else
                this.TESTREPORT.LogFailure("Verify Documents tab", "Document tab is not present", this.SCREENSHOTFILE);

        }

        public void SelectDocuments()
        {

            IWebElement table = driver.FindElement(byDocumentsListTable);
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            if (rows.Count > 1)
            {
                By chkbox = By.XPath("//input[@type='checkbox']");
                this.driver.ClickElement(chkbox, "Checkbox for selecting document");
                this.TESTREPORT.LogInfo("Document selected");
                Thread.Sleep(3000);
                this.driver.ClickElement(byOpenButton, "Open button for downloading document");
                Thread.Sleep(3000);
                this.driver.ClickElement(byOpenButton, "Open button for downloading document");
                Thread.Sleep(5000);
            }
            else
                this.TESTREPORT.LogInfo("No Documents attached ");


        }

        public void VerifyOpenButton()
        {
            Thread.Sleep(1000);

            if (this.driver.IsElementPresent(byOpenButton))
                this.TESTREPORT.LogSuccess("Verify Open Button", "Open Button is present", this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Open Button", "Open Button is not present", this.SCREENSHOTFILE);

        }

        public void VerifyDeselectallButton()
        {
            Thread.Sleep(1000);
            if (this.driver.IsElementPresent(byDeSelectallButton))
                this.TESTREPORT.LogSuccess("Verify DeselectAll Button", "Deselectall Button is present", this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify DeselectAll Button", "Deselectall Button is not present", this.SCREENSHOTFILE);
        }

        public void VerifyCloseWindow()
        {
            Thread.Sleep(1000);
            if (this.driver.IsElementPresent(byCloseWIndowButton))
                this.TESTREPORT.LogSuccess("Verify Close Window Button", "Close Window is present", this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Close Window Button", "Close Window is not present", this.SCREENSHOTFILE);
        }

        public void VerifySortingOnDocumentlist()
        {
            this.driver.WaitElementPresent(byDocumentsListTable);
            IWebElement table = driver.FindElement(byDocumentsListTable);
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            if (rows.Count > 1)
            {
                this.driver.ClickElement(byEntryNumber, "Entry Number Link");
                //getting actual sorted list from page
                IList<IWebElement> coloumnEntryNos = this.driver.FindElements(By.XPath("//table[@class='table table-striped table-hover']//td[2] "));

                var list = coloumnEntryNos.Select(i => i.Text);
                var list1 = list.Select(int.Parse).ToList();
                var sorted = new List<int>();
                sorted.AddRange(list1);
                sorted.Sort();

                if (list1.SequenceEqual(sorted))
                {
                    this.TESTREPORT.LogSuccess("Entry Nos in Order", String.Format("Entry Nos are in sorted correct order <Mark>{0}</Mark>", coloumnEntryNos.Count));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Entry Nos in Order", String.Format("Entry Nos are not in sorted correct order <Mark>{0}</Mark>", coloumnEntryNos.Count));
                }


            }

            else
                this.TESTREPORT.LogInfo("No Documents attached ");




        }

        public void CalculateNetPaidAmount()
        {

            this.TESTREPORT.LogInfo("Check the NetPaid mount");
            string TotalPaid = this.driver.GetElementText(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvFooter')]//td[4]"));
            double x = Convert.ToDouble(TotalPaid);
            string Recoveries = this.driver.GetElementText(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvFooter')]//td[5]"));
            double y = Convert.ToDouble(Recoveries);
            string NetPaid = this.driver.GetElementText(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvFooter')]//td[6]"));
            double z = Convert.ToDouble(NetPaid);
            if ((x + y) == z)
            {
                this.TESTREPORT.LogSuccess("Calculate NetPaid =  Total Paid + Recoveries", "NetPaid Amount matches");
            }
            else
            {
                this.TESTREPORT.LogSuccess("Calculate NetPaid =  Total Paid + Recoveries", string.Format("NetPaid Amount doesnt match", this.SCREENSHOTFILE));
            }

        }


        public void ExpandMedicalExpenseinFinancial()
        {
            this.TESTREPORT.LogInfo("Verify and click Expand button for MedicalExpense");
            Thread.Sleep(2000);

            string value = this.driver.GetElementAttribute(byExpandMedicalExpenseBtnAbsence, "style");
            Thread.Sleep(2000);
            string x = "visibility: hidden;";
            if (value.Equals(x))
            {
                this.TESTREPORT.LogFailure("Verify ExpandMedicalExpense button in Financial Tab", string.Format("Element not present"), this.SCREENSHOTFILE);
            }

            else
            {
                this.driver.ClickElement(byExpandMedicalExpenseBtn, "ExpandMedicalExpense");
                Thread.Sleep(2000);


                if (this.driver.IsElementPresent(byReserveWorksheetsMedicalText))
                {
                    this.TESTREPORT.LogInfo("VerifyReserveWorksheetsMedical");
                    this.TESTREPORT.LogSuccess("Verify ReserveWorksheetsMedical Text", String.Format(" Successfully verified - <Mark>{0}</Mark> text ", "ReserveWorksheetsMedical"));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify ReserveWorksheetsMedical Text", String.Format("Failed to Verify Text"), this.SCREENSHOTFILE);
                }

            }
        }



        //Verify IncurredAmount  in Financial Tab
        public void VerifyIncurredAmount(string IncurredAmount)
        {
            this.TESTREPORT.LogInfo("Verify IncurredAmount  in Financial Tab");
            string ActualIncurredAccount = this.driver.GetElementText(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//tr[contains(@class,'dxgvFooter')]//td[3]"));

            decimal x = Convert.ToDecimal(IncurredAmount);
            decimal y = Convert.ToDecimal(ActualIncurredAccount);
            if (x == y)
            {
                this.TESTREPORT.LogSuccess("verify IncurredAmount", string.Format("Amount:<mark>{0}</mark> matches", x));
            }
            else

            {
                this.TESTREPORT.LogFailure("verify IncurredAmount", string.Format("Amount not matched", this.SCREENSHOTFILE));
            }

        }

        public void VerifyBreakdownbyLossLineTableHeaders(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrfinancial1_0_gridfinancial_0_DXMainTable']//th"));
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in BreakdownbyLossLine Table", string.Format("Header contains:<mark>{0}</mark>", item.Text));
                    break;
                }


            }
        }
        public void BreakdownbyLosslineResultscount()
        {
            this.TESTREPORT.LogInfo("Verify BreakdownbyLosslineResultscount");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byBreakdownbylossLineReslts);
            if (list.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify BreakdownbyLossline data results", String.Format(" Table -<mark>{0}</mark> data is displayed succesfully", "BreakdownbyLosslineResults"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify BreakdownbyLossline data results", String.Format("Table Data not displayed ", this.SCREENSHOTFILE));
            }

        }
        public void FinancialtabResultscount()
        {
            this.TESTREPORT.LogInfo("Verify FinancialtabResultscount");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byFinancialtabResults);
            if (list.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify Financialtab data results", String.Format(" Table -<mark>{0}</mark> data is displayed succesfully", "FinancialtabResults"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Financialtab data results", String.Format("Table Data not displayed ", this.SCREENSHOTFILE));
            }

        }

        // Veriify Payment Columns
        public void VerifyPaymentsTableHeaders(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byColumnHeadersPayments);
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in Payments Table", string.Format("Header contains:<mark>{0}</mark>", item.Text));
                    break;
                }


            }
        }
        //Verify Payments tab grid results Count
        public void PaymentGridResultsCount()
        {
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byPaymentGridCount);
            if (list.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify Payments Grid results", String.Format(" Table - <mark>{0}</mark> rows are displayed succesfully", "PaymentsResults",list.Count()));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Payments Grid results", String.Format("No Records to display ", this.SCREENSHOTFILE));
            }

        }

        public void DragTheColumnHeaderPayments(string value)
        {
            this.driver.WaitElementPresent(byColumnHeadersPayments);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byColumnHeadersPayments);
            IWebElement e2 = this.driver.FindElement(byDraggedColumnListInSpacePayments);
            foreach (var WebItem in list)
            {

                if (WebItem.Text.ToLower().Trim().Equals(value.ToLower().Trim()))
                {
                    this.driver.DragDrop(WebItem, e2);
                    break;
                }

            }
        }
        

        public void VerifyDocumentsCountOnSearch(string value)
        {
            Thread.Sleep(2000);
            int count = 0;
            IReadOnlyList<IWebElement> column = this.driver.FindElements(byEntryNameResultcolumn);
            ArrayList a = new ArrayList();
            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    if (item.Text.ToLower().Contains(value.ToLower()))
                    {
                        this.TESTREPORT.LogSuccess("Verify Documents Entry Name Entered in search", string.Format("Entered value <Mark>{0}</Mark> in search matches with the Table Results", item.Text.ToLower()));
                        break;
                    }
                    else
                        this.TESTREPORT.LogFailure("Verify Documents Entry Name Entered in search", string.Format("Entered value <Mark>{0}</Mark> didn't match with the Table Results", item.Text.ToLower()), this.SCREENSHOTFILE);
                    Thread.Sleep(2000);
                }
            }
            else
                this.TESTREPORT.LogFailure("Verify filtered results", string.Format("There is no data to display"), this.SCREENSHOTFILE);

        }

        public void VerifyAndClickonAccidentTab()
        {
            if (this.driver.IsElementPresent(byAccidentTab))
            {
                this.driver.ClickElement(byAccidentTab, "Accident Tab");
                if (this.driver.IsElementPresent(byAccidentinformationLbl))
                {
                    this.TESTREPORT.LogSuccess("Verify and click Accident Tab", "Accident tab is visble and successfully clicked", this.SCREENSHOTFILE);
                }
            }
            else
                this.TESTREPORT.LogFailure("Verify Accident Tab", "Accident Tab", this.SCREENSHOTFILE);

        }

        public void VerifyAccidentInformationIsDisplayed()
        {
            this.driver.WaitElementPresent(byAccidentinformationLbl);
            if (this.driver.IsElementPresent(byAccidentinformationLbl))
                this.TESTREPORT.LogSuccess("Verify Accident Information Is Displayed", string.Format("<Mark>Accident Information Is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Accident Information Is Displayed", string.Format("<Mark>Accident Information Is Displayed</Mark>"), this.SCREENSHOTFILE);
        }
        public void VerifyAccidentDescriptionIsDisplayed()
        {
            this.driver.WaitElementPresent(byAccidentDescriptionLbl);
            if (this.driver.IsElementPresent(byAccidentDescriptionLbl))
                this.TESTREPORT.LogSuccess("Verify Accident Description Is Displayed", string.Format("<Mark>Accident Description Is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Accident Description Is Displayed", string.Format("<Mark>Accident Description Is Displayed</Mark>"), this.SCREENSHOTFILE);
        }
    
        public void VerifyVehicleListIsDisplayed()
            {
            this.driver.WaitElementPresent(byAccidentVehicleListLbl);
            if (this.driver.IsElementPresent(byAccidentVehicleListLbl))
            this.TESTREPORT.LogSuccess("Verify Accident Vehicle Is Displayed", string.Format("<Mark>Accident Vehicle Is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
            this.TESTREPORT.LogFailure("Verify Accident Vehicle Is Displayed", string.Format("<Mark>Accident Vehicle Is Displayed</Mark>"), this.SCREENSHOTFILE);
            }

        public void VerifyDataInVehicleList()
            {
            this.driver.WaitElementPresent(byVehiclelisttable);
            IWebElement VehicleTable = this.driver.FindElement(byVehiclelisttable);
            IList<IWebElement> rows = VehicleTable.FindElements(By.TagName("tr"));
            if (rows.Count> 1)
                this.TESTREPORT.LogSuccess("Verify VehicleList Data",string.Format("VehicleList Data is present:<Mark>{0}</Mark>",rows.Count.ToString()));
            
            else
               this.TESTREPORT.LogInfo("No Data Found",this.SCREENSHOTFILE); 
            

            }

        public void VerifyAndClickonLossLineTab()
        {
            if(this.driver.IsElementPresent(byLossLineTab))
            {
                this.driver.ClickElement(byLossLineTab,"Loss Line Tab");
                if(this.driver.IsElementPresent(bylosslineDataTable))
                this.TESTREPORT.LogSuccess("Verify and click Lossline Tab","Lossline tab is visble and successfully clicked",this.SCREENSHOTFILE);
            }
            else
                this.TESTREPORT.LogFailure("Verify Lossline Tab","Lossline Tab",this.SCREENSHOTFILE);

        }

        public void VerifyLossLineTableHeaders(string value)
        {
            this.driver.WaitElementPresent(bylosslineDataTable);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(bylosslineDataTable);
            bool headerfound=false;
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in LossLine Table", string.Format("Header contains:<mark>{0}</mark>", value));
                    headerfound=true;
                    break;
                }
            }
            if(!headerfound)
                this.TESTREPORT.LogFailure("verify TableHeaders in LossLine Table", string.Format("Header not contains:<mark>{0}</mark>", value));
        }

        public void VerifyLossLineTableData()
            {
            
             IWebElement VehicleTable = this.driver.FindElement(byVehiclelisttable);
            IList<IWebElement> rows = VehicleTable.FindElements(By.TagName("tr"));
            if (rows.Count> 1)
                this.TESTREPORT.LogSuccess("Verify LossLine Table Data",string.Format("LossLine Table data is present:<Mark>{0}</Mark>",rows.Count.ToString()));
            
            else
               this.TESTREPORT.LogFailure("No Data Found",this.SCREENSHOTFILE); 


            }

        public void VerifyLosslineInformationIsDisplayed()
        {
            this.driver.WaitElementPresent(byLossLineDetailinformationLbl);
            if(this.driver.IsElementPresent(byLossLineDetailinformationLbl))
            this.TESTREPORT.LogSuccess("Verify Lossline Information Is Displayed",string.Format("<Mark>Lossline Information is Displayed</Mark>"),this.SCREENSHOTFILE);
            else
            this.TESTREPORT.LogFailure("Verify Lossline Information Is Displayed", "<Mark>Lossline Information is not Displayed</Mark>", this.SCREENSHOTFILE);
        }
        public void VerifyClaimantInformationIsDisplayed()
            {
             if(this.driver.IsElementPresent(byClaimantDetailInformationLbl))
            this.TESTREPORT.LogSuccess("Verify Claimant Information Is Displayed", string.Format("<Mark>Claimant Information is Displayed </Mark>"), this.SCREENSHOTFILE);
            else
            this.TESTREPORT.LogFailure("Verify Claimant Information Is Displayed", string.Format("<Mark>Claimant Information is not Displayed</Mark>"),this.SCREENSHOTFILE);  
}

        public void VerifyOtherLossLineIsDisplayed()
            {
            if(this.driver.IsElementPresent(byOtherLosslineLbl))
            this.TESTREPORT.LogSuccess("Verify Other LossLine Is Displayed", string.Format("<Mark>Other LossLine is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
            this.TESTREPORT.LogFailure("Verify Other LossLine Is Displayed", string.Format("<Mark>Other LossLine is not Displayed</Mark>"), this.SCREENSHOTFILE);
            } 

         public void VerifyOtherClaimantNameIsDisplayed()
            {
            if(this.driver.IsElementPresent(byOtherClaimantLbl))
            this.TESTREPORT.LogSuccess("Verify Other Claimant Name Is Displayed", string.Format("<Mark>Accident Vehicle is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
            this.TESTREPORT.LogFailure("Verify Other Claimant Name Is Displayed", string.Format("<Mark>Accident Vehicle is not Displayed</Mark>"), this.SCREENSHOTFILE);
            } 

        public void CLickLossLineExpand()
            {
            this.driver.ClickElement(byExpand,"Expand button");

            }

        public void EnterDocumentSearchText(string searchtext)
        {
            this.driver.WaitElementPresent(byDocumentSearchText);
             this.driver.SendKeysToElementClearFirst(byDocumentSearchText, searchtext, "Document Search Text");
        }

        public void SearchByClaimantNameInLossLineTab(string claimantNameText)
        {
            this.driver.WaitElementPresent(byClaimantNameText);
            this.driver.SendKeysToElementClearFirst(byClaimantNameText, claimantNameText, "ClaimantName Search Text");
        }

        public void VerifyandClickClearButton(string claimantNameText)
        {
            string claimantNameText1 = "";
            this.driver.WaitElementPresent(byClearButton);
            this.driver.ClickElement(byClearButton, "Clear Button");
            claimantNameText1=this.driver.GetElementAttribute(byClaimantNameText,"value");
            if (string.IsNullOrEmpty(claimantNameText1))
                this.TESTREPORT.LogSuccess("Verify Clear Button", string.Format("Data Cleared,No Text-<Mark>{0}</Mark> found", claimantNameText));
            else
                this.TESTREPORT.LogFailure("Verify Clear Button", string.Format("Data not cleared,Text found-<Mark>{0}</Mark> found", claimantNameText1),this.SCREENSHOTFILE);

        }


        public void PaymentsDraggedColumnList(int number, string value)
        {
            Thread.Sleep(6000);
            try
            {
                
                IReadOnlyList<IWebElement> list = this.driver.FindElements(byDraggedColumnListPayments);
                if (list[number].Text.Trim().ToLower() == value.Trim().ToLower())
                {
                    this.TESTREPORT.LogSuccess("Verify Dragged column", string.Format("Column -<mark>{0}</mark> Dragged successfully", list[number].Text));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            {
                this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
            }


        }

        public void LossLineAfterExpand()
        {
            Random rnd = new Random();
            int rowCount = this.driver.FindElements(byPaymentsRowCount).Count();
            int value = rnd.Next(0, rowCount);
            string LossLine, name;
            if (rowCount>0)
            {
                By byGroupLossLine = By.XPath("(//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXMainTable']//tr[contains(@class,'dxgvGroupRow')]/td[2])[" + value + "]");
                LossLine = this.driver.GetElementText(byGroupLossLine);
                name = LossLine.Split(':')[1];
                By byExpandClick = By.XPath("(//a/img[@class='dxGridView_gvCollapsedButton'])[" + value + "]");
                this.driver.ClickElementWithJavascript(byExpandClick, " Expand LossLine" + value);
                Thread.Sleep(3000);
                By byExpand = By.XPath("//td[@class='dxgvDetailButton dxgv']//a");
                
                this.driver.ClickElementWithJavascript(byExpand, "Click on Expand");
                Thread.Sleep(2000);
                string ActualLossLine = this.driver.GetElementText(byPaymentLossLine);
                this.driver.AssertTextMatching(ActualLossLine,name);

               
            }

            else
            {
                this.TESTREPORT.LogFailure("Verify Losss line ", String.Format("No records Found to Verify"), this.SCREENSHOTFILE);
            }

            

        }

        public void ExpandLossLineinPayments()
        {
            this.TESTREPORT.LogInfo("Verify and click Expand button for LossLine");
            Thread.Sleep(2000);
            By byNodata = By.XPath("//div[contains(text(),'There are no available payments for this claim')]");
            if (!this.driver.IsElementPresent(byNodata))
            {
                Thread.Sleep(5000);
                this.driver.WaitElementPresent(byExpandLossLineBtn);
                if (this.driver.IsWebElementDisplayed(byExpandLossLineBtn))
                {
                    this.driver.ClickElement(byExpandLossLineBtn, "ExpandLossLine");
                    Thread.Sleep(10000);

                    this.TESTREPORT.LogInfo("Verify Check Detail Information");
                    this.driver.WaitElementPresent(byCheckDetailInformationText);
                    if (this.driver.IsElementPresent(byCheckDetailInformationText))
                    {
                        this.TESTREPORT.LogSuccess("Verify CheckDetailInformation", string.Format("successfully verified : <mark>{0}</mark>", "CheckDetailInformation"));
                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify CheckDetailInformation", "No text Found", this.SCREENSHOTFILE);
                    }

                    this.TESTREPORT.LogInfo("Verify Loss Information");
                    this.driver.WaitElementPresent(byLossInformationText);
                    if (this.driver.IsElementPresent(byLossInformationText))
                    {
                        this.TESTREPORT.LogSuccess("Verify LossInformation", string.Format("successfully verified:<mark>{0}</mark>", "LossInformation"));
                    }

                    else
                    {
                        this.TESTREPORT.LogFailure("Verify LossInformation", "No text Found", this.SCREENSHOTFILE);
                    }
                }
                else
                    this.TESTREPORT.LogFailure("Verify ExpandLossLine button in Payments Tab", string.Format("Element not present", this.SCREENSHOTFILE));
            }
            else
                this.TESTREPORT.LogInfo(string.Format("<Mark>No Data to display</Mark>"));
        }




        public void VerifyPaymentsTabTableHeaders(string value)
        {
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXMainTable']//th[contains(@class,'dxgvHeader')]"));
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in BreakdownbyLossLine Table", string.Format("Header contains:<mark>{0}</mark>", item.Text));
                    break;
                }


            }
        }

        public void clickExpandButtoninPaymentsTab()
        {
            Thread.Sleep(5000);
            this.driver.WaitElementPresent(byExpandLossLineBtn);

            this.driver.ClickElement(byExpandLossLineBtn, "Expand the data");

        }


        public void VerifyPaymentDetail()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("Verify Payment Detail in Payments Tab");
            if (this.driver.IsElementPresent(byPaymentDetailTab))
            {
                this.TESTREPORT.LogSuccess("Verify PaymentDetail", string.Format("Successfully verified : <mark>{0}</mark>", "PaymentDetail"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify PaymentDetail", "PaymentDetail not found", this.SCREENSHOTFILE);
            }

        }

        public void VerifyExplanationofBenefits()
        {
            this.TESTREPORT.LogInfo("Verify Explanation of Benefits in Payments Tab");
            if (this.driver.IsElementPresent(byExplanationofBenefitsTab))
            {
                this.TESTREPORT.LogSuccess("Verify ExplanationofBenefits", string.Format("Successfully verified : <mark>{0}</mark>", "ExplanationofBenefits"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ExplanationofBenefits", "ExplanationofBenefits not found", this.SCREENSHOTFILE);
            }

        }

        public void VerifyInvoiceSummary()
        {
            this.TESTREPORT.LogInfo("Verify InvoiceSummary in Payments Tab");
            if (this.driver.IsElementPresent(byInvoiceSummaryTab))
            {
                this.TESTREPORT.LogSuccess("Verify InvoiceSummary", string.Format("Successfully verified : <mark>{0}</mark>", "InvoiceSummary"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify InvoiceSummary", "InvoiceSummary not found", this.SCREENSHOTFILE);
            }

        }


        public string VerifyPaymentAmount()
        {
            Thread.Sleep(2000);
            By element = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[7]");
            this.driver.WaitElementPresent(element);
            string value = this.driver.GetElementText(element);
            Thread.Sleep(2000);
            string x = this.driver.GetElementText(byPaymentAmountinPaymentDetail);
            string z = "$" + x;
            Thread.Sleep(2000);
            if (value.Equals(z))
            {
                this.TESTREPORT.LogSuccess("Verify PaymentAmount in PaymentDetail", string.Format("Successfully verified : <mark>{0}</mark>", value));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify PaymentAmount in PaymentDetail", "Amount not matched", this.SCREENSHOTFILE);
            }
            return value;
        }

        public void ClickExplanationofBenefits()
        {
            this.driver.ClickElement(byExplanationofBenefitsTab, "ExplanationofBenefits");
            Thread.Sleep(2000);
        }

        public string VerifyInvoiceAmount()
        {
            string value = this.driver.GetElementText(By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpayment1_0_gridpayments_0_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[6]"));
            Thread.Sleep(2000);
            string x = this.driver.GetElementText(byinvoiceAmountinExplanationofBenefits);
            string z = "$" + x;
            if (value.Equals(z))
            {
                this.TESTREPORT.LogSuccess("Verify InvoiceAmount in ExplanationofBenefits", string.Format("Successfully verified : <mark>{0}</mark>", value));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify InvoiceAmount in ExplanationofBenefits", "Amount not matched", this.SCREENSHOTFILE);
            }
            return value;

        }

        public void ClickInvoiceSummary()
        {
            this.driver.ClickElement(byInvoiceSummaryTab, "InvoiceSummary");
            Thread.Sleep(2000);
        }


        public void VerifySavingsandCharges()
        {
            this.TESTREPORT.LogInfo("Verify SavingsandCharges in InvoiceSummary");
            if (this.driver.IsElementPresent(bySavingsandChargesText))
            {
                this.TESTREPORT.LogSuccess("Verify SavingsandCharges", string.Format("Successfully verified : <mark>{0}</mark>", "SavingsandCharges"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify SavingsandCharges", "SavingsandCharges not found", this.SCREENSHOTFILE);
            }

        }

        public void VerifySavingsDetail()
        {
            this.TESTREPORT.LogInfo("Verify SavingsDetail in InvoiceSummary");
            if (this.driver.IsElementPresent(bySavingsDetailText))
            {
                this.TESTREPORT.LogSuccess("Verify SavingsDetail", string.Format("Successfully verified : <mark>{0}</mark>", "SavingsDetail"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify SavingsDetail", "SavingsDetail not found", this.SCREENSHOTFILE);
            }

        }

        public void VerifyPaymentAmtinInvoiceSummary(string x)
        {
            Thread.Sleep(2000);
            string PaymentAmount = this.driver.GetElementText(byPaymentAmtinInvoiceSummary);
            string z = "$" + PaymentAmount;
            if (z.Equals(x))
            {
                this.TESTREPORT.LogSuccess("Verify PaymentAmount in InvoiceSummary", string.Format("Successfully verified : <mark>{0}</mark>", x));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify PaymentAmount in InvoiceSummary", "Amount not matches", this.SCREENSHOTFILE);
            }
        }

        public void VerifyInvoiceAmtinInvoiceSummary(string y)
        {
            Thread.Sleep(2000);
            string InvoiceAmount = this.driver.GetElementText(byInvoiceAmtinInvoiceSummary);
            string z = "$" + InvoiceAmount;
            if (z.Equals(y))
            {
                this.TESTREPORT.LogSuccess("Verify InvoiceAmount in InvoiceSummary", string.Format("Successfully verified : <mark>{0}</mark>", y));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify InvoiceAmount in InvoiceSummary", "Amount not matches", this.SCREENSHOTFILE);
            }
            //Thread.Sleep(10000);
        }

        public void VerifyClaimantNameinCLaimInquiry(string ClaimantName)
        {
            string ActualAccountName = this.driver.GetElementText(byClaimInformationClaimantName);

            string[] words = ClaimantName.Split(',');
            foreach (var item in words)
            {
                if (ActualAccountName.Contains(item))
                {
                    TESTREPORT.LogSuccess("Text Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", ActualAccountName, ClaimantName));
                    break;
                }
                else
                {
                    this.TESTREPORT.LogFailure("Text not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", ActualAccountName, ClaimantName));
                }
            }
        }

        public void verifyAccidentinWorkerAccident()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("verify Accident in WorkerAccident");
            if (this.driver.IsElementPresent(byAccidentTabinWorkerAccident))
            {
                this.TESTREPORT.LogSuccess("verify Accident in WorkerAccident", string.Format("Successfully verified : <mark>{0}</mark>", "Accident"));
            }
            else
            {
                this.TESTREPORT.LogFailure("verify Accident in WorkerAccident", string.Format("Element not found : <mark>{0}</mark>", "Accident", this.SCREENSHOTFILE));
            }
        }


        public void verifyMedicalSummaryinWorkerAccident()
        {

            this.TESTREPORT.LogInfo("verify Medicalsummary in WorkerAccident");
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byMedicalsummaryinWorkerAccident))
            {
                this.TESTREPORT.LogSuccess("verify Medicalsummary in WorkerAccident", string.Format("Successfully verified : <mark>{0}</mark>", "Medicalsummary"));
            }
            else
            {
                this.TESTREPORT.LogFailure("verify v in WorkerAccident", string.Format("Element not found : <mark>{0}</mark>", "Medicalsummary", this.SCREENSHOTFILE));
            }
        }

        public void verifyMedicalsummaryContinWorkerAccident()
        {
            this.TESTREPORT.LogInfo("verify MedicalsummaryCont in WorkerAccident");
            Thread.Sleep(2000);
            if (this.driver.IsElementPresent(byMedicalsummaryContinWorkerAccident))
            {
                this.TESTREPORT.LogSuccess("verify MedicalsummaryCont in WorkerAccident", string.Format("Successfully verified : <mark>{0}</mark>", "MedicalsummaryCont"));
            }
            else
            {
                this.TESTREPORT.LogFailure("verify MedicalsummaryCont in WorkerAccident", string.Format("Element not found : <mark>{0}</mark>", "MedicalsummaryCont", this.SCREENSHOTFILE));
            }
        }

        //Payments table results count
        public int PaymentsTabResultscount()
        {
            this.TESTREPORT.LogInfo("Verify PaymentsTabResultscount");
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byPaymentsTabResultsCount);
            if (list.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify Payments data results", String.Format(" Table -<mark>{0}</mark> data is displayed succesfully", "Payments"));
            }
            else
            {
                this.TESTREPORT.LogInfo(String.Format("<Mark>There are no available payments for this claim</Mark>", this.SCREENSHOTFILE));
            }
            return list.Count;
        }


        public void VerifyandClickWorkerAccident()
        {
            if (this.driver.IsElementPresent(byWorkerAccidentTab))
            {
                this.TESTREPORT.LogSuccess("Verify WorkerAccident", string.Format("Successfully verified : <mark>{0}</mark>", "WorkerAccident"));
                this.TESTREPORT.LogInfo("Click on WorkerAccident");
                this.driver.ClickElement(byWorkerAccidentTab, "Worker Accident");
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify WorkerAccident", "Element not Found", this.SCREENSHOTFILE);
            }
        }

        public void VerifyAndClickLogNotes()
        {
            this.driver.WaitElementPresent(byLogNotesTab);
            if (this.driver.IsElementPresent(byLogNotesTab))
            {
                this.driver.ClickElement(byLogNotesTab, "Log Notes Tab");
                if (this.driver.IsElementPresent(byShortNotesTab))
                {
                    this.TESTREPORT.LogSuccess("Verify and click Log Notes Tab", "Log Notes Tab is visble and successfully clicked", this.SCREENSHOTFILE);
                }
            }
            else
                this.TESTREPORT.LogFailure("Verify Log Notes Tab", "Log Notes Tab", this.SCREENSHOTFILE);

        }

        public void VerifyShortNotesIsDisplayed()
        {
            this.driver.WaitElementPresent(byShortNotesTab);
            if (this.driver.IsElementPresent(byShortNotesTab))
                this.TESTREPORT.LogSuccess("Verify ShortNotes Tab Is Displayed", string.Format("<Mark>ShortNotes Tab is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify ShortNotes Tab Is Displayed", string.Format("<Mark>ShortNotes Tab is not Displayed</Mark>"), this.SCREENSHOTFILE);
        }

        public void VerifyHideNotesIsDisplayed()
        {
            this.driver.WaitElementPresent(byHideNotesTab);
            if (this.driver.IsElementPresent(byHideNotesTab))
                this.TESTREPORT.LogSuccess("Verify HideNotes Tab is Displayed", string.Format("<Mark>HideNotes Tab is Displayed</Mark>"), this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify HideNotes Tab is not Displayed", string.Format("<Mark>HideNotes Tab is not Displayed</Mark>"), this.SCREENSHOTFILE);
        }

        public void VerifyLogNotesTableHeaders(string value)
        {
            this.driver.WaitElementPresent(bylogNotesDataTable);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(bylogNotesDataTable);
            bool headerfound = false;
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in LogNotes Table", string.Format("Header contains:<mark>{0}</mark>", value));
                    headerfound = true;
                    break;
                }
            }
            if (!headerfound)
                this.TESTREPORT.LogFailure("verify TableHeaders in LogNotes Table", string.Format("Header not contains:<mark>{0}</mark>", value));
        }
        
       
        //Verify LogNotes tab grid results Count
        public int LogNotesGridResultsCount()
        {
            Thread.Sleep(6000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byLogNotesGridCount);
            if (list.Count != 0)
            {
                this.TESTREPORT.LogSuccess("Verify LogNotes Table results", String.Format(" Table - <mark>{0}</mark> rows are displayed succesfully", "PaymentsResults", list.Count()));
            }
            else
            {
                this.TESTREPORT.LogInfo(String.Format("There are no available log notes for this claim"), this.SCREENSHOTFILE);
            }
            return list.Count;
        }

        //Dragged Column Header Lognotes
        public void DragTheColumnHeaderLogNotes(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//th[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_col')]"));
            IWebElement e2 = this.driver.FindElement(byDraggedColumnListInSpaceLogNotes);
            foreach (var WebItem in list)
            {

                if (WebItem.Text.ToLower().Trim().Equals(value.ToLower().Trim()))
                {
                    this.driver.DragDrop(WebItem, e2);
                    break;
                }

            }
        }

        //Verify the Dragged Column

        public void LogNotesDraggedColumnList(int number, string value)
        {
            Thread.Sleep(6000);
            try
            {

                IReadOnlyList<IWebElement> list = this.driver.FindElements(byDraggedColumnListLogNotes);
                if (list[number].Text.Trim().ToLower() == value.Trim().ToLower())
                {
                    this.TESTREPORT.LogSuccess("Verify Dragged column", string.Format("Column -<mark>{0}</mark> Dragged successfully", list[number].Text));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            {
                this.TESTREPORT.LogFailure("Verify Dragged column", string.Format("Falied to drag the Columns"), this.SCREENSHOTFILE);
            }


        }

        //Log Notes after Expand
        public void LogNotesAfterExpand()
        {

            int rowCount = this.driver.FindElements(By.XPath("//tr[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXGroupRow')]")).Count();

            string LogNotes, name;
            //string name = null;

            if (rowCount > 0)
            {

                By byGroupLogNotes = By.XPath("(//table[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXMainTable')]//tr[contains(@class,'dxgvGroupRow')]/td[2])[1]");
                LogNotes = this.driver.GetElementText(byGroupLogNotes);
                name = LogNotes.Split(':')[1].Trim();
                By byExpandClick = By.XPath("(//a/img[@class='dxGridView_gvCollapsedButton'])[1]");

                this.driver.ClickElementWithJavascript(byExpandClick, "Expand LogNotes");
                Thread.Sleep(3000);
                By byExpand = By.XPath("//td[@class='dxgvDetailButton dxgv']//a");

                this.driver.ClickElementWithJavascript(byExpand, "Click on Expand");
                Thread.Sleep(2000);

                this.TESTREPORT.LogInfo(String.Format("Group the columns by Catogery <Mark>{0}</Mark>", name));


            }


        }

        public bool ExpandButtoninPaymentsTabIsDisplayed()
        {
            Thread.Sleep(5000);
           return this.driver.IsWebElementDisplayed(byExpandLossLineBtn);
        }

        public void clickCollapseButtoninPaymentsTab()
        {
            Thread.Sleep(5000);
            this.driver.WaitElementPresent(byExpandLossLineBtnAbsence);

            this.driver.ClickElement(byExpandLossLineBtnAbsence, "Collapse the data");

        }
    }

    #endregion




}


