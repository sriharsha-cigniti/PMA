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
    public class ProjectPage : AbstractTemplatePage
    {
        #region UI Object Repository
        //project link
        private By byProjectsLink = By.Id("mProjects");
        //add button
        private By byProjectAddButton = By.Id("CreateProjectSmall");
        //Description
        private By byDescriptionTextBox = By.Id("Description");
        //PurchaseOrder
        private By byPurchaseOrderTextBox = By.Id("PurchaseOrder");
        //save button
        private By bySaveButton = By.XPath("//input[@type='submit' and @value='Save']");
        
        //close
        private By byClose = By.XPath("//a[@class='close-reveal-modal']");

        //search
        private By bySearchTextBox = By.XPath("//div[@class='four columns sectionHeader' and contains(text(),'Projects')]");
        private By bySearchButton = By.XPath("//a[@class='fi-magnifying-glass small circularButton']");
        private By bySearchProjectIdOrDescTextBox = By.Id("SearchTerm");
        private By byApplyFilterButton = By.XPath("//input[@type='submit' and @value='Apply Filter']");
        private By byShowArchivedCheckBox = By.XPath("//span[@class='custom checkbox']");
        private By byCustomerSearchTextBox = By.Id("findClientByName");

        //AddItem
        private By byAddItem = By.XPath("//a[contains(@title,'Add New Item')]");
        private By bySave = By.XPath("//div[contains(text(),'Configuration Details')]/following::a[@class='tiny button' and text()='Save']");
        private By bySaveAndCopy = By.XPath("//div[contains(text(),'Configuration Details')]/following::a[@class='tiny button' and text()='Save&Copy']");
        #endregion
        /// <summary>
        /// /
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private By GetByForProjectItemImages(string text)
        {
            return By.XPath(String.Format("//div[contains(text(),'{0}')]/preceding-sibling::div//img", text));
        }

        private By GetByForDuplicateItemIcon(string accessoryItem, string itemNumber)
        {
            return By.XPath(String.Format("//a[text()='{0}']/preceding::td[span[contains(text(),'{1}')]]/following-sibling::td/a[@title='Duplicate this Item']/i", accessoryItem, itemNumber));
        }

        private By GetByForDeleteItemIcon(string accessoryItem, string itemNumber)
        {
            return By.XPath(String.Format("//a[text()='{0}']/preceding::td[span[contains(text(),'{1}')]]/following-sibling::td/a[@title='Delete this Item']/i", accessoryItem, itemNumber));
        }

        private void OpenProjectModal()
        {
            this.driver.ClickElement(this.byProjectsLink, this.byProjectsLink.ToString());
            this.driver.ClickElement(this.byProjectAddButton, this.byProjectAddButton.ToString());
        }
        //Add Project
        public void AddProject(string projectDescription, string purchaseOrder)
        {

            this.OpenProjectModal();
            this.driver.SendKeysToElementClearFirst(this.byDescriptionTextBox, projectDescription, this.byDescriptionTextBox.ToString());
            this.driver.SendKeysToElementClearFirst(this.byPurchaseOrderTextBox, purchaseOrder, this.byPurchaseOrderTextBox.ToString());
            this.driver.ClickElement(this.bySaveButton, this.bySaveButton.ToString());
            this.SearchProject(projectDescription);


        }

        public void SearchProject(string projectDescription, bool showArchivedProjects = false)
        {
            this.driver.ClickElement(this.byProjectsLink, this.byProjectsLink.ToString());
            this.driver.ClickElement(this.bySearchButton, this.bySearchButton.ToString());
            this.driver.SendKeysToElementClearFirst(this.bySearchProjectIdOrDescTextBox, projectDescription, this.bySearchProjectIdOrDescTextBox.ToString());
            if (showArchivedProjects)
            {
                if (driver.FindElement(this.byShowArchivedCheckBox).Selected == false)
                {
                    this.driver.ClickElement(this.byShowArchivedCheckBox, this.byShowArchivedCheckBox.ToString());
                }
            }
            this.driver.ClickElement(this.byApplyFilterButton, this.byApplyFilterButton.ToString());
            this.SimulateThinkTimeInMilliSecs(1000);
            this.WatchSpinner();
            //verify 
            By byProjectRow = By.XPath(String.Format("//td[@title='{0}']", projectDescription));           
            List<By> listObjects = new List<By>();
            listObjects.Add(byProjectRow);
            this.VerifyObjectsPresence(listObjects);
        }

        public void AssignCustomer(string projectDescription, string customerName)
        {
            this.SearchProject(projectDescription);
            this.driver.SendKeysToElementClearFirst(this.byCustomerSearchTextBox, customerName, this.byCustomerSearchTextBox.ToString());
            By bySelectCustomerAutoComplete = By.PartialLinkText(customerName);
            this.driver.ClickElement(bySelectCustomerAutoComplete, bySelectCustomerAutoComplete.ToString());

            //verify Assignment successful
            By byAssoicationLink = By.XPath("//div[contains(text(),'Customer')]//a[1]");
            Dictionary<object, string> keyPairLabelExpVal = new Dictionary<object, string>();
            keyPairLabelExpVal[byAssoicationLink] = customerName;
            this.VerifyValuesAgainstByObjects(keyPairLabelExpVal, null);
        }

        public void AddProjectItems(string projectDescription, string itemType, string accessoryItem, string itemNumber = "0001")
        {
            this.SearchProject(projectDescription);

            //read accessoryItem count before adding items to project
            By byAccessoryItem = By.LinkText(accessoryItem);
            int? previousCount = this.driver.FindElements(byAccessoryItem).Count;

            //click Add Button
            this.driver.ClickElement(this.byAddItem, this.byAddItem.ToString());

            //get by for image corrosponding to itemType
            By by = this.GetByForProjectItemImages(itemType);
            this.driver.ClickElement(by, by.ToString());

            //get by for image corrosponding to accessoryItem
            by = this.GetByForProjectItemImages(accessoryItem);
            this.driver.ClickElement(by, by.ToString());

            //click on Update against Item Text box
            by = By.XPath("//form[@id='ItemNameForm']//input[@type='submit' and @value='Update']");
            this.driver.ClickElement(by, by.ToString());
            
            //verify message 
            by = By.XPath("//span[contains(text(),'Item name cannot be empty')]");
            List<By> listObjects = new List<By>();
            listObjects.Add(by);
            this.VerifyObjectsPresence(listObjects);

            //click on save            
            this.driver.ClickElement(bySave, bySave.ToString());
            
            //verify Item got added
            this.SimulateThinkTimeInMilliSecs(1000);
            this.WatchSpinner();
            //verify current count should be greater than previous count by 1
            int? currentCount = this.driver.FindElements(byAccessoryItem).Count;
            if (currentCount == (previousCount + 1))
            {
                this.TESTREPORT.LogSuccess("AddProjectItems", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount + 1, currentCount), this.SCREENSHOTFILE);
            }
            else
            {
                this.TESTREPORT.LogFailure("AddProjectItems", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount + 1, currentCount), this.SCREENSHOTFILE);
            }

        }

        public void DuplicateProjectItem(string projectDescription, string accessoryItem, string itemNumber)
        {
            this.SearchProject(projectDescription);
            By byAccessoryItem = By.LinkText(accessoryItem);

            int? previousCount = this.driver.FindElements(byAccessoryItem).Count;
            //click on Copy icon
            By byDuplicateIcon = this.GetByForDuplicateItemIcon(accessoryItem, itemNumber);
            this.driver.ClickElement(byDuplicateIcon, byDuplicateIcon.ToString());
            this.SimulateThinkTimeInMilliSecs(1000);
            this.WatchSpinner();
            //verify current count should be greater than previous count by 1
            int ? currentCount = this.driver.FindElements(byAccessoryItem).Count;
            if (currentCount == (previousCount + 1))
            {
                this.TESTREPORT.LogSuccess("DuplicateProjectItem", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount + 1, currentCount), this.SCREENSHOTFILE);
            }
            else
            {
                this.TESTREPORT.LogFailure("DuplicateProjectItem", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount + 1, currentCount), this.SCREENSHOTFILE);
            }

        }

        public void DeleteProjectItem(string projectDescription, string accessoryItem, string itemNumber)
        {
            this.SearchProject(projectDescription);
            By byAccessoryItem = By.LinkText(accessoryItem);

            int? previousCount = this.driver.FindElements(byAccessoryItem).Count;
            //click on Delete icon
            By byDeleteIcon = this.GetByForDeleteItemIcon(accessoryItem, itemNumber);
            this.driver.ClickElement(byDeleteIcon, byDeleteIcon.ToString());
            By byDeleteConfirmationButton = By.XPath("//div[@id='MessageBox']//a[text()='Yes']");
            this.driver.ClickElement(byDeleteConfirmationButton, byDeleteConfirmationButton.ToString());
            this.SimulateThinkTimeInMilliSecs(1000);
            this.WatchSpinner();
            //verify current count should be greater than previous count by 1
            int? currentCount = this.driver.FindElements(byAccessoryItem).Count;
            if (currentCount == (previousCount - 1))
            {
                this.TESTREPORT.LogSuccess("DeleteProjectItem", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount - 1, currentCount), this.SCREENSHOTFILE);
            }
            else
            {
                this.TESTREPORT.LogFailure("DeleteProjectItem", String.Format("Expected Total Count Of Accessory Item - {0} = {1}, Actual Count = {2}", accessoryItem, previousCount - 1, currentCount), this.SCREENSHOTFILE);
            }

        }
    }
}
