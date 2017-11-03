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
        private By byEmployeeInformationMenu = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
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
        private By byEmployeeStatus = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempstatus_B-1Img");
        //table[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtemphiredate_DDD_C_mt']//tr[@class='dx-ac']//following-sibling::tr/td[contains(text(),'3')]
        private By byNoOfDependents = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempdependents_B-1Img");
        private By bySideOfBody = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsideofbody_B-1Img");
        private By byEmpBeganWorkImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_tmemployeebeganwork_B-2Img");
        private By byExpectedToWorImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_B-1");
        private By byExpectedWorkMT = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_mt");
        private By byExpectedWorkNMT = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_NMCImg");
        private By byFullpayinjury = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddFullPayInjury_I");
        private By byHoursPerDay = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddhrswrkperday_B-1Img");
        private By byTimeEditOccurenceImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_timeEditoccurrence_B-2Img");
        private By byLstWorkDt = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtlastworkdate_I");
        private By byReturnWorkTodayButton = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtReturnedToWork_DDD_C_BT");
        private By byPaymentFreq = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddpaymentfreq_B-1Img");
        private By byReturnedworkImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtReturnedToWork_B-1Img");
        private By bydddaysworperweek = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddaysworperweek_B-1");
        private By bydtModifiedDutyBegan = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtModifiedDutyBegan_B-1Img");
        private By byModifiedDutyBeganTB = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtModifiedDutyBegan_DDD_C_BT");
        private By byinjuryoccur = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtinjuryoccur_I");
        private By byWorkZip = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtWorkZip_I");
        private By byemployeeinjuredImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeeinjured_B-1Img");
        private By byinjurypremisesImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurypremises_B-1Img");
        private By bysafeguardsprovidedImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovided_B-1Img");
        private By byemployerquestionclaimImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployerquestionclaim_B-1Img");
        private By bydrugsinvolvedImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddrugsinvolved_B-1Img");
        private By byemployeerepresented = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeerepresented_B-1Img");
        private By bysafeguardsprovidedused = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovidedused_B-1Img");
        private By byphysicianname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtphysicianname_I");
        private By byphysicianaddress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtphysicianaddress_I");
        private By byPhysicianPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtphysicianphone_I");
        private By byphysiciancity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtphysiciancity_I");
        private By byphysicianstateImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddphysicianstate_B-1Img");
        private By byphysicianzip = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtphysicianzip_I");
        private By byhospitalname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txthospitalname_I");
        private By byhospitalphone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txthospitalphone_I");
        private By byhospitaladdress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txthospitaladdress_I");
        private By byhospitalcity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txthospitalcity_I");
        private By byhospitalstateImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddhospitalstate_B-1Img");
        private By byhospitalzip = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txthospitalzip_I");
        private By byemployerfirstname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtemployerfirstname_I");
        private By byemployerlastname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtemployerlastname_I");
        private By byemployerphone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtemployerphone_I");
        private By bywitnesslastname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtwitnesslastname_I");
        private By bywitnessfirstname = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtwitnessfirstname_I");
        private By bywitnessphone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtwitnessphone_I");
        private By byComments = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_memcomment_I");
        private By byChkrecordonly = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_chkrecordonly_S_D");
        private By byEmailCopyCheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_chkEmailCopy_S_D");
        private By byMultipleemails = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_mememailcc_I");
        private By bySearchButton = By.Id("MainContent_btnSearch_CD");
        private By bySearchLstName = By.Id("MainContent_txtlname_I");
        private By bySearchID = By.Id("MainContent_txtID_I");
        private By byLocation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_I");
        private By byDataGridRows = By.XPath("//table[@id='MainContent_griddata_DXMainTable']/tbody/tr[contains(@id,'MainContent_griddata_DXDataRow')]");
        private By byHireDatePMT = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtemphiredate_DDD_C_PMCImg");
        private By byLocationNumber = By.Id("MainContent_txtlocnumber_I");
        private By byLocationName = By.Id("MainContent_txtlocname_I");
        private By byCustomImg = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_pnlCustomCodes_ddAnswer1_B-1Img");

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
            Thread.Sleep(10000);
            if (this.driver.IsElementPresent(byEmployeeNotOnListButton))
            {
                this.driver.ClickElement(byEmployeeNotOnListButton, "Employee Not In List Button");
            }
        }

        public string GetLocationText()
        {
            return this.driver.GetElementAttribute(byLocation, "value");
        }

        public void ValidateText(string valueToVerify)
        {
            this.TESTREPORT.LogInfo(string.Format("Workers compensation Text : {0}", this.driver.GetElementText(byWCText)));
            this.driver.AssertTextMatching(this.driver.GetElementText(byWCText), valueToVerify);
        }

        public void SelectLocationLoss()
        {
            this.driver.ClickElement(byLocationDropDown, "location dropdown image");
            By byLocationDropDownD = By.XPath("//td[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_DDD_L_LBI1T0']");
            this.driver.ClickElement(byLocationDropDownD, "Location Dropdown");
        }

        public void FillAllRequiredFieldsInWCForm(string FirstName, string LastName, string Adress, string City, string Zip, string DOB, string SSN, string Occupation, string DateOfInjury, string AccidentCause, string InjuryType, string BodyPart, string Description, string IsInjuredWorkerLosingTime, string IsInjuredWorkerModifiedShift, string State, string PreparerPhone, string date, bool LocationTobeSelect = true)
        {
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");

            if (LocationTobeSelect)
            {
                SelectLocationLoss();
            }
            //SelectDropDown(Location, byLocationDropDown);
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

            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
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

            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
            this.driver.ClickElement(byContactTelePhone, "TelePhones textBox");
            this.driver.SendKeysToElementClearFirst(byContactTelePhone, PreparerPhone, "TelePhone");
        }

        public void FillAllNonRequiredFieldsInWCForm(string MiddleName, string Suffix, string Gender, string TelePhone, string HireDate, string MaritalStatus, string EmployeeStatus, string NoOfDepedents, string SideOfBody, string HoursPerDay, string Date, string PaymentFrequency, string DaysWorkedPerWeek, string Address, string City, string State, string Zip, string YesText, string NoText, string fname, string lname)
        {
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
            this.driver.SendKeysToElementClearFirst(byMiddleName, MiddleName, "Employee MiddleName");
            SelectDropDown(Suffix, bySuffixImg);
            SelectDropDown(Gender, byGender);
            this.driver.SendKeysToElementClearFirst(byTelePhone, TelePhone, "TelePhone");
            //Hiredate
            this.driver.ClickElement(byHireImg, "Click On Hire");
            this.driver.ClickElement(byHireDatePMT, "Click On previous month Img");
            ClickOnSpecificDate("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_dtemphiredate_DDD_C_mt", HireDate);
            SelectDropDown(MaritalStatus, byMaritalStatus);
            SelectDropDown(EmployeeStatus, byEmployeeStatus);
            SelectDropDownWithParent(NoOfDepedents, byNoOfDependents, "MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_usremployee_ddempdependents_DDD_L_LBT");

            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
            SelectDropDown(SideOfBody, bySideOfBody);
            this.driver.ClickElement(byEmpBeganWorkImg, "Time occurance employee began work");
            this.driver.ClickElement(byTimeEditOccurenceImg, "Time Edit occurance");
            this.driver.ClickElement(byLstWorkDt, "Last Work Day Image");
            this.driver.SendKeysToElement(byLstWorkDt, Date, "Last Work Day ");

            this.driver.ClickElement(byReturnedworkImg, "Return Work Day Img");
            this.driver.ClickElement(byReturnWorkTodayButton, "Today Button in  Return Work Day");
            //Expected date to return
            this.driver.ClickElement(byExpectedToWorImg, "Click On Expected date to return");
            this.driver.ClickElement(byExpectedWorkNMT, "Click On next month Img");
            ClickOnSpecificDate("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_mt", HireDate);

            this.driver.ClickElement(byFullpayinjury, "Full Pay for Date of Injury");
            this.driver.SendKeysToElementClearFirst(byFullpayinjury, YesText, "Full Pay for Date of Injury");
            SelectDropDown(PaymentFrequency, byPaymentFreq);

            SelectDropDownWithParent(HoursPerDay, byHoursPerDay, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddhrswrkperday_DDD_L_LBT");

            SelectDropDownWithParent(DaysWorkedPerWeek, bydddaysworperweek, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddaysworperweek_DDD_L_LBT");

            this.driver.ClickElement(bydtModifiedDutyBegan, "Modified Duty Date Began Image");
            this.driver.ClickElement(byModifiedDutyBeganTB, "Today Button in Modified Duty Date Began");
            this.driver.SendKeysToElementClearFirst(byinjuryoccur, State, "Injury Location");
            this.driver.SendKeysToElementClearFirst(byWorkZip, Zip, "Work Zip");
            SelectDropDownWithParent(YesText, byemployeeinjuredImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeeinjured_DDD_L_LBT");
            SelectDropDownWithParent(YesText, byinjurypremisesImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurypremises_DDD_L_LBT");
            SelectDropDownWithParent(YesText, bysafeguardsprovidedImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovided_DDD_L_LBT");
            SelectDropDownWithParent(NoText, byemployerquestionclaimImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployerquestionclaim_DDD_L_LBT");
            SelectDropDownWithParent(NoText, bydrugsinvolvedImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddrugsinvolved_DDD_L_LBT");
            SelectDropDownWithParent(NoText, byemployeerepresented, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeerepresented_DDD_L_LBT");
            SelectDropDownWithParent(YesText, bysafeguardsprovidedused, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovidedused_DDD_L_LBT");

            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
            this.driver.SendKeysToElementClearFirst(byphysicianname, "PHY" + fname, "Physician Name");
            this.driver.SendKeysToElementClearFirst(byPhysicianPhone, TelePhone, "Physician TelePhone");
            this.driver.SendKeysToElementClearFirst(byphysicianaddress, "PHY" + Address, "Physician Address");
            this.driver.SendKeysToElementClearFirst(byphysiciancity, "PHY" + City, "Physician City");
            SelectDropDownWithParent(State, byphysicianstateImg, "MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddphysicianstate_DDD_L_LBT");
            this.driver.SendKeysToElementClearFirst(byphysicianzip, Zip, "Physician Zip");

            this.driver.SendKeysToElementClearFirst(byhospitalname, "PHY" + fname, "Hospital Name");
            this.driver.SendKeysToElementClearFirst(byhospitalphone, TelePhone, "Hospital TelePhone");
            this.driver.SendKeysToElementClearFirst(byhospitaladdress, "PHY" + Address, "Hospital Address");
            this.driver.SendKeysToElementClearFirst(byhospitalcity, "PHY" + City, "Hospital City");
            SelectDropDownWithParent(State, byhospitalstateImg, "MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddhospitalstate_DDD_L_LBT");
            this.driver.SendKeysToElementClearFirst(byhospitalzip, Zip, "Hospital Zip");

            this.driver.SendKeysToElementClearFirst(byemployerfirstname, "EMP" + fname, "Employer first Name");
            this.driver.SendKeysToElementClearFirst(byemployerlastname, "EMP" + lname, "Employer last Name");
            this.driver.SendKeysToElementClearFirst(byemployerphone, TelePhone, "Employer telephone");

            this.driver.SendKeysToElementClearFirst(bywitnessfirstname, "WIT" + fname, "Witness first Name");
            this.driver.SendKeysToElementClearFirst(bywitnesslastname, "WIT" + lname, "Witness last Name");
            this.driver.SendKeysToElementClearFirst(bywitnessphone, TelePhone, "Witness telephone");
        }

        public void ClickOnSubmitButton()
        {
            this.driver.ClickElement(bySubmit, "Submit Button");
        }

        public void FillRequiredFieldsForSaveDraftInWCForm(string FirstName, string LastName, string DateOfInjury, string Description)
        {
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
            //SelectDropDown(Location, byLocationDropDown);
            SelectLocationLoss();
            this.driver.SendKeysToElementClearFirst(byFirstName, FirstName, "Employee FirstName");
            this.driver.SendKeysToElementClearFirst(byLastName, LastName, "Employee LastName");

            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");

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

        public void VerifyName(string valueToVerify)
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

            string name = this.driver.GetElementAttribute(byLastName, "value") + " " + this.driver.GetElementAttribute(byFirstName, "value");
            name = name.Replace(",", "");
            if (valueToVerify.Trim().ToLower().Equals(name.Trim().ToLower()))
            {
                this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is equal", name, valueToVerify));
            }
            else
            {
                this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is not equal", name, valueToVerify));
            }
        }

        public void VerifyLocation(string valueToVerify)
        {
            this.driver.SwitchToDefaultFrame();
            this.driver.SwitchToFrameByLocator(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']"));

            string name = GetLocationText();
            name = name.Replace(" ", "");
            if (valueToVerify.Trim().ToLower().Equals(name.Trim().ToLower()))
            {
                this.TESTREPORT.LogSuccess("Verify Text Location ", string.Format("actual text -<mark>{0}</mark> expected count {1} is equal", name, valueToVerify));
            }
            else
            {
                this.TESTREPORT.LogSuccess("Verify Text Location s", string.Format("actual text -<mark>{0}</mark> expected count {1} is not equal", name, valueToVerify));
            }
        }

        public void VerifyDate(string valueToVerify)
        {
            this.driver.SwitchToDefaultFrame();
            this.driver.SwitchToFrameByLocator(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']"));

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

        public void ClickOnSearchButton()
        {
            Thread.Sleep(5000);
            this.TESTREPORT.LogInfo("Click on Search Button");
            this.driver.ClickElement(bySearchButton, "Search", 60);
        }

        public void EnterLastNameInField(string LastName)
        {
            EnterDataInField(LastName, bySearchLstName);
        }

        public void EnterEmployeeIdInField(string EmployeeID)
        {
            EnterDataInField(EmployeeID, bySearchID);
        }

        public void EnterLocationNumberInField(string LocationNumber)
        {
            EnterDataInField(LocationNumber, byLocationNumber);
        }

        public void EnterLocationNameInField(string LocationName)
        {
            EnterDataInField(LocationName, byLocationName);
        }

        public void ValidateColumnDataFromRow(string ColumnValue)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byDataGridRows);
            foreach (IWebElement element in list)
            {
                if (element.Text.Trim().ToLower().Contains(ColumnValue.Trim().ToLower()))
                {
                    this.TESTREPORT.LogSuccess("Verify Column Data from Grid row data ", string.Format("actual text -<mark>{0}</mark> expected count {1} is equal", element.Text, ColumnValue));
                }
                else
                {
                    this.TESTREPORT.LogFailure("Verify Column Data from Grid row data ", string.Format("actual text -<mark>{0}</mark> expected count {1} is not equal", element.Text, ColumnValue), this.SCREENSHOTFILE);
                }
            }
        }

        public void EnterContactInformation(string TelePhone, string Address, string City, string State, string Zip, string fname, string lname)
        {
            Thread.Sleep(3000);
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
            this.driver.ClickElement(byContactTelePhone, "TelePhones textBox");
            this.driver.SendKeysToElementClearFirst(byContactTelePhone, TelePhone, "TelePhone");
            this.driver.SendKeysToElementClearFirst(byphysicianname, "PHY" + fname, "Physician Name");
            this.driver.SendKeysToElementClearFirst(byPhysicianPhone, TelePhone, "Physician TelePhone");
            this.driver.SendKeysToElementClearFirst(byphysicianaddress, "PHY" + Address, "Physician Address");
            this.driver.SendKeysToElementClearFirst(byphysiciancity, "PHY" + City, "Physician City");
            SelectDropDownWithParent(State, byphysicianstateImg, "MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddphysicianstate_DDD_L_LBT");
            this.driver.SendKeysToElementClearFirst(byphysicianzip, Zip, "Physician Zip");

            this.driver.SendKeysToElementClearFirst(byhospitalname, "PHY" + fname, "Hospital Name");
            this.driver.SendKeysToElementClearFirst(byhospitalphone, TelePhone, "Hospital TelePhone");
            this.driver.SendKeysToElementClearFirst(byhospitaladdress, "PHY" + Address, "Hospital Address");
            this.driver.SendKeysToElementClearFirst(byhospitalcity, "PHY" + City, "Hospital City");
            SelectDropDownWithParent(State, byhospitalstateImg, "MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddhospitalstate_DDD_L_LBT");
            this.driver.SendKeysToElementClearFirst(byhospitalzip, Zip, "Hospital Zip");

            this.driver.SendKeysToElementClearFirst(byemployerfirstname, "EMP" + fname, "Employer first Name");
            this.driver.SendKeysToElementClearFirst(byemployerlastname, "EMP" + lname, "Employer last Name");
            this.driver.SendKeysToElementClearFirst(byemployerphone, TelePhone, "Employer telephone");

            this.driver.SendKeysToElementClearFirst(bywitnessfirstname, "WIT" + fname, "Witness first Name");
            this.driver.SendKeysToElementClearFirst(bywitnesslastname, "WIT" + lname, "Witness last Name");
            this.driver.SendKeysToElementClearFirst(bywitnessphone, TelePhone, "Witness telephone");
        }

        public void EnterOccuranceInformation(string HireDate, string SideOfBody, string HoursPerDay, string Date, string PaymentFrequency, string DaysWorkedPerWeek, string Address, string City, string State, string Zip, string YesText, string NoText, string fname, string lname, string DateOfInjury, string AccidentCause, string InjuryType, string BodyPart, string Description)
        {
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
            //SelectDropDown(Location, byLocationDropDown);
            SelectLocationLoss();
            VerifyAndClickOnMenu("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
            this.driver.ClickElement(byIsInjuryWorkedLosingTimeText, "IsInjuryWorkedLosingTimeText");
            this.driver.SendKeysToElementClearFirst(byIsInjuryWorkedLosingTimeText, YesText, "IsInjuredWorkerLosingTime");

            this.driver.ClickElement(byDateOfInjury, "Date of Injury");
            this.driver.SendKeysToElement(byDateOfInjury, DateOfInjury, "Date of Injury");
            SelectDropDown(AccidentCause, byAccidentCauseDD);
            SelectDropDown(InjuryType, byInjuryTypeDD);
            SelectDropDown(BodyPart, byBodyPartDD);
            SelectDropDown(SideOfBody, bySideOfBody);
            this.driver.SendKeysToElementClearFirst(byAccidentDescription, Description, "Accident Description");

            this.driver.ClickElement(byEmpBeganWorkImg, "Time occurance employee began work");
            this.driver.ClickElement(byTimeEditOccurenceImg, "Time Edit occurance");
            this.driver.ClickElement(byDateEmployerNotified, "Employee Notified");
            this.driver.SendKeysToElement(byDateEmployerNotified, Date, "Employee Notified");

            this.driver.ClickElement(byIsInjuredWorkerOnModifiedDutyText, "IsInjuredWorkerOnModifiedDuty");
            this.driver.SendKeysToElementClearFirst(byIsInjuredWorkerOnModifiedDutyText, NoText, "IsInjuredWorkerOnModifiedDuty");

            this.driver.ClickElement(byDateDisabilityBegan, "Date of Disability");
            this.driver.SendKeysToElement(byDateDisabilityBegan, Date, "Date of Disability");

            this.driver.ClickElement(byLstWorkDt, "Last Work Day Image");
            this.driver.SendKeysToElement(byLstWorkDt, Date, "Last Work Day ");

            this.driver.ClickElement(byReturnedworkImg, "Return Work Day Img");
            this.driver.ClickElement(byReturnWorkTodayButton, "Today Button in  Return Work Day");
            //Expected date to return
            this.driver.ClickElement(byExpectedToWorImg, "Click On Expected date to return");
            this.driver.ClickElement(byExpectedWorkNMT, "Click On next month Img");
            ClickOnSpecificDate("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtExpectedToWork_DDD_C_mt", HireDate);

            this.driver.ClickElement(byFullpayinjury, "Full Pay for Date of Injury");
            this.driver.SendKeysToElementClearFirst(byFullpayinjury, YesText, "Full Pay for Date of Injury");
            SelectDropDown(PaymentFrequency, byPaymentFreq);

            SelectDropDownWithParent(HoursPerDay, byHoursPerDay, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddhrswrkperday_DDD_L_LBT");

            SelectDropDownWithParent(DaysWorkedPerWeek, bydddaysworperweek, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddaysworperweek_DDD_L_LBT");

            this.driver.ClickElement(bydtModifiedDutyBegan, "Modified Duty Date Began Image");
            this.driver.ClickElement(byModifiedDutyBeganTB, "Today Button in Modified Duty Date Began");
            this.driver.SendKeysToElementClearFirst(byinjuryoccur, State, "Injury Location");

            this.driver.SendKeysToElementClearFirst(byLossLocationAdress, Address, "Loss Location Address");
            this.driver.SendKeysToElementClearFirst(byLossLocationCity, City, "Loss Location City");

            SelectDropDownWithParent(State, byLossLocationState, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurystate_DDD_L_LBT");

            this.driver.SendKeysToElementClearFirst(byLossLocationZip, Zip, "Loss Location Zip");
            this.driver.SendKeysToElementClearFirst(byWorkGroupAdress, Address, "Work Group Address");
            this.driver.SendKeysToElementClearFirst(byWorkCity, City, "Work Group City");
            SelectDropDownWithParent(State, byWorkState, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddWorkState_DDD_L_LBT");

            SelectDropDownWithParent(YesText, byemployeeinjuredImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeeinjured_DDD_L_LBT");
            SelectDropDownWithParent(YesText, byinjurypremisesImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinjurypremises_DDD_L_LBT");
            SelectDropDownWithParent(YesText, bysafeguardsprovidedImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovided_DDD_L_LBT");
            SelectDropDownWithParent(NoText, byemployerquestionclaimImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployerquestionclaim_DDD_L_LBT");
            SelectDropDownWithParent(YesText, bysafeguardsprovidedused, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddsafeguardsprovidedused_DDD_L_LBT");
            this.driver.SendKeysToElementClearFirst(byWorkZip, Zip, "Work Zip");
            this.driver.ScrollToPageBottom();
            SelectDropDownWithParent(NoText, bydrugsinvolvedImg, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddrugsinvolved_DDD_L_LBT");
            SelectDropDownWithParent(NoText, byemployeerepresented, "MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddemployeerepresented_DDD_L_LBT");
        }

        public void EnterCustomerSpecialDialog()
        {
            By CustomerSpecialDialog = By.XPath("//span[contains(text(),'Customer Special Coding')]");
            this.driver.ClickElement(CustomerSpecialDialog, "Customer Special Dialog bar");

            this.driver.ClickElement(byCustomImg, "Customer Special Dialog image");
            By byLocationDropDownD = By.XPath("//td[@id='MainContent_CallbackPanel_ASPxRoundPanel4_pnlCustomCodes_ddAnswer1_DDD_L_LBI1T0']");
            this.driver.ClickElement(byLocationDropDownD, "Customer Special Dialog value");
        }

        public void VerifyAndClickOnMenu(string menuId)
        {
            By menu = By.XPath(string.Format("//span[@id='{0}']/img", menuId));
            if (this.driver.GetElementAttribute(menu, "alt").Contains("[Collapse/Expand]"))
            {
                this.driver.ClickElement(menu, "Menu");
                this.TESTREPORT.LogInfo(string.Format("Clicked on Menu : ", menu));
            }
            else if (this.driver.GetElementAttribute(menu, "alt").Contains("Show / Hide"))
            {
                this.TESTREPORT.LogInfo("Element is already expanded");
            }
        }
        #endregion

    }
}
