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
using System.Collections;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class DiaryNotesPage : AbstractTemplatePage
    {
        HomePage home = new HomePage();
        #region UI Objects
        //Locators for  Links

        public By byDairyLink = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_T8T");
        private By byCreateEntry = By.XPath("//th[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_col0']//a");
        private By byNoEntriesText= By.XPath("//div[contains(text(),'There are no diary / note entries for this claim')]");
        private By byListValues = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_DDD_L_LBT']//tr");
        private By bySelectCatogery = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_B-1");
        private By bySubjectTextBox = By.XPath("//label[contains(text(),'Subject:')]/../..//input");
        //private By byNote = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_efnew_0_DXEFL_DXEditor2_DDD_L_LBI1T0");
        private By byTextInputBox = By.XPath("//textarea[contains(@class,'dxeMemoEditArea')]");
        private By bySave = By.XPath("//span[contains(text(),'Save')]");
        // private By bySubjectText = By.XPath("//tr[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_DXDataRow0']/td[5]");
        private By byColumnsData = By.XPath("//tr[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_DXDataRow0']/td");
        private By byHome = By.LinkText("Home");
        private By byHomeDairy = By.XPath("//tr[@id='MainContent_sppage_pnlDiary_griddiary_DXDataRow0']/td");
        private By byHomeDairyCount = By.XPath("//tr[contains(@id,'MainContent_sppage_pnlDiary_griddiary_DXDataRow')]");
        private By byDairyClaimNumber = By.XPath("//tr[contains(@id,'MainContent_sppage_pnlDiary_griddiary_DXDataRow')]/td[2]");
        private By byDairyClaimantName = By.XPath("//tr[contains(@id,'MainContent_sppage_pnlDiary_griddiary_DXDataRow')]/td[3]");
       // private By byEdit = By.XPath("//span[contains(text(),'Edit')]");
        private By byEdit = By.LinkText("Edit");
        private By byDelete = By.LinkText("Delete");

        private By bySelectStatus = By.XPath("//td[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_ef0_0_DXEFL_0_DXEditor3_B-1']");
        private By byStatusList = By.XPath("//table[@id='MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_ef0_0_DXEFL_0_DXEditor3_DDD_L_LBT']/tbody/tr");            
        private By byDueDate = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_ef0_0_DXEFL_0_DXEditor4_B-1Img");
        private By byToday = By.Id("MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_ef0_0_DXEFL_0_DXEditor4_DDD_C_BT");
        private By byEntryCount = By.XPath("//tr[contains(@id,'MainContent_dvclaims_IT0_usrdetail1_0_ASPxPageControl1_0_usrdiary1_0_griddiary_0_DXDataRow')]");
        public By byMyDiaryResultsTable = By.XPath("//table[@id='MainContent_sppage_pnlDiary_griddiary_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
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
            this.driver.WaitElementPresent(byCreateEntry, 60);
            VerifyLablePresent(byCreateEntry);
            this.TESTREPORT.LogInfo("Click on Create Entry Link ");
            this.driver.ClickElement(byCreateEntry, "Create Entry", 60);
        }
        // verify Diary lable
        public void VerifyDiaryLable()
        {
            Thread.Sleep(3000);
            VerifyLablePresent(byDairyLink);
            
        }

        //Verify Dairy Tab lable present 
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

        
        public void VerifyDiaryCount(int beforeCount)
        {
            int results = this.driver.FindElements(byMyDiaryResultsTable).Count;
            if (results == beforeCount)
            {

                this.TESTREPORT.LogSuccess("Verify MyDiaryCount after deletion", String.Format("Results - {0} are displayed succesfully", results));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify MyDiaryCount after deletion", String.Format("Failed to delete from home page"), this.SCREENSHOTFILE);
            }

        }

        //Get Dairy Count from Home page
        public int GetDiaryCount()
        {
            int beforeCount = this.driver.FindElements(byMyDiaryResultsTable).Count;
            if (beforeCount != 0)
            {

                this.TESTREPORT.LogSuccess("Verify MyDiaryCount from home page", String.Format("Results - {0} are displayed succesfully", beforeCount));
            }
            else
            {
                this.TESTREPORT.LogInfo(String.Format("There are no records found in Mydairy Section"));
            }
            return beforeCount;
        }

        //Verify No Entries Text in Dairy tab
        public void VerifyNoEntriesText(string EmptyText)
        {
            this.TESTREPORT.LogInfo("Verify No Entries Text");
            //this.driver.WaitElementPresent(byNoEntriesText);

            if (this.driver.IsElementPresent(byNoEntriesText))
            {
                string noEntriesTextExpected = this.driver.GetElementText(byNoEntriesText, 60);
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
        public string SelectCategoryDropDown(string Value)
        {
            this.TESTREPORT.LogInfo("Select Category from dropdown");
            string selectedValue = null;
            try
            {
                // System.Collections.Generic.IReadOnlyList<IWebElement> category = this.driver.FindElements(byListValues);
                IList<IWebElement> category = this.driver.FindElements(byListValues);
                for (int i = 0; i < category.Count; i++)
                {
                    if ((Value.Trim()).Equals(category[i].Text.Trim()))
                    {
                        category[i].Click();                        
                        break;
                    }
                }
               
                this.TESTREPORT.LogSuccess("Select Dairy from Catogery dropdown", String.Format("Category - {0} is selcted succesfully", category[0]));
            }
            catch
            {
                this.TESTREPORT.LogFailure("Select Dairy from Catogery dropdown", String.Format("Category is not selected", this.SCREENSHOTFILE));

            }
            return selectedValue;
        }

        //Enter Text in Subject field
        public void EnterSubjectText(string subject)
        {
            this.TESTREPORT.LogInfo("Enter Subject");
            //this.driver.SendKeysToElement(bySubjectTextBox, subject, "Subject");
            this.driver.SendKeysToElementClearFirst(bySubjectTextBox, subject, "Subject");
        }

        //Enter text in text area field

        public void EnterTextInTextArea(string inputText)
        {
            this.driver.WaitElementPresent(byTextInputBox, 60);
            this.TESTREPORT.LogInfo("Enter text in text area");
           // this.driver.SendKeysToElement(byTextInputBox, inputText, "inputText");
            this.driver.SendKeysToElementClearFirst(byTextInputBox, inputText, "inputText");
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
            this.driver.WaitElementPresent(byColumnsData);
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

            IReadOnlyList<IWebElement> element = driver.FindElements(byHomeDairyCount);
            IReadOnlyList<IWebElement> ClaimNumberDairyTable = driver.FindElements(byDairyClaimNumber);
            IReadOnlyList<IWebElement> ClaimantNameDairyTable = driver.FindElements(byDairyClaimantName);
            if (element.Count != 0)
            {                
                    for (int j = 0; j < ClaimNumberDairyTable.Count; j++)
                    {
                        string ClaimNumber = ClaimNumberDairyTable[j].Text;
                        string ClaimantName = ClaimantNameDairyTable[j].Text;
                        if (ClaimNumber.Equals(DairyClaimNumber))
                        {
                            this.TESTREPORT.LogSuccess("Claim Number Verified successfully", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", ClaimNumber, DairyClaimNumber));
                            this.driver.AssertTextMatching(ClaimantName, DairyClaimantName);
                            break;
                        }
                    }
                
            }

            else
            {
               this.TESTREPORT.LogFailure("Verify Home Diary Table Count", String.Format("Dairy Entry is not created"), this.SCREENSHOTFILE);
            }
        }

        //Click on Edit
        public void ClickEdit()
        {
            this.driver.WaitElementExistsAndVisible(byEdit);          
            this.TESTREPORT.LogInfo("Click on Edit Link");
            this.driver.ClickElement(byEdit, "Edit", 60);
            Thread.Sleep(3000);
        }

        //Click on Status Dropdown
        public void ClickStatusDropDown()
        {
            this.TESTREPORT.LogInfo("Click on Status dropdown");
            this.driver.ClickElement(bySelectStatus, "Status", 60);
        }

        //Select the value from Status drop down
        public string SelectStatusDropDown(string Value)
        {
            this.TESTREPORT.LogInfo("Select Status from dropdown");
            string selectedValue = null;
            try
            {
                System.Collections.Generic.IReadOnlyList<IWebElement> Status = this.driver.FindElements(byStatusList);
                for (int i = 0; i < Status.Count; i++)
                {
                    if (Value.Equals(Status[i].Text))
                    {
                        Status[i].Click();
                    }
                }
                
                this.TESTREPORT.LogSuccess("Select Status from dropdown", String.Format("Status - {0} is selcted succesfully", Status[0]));
            }
            catch
            {
                this.TESTREPORT.LogFailure("Select Status from dropdown", String.Format("Status is not selected", this.SCREENSHOTFILE));

            }
            return selectedValue;
        }


        //Select date from due date dropdown
        public void  DueDate()
        {
            this.TESTREPORT.LogInfo("Click on Today date from Calender");
            this.driver.ClickElement(byDueDate, "DueDate", 60);
            this.driver.WaitElementPresent(byToday, 60);
            this.driver.ClickElement(byToday, "Today", 60);
        }
        
        //Click on Delete
        public void ClickDelete()
        {
            Thread.Sleep(3000);
            this.driver.WaitElementExistsAndVisible(byDelete);
            this.TESTREPORT.LogInfo("Click on Delete Link");
            this.driver.ClickElement(byDelete, "Delete", 60);
            //Thread.Sleep(3000);
        }

        //Verify Claimant Name  in ClaimInformation Page
        public void VerifyClaimantName(string ClaimantNameExpected)
        {   
            //if (ClaimantNameExpected.Contains(','))
            //{
            //    ClaimantNameExpected = ClaimantNameExpected.Split(',')[0];
            //    //String CNameLast = ClaimantNameExpected.Split(',')[1];
            //    //ClaimantNameExpected = CNameLast + " " + CNameFirst;
            //}
           
            string ActualAccountName = this.driver.GetElementText(HomePage.byClaimInformationClaimantName);            
            bool flag = false;
            if (ActualAccountName.Trim().ToLower().Contains(ClaimantNameExpected.Trim().ToLower()))
            {
                flag = true;
            }
            if (flag)
                TESTREPORT.LogSuccess("Name is Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are matching", ActualAccountName, ClaimantNameExpected));
            else
                TESTREPORT.LogFailure("Name is not Matching", String.Format("Actual: <mark>{0}</mark>,Expected: <mark>{1}</mark> are not matching", ActualAccountName, ClaimantNameExpected), this.SCREENSHOTFILE);

        }

        public string GenerateRandomNumber()
        {
            return DateTime.Now.ToString("hh:mm:ss").Replace(":", "");
        }




    }
}
