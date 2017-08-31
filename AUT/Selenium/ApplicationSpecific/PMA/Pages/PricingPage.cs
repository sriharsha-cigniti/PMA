using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;

namespace AUT.Selenium.ApplicationSpecific.EdgeNet.Pages
{
    public class PricingPage : AbstractTemplatePage
    {
        private By byPricingLink = By.Id("mPricing");
        private By byPriceAddButton = By.Id("CreatePricingSmall");
        private By byTemplateDescription = By.Id("AdjustmentTemplate_Description");
        private By byCustomCheckBox = By.XPath("//span[@class='custom checkbox']");
        private By bySaveButton = By.XPath("//input[@type='submit' and @value='Save']");
        //close
        private By byClose = By.XPath("//a[@class='close-reveal-modal']");


        private void OpenPricingModal()
        {
            this.driver.ClickElement(this.byPricingLink, this.byPricingLink.ToString());
            this.driver.ClickElement(this.byPriceAddButton, this.byPriceAddButton.ToString());

        }
        public void IntentionalFailure()
        {
            this.OpenPricingModal();
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            Dictionary<object, string> keyPairLabelExpVal = new Dictionary<object, string>();
            keyPairLabelExpVal["AdjustmentTemplate_Description"] = "Intentional Failure Where Field Label Message Does Not Match";
            this.VerifyValuesAgainstByObjects(keyPairLabelExpVal, "//span[@for='{0}']");
            //close
            this.driver.ClickElement(this.byClose, this.byClose.ToString());
        }
        public void ValidateMandatoryFields()
        {
            this.OpenPricingModal();
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            Dictionary<object, string> keyPairLabelExpVal = new Dictionary<object, string>();
            keyPairLabelExpVal["AdjustmentTemplate_Description"] = "The Description field is required.";
            this.VerifyValuesAgainstByObjects(keyPairLabelExpVal, "//span[@for='{0}']");
            //close
            this.driver.ClickElement(this.byClose, this.byClose.ToString());
        }
        public void AddPricingTemplate(string description)
        {
            this.OpenPricingModal();
            this.driver.SendKeysToElementClearFirst(this.byTemplateDescription, description, this.byTemplateDescription.ToString());
            if (!this.driver.FindElement(this.byCustomCheckBox).Selected)
            {
                this.driver.ClickElement(this.byCustomCheckBox, this.byCustomCheckBox.ToString());
            }
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());

        }
    }
}
