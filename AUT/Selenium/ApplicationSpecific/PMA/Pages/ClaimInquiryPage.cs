using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private By byLocationIcon= By.Id("MainContent_ASPxRoundPanel1_pnlContent_btnlocationlookupImg");
        private By bylocationCodeTable = By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@id,'gridlocation_DXDataRow')]");
        private By byGeneralTab = By.LinkText("General");
        private By byWorkerAccidentTab =  By.LinkText("Worker-Accident");
        private By byFinancialTab = By.LinkText("Financial");
        private By byPaymentsTab = By.LinkText("Payments");
        private By byDiaryTab = By.LinkText("Diary");
        private By byLogNotesTab = By.LinkText("Log Notes");
        private By byDocumentsTab = By.LinkText("Documents");
        private By byWagesText = By.XPath("//span[text()='Wages']");
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
        #endregion



        #region Public Methods

        public void ClickLosslineSummary()

        {
            this.driver.ClickElement(byLossLineSummary,"LosslineSummary");
        }
        public void ClickEmailAdjuster()

        {
            this.driver.ClickElement(byEmailAdjusterBtn, "EmailAdjuster");
        }

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

        public void VerifyLossLineSummary()
        {
            bool flag=this.driver.IsElementPresent(byLossLineSummary);
            try
            {
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify Loss Line Summary link", String.Format(" Successfully verified - <Mark>{0}</Mark>","Loss Line Summary"));
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

        public void VerifyDetailedClaimList()
        {
           bool flag= this.driver.IsElementPresent(byDetailedClaimList);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Detailed Claim List", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Detailed claim list"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Detailed Claim List", String.Format("Failed to Verify link"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyCreateEntryLink()
        {
            bool flag = this.driver.IsElementPresent(byCreateEntryLink);
            if (flag)
            {
                this.TESTREPORT.LogSuccess("Verify Create Entry link", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Create Entry link"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Create Entry link", String.Format("Failed to Verify link"), this.SCREENSHOTFILE);
            }
        }

        public void VerifyWagesText()
        {
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

        public void VerifyLossLineDescriptionlink()
        {
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
            this.driver.ClickElement(byResetButton,"Reset Button");
            
        }
        public void EnterClaimNumber(String ClaimNumbervalue)
        
        {
            this.driver.SendKeysToElement(byClaimNumber, ClaimNumbervalue,"Claim Number");
        }

        public void EnterLast4SSN(String Last4SSNvalue)

        {
            this.driver.SendKeysToElement(byLast4SSN, Last4SSNvalue, "Last4SSN");
        }

        public void EnterClaimstatus(String Claimstatusvalue)

        {
            this.driver.SendKeysToElement(byClaimstatus, Claimstatusvalue, "Claimstatus");
        }
        public void EnterLastName(String LastNamevalue)

        {
            this.driver.SendKeysToElement(byLastName, LastNamevalue, "LastName");
        }

        public void EnterFirstName(String FirstNamevalue)

        {
            this.driver.SendKeysToElement(byFirstName, FirstNamevalue, "FirstName");
        }

        public void EnterIncurredfrom(String Incurredfromvalue)

        {
            this.driver.SendKeysToElement(byIncurredfrom, Incurredfromvalue , "Incurred from");
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

        public void ClickLocationSearchIcon()
        {
            this.driver.ClickElement(byLocationIcon,"Location Icon");
           
        }

        public void ClickWorkerAccident()
        {
            this.driver.ClickElement(byWorkerAccidentTab, "Worker Accident");

        }

        public void ClickFinancial()
        {
            this.driver.ClickElement(byFinancialTab, "Financial");

        }

        public void ClickPayments()
        {
            this.driver.ClickElement(byPaymentsTab, "Payments");

        }

        public void ClickDiary()
        {
            this.driver.ClickElement(byDiaryTab, "Diary");

        }

        public void ClickLogNotes()
        {
            this.driver.ClickElement(byLogNotesTab, "LogNotes");

        }

        public void ClickDocuments()
        {
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

        public void EnterLocationcodeField()
        {
            this.driver.SendKeysToElement(bylocationCodeTable, "0000000005", "LocationCodeField");

            
        }

       

        public void ClickLocationCode()

        {
            string Locationcodefield = this.driver.GetElementText(bylocationCodeTable);
           
            IList<IWebElement> rows = this.driver.FindElements(By.XPath("//table[@id='gridlocation_DXMainTable']//tr[contains(@id,'gridlocation_DXDataRow')]"));

            for(int k=0;k<=rows.Count;k++)
            {
                if (rows[k].Displayed && rows[k].Text== Locationcodefield)
                {
                    rows[k].Click();
                }
               
            }


        }







        #endregion

    }
}
