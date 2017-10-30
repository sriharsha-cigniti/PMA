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

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
   public class OshaPage : AbstractTemplatePage
    {
        #region UI Objects
        private By byOshatab = By.XPath("//span[contains(text(),'OSHA')]");
        private By byAcceptButton = By.XPath("//span[contains(text(),'Accept')]");
        private By byOshaLink = By.Id("CinchMenu_DXI4_T");
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
        #endregion



        #region public methods

        public void ClickOnOsha()
        {
            this.driver.ClickElement(byOshatab, "Claim Inquiry Tab");
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
            this.driver.ClickElement(byAcceptButton,"Accept Button");
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
                By Claimno = By.XPath("//td[@id='MainContent_gridresult_tccell0_1']//a");
                ClaimNo = this.driver.GetElementText(Claimno);
                listName.Add(ClaimNo);
                By Jobtitle = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow0')]/td[6]");
                jobTitle = this.driver.GetElementText(Jobtitle);
                listName.Add(jobTitle);
                By Establishmentname = By.XPath("//table[@id='MainContent_gridresult_DXMainTable']//tr[contains(@id,'MainContent_gridresult_DXDataRow0')]/td[8]");
                EstablishmentName = this.driver.GetElementText(Establishmentname);
                listName.Add(EstablishmentName);
                this.driver.ClickElement(Claimno,"Claim No link");

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
            this.driver.ClickElement(byClickDropDownArrow,"Drop Down Arrow");
            By ByYear = By.XPath(string.Format("//td[contains(text(),'{0}')]", Year));
            this.driver.WaitElementPresent(ByYear);
            if (this.driver.IsElementPresent(ByYear))
                this.driver.ClickElement(ByYear, "DropDown Year");
            else
                yearPresent = false;

            return yearPresent;
        }

        public void VerifyOshaClaimDetail(string expectedValue,string actualvalue)
        {
            this.driver.AssertTextMatching(actualvalue, expectedValue);
        }
        
        public string GetAccountNoFromPageHeader()
        {
          string accountDetail=  this.driver.GetElementText(byAccountDetails);
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
            string accountNo = this.driver.GetElementAttribute(byAccountNo,"value");
            return accountNo;
            
        }
        
        public string GetJobtitle()
        {
            string jobTitle = this.driver.GetElementAttribute(byJobtitle,"value");
            return jobTitle;
            
        }

        public string GetEstablishmentName()
        {
            string Name = this.driver.GetElementAttribute(byNameText,"value");
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
                    if (string.IsNullOrEmpty(item.Text)|| string.IsNullOrWhiteSpace(item.Text))
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
                    this.TESTREPORT.LogSuccess("Verify Injured Date",string.Format("Injured Date all coloumn value contains -<Mark> {0} </Mark>",year));
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
            this.driver.ClickElement(PageValue,"DropDown value");
            Thread.Sleep(10000);
        }









        #endregion

    }
}

