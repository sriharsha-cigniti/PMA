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
using System.Windows.Forms;
using Engine.Factories;
using System.Text.RegularExpressions;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class OshaPage : AbstractTemplatePage
    {
        #region UI Objects
        private By byOshatab = By.XPath("//span[contains(text(),'OSHA')]");
        private By byAcceptButton = By.XPath("//span[contains(text(),'Accept')]");
        private By byOshaLink = By.LinkText("OSHA");        
        private By byInformationText = By.XPath("//span[contains(text(),'Important Information Please Read')]");
        private By byClickDropDownArrow = By.Id("MainContent_ddyear_B-1");
        private By byAccountDetails = By.Id("lblAccount1");
        private By byClaimNo = By.Id("MainContent_DisplayClaimNum");
        private By byAccountNo = By.Id("MainContent_txbAcctNum_I");
        private By byJobtitle = By.Id("MainContent_txtjob_I");
        private By byNameText = By.Id("MainContent_txtestabname_I");
        private By byExitDetailButton = By.XPath("//span[contains(text(),'Exit Claim Detail')]");
        private By byYearValue = By.Id("MainContent_ddyear_I");
        private By byInjuryDatecoloumns = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow')]");
        private By byOshaClaimrows = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow')]");
        private By byPageSizeDropDown = By.XPath("//span[@id='MainContent_gridresult_DXPagerTop_DDBImg']");
        private By byNewLink = By.Id("MainContent_gridlost_DXCBtn0");
        private By byUpdateLink = By.XPath("//span[contains(text(),'Update')]");
        private By byCancelLink = By.XPath("//span[contains(text(),'Cancel')]");
        private By byLostDaysColoumns = By.XPath("//table[@id='MainContent_gridlost']//tr[contains(@id,'MainContent_gridlost_DXDataRow')]/td[3]");
        private By byLostDaysTotalColoumn = By.XPath("//table[@id='MainContent_gridlost']//tr[contains(@id,'MainContent_gridlost_DXFooterRow')]/td[3]");
        private By bySubmitChangeButton = By.XPath("//span[contains(text(),'Submit changes')]");
        private By bySubmitText = By.Id("MainContent_lblMessage");
        private By BeginDate = By.Id("MainContent_gridlost_DXEFL_DXEditor1_I");
        private By byEndDate = By.Id("MainContent_gridlost_DXEFL_DXEditor2_I");
        private By byRestrictedDaysColoumns = By.XPath("//table[@id='MainContent_gridrestricted_DXMainTable']//tr[contains(@id,'MainContent_gridrestricted_DXDataRow')]/td[3]");
        private By byRestrictedDaysTotalColoumn = By.XPath("//table[@id='MainContent_gridrestricted_DXMainTable']//tr[contains(@id,'MainContent_gridrestricted_DXFooterRow')]/td[3]");
        private By byRestrictedNewLink = By.Id("MainContent_gridrestricted_DXCBtn0");
        private By byRestrictedBeginDate = By.Id("MainContent_gridrestricted_DXEFL_DXEditor1_I");
        private By byRestrictedEndDate = By.Id("MainContent_gridrestricted_DXEFL_DXEditor2_I");
        private By byLocationText = By.Id("MainContent_txtlocnumdesc_I");
        private By byEmployeeNameText = By.Id("MainContent_txtemplyeename_I");
        private By byEmployeeJobTitleText = By.Id("MainContent_txtjob_I");
        private By byExcludedCheckBox = By.Id("MainContent_ckbExclude1");
        private By byPrivacyCheckBox = By.Id("MainContent_ckbPrivacy1");
        private By byInjuryDate = By.Id("MainContent_dtinjury_I");
        private By byInjuryOrIllnessText = By.Id("MainContent_memlossdesc_I");
        private By byExcludeInGridCheckBox = By.XPath("//tr[@id='MainContent_gridresult_DXDataRow0']/td[4]//span");
        private By byPrivacyInGridCheckBox = By.XPath("//tr[@id='MainContent_gridresult_DXDataRow0']/td[5]//span");
        private By Claimno = By.XPath("//td[@id='MainContent_gridresult_tccell0_1']//a");
        private By modifyLink = By.XPath("//a[contains(text(),'Modified')]");
        private By bySubmitChangesOnreportableButton = By.XPath("//span[contains(text(),'Submit Changes')]");
        private By byExportSpreadsheet = By.XPath("//span[contains(text(),'Export to Spreadsheet')]");
        private By byClaimNoSearchText = By.Id("MainContent_gridresult_DXFREditorcol1_I");
        private By byClearButton = By.XPath("//span[contains(text(),'Clear')]");
        private double timeoutInSeconds;


        #endregion



        #region public methods

        public void ClickOnOsha()
        {
            this.driver.ClickElement(byOshaLink, "Claim Inquiry Tab");
            //Switching to frame.......
            // this.driver.SwitchTo().Frame("MainContent_ASPxSplitter1_0_CC");
            this.driver.WaitElementPresent(byAcceptButton);
            if (this.driver.IsElementPresent(byAcceptButton))
                this.TESTREPORT.LogSuccess("Click Osha Tab", String.Format("Osha Tab clicked and <mark>{0}</mark> is visible", "Accept button"));
            else
                this.TESTREPORT.LogFailure("Click Osha Tab", String.Format("Osha Tab clicked and <mark>{0}</mark> is not visible", "Accept button"), this.SCREENSHOTFILE);
        }

        public void VerifyOshaTabHighLightColor(string HighlightColor)
        {
            this.driver.WaitElementPresent(byOshaLink);
            this.driver.ClickElement(byOshaLink, "Claim Inquiry link");
            string actualHighlightcolor = this.driver.GetElementAttribute(byOshaLink, "style");
            string color = actualHighlightcolor.Split(':')[1];
            if (actualHighlightcolor.Equals(HighlightColor))
                this.TESTREPORT.LogSuccess("Verify Osha tab is highlighted", string.Format("Osha highlighted color is:<Mark>{0}</Mark>", color), this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Osha tab is highlighted", string.Format("Osha highlighted color is:<Mark>{0}</Mark>", color), this.SCREENSHOTFILE);

        }

        public void VerifyInformation()
        {
            Thread.Sleep(2000);
            this.driver.WaitElementPresent(byInformationText);
            if (this.driver.IsElementPresent(byInformationText))
                this.TESTREPORT.LogSuccess("Verify Information Text", String.Format("Information Text - <mark>{0}</mark> appeared", "'Important Information Please Read'"));
            else
                this.TESTREPORT.LogFailure("Verify Information Text", String.Format("Information Text - <mark>{0}</mark> doesn't appeared", "'Important Information Please Read'"), this.SCREENSHOTFILE);
        }

        public void ClickAcceptButton()
        {
            this.driver.ClickElement(byAcceptButton, "Accept Button");
        }

        public ArrayList ClickOnClaimnumber()
        {
            this.TESTREPORT.LogInfo(" Click on  claim number");
            ArrayList listName = new ArrayList();
            string ClaimNo = "";
            string jobTitle = "";
            string EstablishmentName = "";
            this.driver.WaitElementPresent(byOshaClaimrows);
            IReadOnlyList<IWebElement> rows = driver.FindElements(byOshaClaimrows);
            if (rows.Count > 0)
            {

                ClaimNo = this.driver.GetElementText(Claimno);
                listName.Add(ClaimNo);
                By Jobtitle = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow0')]/td[6]");
                jobTitle = this.driver.GetElementText(Jobtitle);
                listName.Add(jobTitle);
                By Establishmentname = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow0')]/td[8]");
                EstablishmentName = this.driver.GetElementText(Establishmentname);
                listName.Add(EstablishmentName);
                this.driver.ClickElement(Claimno, "Claim No link");

            }
            else
            {
                this.TESTREPORT.LogInfo("NO DATA TO DISPLAY");
            }

            return listName;
        }

        public bool SelectYearFromDropdown(string Year)
        {
            bool yearPresent = true;
            this.driver.ClickElement(byClickDropDownArrow, "Drop Down Arrow");
            By ByYear = By.XPath(string.Format("//td[contains(text(),'{0}')]", Year));
            this.driver.WaitElementPresent(ByYear);
            if (this.driver.IsElementPresent(ByYear))
                this.driver.ClickElement(ByYear, "DropDown Year");
            else
                yearPresent = false;

            return yearPresent;
        }

        public void VerifyOshaClaimDetail(string expectedValue, string actualvalue)
        {
            this.driver.AssertTextMatching(actualvalue, expectedValue);
        }

        public string GetAccountNoFromPageHeader()
        {
            string accountDetail = this.driver.GetElementText(byAccountDetails);
            string accountNo = accountDetail.Split('-')[1];
            return accountNo;
        }

        public string GetClaimno()
        {
            string Claimno = this.driver.GetElementText(byClaimNo);
            return Claimno;
        }

        public string GetClaimAccountNo()
        {
            string accountNo = this.driver.GetElementAttribute(byAccountNo, "value");
            return accountNo;

        }

        public string GetJobtitle()
        {
            string jobTitle = this.driver.GetElementAttribute(byJobtitle, "value");
            return jobTitle;

        }

        public string GetEstablishmentName()
        {
            string Name = this.driver.GetElementAttribute(byNameText, "value");
            return Name;

        }

        public void ClickOnExitDetail()
        {
            this.driver.ClickElement(byExitDetailButton, "Exit claim Detail button");
        }

        public void VerifyDropDownValue(string value)
        {
            string actualopdownValue = this.driver.GetElementAttribute(byYearValue, "value");
            this.driver.AssertTextMatching(actualopdownValue, value);

        }

        public void VerifyInjuryDateColoumn(string year)
        {
            this.driver.WaitElementPresent(byInjuryDatecoloumns);
            IReadOnlyList<IWebElement> coloumns = driver.FindElements(byInjuryDatecoloumns);
            bool yearvalue = false;
            if (coloumns.Count > 0)
            {
                foreach (var item in coloumns)
                {
                    if (string.IsNullOrEmpty(item.Text) || string.IsNullOrWhiteSpace(item.Text))
                        continue;
                    else if (item.Text.Trim().Contains(year.Trim()))
                    {
                        yearvalue = true;
                    }
                    else
                    {
                        this.TESTREPORT.LogFailure("Verify Injured Date", string.Format("Injured Date coloumn value:<Mark>{0}</Mark> Expected value:<Mark>{1}</Mark>", item.Text, year), this.SCREENSHOTFILE);
                        yearvalue = false;
                        break;
                    }
                }
                if (yearvalue)
                    this.TESTREPORT.LogSuccess("Verify Injured Date", string.Format("Injured Date all coloumn value contains -<Mark> {0} </Mark>", year));
            }
            else
            {
                this.TESTREPORT.LogInfo("NO DATA TO DISPLAY");
            }

        }

        public void SelectPageSizeAll(string value)
        {
            this.driver.WaitElementPresent(byPageSizeDropDown);
            this.driver.ClickElement(byPageSizeDropDown, "Osha Claim DropdownButton");
            Thread.Sleep(5000);
            By PageValue = By.XPath(string.Format("//div[@id='MainContent_gridresult_DXPagerTop_PSP_DXI0_T']/span[contains(text(),'{0}')]", value));
            this.driver.WaitElementPresent(PageValue);
            Thread.Sleep(5000);
            this.driver.ClickElement(PageValue, "DropDown value");
            Thread.Sleep(10000);
        }

        public void ClickOnNewLink()
        {
            this.driver.ClickElement(byNewLink, "New link button");
        }

        public void VerifyAndClickUpdate()
        {
            this.driver.WaitElementPresent(byUpdateLink);
            if (this.driver.IsElementPresent(byUpdateLink))
            {
                this.driver.ClickElement(byUpdateLink, "Update link button");
                this.TESTREPORT.LogSuccess("Verify and click Update link", "Update Link is present and successfully clicked", this.SCREENSHOTFILE);
            }
            else
                this.TESTREPORT.LogFailure("Verify and click Update link", "Update Link is not present", this.SCREENSHOTFILE);
        }

        public void VerifyCancel()
        {
            this.driver.WaitElementPresent(byCancelLink);
            if (this.driver.IsElementPresent(byCancelLink))
                this.TESTREPORT.LogSuccess("Verify Cancel link", "Cancel Link is present", this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify Cancel link", "Cancel Link is not present", this.SCREENSHOTFILE);
        }

        public void EnterBeginDate()
        {
            DateTime today = DateTime.Today; // As DateTime
            string s_today = today.ToString("MM/dd/yyyy"); // As String
            this.driver.SendKeysToElement(BeginDate, s_today, "Begin Date Textbox ");

        }

        public void EnterEndDate()
        {
            DateTime today = DateTime.Today.AddMonths(1); // As DateTime
            string s_today = today.ToString("MM/dd/yyyy"); // As String

            this.driver.SendKeysToElement(byEndDate, s_today, "bEginDAte");
        }

        public void VerifyTotalLostDays()
        {
            this.driver.WaitElementPresent(byLostDaysColoumns);

            int totalDaysTemp = 0;
            IReadOnlyList<IWebElement> coloumns = driver.FindElements(byLostDaysColoumns);

            if (coloumns.Count > 0)
            {
                foreach (var item in coloumns)
                {
                    string totaldayColValue = item.Text.Trim();
                    totalDaysTemp = totalDaysTemp + Convert.ToInt32(totaldayColValue);
                }
                string Totalvalue = this.driver.GetElementText(byLostDaysTotalColoumn);
                Totalvalue = Totalvalue.Split(':')[1];
                if (Convert.ToInt32(Totalvalue.Trim()) == totalDaysTemp)
                    this.TESTREPORT.LogSuccess("Verify Total Lost Days", string.Format("Total Lost Days:<Mark>{0}</Mark>,Lost Days Coloumn Total:<Mark>{1}</Mark>", Totalvalue, totalDaysTemp.ToString()));
                else
                    this.TESTREPORT.LogFailure("Verify Total Lost Days", string.Format("Total Lost Days:<Mark>{0}</Mark>,Lost Days Coloumn Total:<Mark>{1}</Mark>", Totalvalue, totalDaysTemp.ToString()));
            }
            else
            {
                this.TESTREPORT.LogInfo("NO DATA TO DISPLAY");
            }

        }

        public void ClickAndVerifySubmitChanges()
        {
            this.driver.ClickElement(bySubmitChangeButton, "Submit changes Button");

            this.driver.WaitElementPresent(bySubmitText);
            string submitActualText = this.driver.GetElementText(bySubmitText);
            string text = "Submit Changes completed at " + DateTime.Now.ToString("%h:mm");
            text = text.Split(':')[0];
            submitActualText = submitActualText.Split(':')[0];

            if (this.driver.IsElementPresent(bySubmitText) && text.Equals(submitActualText))
            {

                this.TESTREPORT.LogSuccess("Verify Submit Text", string.Format("Submit text appears:<Mark>{0}</Mark>", submitActualText));
            }
            else
                this.TESTREPORT.LogFailure("Verify Submit Text", string.Format("Submit text appears:<Mark>{0}</Mark>", submitActualText), this.SCREENSHOTFILE);


        }

        public void VerifyRestrictedDays()
        {
            this.driver.WaitElementPresent(byRestrictedDaysColoumns);

            int totalDaysTemp = 0;
            IReadOnlyList<IWebElement> coloumns = driver.FindElements(byRestrictedDaysColoumns);

            if (coloumns.Count > 0)
            {
                foreach (var item in coloumns)
                {
                    string totaldayColValue = item.Text.Trim();
                    totalDaysTemp = totalDaysTemp + Convert.ToInt32(totaldayColValue);
                }
                string Totalvalue = this.driver.GetElementText(byRestrictedDaysTotalColoumn);
                Totalvalue = Totalvalue.Split(':')[1];
                if (Convert.ToInt32(Totalvalue.Trim()) == totalDaysTemp)
                    this.TESTREPORT.LogSuccess("Verify Total Restricted Days", string.Format("Total Restricted Days:<Mark>{0}</Mark>,Restricted Days Coloumn Total:<Mark>{1}</Mark>", Totalvalue, totalDaysTemp.ToString()));
                else
                    this.TESTREPORT.LogFailure("Verify Total Restricted Days", string.Format("Total Restricted Days:<Mark>{0}</Mark>,Restricted Days Coloumn Total:<Mark>{1}</Mark>", Totalvalue, totalDaysTemp.ToString()));
            }
            else
            {
                this.TESTREPORT.LogInfo("NO DATA TO DISPLAY");
            }

        }

        public void EnterRestrictedBeginDate()
        {
            DateTime today = DateTime.Today; // As DateTime
            string s_today = today.ToString("MM/dd/yyyy"); // As String
            this.driver.SendKeysToElement(byRestrictedBeginDate, s_today, "Restricted Begin Date");

        }

        public void EnterRestrictedEndDate()
        {
            DateTime today = DateTime.Today.AddMonths(1); // As DateTime
            string s_today = today.ToString("MM/dd/yyyy"); // As String
            this.driver.SendKeysToElement(byRestrictedEndDate, s_today, "Restricted End Date");
        }

        public void ClickOnRestrictedLink()
        {
            this.driver.ClickElement(byRestrictedNewLink, "Restricted New Link");
        }

        public void VerifyEstablishmentName()
        {
            this.driver.GetSetAndVerifyTextValues(byNameText, "Establishment Name Textbox");
        }

        public void VerifyLocation(string location = "")
        {
            this.driver.GetSetAndVerifyTextValues(byLocationText, "Location Textbox", location);
        }

        public void VerifyEmployeeName()
        {
            this.driver.GetSetAndVerifyTextValues(byEmployeeNameText, "Employee Name Textbox");
        }

        public void VerifyEmployeeJobtitle(string jobtitle="")
        {
            this.driver.GetSetAndVerifyTextValues(byEmployeeJobTitleText, "Employee Job title Textbox", jobtitle);
        }

        public void VerifyExclude()
        {
            if (this.driver.CheckBoxIsSelected(byExcludedCheckBox))
            {
                this.driver.ClickElement(byExcludedCheckBox, "Excluded Checkbox");
                Thread.Sleep(2000);
                if (!this.driver.CheckBoxIsSelected(byExcludedCheckBox))
                    this.TESTREPORT.LogSuccess("Verify exclude is set", string.Format("<mark>Excluded unchecked </mark>"), this.SCREENSHOTFILE);
                else
                    this.TESTREPORT.LogFailure("Verify exclude is set", string.Format("<mark>Excluded checked </mark>"), this.SCREENSHOTFILE);
            }

            else
            {
                this.driver.ClickElement(byExcludedCheckBox, "Excluded Checkbox");
                Thread.Sleep(2000);
                if (this.driver.CheckBoxIsSelected(byExcludedCheckBox))
                    this.TESTREPORT.LogSuccess("Verify exclude is set/reset", string.Format("<mark>Excluded checked </mark>"), this.SCREENSHOTFILE);
                else
                    this.TESTREPORT.LogFailure("Verify exclude is set/reset", string.Format("<mark>Excluded unchecked </mark>"), this.SCREENSHOTFILE);

            }

        }


        public void VerifyPrivacy()
        {
            if (this.driver.CheckBoxIsSelected(byPrivacyCheckBox))
            {
                this.driver.ClickElement(byPrivacyCheckBox, "Privacy Checkbox");
                Thread.Sleep(2000);
                if (!this.driver.CheckBoxIsSelected(byPrivacyCheckBox))
                    this.TESTREPORT.LogSuccess("Verify Privacy is set", string.Format("<mark>Privacy unchecked </mark>"), this.SCREENSHOTFILE);
                else
                    this.TESTREPORT.LogFailure("Verify Privacy is set", string.Format("<mark>Privacy checked </mark>"), this.SCREENSHOTFILE);
            }

            else
            {
                this.driver.ClickElement(byPrivacyCheckBox, "Privacy Checkbox");
                Thread.Sleep(2000);
                if (this.driver.CheckBoxIsSelected(byPrivacyCheckBox))
                    this.TESTREPORT.LogSuccess("Verify Privacy is set/reset", string.Format("<mark>Privacy checked </mark>"), this.SCREENSHOTFILE);
                else
                    this.TESTREPORT.LogFailure("Verify Privacy is set/reset", string.Format("<mark>Privacy unchecked </mark>"), this.SCREENSHOTFILE);

            }
        }

        public void VerifyInjuryDate()
        {
            By injurydate = By.Id("MainContent_dtinjury_I");
            this.driver.WaitElementPresent(injurydate);
            string injuryDate = DateTime.Now.ToString("MM/dd/yyyy");
            By dropDOwn = By.XPath("//span[@id='MainContent_dtinjury_B-1Img']");
            this.driver.ClickElement(dropDOwn, "");
            Thread.Sleep(5000);
            By Clear = By.XPath("//td[@id='MainContent_dtinjury_DDD_C_BC']");
            this.driver.WaitUntilElementVisible(Clear, 60);
            this.driver.ClickElement(Clear, "Clear Button cLicked");
            Thread.Sleep(5000);
            this.driver.ClickElement(dropDOwn, "");
            By Today = By.XPath("//td[@id='MainContent_dtinjury_DDD_C_BT']");
            this.driver.WaitElementPresent(Today);
            this.driver.ClickElement(Today, "Today Date");
            string injurydatechanged = this.driver.GetElementAttribute(byInjuryDate, "value");
            this.driver.AssertTextMatching(injuryDate, injurydatechanged);

        }

        public void VerifyInjuryorIllness(string illness = "")
        {
            this.driver.GetSetAndVerifyTextValues(byInjuryOrIllnessText, "Injury/illness Textbox", illness);
        }

        public ArrayList Getfieldstext()
        {
            ArrayList fields = new ArrayList();

            string employee = this.driver.GetElementAttribute(byEmployeeNameText, "value");
            fields.Add(employee);
            string jobtitle = this.driver.GetElementAttribute(byJobtitle, "value");
            fields.Add(jobtitle);
            string injuryDate = this.driver.GetElementAttribute(byInjuryDate, "value");
            fields.Add(injuryDate);
            string establishmentname = this.driver.GetElementAttribute(byNameText, "value");
            fields.Add(establishmentname);
            string location = this.driver.GetElementAttribute(byLocationText, "value");
            fields.Add(location);
            string injury = this.driver.GetElementAttribute(byInjuryOrIllnessText, "value");
            fields.Add(injury);

            return fields;

        }

        public void VerifyModifiedOshaClaimDetails(string expectedValue, string fieldName)
        {
            Thread.Sleep(5000);
            By field = By.XPath(string.Format("//tr[@id='MainContent_gridresult_DXDataRow0']//td[contains(text(),'{0}')]", expectedValue));
            Thread.Sleep(5000);
            if (this.driver.IsElementPresent(field))
                this.TESTREPORT.LogSuccess("Verify Modified osha claim details", string.Format("<mark>{0}</mark> modified value:<mark>{1}</mark>", fieldName, expectedValue));
            else
                this.TESTREPORT.LogFailure("Verify Modified osha claim details", string.Format("<mark>{0}</mark> modified value:<mark>{1}</mark>", fieldName, expectedValue));

        }

        public void VerifyModifiedExcludeValueOshaClaimDetails()
        {
            string selectedStatus = "";
            this.driver.ClickElement(Claimno, "Claim no");
            this.driver.WaitElementPresent(byExcludedCheckBox);
            bool expectedValue = this.driver.CheckBoxIsSelected(byExcludedCheckBox);
            string expectedvalue = expectedValue.ToString();
            ClickOnExitDetail();
            ClickOnModifySortLink();
            ClickOnModifySortLink();
            this.driver.WaitElementPresent(byExcludeInGridCheckBox);
            string actualValue = this.driver.GetElementAttribute(byExcludeInGridCheckBox, "aria-checked");
            if (actualValue.Equals(expectedvalue.ToLower()))
            {
                if (actualValue == "true")
                    selectedStatus = "selected";
                else
                    selectedStatus = "un-selected";
                this.TESTREPORT.LogSuccess("Verify Exclude modified value", string.Format("Exclude checkbox is:<Mark>{0}</Mark> and successfully modified", selectedStatus));

            }
            else
                this.TESTREPORT.LogFailure("Verify Exclude modified value", string.Format("<mark> Exclude checkbox is not modified </mark>"), this.SCREENSHOTFILE);


        }

        public void VerifyModifiedPrivacyValueOshaClaimDetails()
        {
            string selectedStatus = "";
            this.driver.ClickElement(Claimno, "Claim no");
            this.driver.WaitElementPresent(byPrivacyCheckBox);
            bool expectedValue = this.driver.CheckBoxIsSelected(byPrivacyCheckBox);
            string expectedvalue = expectedValue.ToString();
            ClickOnExitDetail();
            ClickOnModifySortLink();
            ClickOnModifySortLink();
            this.driver.WaitElementPresent(byPrivacyInGridCheckBox);
            string actualValue = this.driver.GetElementAttribute(byPrivacyInGridCheckBox, "aria-checked");
            if (actualValue.Equals(expectedvalue.ToLower()))
            {
                if (actualValue == "true")
                    selectedStatus = "selected";
                else
                    selectedStatus = "un-selected";
                this.TESTREPORT.LogSuccess("Verify Privacy modified value", string.Format("Privacy checkbox is:<Mark>{0}</Mark> and successfully modified", selectedStatus));

            }
            else
                this.TESTREPORT.LogFailure("Verify Privacy modified value", string.Format("<mark> Privacy checkbox is not modified </mark>"), this.SCREENSHOTFILE);


        }

        public void ClickOnModifySortLink()
        {
            this.driver.WaitElementPresent(modifyLink);
            this.driver.ClickElement(modifyLink, "Modify Sort Link");
        }

        public void ModifyPrivacyCheckboxinGridView()
        {
            if (this.driver.GetElementAttribute(byPrivacyInGridCheckBox, "aria-checked").Equals("true"))
            {
                this.driver.ClickElement(byPrivacyInGridCheckBox, "Privacy Checkbox");
                this.driver.ClickElement(byPrivacyInGridCheckBox, "Privacy Checkbox");
                this.TESTREPORT.LogSuccess("Verify privacy is set/reset in grid", string.Format("<mark>Privacy unchecked </mark>"), this.SCREENSHOTFILE);
            }

            else
            {
                this.driver.ClickElement(byPrivacyInGridCheckBox, "Privacy Checkbox");
                this.driver.ClickElement(byPrivacyInGridCheckBox, "Privacy Checkbox");
                this.TESTREPORT.LogSuccess("Verify privacy is set/reset in grid", string.Format("<mark>Privacy checked </mark>"), this.SCREENSHOTFILE);

            }
        }

        public void ModifyExcludeCheckboxinGridView()
        {
            if (this.driver.GetElementAttribute(byExcludeInGridCheckBox, "aria-checked").Equals("true"))
            {
                this.driver.ClickElement(byExcludeInGridCheckBox, "Excluded Checkbox");
                this.driver.ClickElement(byExcludeInGridCheckBox, "Excluded Checkbox");
                this.TESTREPORT.LogSuccess("Verify exclude is set/reset in grid", string.Format("<mark>Excluded unchecked </mark>"), this.SCREENSHOTFILE);
            }
            else
            {
                this.driver.ClickElement(byExcludeInGridCheckBox, "Excluded Checkbox");
                this.driver.ClickElement(byExcludeInGridCheckBox, "Excluded Checkbox");
                this.TESTREPORT.LogSuccess("Verify exclude is set/reset in grid", string.Format("<mark>Excluded checked </mark>"), this.SCREENSHOTFILE);

            }

        }

        public void ClickSubmitChangesOnReportClaims()
        {
            this.driver.ClickElement(bySubmitChangesOnreportableButton, "Submit Changes On report claims ");

        }


        public int TableRowExists()
        {

            IReadOnlyList<IWebElement> rows = driver.FindElements(byOshaClaimrows);
            return rows.Count;

        }

        public void ClickOnExportSpreadsheet()
        {
            this.driver.ClickElement(byExportSpreadsheet, "Export Spreadsheet");
        }

        public void SearchWithClaimNo(string claimNo)
        {
            this.driver.SendKeysToElementClearFirst(byClaimNoSearchText, claimNo, "Claim no serach text");

        }

        public void ClickOnClear()
        {
            this.driver.WaitElementPresent(byClearButton);
            this.driver.ClickElement(byClearButton, "Clear Button");

        }

        public void VerifyClaimNoSearchResult(string expected)
        {
            ClickOnModifySortLink();
            ClickOnModifySortLink();
            string actual = GetOshaDetailClaimNo();
            this.driver.AssertTextMatching(actual, expected);

        }
        public string GetOshaDetailClaimNo()
        {
            return this.driver.GetElementText(Claimno);
        }

        public void VerifyClaimTextAfterClear(string beforesetText)
        {
            string actual = this.driver.GetElementAttribute(byClaimNoSearchText, "value");
            if (!actual.Equals(beforesetText))
            {
                if (string.IsNullOrEmpty(actual))
                    actual = "empty";
                this.TESTREPORT.LogSuccess("Verify Claim Text after clear", string.Format("Earlier Text set is :<Mark>{0}</Mark>,current value after clear  is:<Mark>{1}</Mark>", beforesetText, actual));
            }
            else
                this.TESTREPORT.LogFailure("Verify Claim Text after clear", string.Format("Earlier Text set is :<Mark>{0}</Mark>,current value after  is:<Mark>{1}</Mark>", beforesetText, actual), this.SCREENSHOTFILE);
        }

        public void VerifySearchResultsAfterClear(string beforeCount)
        {
            Thread.Sleep(10000);
            int actual = TableRowExists();
            if (!(actual.ToString().Equals(beforeCount)))
                this.TESTREPORT.LogSuccess("Verify Claim Search results count after clear", string.Format("Earlier Search count is :<Mark>{0}</Mark>,current search result value after clear is:<Mark>{1}</Mark>", beforeCount, actual));
            else
                this.TESTREPORT.LogFailure("Verify Claim Search results count after clear", string.Format("Earlier Search count is :<Mark>{0}</Mark>,current search result value after clear is:<Mark>{1}</Mark>", beforeCount, actual), this.SCREENSHOTFILE);
        }

        public void WaitforCheckboxChange(By locator, string value)
        {

            int timeoutInSeconds = 60;
            bool valueChanged = false;
            while (timeoutInSeconds != 0)
            {
                if (this.driver.GetElementAttribute(locator, "aria-checked").Equals(value))
                {
                    valueChanged = true;
                    break;
                }
                timeoutInSeconds--;

            }


        }





    }
    #endregion

}


