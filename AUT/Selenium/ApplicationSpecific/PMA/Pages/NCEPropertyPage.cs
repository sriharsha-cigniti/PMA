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
        private By byLocationDropDownImage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocationloss_B-1Img']");
        private By byDescriptionOfDamage = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_memDamageDesc_I']");
        private By byLocationofLossField= By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocationloss_I']");
        #endregion



        public void VerifyPropertyForm(string propertyText)
        {
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
        //Describe Loss

        public void EnterDescriptionOfDamage(string describelossvalue)
        {
            Thread.Sleep(2000);
            this.driver.SendKeysToElementClearFirst(byDescriptionOfDamage, describelossvalue, "Enter DescribeLoss");
        }

        public string GetLocationofLoss()
        {

            return (this.driver.GetElementAttribute(byLocationofLossField, "value"));

        }

        public string GetDescriptionOfDamage()
        {
           return (this.driver.GetElementText(byDescriptionOfDamage));

        }

    }
}
