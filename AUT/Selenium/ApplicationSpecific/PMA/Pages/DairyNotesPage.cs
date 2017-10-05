using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Engine.Setup;
using AUT.Selenium.CommonReUsablePages;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class DairyNotesPage : AbstractTemplatePage
    {
        #region UI Objects
        //Locators for  Links

        private By byDairyLink = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_T8T");
        private By byCreateEntry = By.XPath("//th[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_col0']//a");
        private By byEmptyData = By.XPath("//div[contains(text(),'There are no diary / note entries for this claim')]");
        private By byListValues = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_DDD_L_LBT']//tr");
        private By bySelectCatogery = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_B-1");
        private By bySubjectTextBox = By.XPath("//label[contains(text(),'Subject:')]/../..//input");
        //private By byNote = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_DDD_L_LBI1T0");
        private By byTextInputBox = By.XPath("//textarea[@class='dxeMemoEditArea dxeMemoEditAreaSys']");
        private By bySave = By.XPath("//span[contains(text(),'Save')]");
       // private By bySubjectText = By.XPath("//tr[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_DXDataRow0']/td[5]");
        private By byColumnsData = By.XPath("//tr[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_DXDataRow0']/td");
        private By byHome = By.LinkText("Home");
        private By byHomeDairy = By.XPath("//tr[@id='MainContent_sppage_pnlDiary_griddiary_DXDataRow0']/td");
       // private By byEdit = By.XPath("//span[contains(text(),'Edit')]");
        private By byEdit = By.LinkText("Edit");
        private By byDelete = By.LinkText("Delete");
        #endregion


        //Click on Dairy Tab
        public void ClickOnDairy()
        {
            VerifyLablePresent(byDairyLink);
            this.TESTREPORT.LogInfo("Click on Dairy");
            this.driver.ClickElement(byDairyLink, "Dairy", 60);
        }
        //Click on Create entry
        public void ClickOnCreateEntry()
        {
            VerifyLablePresent(byCreateEntry);
            this.TESTREPORT.LogInfo("Click on Create Entry Link ");
            this.driver.ClickElement(byCreateEntry, "Create Entry", 60);
        }

        //Verify Dairy Tab
        public void VerifyLablePresent(By element)
        {
            bool flag = this.driver.IsElementPresent(element);
            try
            {
                if (flag)
                {
                    this.TESTREPORT.LogSuccess("Verify lable is present", String.Format(" Successfully verified - <Mark>{0}</Mark> ", "Dairy"));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify lable is present", String.Format("Failed to Verify Lable"), this.SCREENSHOTFILE);
                }
            }
            catch (Exception e)
            {

            }
        }

        //Verify No Entries Text in Dairy tab
        public void VerifyNoEntriesText(string EmptyText)
        {
            this.TESTREPORT.LogInfo("Verify No Entries Text");
            if (this.driver.IsElementPresent(byEmptyData))
            {
                string noEntriesTextExpected = this.driver.GetElementText(byEmptyData, 60);
                this.driver.AssertTextMatching(noEntriesTextExpected, EmptyText);
            }

            else
            {
                this.TESTREPORT.LogInfo("Dairy entry is available");
            }

        }


        //Click on Dropdown
        public void ClickDropDown()
        {
            this.TESTREPORT.LogInfo("Click on Catogery dropdown");
            this.driver.ClickElement(bySelectCatogery, "Catogery", 60);
        }

        //Click on Select value from category dropdown
        public string SelectCategoryDropDown()
        {
            this.TESTREPORT.LogInfo("Select Category from dropdown");
            string selectedValue = null;
            try
            {
                System.Collections.Generic.IReadOnlyList<IWebElement> category = this.driver.FindElements(byListValues);
                category[1].Click();       
                this.TESTREPORT.LogSuccess("Select Random Catogery from dropdown", String.Format("Category - {0} is selcted succesfully", category[1]));
            }
            catch
            {
                this.TESTREPORT.LogFailure("Select Random Catogery from dropdown", String.Format("Category is not selected", this.SCREENSHOTFILE));

            }
            return selectedValue;
        }

        //Enter Text in Subject field
        public void EnterSubjectText(string subject)
        {
            this.TESTREPORT.LogInfo("Enter Subject");
            this.driver.SendKeysToElement(bySubjectTextBox, subject, "Subject");
        }

        //Enter text in text area field

        public void EnterTextInTextArea(string inputText)
        {
            this.TESTREPORT.LogInfo("Enter text in text area");
            this.driver.SendKeysToElement(byTextInputBox, inputText,"inputText");
        }

        //Click on save
        public void ClickSave()
        {
            this.TESTREPORT.LogInfo("Click on Save button");
            this.driver.ClickElement(bySave, "Save", 60);
            Thread.Sleep(5000);
        }


        //Verify Subject and Text from newly created entry

        public void VerifyColumns(string SubjectText, string TextInTextArea)
        {
            this.TESTREPORT.LogInfo("Verify Columns Data");
              
            IReadOnlyList<IWebElement> element = driver.FindElements(byColumnsData);
            this.driver.AssertTextMatching(element[4].Text, SubjectText);
            this.driver.AssertTextMatching(element[5].Text, TextInTextArea);
        }

        //Click on Home
        public void ClickHome()
        {
            this.TESTREPORT.LogInfo("Click on Home tab");
            this.driver.ClickElement(byHome, "Home", 60);
        }

        public void VerifyHomeDairyColumns(string DairyClaimNumber, string DairyClaimantName)
        {
            this.TESTREPORT.LogInfo("Verify My Dairy Columns Data");

            IReadOnlyList<IWebElement> element = driver.FindElements(byHomeDairy);
            if (element.Count != 0)
            {
                this.driver.AssertTextMatching(element[2].Text, DairyClaimNumber);
                this.driver.AssertTextMatching(element[3].Text, DairyClaimantName);
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Home Diary Coloumns","NO records found");
            }
        }
    }
}
