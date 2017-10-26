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
    public class NCEWorkersCompensationPage : AbstractTemplatePage
    {
        #region UI Objects
        private By byState = By.XPath("//label[contains(text(),'State:')]");
        private By byStateDropDown = By.Id("MainContent_ddstate_B-1Img");
        private By byEmployeeNotOnListButton = By.XPath("//div[@id='MainContent_btnEmployee_CD']/span[contains(text(),'Employee Not On List')]");
        private By byFrameId = By.Id("MainContent_ASPxSplitter1_0_CC");
        private By byWCText = By.XPath("//div[@id='MainContent_up1']//span[@id='MainContent_Label6']");
        private By byLocationDropDown = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_B-1Img");
        private By byFirstName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempfname_I");
        private By byLastName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtemplname_I");
        private By byAddress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempaddress_I");
        private By byCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempcity_I");
        private By byWCStates = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempstate_B-1Img");
        private By byZip = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempzip_I");
        private By byBirthDate = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtempbirthdate_I");
        private By bySSN = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempssn_I");
        private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        private By byOccurenceInformationMenu = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
        private By byDateOfInjury = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInjury_I");
        private By byAccidentCauseDD = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddaccidentcause_B-1Img");
        private By byInjuryTypeDD = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurytype_B-1Img");
        private By byBodyPartDD = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddbodypart_B-1Img");
        private By byAccidentDescription = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_memaccidentdesc_I");
        private By byDateEmployerNotified = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtemployernotified_I");
        private By byIsInjuryWorkedLosingTimeText = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddIWLosingTime_I");
        private By byIsInjuredWorkerOnModifiedDutyText = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddIWModDuty_I");
        private By byDateDisabilityBegan = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtDisabilityBegan_I");
        private By byLossLocationAdress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtinjuryaddress_I");
        private By byLossLocationCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtinjurycity_I");
        private By byLossLocationState = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurystate_B-1Img");
        private By byLossLocationZip = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtinjuryzip_I");
        private By byWorkGroupAdress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtWorkAddress_I");
        private By byWorkCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtWorkCity_I");
        private By byWorkState = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddWorkState_B-1Img");
        private By byContactInformationBar = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
        private By byContactTelePhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtpreparerphone_I");
        private By byDateOfInjuryImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInjury_B-1Img");
        private By byClearButton = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInjury_DDD_C_BC");
        private By bySubmit = By.XPath("//div[@id='MainContent_btnSubmit_CD']//span[contains(text(),'Submit')]");
        private By byMiddleName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempmiddlename_I");
        private By bySuffixImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempsuffix_B-1Img");
        private By byGender = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempSex_B-1Img");
        private By byTelePhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtempphone_I");
        private By byHireImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtemphiredate_B-1Img");
        private By byMaritalStatus = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempmaritalstatus_B-1Img");
        //table[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtemphiredate_DDD_C_mt']//tr[@class='dx-ac']//following-sibling::tr/td[contains(text(),'3')]
        private By byNoOfDependents = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempdependents_B-1Img");
        //private By bySSN = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsideofbody_B-1Img");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_tmemployeebeganwork_B-2Img");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_mt");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_NMCImg");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");
        //private By byOccupation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_txtOccupation_I");

        #endregion

        #region Public Methods

        public void SelectWorkersCompensationAndVerifyState(string dropDOwnText)
        {
            VerifyForm(dropDOwnText, byState);
        }

        public void SelectStateFromDropDown(string StateText)
        {
            SelectDropDown(StateText, byStateDropDown);
        }

        public void ClickOnEmployeeNotOnList()
        {
            this.driver.SwitchToDefaultFrame();
            this.driver.SwitchToFrameByLocator(byFrameId);
            this.driver.ClickElement(byEmployeeNotOnListButton, "Employee Not In List Button");
        }

        public void ValidateText(string valueToVerify)
        {
            this.TESTREPORT.LogInfo(string.Format("Workers compensation Text : {0}", this.driver.GetElementText(byWCText)));
            this.driver.AssertTextMatching(this.driver.GetElementText(byWCText), valueToVerify);
        }

        public void FillAllRequiredFieldsInWCForm(string Location, string FirstName, string LastName, string Adress, string City, string Zip, string DOB, string SSN, string Occupation, string DateOfInjury, string AccidentCause, string InjuryType, string BodyPart, string Description, string IsInjuredWorkerLosingTime, string IsInjuredWorkerModifiedShift, string State, string PreparerPhone, string date)
        {
            SelectDropDown(Location, byLocationDropDown);
            this.driver.SendKeysToElementClearFirst(byFirstName, FirstName, "Employee FirstName");
            this.driver.SendKeysToElementClearFirst(byLastName, LastName, "Employee LastName");
            this.driver.SendKeysToElementClearFirst(byAddress, Adress, "Employee Address");
            this.driver.SendKeysToElementClearFirst(byCity, City, "Employee City");
            SelectDropDown(State, byWCStates);
            this.driver.SendKeysToElementClearFirst(byZip, Zip, "Employee Zip");

            this.driver.ClickElement(byBirthDate, "Employee Date Of Birth");
            this.driver.SendKeysToElement(byBirthDate, DOB, "Employee Date Of Birth");

            this.driver.SendKeysToElementClearFirst(bySSN, SSN, "Employee SSN");
            this.driver.SendKeysToElementClearFirst(byOccupation, Occupation, "Employee Occupation");

            this.driver.ClickElement(byOccurenceInformationMenu, "Occurence Information");
            this.driver.ClickElement(byIsInjuryWorkedLosingTimeText, "IsInjuryWorkedLosingTimeText");
            this.driver.SendKeysToElementClearFirst(byIsInjuryWorkedLosingTimeText, IsInjuredWorkerLosingTime, "IsInjuredWorkerLosingTime");

            this.driver.ClickElement(byDateOfInjury, "Date of Injury");
            this.driver.SendKeysToElement(byDateOfInjury, DateOfInjury, "Date of Injury");
            SelectDropDown(AccidentCause, byAccidentCauseDD);
            SelectDropDown(InjuryType, byInjuryTypeDD);
            SelectDropDown(BodyPart, byBodyPartDD);
            this.driver.SendKeysToElementClearFirst(byAccidentDescription, Description, "Accident Description");

            this.driver.ClickElement(byDateEmployerNotified, "Employee Notified");
            this.driver.SendKeysToElement(byDateEmployerNotified, date, "Employee Notified");

            this.driver.ClickElement(byIsInjuredWorkerOnModifiedDutyText, "IsInjuredWorkerOnModifiedDuty");
            this.driver.SendKeysToElementClearFirst(byIsInjuredWorkerOnModifiedDutyText, IsInjuredWorkerModifiedShift, "IsInjuredWorkerOnModifiedDuty");

            this.driver.ClickElement(byDateDisabilityBegan, "Date of Disability");
            this.driver.SendKeysToElement(byDateDisabilityBegan, date, "Date of Disability");

            this.driver.SendKeysToElementClearFirst(byLossLocationAdress, Adress, "Loss Location Address");
            this.driver.SendKeysToElementClearFirst(byLossLocationCity, City, "Loss Location City");

            SelectDropDownWithParent(State, byLossLocationState, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurystate_DDD_L_LBT");

            this.driver.SendKeysToElementClearFirst(byLossLocationZip, Zip, "Loss Location Zip");
            this.driver.SendKeysToElementClearFirst(byWorkGroupAdress, Adress, "Work Group Address");
            this.driver.SendKeysToElementClearFirst(byWorkCity, City, "Work Group City");
            SelectDropDownWithParent(State, byWorkState, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddWorkState_DDD_L_LBT");

            this.driver.ClickElement(byContactInformationBar, "Contact Information");
            this.driver.ClickElement(byContactTelePhone, "TelePhones textBox");
            this.driver.SendKeysToElementClearFirst(byContactTelePhone, PreparerPhone, "TelePhone");
        }

        public void ClickOnSubmitButton()
        {
            this.driver.ClickElement(bySubmit, "Submit Button");
        }

        public void FillRequiredFieldsForSaveDraftInWCForm(string Location, string FirstName, string LastName, string DateOfInjury, string Description)
        {
            SelectDropDown(Location, byLocationDropDown);
            this.driver.SendKeysToElementClearFirst(byFirstName, FirstName, "Employee FirstName");
            this.driver.SendKeysToElementClearFirst(byLastName, LastName, "Employee LastName");

            this.driver.ClickElement(byOccurenceInformationMenu, "Occurence Information");

            this.driver.ClickElement(byDateOfInjury, "Date of Injury");
            this.driver.SendKeysToElement(byDateOfInjury, DateOfInjury, "Date of Injury");
            this.driver.SendKeysToElementClearFirst(byAccidentDescription, Description, "Accident Description");
        }

        public void VerifySavedGridText(string saveDraftText)
        {
            By bysaveDraftText = By.XPath(string.Format("//table[@id='MainContent_griddata_DXMainTable']/caption[contains(text(),'')]", saveDraftText));
            this.driver.WaitElementPresent(bysaveDraftText);
            if (this.driver.IsElementPresent(bysaveDraftText))
            {
                this.TESTREPORT.LogSuccess("Verify Text On Table", string.Format("Text - <mark>{0}</mark> appeared", saveDraftText));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Text On Table", string.Format("Text -<mark>{0}</mark> is not appeared", saveDraftText));
            }
        }

        public void VerifyInvalidFormatErrorMessage(int Count)
        {
            IList<IWebElement> FieldError = driver.FindElements(By.XPath("//td[contains(text(),'Invalid Format')]"));
            if (FieldError.Count > 0 && FieldError.Count == Count)
                this.TESTREPORT.LogSuccess("Verify InvalidFormat field Error Message", String.Format("InvalidFormat field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
            else
                this.TESTREPORT.LogFailure("Verify InvalidFormat field Error Message", String.Format("InvalidFormat field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
        }

        public void VerifyDate(string valueToVerify)
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

            this.driver.ClickElement(byOccurenceInformationMenu, "Occurence Information");
            string value = this.driver.GetElementAttribute(byDateOfInjury, "value");

            if (valueToVerify.Trim().ToLower().Contains(value.Trim().ToLower()))
            {
                this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is equal", value, valueToVerify));
            }
            else
            {
                this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is not equal", value, valueToVerify));
            }
        }

        public void ClickOnClearButtonInDD()
        {
            this.driver.ClickElement(byOccurenceInformationMenu, "Occurence Information");
            Thread.Sleep(2000);
            this.driver.ClickElement(byDateOfInjuryImg, "Date of Injury DropDown Image");
            Thread.Sleep(2000);
            this.driver.ClickElement(byClearButton, "Clear the date");
        }
        #endregion

    }
}
