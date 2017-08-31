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
    public class CustomerPage: AbstractTemplatePage
    {
        #region UI Object Repository
        //Customers Link
        private By byCustomerLink = By.Id("mCustomers");
        //add button
        private By byCustomerAddButton = By.Id("CreateDealerSmall");
        //Company Name
        private By byCompanyNameTextBox = By.Id("Name");
        //Internal Customer Id
        private By byCustomerIdTextBox = By.Id("CustomerId");
        //First Name
        private By byFirstNameTextBox = By.Id("Contact_FirstName");

        //LastName
        private By byLastNameTextBox = By.Id("Contact_LastName");
        //WorkPhone
        private By byWorkPhoneTextBox = By.Id("Contact_WorkPhone");
        //CellPhone
        private By byCellPhoneTextBox = By.Id("Contact_CellPhone");
        //Email
        private By byEmailTextBox = By.Id("Contact_Email");

        //Save
        private By bySaveButton = By.Id("newCustomerSubmit");

        //close
        private By byClose = By.XPath("//a[@class='close-reveal-modal']");

        //search

        private By bySearchButton = By.XPath("//span[@class='fi-magnifying-glass small']");
        private By bySearchCompanyNameTextBox = By.Id("SearchTerm");
        private By byApplyFilterButton = By.XPath("//input[@type='submit' and @value='Apply Filter']");
        #endregion
        private void OpenCustomerModal()
        {
            this.driver.ClickElement(this.byCustomerLink, this.byCustomerLink.ToString());
            this.driver.ClickElement(this.byCustomerAddButton, this.byCustomerAddButton.ToString());
        }
        public void IntentionalFailure()
        {
            this.OpenCustomerModal();
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            //validate message for mandatory fields
            Dictionary<object, string> keyPairLabelExpVal = new Dictionary<object, string>();
            keyPairLabelExpVal["Name"] = "Demonstration Of Intentional Failure";
            this.VerifyValuesAgainstByObjects(keyPairLabelExpVal, "//span[@for='{0}']");
            //close
            this.driver.ClickElement(this.byClose, this.byClose.ToString());
        }
        public void ValidateMandatoryFields()
        {
            this.OpenCustomerModal();
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            //validate message for mandatory fields
            Dictionary<object, string> keyPairLabelExpVal = new Dictionary<object, string>();
            keyPairLabelExpVal["Name"] = "The Company name field is required.";
            keyPairLabelExpVal["CustomerId"] = "The Internal Customer Id: field is required.";
            keyPairLabelExpVal["Contact_FirstName"] = "The First Name: field is required.";
            keyPairLabelExpVal["Contact_LastName"] = "The Last Name: field is required.";
            keyPairLabelExpVal["Contact_WorkPhone"] = "The Work Phone: field is required.";
            keyPairLabelExpVal["Contact_Email"] = "The Email address: field is required.";
            this.VerifyValuesAgainstByObjects(keyPairLabelExpVal, "//span[@for='{0}']");
            //close
            this.driver.ClickElement(this.byClose, this.byClose.ToString());
        }

        public void CreateCustomer(string companyName, string customerId, string firstName, string lastName, string workPhone, string cellPhone, string email)
        {
            this.OpenCustomerModal();
            this.driver.SendKeysToElementClearFirst(this.byCompanyNameTextBox, companyName, this.byCompanyNameTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byCustomerIdTextBox, customerId, this.byCustomerIdTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byFirstNameTextBox, firstName, this.byFirstNameTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byLastNameTextBox, lastName, this.byLastNameTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byWorkPhoneTextBox, workPhone, this.byWorkPhoneTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byCellPhoneTextBox, cellPhone, this.byCellPhoneTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byEmailTextBox, email, this.byEmailTextBox.ToString());
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            this.SearchCustomer(companyName);

            
        }

        public void SearchCustomer(string companyName)
        {
            this.driver.ClickElement(this.byCustomerLink, this.byCustomerLink.ToString());
            this.driver.ClickElement(this.bySearchButton, this.bySearchButton.ToString());
            this.driver.SendKeysToElementClearFirst(this.bySearchCompanyNameTextBox, companyName, this.bySearchCompanyNameTextBox.ToString());
            this.driver.ClickElement(this.byApplyFilterButton, this.byApplyFilterButton.ToString());

            //verify
            By byCustomer = By.LinkText(companyName);
            List<By> listObjects = new List<By>();
            listObjects.Add(byCustomer);
            this.VerifyObjectsPresence(listObjects);
        }
    }
}
