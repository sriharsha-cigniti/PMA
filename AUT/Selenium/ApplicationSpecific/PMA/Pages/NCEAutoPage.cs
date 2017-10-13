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
    public class NCEAutoPage : AbstractTemplatePage
    {
        #region UI Objects
        //New ClaimInquiry and auto Form
        private By byClaimNewInquirytab = By.XPath("//span[contains(text(),'New Claim Entry')]");
        
        private By byDropdOwnimage = By.XPath("//span[@id='MainContent_ddlob_B-1Img']");
        private By bySelectBusinessLabel = By.XPath("//div[@id='MainContent_up1']//label[contains(text(),'Select Line of Business:')]");
        private By byAutoSpan = By.XPath("//span[contains(text(),'Auto')]");
        private By byCancelButton = By.XPath("//div[@id='MainContent_btncancel_CD']/span[contains(text(),'Cancel')]");
        private By bySubmitButton = By.XPath("//div[@id='MainContent_btnSubmit']//span[contains(text(),'Submit')]");
        private By byOccurenceDate = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_I");
        private By byLocationDropdOwnimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_B-1Img']");
        private By byStateOfLossDropdOwnimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlossstate_B-1Img']");
        private By byContactBusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone_I");
        private By byDateOfOccurenceDropdownimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_B-1Img']");
        private By byTodayDate = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_DDD_C_BT");



        #endregion

        public void ClickOnNewClaimEntry()
        {
            this.driver.ClickElement(byClaimNewInquirytab, "Claim Inquiry Tab");
            //Switching to frame.......
            this.driver.SwitchTo().Frame(0);
            this.driver.WaitElementPresent(bySelectBusinessLabel);
            if (this.driver.IsElementPresent(bySelectBusinessLabel))
                this.TESTREPORT.LogSuccess("Click New Claim Entry", String.Format("<mark>{0}</mark> is visible", "Select Line of Business:"));
            else
                this.TESTREPORT.LogFailure("Click New Claim Entry", String.Format("<mark>{0}</mark> is not visible", "Select Line of Business:"), this.SCREENSHOTFILE);
        }

        public void VerifyAutoForm(string autoText)
        {
            this.driver.ClickElement(byDropdOwnimage, "Image");
             By bySelectBusinessDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", autoText));
            this.driver.ClickElement(bySelectBusinessDropDown,"Drop Down value");
            //SWitching to Default..... 
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            //Switching to different frame.....
            this.driver.WaitElementPresent(byAutoSpan);
            if (this.driver.IsElementPresent(byAutoSpan))
                this.TESTREPORT.LogSuccess("Verify auto Form",String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form appeared", autoText, autoText));
            else
                this.TESTREPORT.LogFailure("Verify auto Form", String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form not appeared", autoText, autoText));
        }

        public void ClickCancel()
        {
            this.driver.ClickElement(byCancelButton,"Cancel Button");
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(0);
            if (this.driver.IsElementPresent(bySelectBusinessLabel))
                if (this.driver.IsElementPresent(bySelectBusinessLabel))
                    this.TESTREPORT.LogSuccess("Click Cancel", String.Format("<mark>{0}</mark> is visible", "Select Line of Business:"));
                else
                    this.TESTREPORT.LogFailure("Click Cancel", String.Format("<mark>{0}</mark> is not visible", "Select Line of Business:"), this.SCREENSHOTFILE);
            this.driver.SwitchTo().DefaultContent();
        }

        public void ClickSubmit()
        {
            this.driver.ClickElement(bySubmitButton, "Submit Button");
            
        }

        public void VerifyRequiredfieldErrorMessage(int Count)
        {
            IList<IWebElement> FieldError =driver.FindElements(By.XPath("//td[contains(text(),'Required Field')]"));
            if(FieldError.Count>0&& FieldError.Count== Count)
                this.TESTREPORT.LogSuccess("Verify Required field Error Message", String.Format("Required field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
            else
                this.TESTREPORT.LogFailure("Verify Required field Error Message", String.Format("Required field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
        }

        public void EnterOccurenceDate(string date)
        {
            
            this.driver.ClickElement(byDateOfOccurenceDropdownimage, "Occurence DropDown Image");
            this.driver.ClickElement(byTodayDate,"Today Date in Occurence Calendar");

        }

        public void SelectLocationLoss(string LocationLoss)
        {
            this.driver.ClickElement(byLocationDropdOwnimage,"location dropdown image");
            By byLocationDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", LocationLoss));
            this.driver.ClickElement(byLocationDropDown,"Location Dropdown");
    }

        public void SelectStateOfLoss(string StateOfLoss)
        {
            this.driver.ClickElement(byStateOfLossDropdOwnimage, "StateOfLoss dropdown image");
            By byStateOfLossDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", StateOfLoss));
            this.driver.ClickElement(byStateOfLossDropDown, "Location Dropdown");

        }

        public void EnterContactBusinessPhone(string BusinessContact)
        {
            Thread.Sleep(3000);
            By BusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone");
            this.driver.ClickElement(BusinessPhone, "Business phone textBox");
            this.driver.SendKeysToElementClearFirst(byContactBusinessPhone, BusinessContact,"Business Phone Contact");

        }
        
        public void VerifyDataSaveMessage(string saveMessage)
        {
            By DataSaveMessage = By.XPath(string.Format("//span[contains(text(),'{0}')]", saveMessage));
            this.driver.WaitElementPresent(DataSaveMessage);
            if (this.driver.IsElementPresent(DataSaveMessage))
                this.TESTREPORT.LogSuccess("Verify Data save Message", String.Format("Data Message - <mark>{0}</mark> appeared", saveMessage));
            else
                this.TESTREPORT.LogFailure("Verify Data save Message", String.Format("Data Message - <mark>{0}</mark> doesn't appeared", saveMessage), this.SCREENSHOTFILE);

        }

        public void SwitchToDefaultContent()
        {
            this.driver.SwitchTo().DefaultContent();
        }


    }
}
