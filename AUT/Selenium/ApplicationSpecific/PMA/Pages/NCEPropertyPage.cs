using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
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
    public class NCEPropertyPage : AbstractTemplatePage
    {
        #region UI Objects
        //New ClaimInquiry and auto Form
        private By byDropdOwnimage = By.XPath("//span[@id='MainContent_ddlob_B-1Img']");
        private By byPropertySpan = By.XPath("//span[contains(text(),'Property')]");
        #endregion

        #region LossInformationsection
        private By byLocationDropDownImage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocationloss_B-1Img']");
        private By byDescriptionOfDamage = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_memDamageDesc_I']");
        private By byLocationofLossField = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocationloss_I']");
        private By byTimeofOccurrenceLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_timeEditoccurrence_I']");
        private By byAddressLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempaddress_I']");
        private By byCityLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempcity_I']");
        private By byZipLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtLossZip_I']");
        private By byKindOfLossImg = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddkindofloss_B-1Img']");
        private By byKindOfLoss = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddkindofloss_I']");
        private By byEstimatedLossAmount = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_spEstimateAmount_I']");        
        private By byDescribeLossLI = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_memPropertyDesc_I']");
        #endregion

        #region Claim Submission
        private By byClaimSubmissionBar = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel3_CBImg']");
        private By byClaimSubmissionComments = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel3_memcomment_I']");
        private By byClaimRecordOnly = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel3_chkrecordonly_S_D");
        private By byClaimEmailcheck = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel3_chkEmailCopy_S_D");
        private By byClaimMultipleAdressTextbox = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel3_mememailcc_I']");
        #endregion


        public void VerifyPropertyForm(string propertyText)
        {
            this.driver.WaitElementExistsAndVisible(byDropdOwnimage);
            this.driver.ClickElement(byDropdOwnimage, "Image");
            By bySelectBusinessDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", propertyText));
            this.driver.ClickElement(bySelectBusinessDropDown, "Drop Down value");
            //SWitching to Default..... 
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            //Switching to different frame.....
            this.driver.WaitElementPresent(byPropertySpan);
            if (this.driver.IsElementPresent(byPropertySpan))
                this.TESTREPORT.LogSuccess("Verify Property Form", String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form appeared", propertyText, propertyText));
            else
                this.TESTREPORT.LogFailure("Verify Property Form", String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form not appeared", propertyText, propertyText));
        }
        // Location of Loss
        public void SelectLocationLoss(string LocationLoss)
        {
            this.driver.ClickElement(byLocationDropDownImage, "location dropdown image");
            By byLocationDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", LocationLoss));
            this.driver.ClickElement(byLocationDropDown, "Location of Loss Dropdown");
        }
        //Description of Damage
        public void EnterDescriptionOfDamage(string describelossvalue)
        {
            Thread.Sleep(2000);
            this.driver.SendKeysToElementClearFirst(byDescriptionOfDamage, describelossvalue, "Enter DescribeLoss");
        }

        //Decribe of loss
        public void EnterDescribeLoss(string DescribeLoss)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byDescribeLossLI, "Describe Loss textBox");
            this.driver.SendKeysToElementClearFirst(byDescribeLossLI, DescribeLoss, "Describe Loss textBox");
        }

        public string GetLocationofLoss()
        {

            return (this.driver.GetElementAttribute(byLocationofLossField, "value"));

        }

        public string GetDescriptionOfDamage()
        {
           return (this.driver.GetElementText(byDescriptionOfDamage));

        }        

        //Enter Kind of Loss
        public void EnterKindOfloss(string KindOfLoss)
        {
            this.driver.ClickElement(byKindOfLossImg, "Kind of Loss dropdown image");
            By byKindOfLoss = By.XPath(string.Format("//td[contains(text(),'{0}')]", KindOfLoss));
            this.driver.ClickElement(byKindOfLoss, "Kind of Loss Dropdown");
        }
        //Enter Estimated loss amount
        public void EstimatedLossAmount(string EstimatedLossAmount)
        {
            this.driver.ClickElement(byEstimatedLossAmount, "EstimatedLossAmount");
            this.driver.SendKeysToElementClearFirst(byEstimatedLossAmount, EstimatedLossAmount, "EstimatedLossAmount");
        }
        //Enter data for Claim SUbmission in Property
        public void EnterclaimSubmission(string comments, string EmailAdress)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byClaimSubmissionBar, "Claim Submission Bar");

            this.driver.SendKeysToElementClearFirst(byClaimSubmissionComments, comments, "ClaimSubmissionComments");
            this.driver.ClickElement(byClaimRecordOnly, "Claim record only CheckBox");
            this.driver.ClickElement(byClaimEmailcheck, "Claim Email Check CheckBox");
            this.driver.SendKeysToElementClearFirst(byClaimMultipleAdressTextbox, EmailAdress, "ClaimEmailTextbox");
        }
        //Display the Claim Number
        public void GetClaimNumber()
        {
            string ClaimNumber = this.driver.GetElementText(By.XPath("//span[text()='Claim Number : ']/../following-sibling::td[1]/span"));
            this.TESTREPORT.LogSuccess("Claim Number", string.Format("Claim Number <mark>{0}</mark> created Successfully", ClaimNumber));
        }


    }
}
