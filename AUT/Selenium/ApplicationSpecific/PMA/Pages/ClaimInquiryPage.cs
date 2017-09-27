using AUT.Selenium.CommonReUsablePages;
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

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class ClaimInquiry : AbstractTemplatePage
    {
        #region UI Objects
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
        private By byDragaColoumnheaderSpace = By.XPath("//div[@id='MainContent_ASPxPageControl1_gridresult_grouppanel']");
        private By bysecondcolumnheader = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@id,'MainContent_ASPxPageControl1_gridresult_DXHeadersRow0')]//th[2]");
        private By byClaimInquiryResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]"); 
        private By bythirdcolumnheader = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@id,'MainContent_ASPxPageControl1_gridresult_DXHeadersRow0')]/th[3]");
        private By byLossLineSummaryResultsTable = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridlossline_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byLocationIconResultsTable = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        //private By byLocationField = By.Id("MainContent_ASPxRoundPanel1_pnlContent_txtlocation_I");
        private By byLocationField = By.XPath("//label[contains(text(),'Location : ')]/../..//input[@type='text']");
        private By byLocationCodeFieldColumn = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[1]");
        private By byClaimantNameResultcolumn = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[2]");
        private By byAccidentTab = By.LinkText("Accident");
        private By byAccidentInformationText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalaccident1_0_ASPxLabel1_0");
        private By byLossLineTab = By.LinkText("Loss Line");
        private By byLossLineDescriptionText = By.LinkText("Loss Line Description");
        private By byClaimFinancialTotalsText = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrpalfinancial1_0_Label1_0");

        private By byPaymentStatusText = By.LinkText("Payment Status");
        private By byNote = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_DXMainTable']//th[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrnotes1_0_gridNotes_0_col0']");
        private By byClaimantName = By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXFREditorcol1']//input[@id='MainContent_ASPxPageControl1_gridresult_DXFREditorcol1_I']");

        #endregion



        #region Public Methods

        //Click AccidentDateRange Begin ClearBtn in Calendar
        public void ClickAccidentDateRangeBeginClearBtn()

        {
            this.driver.ClickElement(byAccidentDateRangeBeginClearBtn, "AccidentDateRangeBeginClearBtn");
        }


        //Click AccidentTab in claimInformation
        public void ClickAccidentTab()

        {
            this.driver.ClickElement(byAccidentTab, "AccidentTab");
        }

        //Click LossLineTab in claimInformation
        public void ClickLossLineTab()

        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byLossLineTab, "LossLineTab");
        }

        //Click FinancialTab in claimInformation
        public void ClickFinancialTab()

        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byFinancialTab, "FinancialTab");
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
                this.TESTREPORT.LogSuccess("Verify AccidentInformation", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "AccidentInformation Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify AccidentInformation", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
            }
        }


        //Verify Claim FinancialTotal in the Financial Tab
        public void VerifyClaimFinancialTotallink()
        {
            Thread.Sleep(2000);
            bool flag = this.driver.IsElementPresent(byClaimFinancialTotalsText);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify ClaimFinancialTotal", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "ClaimFinancialTotal Link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify ClaimFinancialTotal", String.Format("Failed to Verify Link"), this.SCREENSHOTFILE);
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
        public string EnterClaimNumber(String ClaimNumbervalue)

        {
            this.driver.SendKeysToElement(byClaimNumber, ClaimNumbervalue, "Claim Number");
            Thread.Sleep(2000);
            string str = this.driver.GetElementAttribute(byClaimNumber,"value");
            return str;
        }

        public void VerifyClaimNumber(string value1)
        {
          string value =  this.driver.GetElementAttribute(byClaimNumber, "value");
            if(value.Length != value1.Length)
            {
                this.TESTREPORT.LogSuccess("To verify the ClaimNumber field after Reset", "Field set to empty");
            }
            else
            {
                this.TESTREPORT.LogFailure ("To verify the ClaimNumber field after Reset", "Field notset to empty");
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
            a.SendKeys(Keys.Down).Build().Perform();
            a.SendKeys(Keys.Down).Build().Perform();
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
            this.driver.SendKeysToElement(byIncurredfrom, IncurredTovalue, "Incurred to");
        }

        public void EnterAccidentDateRangeBegin(String AccidentDateRangeBeginFieldvalue)

        {
            this.driver.SendKeysToElement(byAccidentDateRangeBeginField, AccidentDateRangeBeginFieldvalue, "AccidentDateRangeBeginField");
        }

        public void EnterAccidentDateRangeEnd(String AccidentDateRangeEndFieldvalue)

        {
            this.driver.SendKeysToElement(byAccidentDateRangeEndField, AccidentDateRangeEndFieldvalue, "AccidentDateRangeEndField");
        }

        public void EnterReportDateRangeBegin(String ReportDateRangeBeginFieldvalue)

        {
            this.driver.SendKeysToElement(byReportDateRangeBeginField, ReportDateRangeBeginFieldvalue, "ReportDateRangeBeginField");
        }

        public void EnterReportDateRangeEnd(String ReportDateRangeEndFieldvalue)

        {
            this.driver.SendKeysToElement(byReportDateRangeBeginField, ReportDateRangeEndFieldvalue, "ReportDateRangeEndField");
        }

        public void EnterActivityDateRangeBegin(String ActivityDateRangeBeginFieldvalue)

        {
            this.driver.SendKeysToElement(byActivityDateRangeBeginField, ActivityDateRangeBeginFieldvalue, "ActivityDateRangeBeginField");
        }

        public void EnterActivityDateRangeEnd(String ActivityDateRangeEndFieldvalue)

        {
            this.driver.SendKeysToElement(byActivityDateRangeEndField, ActivityDateRangeEndFieldvalue, "ActivityDateRangeEndField");
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
            string mainWindow = this.driver.GetCurrentWindowHandles();
            this.driver.SwitchToChildWindow();
            //Verify the Page title for the Documents 
            VerifyPageTitle(value);
            this.driver.CloseChildWindow();
            this.driver.SwitchToParentWindow(mainWindow);
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
            IReadOnlyList< IWebElement> list = this.driver.FindElements(bythirdcolumnheader);
            IWebElement e2 = this.driver.FindElement(byDragaColoumnheaderSpace);
            foreach (var WebItem in list)
            {
                if(WebItem.Text.ToLower().Equals(value.ToLower()))
                {
                    this.driver.DragDrop(WebItem, e2);
                    break;
                }
                    
            }

            
        }

        public void VerifyLossLineSummaryResultsCount()
        {
            IReadOnlyList<IWebElement> rows = this.driver.FindElements(byLossLineSummaryResultsTable);
            if(rows.Count!=0)
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
                this.TESTREPORT.LogFailure("Verify filtered results",string.Format("There is no data to display"),this.SCREENSHOTFILE);
            }
        }

        public void VerifyTotalIncurredTableValue(float value)
        {
            //string value1 = this.driver.GetElementText(byLocationCodeField);
            Thread.Sleep(3000);
            IReadOnlyList<IWebElement> column = this.driver.FindElements(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[contains(@class,'dxgvDataRow')]//td[9]"));

            if (column.Count != 0)
            {
                foreach (var item in column)
                {
                    //string value = this.driver.GetElementText(item);                    
                    if (item.Text.LongCount)
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

        public void EnterClaimantName(string ClaimantName)
        {
            if (ClaimantName.Contains("L"))
            {
                this.driver.SendKeysToElementClearFirst(byClaimantName, ClaimantName, "ClaimantName");
            }
            else
            {
                this.driver.SendKeysToElementClearFirst(byClaimantName, "w", "ClaimantName");
            }
            
        }


        public ArrayList VerifyClaimantNameColumn(string value)
        {
            Thread.Sleep(2000);
            int count = 0;
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
                      IWebElement ele= this.driver.FindElement(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[@id='MainContent_ASPxPageControl1_gridresult_DXDataRow0']/td[2]"));
                        string text=ele.Text;
                        IWebElement ele1 = this.driver.FindElement(By.XPath("//table[@id='MainContent_ASPxPageControl1_gridresult_DXMainTable']//tr[@id='MainContent_ASPxPageControl1_gridresult_DXDataRow0']/td[3]"));
                        string text1 = ele1.Text;
                        ele1.Click();
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




        #endregion

    }
}
