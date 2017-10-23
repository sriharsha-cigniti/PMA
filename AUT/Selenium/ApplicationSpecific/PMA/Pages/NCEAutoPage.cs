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

        private By byDropDownimage = By.XPath("//span[@id='MainContent_ddlob_B-1Img']");
        private By bySelectBusinessLabel = By.XPath("//div[@id='MainContent_up1']//label[contains(text(),'Select Line of Business:')]");
        private By byAutoSpan = By.XPath("//span[contains(text(),'Auto')]");
        private By byCancelButton = By.XPath("//div[@id='MainContent_btncancel_CD']/span[contains(text(),'Cancel')]");
        private By bySubmitButton = By.XPath("//div[@id='MainContent_btnSubmit']//span[contains(text(),'Submit')]");
        private By byOccurenceDate = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_I");
        private By byLocationDropdOwnimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_B-1Img']");
        private By byStateOfLossDropdOwnimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlossstate_B-1Img']");
        private By byContactBusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone_I");
        private By byDateOfOccurenceDropdownimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_B-1Img']");
        private By byTodayDate = By.XPath("//div[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_DDD_PWC-1']//td[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_DDD_C_BT']");
        private By bySaveDraftButton = By.Id("MainContent_btnSaveAsDraft_CD");
        private By byLocationofLossRequiredFieldText = By.XPath("//td[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_ETC']");
        private By byContactBusinessPhoneRequiredFieldText = By.XPath("//td[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone_ETC']");
        private By byDateofOccuRequiredFieldText = By.XPath("//td[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_ETC']");
        private By byDraftSavedSuccessfullyText = By.XPath("//span[text()='Draft Saved Successfully']");
        private By bySavedDraftsText = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//caption[contains(text(),'Saved Drafts')]");
        private By byDescribeLoss = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_memaccidentdesc_I']");
        private By byDateofOccurenceField = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_I']");
        private By byLocationofLossField = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_I']");
        private By byStateofLossField = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlossstate_I']");
        private By byDeleteButton = By.XPath("//a[@id='MainContent_griddata_DXCBtn0']");
        private By bySavedDraftsTableCount = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow')]");
        private By byLossInformationDropdownButton = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
        private By byInsuredVehicleInformationDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
        private By byPropertyDamageInformationDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
        private By byPartyInformationDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_CBImg");
        private By byClaimSubmissionDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel6_CBImg");

        #region sections in AutoPage
        //secions present in the Auto page
        private By byLossInformation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_RPHT");
        private By byInsuredVehicleInformation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_RPHT");
        private By byPropertyDamageInformation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_RPHT");
        private By byPartyInformation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_RPHT");
        private By byClaimSubmission = By.Id("MainContent_CallbackPanel_ASPxRoundPanel6_RPHT");
        #endregion

        #region FieldsinInsuredVehicleInformationSection
        //****Insured Vehicle information Section
        private By byVehicleNo = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleNumber_I']");
        private By byYear = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleYear_I']");
        private By byMake = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleMake_I']");
        private By byModel = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleModel_I']");
        private By byBodyTypeDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddInsuredVehiclebodytype_B-1Img");
        private By byBodyTypeSelection = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddInsuredVehiclebodytype_DDD_L_LBT']//td[contains(text(),'Bus')]");
        private By byVIN = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleVIN_I']");
        private By byPlateNo = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehiclePlate_I']");
        private By byStateDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddvehiclestate_B-1Img");
        private By byStateSelection = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddvehiclestate_DDD_L_LBT']//td[contains(text(),'California')]");


        //Insured vehicle driver information
        private By byifdriverisownercheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_chkDriverisOwner_S_D");
        private By byDriverFirstName = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverFirstName_I']");
        private By byDriverLastName = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverLastName_I']");
        private By byAddress = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverAddress_I']");
        private By byCity = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverCity_I']");
        private By byStateDropdownBtninInsuredVehicle = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinsureddriverstate_B-1Img");
        private By byStateSelectioninInsuredVehicle = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddinsureddriverstate_DDD_L_LBT']//td[contains(text(),'California')]");
        private By byZipInInsuredVehicle = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverZip_I']");
        private By byResidencePhone = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverResPhone_I']");
        private By byBusinessPhone = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverBusPhone_I']");
        private By byRelationtoInsuredDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddrelationtoinsured_B-1Img");
        private By byRelationtoInsuredSelect = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddrelationtoinsured_DDD_L_LBT']//td[contains(text(),'Agent')]");
        //need to implement date of birth
        private By byDriversLicense = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtInsuredDriverLicense_I']");
        private By byLicensedstateDropdownBtn = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddriverlicensestate_B-1Img");
        private By byLicensedstateSelect = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dddriverlicensestate_DDD_L_LBT']//td[contains(text(),'California')]");
        private By byPurposeofUsedropdown = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddpurposeofuse_B-1Img");
        private By byPurposeofUseSelect = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_ddpurposeofuse_DDD_L_LBT']//td[contains(text(),'Business')]");
        private By byUsedwithPermissionYes = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_radusedwithpermission_RB0_I_D']");
        private By byIfDriverisÏnjuredCheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_chkDriverInjured_S_D");
        private By byDescriptionofinjuryField = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtDriverInjuryDesc_I']");
        //other information
        private By byDescribeDamage = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_memDamageDescr_I']");
        private By byEstimateAmount = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_spEstimateAmount_I']");
        private By byWherecanVehiclebeseeen = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtWhereSeen_I']");
        private By byWhencanVehiclebeseeen = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtWhenSeen_I']");
        private By byOtherInsuranceonVehicle = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_txtVehicleOtherInsurance_I']");
        #endregion

        #region FieldsinPartyInformationsection
        //****Party Information****
        //party1(atlast included P1 for all the locators related to party1)
        private By byPassengerinInsuredVehiclecheckboxP1 = By.XPath("//span[@id='chkParty1InsureVeh_S_D']");
        private By byFirstNameP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1FirstName_I']");
        private By byLastNameP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1LastName_I']");
        private By byAddressP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1Address_I']");
        private By byCityP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1City_I']");
        private By byStateDRopdownP1 = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddParty1State_B-1Img");
        private By byStateSelectP1 = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddParty1State_DDD_L_LBT']//td[contains(text(),'Florida')]");
        private By byZipP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1Zip_I']");
        private By byPhoneP1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty1Phone_I']");
        private By byDescriptionofInjuryP1 = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_memParty1Desc_I']");
        //party2(atlast included P1 for all the locatorsrelated to party2)
        private By byPassengerinInsuredVehiclecheckboxP2 = By.XPath("//span[@id='chkParty2InsuredVehicle_S_D']");
        private By byFirstNameP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2FirstName_I']");
        private By byLastNameP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2LastName_I']");
        private By byAddressP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2Address_I']");
        private By byCityP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2City_I']");
        private By byStateDRopdownP2 = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddParty2State_B-1Img");
        private By byStateSelectP2 = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddParty2State_DDD_L_LBT']//td[contains(text(),'Florida')]");
        private By byZipP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2Zip_I']");
        private By byPhoneP2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtParty2Phone_I']");
        private By byDescriptionofInjuryP2 = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_memParty2Desc_I']");
        //Witness1(atlast included W1 for all the locatorsrelated to witness1)
        private By byFirstNamew1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness1FirstName_I']");
        private By byLastNamew1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness1LastName_I']");
        private By byAddressw1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness1Address_I']");
        private By byCityw1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness1City_I']");
        private By byStateDRopdownw1 = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddWitness1State_B-1Img");
        private By byStateSelectw1 = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddWitness1State_DDD_L_LBT']//td[contains(text(),'Florida')]");
        private By byZipw1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2Zip_I']");
        private By byPhonew1 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness1Phone_I']");
        //witness2(atlast included W2 for all the locatorsrelated to witness2)
        private By byFirstNamew2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2FirstName_I']");
        private By byLastNamew2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2LastName_I']");
        private By byAddressw2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2Address_I']");
        private By byCityw2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2City_I']");
        private By byStateDRopdownw2 = By.Id("MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddWitness2State_B-1Img");
        private By byStateSelectw2 = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_ddWitness2State_DDD_L_LBT']//td[contains(text(),'Florida')]");
        private By byZipw2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2Zip_I']");
        private By byPhonew2 = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtWitness2Phone_I']");
        //other(atlast included o for all the locatorsrelated to other)
        private By byRemarkstoClaimAdjustero = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_memRemarks_I']");
        private By byReportedbyFirstNameo = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtReportedByFirstName_I']");
        private By byLastNameo = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtReportedByLastName_I']");
        private By byReportedToo = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel4_ASPxPanel4_txtReportedTo_I']");
        #endregion

        #region  PropertyDamageInformation
        //****PropertyDamageInformation***
        private By byIndicateDamagetoVehicleorPropertyCheckbox = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_rdVehicleOrProperty_RB1_I_D']");
        private By byDescribeProperty = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_memPropertyDescription_I']");
        private By byOtherVehicleorPropertyInsuranceCheckbox = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_radVehInsYesRdo_RB1_I_D']");
        //Other Driver Information(atlast included DI for all the locators related to Driver Information)
        private By byCheckifDriverisOwnerCheckbox = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_chkOtherDriverOwner_S_D']");
        private By byFirstNameDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverFirstName_I']");
        private By byLastNameDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverLastName_I']");
        private By byAddressDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverAddress_I']");
        private By byCityDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverCity_I']");
        private By byStateDRopdownDI = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddOtherDriverState_B-1Img");
        private By byStateSelectDI = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ddOtherDriverState_DDD_L_LBT']//td[contains(text(),'Florida')]");
        private By byZipDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverZip_I']");
        private By byResidencePhoneDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverResPhone_I']");
        private By byBusinessPhoneDI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOtherDriverBusPhone_I']");
        private By byCheckIfDriverisInjuredCheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ChkOtherDriverInjured_S_D");
        private By byCheckIfInjuryisFatalCheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_ChkOtherDriverInjuryFatal_S_D");
        private By byDescriptionofInjuryDI = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_memOtherDriverInjuryDesc_I']");
        //Other information(atlast included OI for all the locators related to Other Information)
        private By byDescribeDamageOI = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_memOwnerDamageDesc_I']");
        private By byEstimateAmountOI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_spOwnerDamageAmount_I']");
        private By byWherecanDamagebeseenOI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOwnerWhereSeen_I']");
        private By byWhencanDamagebeseenOI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel2_txtOwnerWhenSeen_I']");
        #endregion

        #region Cliam submission
        private By byComments = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel6_ASPxPanel3_memcomment_I']");
        private By byRecordOnlyCheckbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel6_ASPxPanel3_chkrecordonly_S_D");

        #endregion

        #region LossInformationsection	
        private By byTimeofOccurrenceLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_timeEditoccurrence_I']");
        private By byAddressLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempaddress_I']");
        private By byCityLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempcity_I']");
        private By byZipLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtLossZip_I']");
        private By byViolationsorCitationsDropdownLI = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddViolations_B-1Img");
        private By byViolationsorCitationsDropdownSelectLI = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddViolations_DDD_L_LBT']//td[contains(text(),'Reckless driving')]");
        private By byReportNumberLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtReportNum_I']");
        private By byAuthorityContactedLI = By.XPath("//input[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtAuthority_I']");
        private By byDescribeLossLI = By.XPath("//textarea[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_memaccidentdesc_I']");


        #endregion

        #endregion

        //Fill the fields for LossInformation
        public void FillLossInformation(string TimeofOccurrence, string Address, string city, string zip, string ReportNumber, string Authoritycontacted, string DLoss)
        {

            // this.driver.ClickElement(byLossInformationDropdownButton, "LossInformationDropdownButton");
            this.driver.ClickElement(byTimeofOccurrenceLI, "Timeofoccurence");
            this.driver.SendKeysToElementClearFirst(byTimeofOccurrenceLI, TimeofOccurrence, "TimeofOccurrence");
            this.driver.SendKeysToElementClearFirst(byAddressLI, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityLI, city, "city");
            this.driver.SendKeysToElementClearFirst(byZipLI, zip, "zip");
            this.driver.ClickElement(byViolationsorCitationsDropdownLI, "ViolationsorCitationsDropdown");
            this.driver.ClickElement(byViolationsorCitationsDropdownSelectLI, "ViolationsorCitationValue");
            this.driver.SendKeysToElementClearFirst(byReportNumberLI, ReportNumber, "ReportNumber");
            this.driver.SendKeysToElementClearFirst(byAuthorityContactedLI, Authoritycontacted, "Authoritycontacted");
            this.driver.SendKeysToElementClearFirst(byDescribeLossLI, DLoss, "DLoss");
            this.driver.ClickElement(byLossInformationDropdownButton, "LossInformationDropdownButton");
        }

        //Fill the fields for CliamSubmission
        public void FillClaimSubmission(string Comments)
        {
            this.TESTREPORT.LogInfo("Fill the fields for CliamSubmission Section");
            this.driver.ClickElement(byClaimSubmissionDropdownBtn, "ClaimSubmission");
            this.driver.SendKeysToElementClearFirst(byComments, Comments, "Comments");
            this.driver.ClickElement(byRecordOnlyCheckbox, "RecordOnly");
            this.driver.ClickElement(byClaimSubmissionDropdownBtn, "ClaimSubmission");
        }

        //Fill the fields for PropertyDamageInformation
        public void FillPropertyDamageInformationSection(string FirstName, string LastName, string Address, string City, string Zip, string Rphone, string Bphone, string DInjury, string Ddamage, string EAmount, string WherecanDamagebeseen, string WhencanDamagebeseen, string DescribeProperty)
        {
            this.TESTREPORT.LogInfo("Fill the fields for PropertyDamageInformation Section");
            this.driver.ClickElement(byPropertyDamageInformationDropdownBtn, "PropertyDamageInformation");
            this.driver.ClickElement(byIndicateDamagetoVehicleorPropertyCheckbox, "IndicateDamagetoVehicleorProperty");
            this.driver.SendKeysToElementClearFirst(byDescribeProperty, DescribeProperty, "DescribeProperty");
            this.driver.ClickElement(byOtherVehicleorPropertyInsuranceCheckbox, "OtherVehicleorPropertyInsurance");
            this.driver.ClickElement(byCheckifDriverisOwnerCheckbox, "CheckifDriverisOwner");
            this.driver.SendKeysToElementClearFirst(byFirstNameDI, FirstName, "FirstName");
            this.driver.SendKeysToElementClearFirst(byLastNameDI, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byAddressDI, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityDI, City, "City");
            this.driver.ClickElement(byStateDRopdownDI, "StateDRopdown");
            this.driver.ClickElement(byStateSelectDI, "StateSelect");
            this.driver.SendKeysToElementClearFirst(byZipDI, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byResidencePhoneDI, Rphone, "Rphone");
            this.driver.SendKeysToElementClearFirst(byBusinessPhoneDI, Bphone, "Bphone");
            this.driver.ClickElement(byCheckIfDriverisInjuredCheckbox, "CheckIfDriverisInjured");
            this.driver.ClickElement(byCheckIfInjuryisFatalCheckbox, "CheckIfInjuryisFatal");
            this.driver.SendKeysToElementClearFirst(byDescriptionofInjuryDI, DInjury, "DescriptionofInjury");
            this.driver.SendKeysToElementClearFirst(byDescribeDamageOI, Ddamage, "DescribeDamage");
            this.driver.SendKeysToElementClearFirst(byEstimateAmountOI, EAmount, "EstimateAmount");
            this.driver.SendKeysToElementClearFirst(byWherecanDamagebeseenOI, WherecanDamagebeseen, "WherecanDamagebeseen");
            this.driver.SendKeysToElementClearFirst(byWhencanDamagebeseenOI, WhencanDamagebeseen, "WhencanDamagebeseen");
            this.driver.ClickElement(byPropertyDamageInformationDropdownBtn, "PropertyDamageInformation");
        }


        //Fill the fields for PartyInformation 
        public void FillPartyInformationSection(string FirstName, string LastName, string Address, string City, string Zip, string Phone, string DescriptionofInjury, string RemarkstoClaimAdjuster)
        {
            this.TESTREPORT.LogInfo("Fill the fields for PartyInformation Section");
            this.driver.ClickElement(byPartyInformationDropdownBtn, "PartyInformation");
            //party1
            this.TESTREPORT.LogInfo("Fill the fields for Party1 in PartyInformation");
            this.driver.ClickElement(byPassengerinInsuredVehiclecheckboxP1, "PassengerinInsuredVehicle");
            this.driver.SendKeysToElementClearFirst(byFirstNameP1, FirstName, "FirstName");
            this.driver.SendKeysToElementClearFirst(byLastNameP1, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byAddressP1, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityP1, City, "City");
            this.driver.ClickElement(byStateDRopdownP1, "StateDRopdown");
            this.driver.ClickElement(byStateSelectP1, "State Value");
            this.driver.SendKeysToElementClearFirst(byZipP1, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byPhoneP1, Phone, "Phone");
            this.driver.SendKeysToElementClearFirst(byDescriptionofInjuryP1, DescriptionofInjury, "DescriptionofInjury");
            //party2
            this.TESTREPORT.LogInfo("Fill the fields for Party2 in PartyInformation");
            this.driver.ClickElement(byPassengerinInsuredVehiclecheckboxP2, "PassengerinInsuredVehicle");
            this.driver.SendKeysToElementClearFirst(byFirstNameP2, FirstName, "FirstName");
            this.driver.SendKeysToElementClearFirst(byLastNameP2, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byAddressP2, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityP2, City, "City");
            this.driver.ClickElement(byStateDRopdownP2, "StateDRopdown");
            this.driver.ClickElement(byStateSelectP2, "State Value");
            this.driver.SendKeysToElementClearFirst(byZipP2, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byPhoneP2, Phone, "Phone");
            this.driver.SendKeysToElementClearFirst(byDescriptionofInjuryP2, DescriptionofInjury, "DescriptionofInjury");
            //witness1
            this.TESTREPORT.LogInfo("Fill the fields for witness1 in PartyInformation");
            this.driver.SendKeysToElementClearFirst(byFirstNamew1, FirstName, "FirstName");
            this.driver.SendKeysToElementClearFirst(byLastNamew1, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byAddressw1, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityw1, City, "City");
            this.driver.ClickElement(byStateDRopdownw1, "StateDRopdown");
            this.driver.ClickElement(byStateSelectw1, "State Value");
            this.driver.SendKeysToElementClearFirst(byZipw1, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byPhonew1, Phone, "Phone");
            //witness2
            this.TESTREPORT.LogInfo("Fill the fields for witness2 in PartyInformation");
            this.driver.SendKeysToElementClearFirst(byFirstNamew2, FirstName, "FirstName");
            this.driver.SendKeysToElementClearFirst(byLastNamew2, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byAddressw2, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCityw2, City, "City");
            this.driver.ClickElement(byStateDRopdownw2, "StateDRopdown");
            this.driver.ClickElement(byStateSelectw2, "State Value");
            this.driver.SendKeysToElementClearFirst(byZipw2, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byPhonew2, Phone, "Phone");
            //other
            this.driver.SendKeysToElementClearFirst(byRemarkstoClaimAdjustero, RemarkstoClaimAdjuster, "RemarkstoClaimAdjuster");
            this.driver.SendKeysToElementClearFirst(byReportedbyFirstNameo, FirstName, "ReportedbyFirstName");
            this.driver.SendKeysToElementClearFirst(byLastNameo, LastName, "LastName");
            this.driver.SendKeysToElementClearFirst(byReportedToo, DescriptionofInjury, "ReportedTo");
            this.driver.ClickElement(byPartyInformationDropdownBtn, "PartyInformation");
        }




        //Fill the fields for Insured Vehicle Information
        public void FillInsuredVehicleInformationSection(string VehicleNo, string Year, string Make, string Model, string VIN, string PlateNo, string DriverFirstName, string DriverLastName, string Address, string City, string Zip, string ResidencePhone, string BusinessPhone, string DriversLicense, string Descriptionofinjury, string DescribeDamage, string EstimateAmount, string WherecanVehiclebeseen, string WhencanVehiclebeseen, string OtherInsuranceonVehicle)
        {
            this.TESTREPORT.LogInfo("Fill the fields for InsuredVehicleInformation Section");
            //click dropdownbutton for Insredvehicleinformation
            this.driver.ClickElement(byInsuredVehicleInformationDropdownBtn, "InsuredVehicleInformation dropdown");
            Thread.Sleep(2000);
            this.driver.SendKeysToElementClearFirst(byVehicleNo, VehicleNo, "vehicle No");
            this.driver.SendKeysToElementClearFirst(byYear, Year, "Year");
            this.driver.SendKeysToElementClearFirst(byMake, Make, "Make");
            this.driver.SendKeysToElementClearFirst(byModel, Model, "Model");
            this.driver.ClickElement(byBodyTypeDropdownBtn, "BodyType DropDownbutton");
            this.driver.ClickElement(byBodyTypeSelection, "BodyType value");
            this.driver.SendKeysToElementClearFirst(byVIN, VIN, "VIN");
            this.driver.SendKeysToElementClearFirst(byPlateNo, PlateNo, "Plate No");
            this.driver.ClickElement(byStateDropdownBtn, "state Dropdown Btn");
            this.driver.ClickElement(byStateSelection, "State Value");
            this.driver.ClickElement(byifdriverisownercheckbox, "ifdriverisowner");
            this.driver.SendKeysToElementClearFirst(byDriverFirstName, DriverFirstName, "DriverFirstName");
            this.driver.SendKeysToElementClearFirst(byDriverLastName, DriverLastName, "DriverLastName");
            this.driver.SendKeysToElementClearFirst(byAddress, Address, "Address");
            this.driver.SendKeysToElementClearFirst(byCity, City, "City");
            this.driver.ClickElement(byStateDropdownBtninInsuredVehicle, "StateDropdownBtninInsuredVehicle");
            this.driver.ClickElement(byStateSelectioninInsuredVehicle, "state value");
            this.driver.SendKeysToElementClearFirst(byZipInInsuredVehicle, Zip, "Zip");
            this.driver.SendKeysToElementClearFirst(byResidencePhone, ResidencePhone, "ResidencePhone");
            this.driver.SendKeysToElementClearFirst(byBusinessPhone, BusinessPhone, "BusinessPhone");
            this.driver.ClickElement(byRelationtoInsuredDropdownBtn, "RelationtoInsuredDropdownBtn");
            this.driver.ClickElement(byRelationtoInsuredSelect, "RelationtoInsured value");
            //***select date of birth
            By byDateofBirthdropdown = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_B-1Img");
            this.driver.ClickElement(byDateofBirthdropdown, "DateofBirthdropdown");
            By byMonthandYear = By.XPath("//div[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_PWC-1']//span[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_T']");
            this.driver.ClickElement(byMonthandYear, "Select Month and Year");
            By byselectbirthYearintable = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_FNP_y']//td[contains(@onclick,'ASPx.CalFNYShuffle')][1]");
            this.driver.ClickElement(byselectbirthYearintable, "To select the birth year");
            this.driver.ClickElement(byselectbirthYearintable, "To select the birth year");
            this.driver.ClickElement(byselectbirthYearintable, "To select the birth year");
            this.driver.ClickElement(byselectbirthYearintable, "To select the birth year");
            Thread.Sleep(2000);
            By byyear = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_FNP_y']//td[contains(@id,'MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_FNP_Y0')]");
            this.driver.ClickElement(byyear, "Birth Year selected");
            By byokbutton = By.XPath("//div[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_FNP_PW-1']//td[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_FNP_BO']");
            this.driver.ClickElement(byokbutton, "Select month and year");
            By byBirthDate = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel1_dtInsuredDriverDOB_DDD_C_mt']//td[contains(text(),'12')]");
            this.driver.ClickElement(byBirthDate, "selecte birthdate");

            this.driver.SendKeysToElementClearFirst(byDriversLicense, DriversLicense, "DriversLicense");
            Actions a = new Actions(driver);
            a.SendKeys(OpenQA.Selenium.Keys.PageDown).Build().Perform();
            this.driver.ClickElement(byLicensedstateDropdownBtn, "LicensedstateDropdownBtn");
            this.driver.ClickElement(byLicensedstateSelect, "Licensedstate value");
            this.driver.ClickElement(byPurposeofUsedropdown, "PurposeofUseDropdownBtn");
            this.driver.ClickElement(byPurposeofUseSelect, "PurposeofUse value");
            this.driver.ClickElement(byUsedwithPermissionYes, "UsedwithPermissionYes");
            this.driver.ClickElement(byIfDriverisÏnjuredCheckbox, "IfDriverisÏnjured");
            this.driver.SendKeysToElementClearFirst(byDescriptionofinjuryField, Descriptionofinjury, "Descriptionofinjury");
            this.driver.SendKeysToElementClearFirst(byDescribeDamage, DescribeDamage, "DescribeDamage");
            this.driver.SendKeysToElementClearFirst(byEstimateAmount, EstimateAmount, "EstimateAmount");
            this.driver.SendKeysToElementClearFirst(byWherecanVehiclebeseeen, WherecanVehiclebeseen, "WherecanVehiclebeseeen");
            this.driver.SendKeysToElementClearFirst(byWhencanVehiclebeseeen, WhencanVehiclebeseen, "WhencanVehiclebeseeen");
            this.driver.SendKeysToElementClearFirst(byOtherInsuranceonVehicle, OtherInsuranceonVehicle, "OtherInsuranceonVehicle");
            this.driver.ClickElement(byInsuredVehicleInformationDropdownBtn, "InsuredVehicleInformation dropdown");


        }


        public void ClickOnNewClaimEntry()
        {
            this.driver.ClickElement(byClaimNewInquirytab, "Claim Inquiry Tab");
            //Switching to frame.......
            this.driver.SwitchTo().Frame("MainContent_ASPxSplitter1_0_CC");
            this.driver.WaitElementPresent(bySelectBusinessLabel);
            if (this.driver.IsElementPresent(bySelectBusinessLabel))
                this.TESTREPORT.LogSuccess("Click New Claim Entry", String.Format("<mark>{0}</mark> is visible", "Select Line of Business:"));
            else
                this.TESTREPORT.LogFailure("Click New Claim Entry", String.Format("<mark>{0}</mark> is not visible", "Select Line of Business:"), this.SCREENSHOTFILE);
        }

        public void VerifyAutoForm(string autoText)
        {
            this.driver.ClickElement(byDropDownimage, "Image");
            By bySelectBusinessDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", autoText));
            this.driver.ClickElement(bySelectBusinessDropDown, "Drop Down value");
            //SWitching to Default..... 
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            //Switching to different frame.....
            this.driver.WaitElementPresent(byAutoSpan);
            if (this.driver.IsElementPresent(byAutoSpan))
                this.TESTREPORT.LogSuccess("Verify auto Form", String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form appeared", autoText, autoText));
            else
                this.TESTREPORT.LogFailure("Verify auto Form", String.Format("<mark>{0}</mark> selected from dropdown <mark>{1}</mark> form not appeared", autoText, autoText));
        }

        public void ClickCancel()
        {
            this.driver.ClickElement(byCancelButton, "Cancel Button");
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
            this.TESTREPORT.LogInfo("Click Submit Button");
            this.driver.ClickElement(bySubmitButton, "Submit Button");

        }

        public void VerifyRequiredfieldErrorMessage(int Count)
        {
            IList<IWebElement> FieldError = driver.FindElements(By.XPath("//td[contains(text(),'Required Field')]"));
            if (FieldError.Count > 0 && FieldError.Count == Count)
                this.TESTREPORT.LogSuccess("Verify Required field Error Message", String.Format("Required field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
            else
                this.TESTREPORT.LogFailure("Verify Required field Error Message", String.Format("Required field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
        }

        public void EnterOccurenceDate()
        {
            Thread.Sleep(2000);
            this.driver.ClickElement(byDateOfOccurenceDropdownimage, "Occurence DropDown Image");
            Thread.Sleep(2000);
            this.driver.ClickElement(byTodayDate, "Today Date in Occurence Calendar");

        }

        public void SelectLocationLoss(string LocationLoss)
        {
            this.driver.ClickElement(byLocationDropdOwnimage, "location dropdown image");
            By byLocationDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", LocationLoss));
            this.driver.ClickElement(byLocationDropDown, "Location Dropdown");
        }

        public void SelectStateOfLoss(string StateOfLoss)
        {
            this.driver.ClickElement(byStateOfLossDropdOwnimage, "StateOfLoss dropdown image");
            By byStateOfLossDropDown = By.XPath(string.Format("//td[contains(text(),'{0}')]", StateOfLoss));
            this.driver.ClickElement(byStateOfLossDropDown, "StateofLoss Dropdown");

        }

        public void EnterContactBusinessPhone(string BusinessContact)
        {
            this.TESTREPORT.LogInfo("EnterContactBusinessPhone");
            Thread.Sleep(3000);
            By BusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone");
            this.driver.ClickElement(BusinessPhone, "Business phone textBox");
            this.driver.SendKeysToElementClearFirst(byContactBusinessPhone, BusinessContact, "Business Phone Contact");

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

        public void ClickSaveDraft()
        {
            this.TESTREPORT.LogInfo("Click save Draft");
            Thread.Sleep(2000);
            this.driver.ClickElement(bySaveDraftButton, "CLick SaveDraft");
        }

        public void VerifyRequiredFieldErrormessage()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("verify RequiredField Error message");
            if (this.driver.IsWebElementDisplayed(byDateofOccuRequiredFieldText))
            {
                this.TESTREPORT.LogSuccess("Verify Required Field Message", String.Format("Error Message - <mark>{0}</mark> appeared for DateofOccurence", "Required Field"));
                Thread.Sleep(2000);
            }

            else if (this.driver.IsWebElementDisplayed(byLocationofLossRequiredFieldText))
            {
                this.TESTREPORT.LogSuccess("Verify Required Field Message", String.Format("Error Message - <mark>{0}</mark> appeared for LocationofLoss", "Required Field"));
                Thread.Sleep(2000);
            }

            else if (this.driver.IsWebElementDisplayed(byContactBusinessPhoneRequiredFieldText))
            {
                this.TESTREPORT.LogSuccess("Verify Required Field Message", String.Format("Error Message - <mark>{0}</mark> appeared for contactbusinesphone", "Required Field"));
                Thread.Sleep(2000);
            }

            else
            {
                this.TESTREPORT.LogFailure("Verify Required Field Message", String.Format("Error Message - <mark>{0}</mark> doesn't appeared", "Required Field"), this.SCREENSHOTFILE);
            }

        }

        public void VerifyDraftSavedSuccessfullyText()
        {
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("Verify Draft Saved Successfully text");
            this.driver.WaitElementPresent(byDraftSavedSuccessfullyText);
            if (this.driver.IsElementPresent(byDraftSavedSuccessfullyText))
            {
                this.TESTREPORT.LogSuccess("Verify DraftSavedSuccessfully Message", String.Format("Message - <mark>{0}</mark> appeared", "DraftSavedSuccessfully"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify DraftSavedSuccessfully Message", String.Format("Message - <mark>{0}</mark> doesn't appeared", "DraftSavedSuccessfully"), this.SCREENSHOTFILE);
            }
        }

        public void SavedDraftsText()
        {
            this.TESTREPORT.LogInfo("verify SavedDrafts text in table");
            Thread.Sleep(2000);
            this.driver.SwitchTo().Frame("MainContent_ASPxSplitter1_0_CC");
            this.driver.WaitElementPresent(bySavedDraftsText);
            if (this.driver.IsElementPresent(bySavedDraftsText))
            {
                this.TESTREPORT.LogSuccess("Verify SavedDrafts Text", String.Format("Text - <mark>{0}</mark> appeared", "SavedDrafts"));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify SavedDrafts Text", String.Format("Text - <mark>{0}</mark> doesn't appeared", "SavedDrafts"), this.SCREENSHOTFILE);
            }

        }

        public void VerifyLineofBusinessinTable(string value)
        {
            this.TESTREPORT.LogInfo("verify LOB value for the savedDraft in table");
            string expectedvalue = value.ToLower();
            By byLOB = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[1]");
            string actualvalue = this.driver.GetElementText(byLOB).ToLower();
            this.driver.AssertTextMatching(actualvalue, expectedvalue);
        }

        public void VerifyAccidentDateinTable(string expectedvalue)
        {
            this.TESTREPORT.LogInfo("verify Accident date value for the SavedDraft in table");
            By byAccidentDate = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[2]");
            string actualvalue = this.driver.GetElementText(byAccidentDate);
            this.driver.AssertTextMatching(actualvalue, expectedvalue);
        }

        public void VerifyClaimanatNameinTable(string expectedvalue)
        {
            this.TESTREPORT.LogInfo("Verify Claimant Name value for the SavedDraft in table");
            By byClaimantName = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[3]");
            string actualvalue = this.driver.GetElementText(byClaimantName);
            this.driver.AssertTextMatching(actualvalue, expectedvalue);
        }

        public void VerifyLocationinTable(string value)
        {

            this.TESTREPORT.LogInfo("verfiy location value for the SavedDraft in table");
            Thread.Sleep(2000);
            By byLocation = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[4]");
            //to split actual value
            string value2 = this.driver.GetElementText(byLocation);
            string[] values = value2.Split('-');
            string actualvalue = values[0].Trim() + values[1].Trim();

            //to split expected value
            string[] value1 = value.Split('-');
            string expectedvalue = value1[0].Trim() + value1[1].Trim();
            this.driver.AssertTextMatching(actualvalue, expectedvalue);
        }

        public void VerifyDescriptioninTable(string expectedvalue)
        {
            this.TESTREPORT.LogInfo("verfiy Description value for the SavedDraft in table");
            By bydescription = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[5]");
            string actualvalue = this.driver.GetElementText(bydescription);
            this.driver.AssertTextMatching(actualvalue, expectedvalue);

        }

        public void EnterDescribeLoss(string describelossvalue)
        {
            Thread.Sleep(2000);
            this.driver.SendKeysToElementClearFirst(byDescribeLoss, describelossvalue, "Enter DescribeLoss");
        }

        public string GetDateofOccurence()
        {

            return (this.driver.GetElementAttribute(byDateofOccurenceField, "value"));

        }

        public string GetLocationofLoss()
        {

            return (this.driver.GetElementAttribute(byLocationofLossField, "value"));

        }

        public string GetDescribeLoss()
        {

            return (this.driver.GetElementText(byDescribeLoss));

        }

        public void ClickDelete(string ExpectedAlertmessage)
        {
            this.TESTREPORT.LogInfo("click Delete in SavedDrafts table and click ok in the alert");
            this.driver.ClickElement(byDeleteButton, "CLick Delete button in savedDrafts table");
            Thread.Sleep(2000);
            string ActualAlertmessage = this.driver.SwitchTo().Alert().Text;
            this.TESTREPORT.LogInfo("Verify Alert message when delete a draft");
            this.driver.AssertTextMatching(ActualAlertmessage, ExpectedAlertmessage);
            this.driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        public int SavedDraftsTableCount()
        {
            By bysaveddraftdropdownbutton = By.XPath("//span[@id='MainContent_griddata_DXPagerTop_DDBImg']");
            this.driver.ClickElement(bysaveddraftdropdownbutton, "Click SavedDraft Dropdown Button");
            Thread.Sleep(2000);
            By byAll = By.XPath("//div[@id='MainContent_griddata_DXPagerTop_PSP_DXI5_T']");
            this.driver.ClickElement(byAll, "Click 'All' to display the results in a single page");
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(bySavedDraftsTableCount);
            return (list.Count());
        }

        public void VerifySavedDraftsTablecountAfterDelete(int a)
        {
            this.TESTREPORT.LogInfo("count SavedDrafts table after deleting a draft");
            IReadOnlyList<IWebElement> listafterdelete = this.driver.FindElements(bySavedDraftsTableCount);
            int b = listafterdelete.Count();
            Thread.Sleep(2000);
            if ((a - b) == 1)
            {
                this.TESTREPORT.LogSuccess("Verify SavedDrafts tablecount after 1 draft is Deleted", string.Format("Draft deleted,Table Count:<mark>{0}</mark> satisfied", listafterdelete.Count));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify SavedDrafts tablecount after 1 draft is Deleted", string.Format("Draft not deleted,Table Count:<mark>{0}</mark> doesn't satisfy", listafterdelete.Count), this.SCREENSHOTFILE);

            }
        }

        public void VerifyLossInformation()
        {

            this.TESTREPORT.LogInfo("Verify LossInformation");
            this.driver.WaitElementPresent(byLossInformation);
            if (this.driver.IsElementPresent(byLossInformation))
                this.TESTREPORT.LogSuccess("Verify LossInformation", string.Format("section:<mark>{0}</mark> is present in the AUTO Page", "LossInformation"));
            else
                this.TESTREPORT.LogFailure("Verify LossInformation", string.Format("Unable to find, section:<mark>{0}</mark>", "LossInformation"), this.SCREENSHOTFILE);


            this.driver.ClickElement(byLossInformationDropdownButton, "LossInformationDropdownButton");
        }

        public void VerifyInsuredVehicleInformation()
        {
            this.TESTREPORT.LogInfo("Verify InsuredVehicleInformation");
            this.driver.WaitElementPresent(byInsuredVehicleInformation);
            if (this.driver.IsElementPresent(byInsuredVehicleInformation))
                this.TESTREPORT.LogSuccess("Verify InsuredVehicleInformation", string.Format("section:<mark>{0}</mark> is present in the AUTO Page", "InsuredVehicleInformation"));
            else
                this.TESTREPORT.LogFailure("Verify InsuredVehicleInformation", string.Format("Unable to find, section:<mark>{0}</mark>", "InsuredVehicleInformation"), this.SCREENSHOTFILE);

        }

        public void VerifyPropertyDamageInformation()
        {
            this.TESTREPORT.LogInfo("Verify PropertyDamageInformation");
            this.driver.WaitElementPresent(byPropertyDamageInformation);
            if (this.driver.IsElementPresent(byPropertyDamageInformation))
                this.TESTREPORT.LogSuccess("Verify PropertyDamageInformation", string.Format("section:<mark>{0}</mark> is present in the AUTO Page", "PropertyDamageInformation"));
            else
                this.TESTREPORT.LogFailure("Verify PropertyDamageInformation", string.Format("Unable to find, section:<mark>{0}</mark>", "PropertyDamageInformation"), this.SCREENSHOTFILE);

        }

        public void VerifyPartyInformation()
        {
            this.TESTREPORT.LogInfo("Verify PartyInformation");
            this.driver.WaitElementPresent(byPartyInformation);
            if (this.driver.IsElementPresent(byPartyInformation))
                this.TESTREPORT.LogSuccess("Verify PartyInformation", string.Format("section:<mark>{0}</mark> is present in the AUTO Page", "PartyInformation"));
            else
                this.TESTREPORT.LogFailure("Verify PartyInformation", string.Format("Unable to find, section:<mark>{0}</mark>", "PartyInformation"), this.SCREENSHOTFILE);

        }

        public void VerifyClaimSubmission()
        {
            this.TESTREPORT.LogInfo("Verify ClaimSubmission");
            this.driver.WaitElementPresent(byClaimSubmission);
            if (this.driver.IsElementPresent(byClaimSubmission))
                this.TESTREPORT.LogSuccess("Verify ClaimSubmission", string.Format("section:<mark>{0}</mark> is present in the AUTO Page", "ClaimSubmission"));
            else
                this.TESTREPORT.LogFailure("Verify ClaimSubmission", string.Format("Unable to find, section:<mark>{0}</mark>", "ClaimSubmission"), this.SCREENSHOTFILE);

        }

        public string ClickontheSavedAutoClaim()
        {

            By byAccidentDate = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[2]");
            string accidentdate = this.driver.GetElementText(byAccidentDate);
            Thread.Sleep(2000);
            this.TESTREPORT.LogInfo("ClickontheSavedAutoClaim");
            By byClaim = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[contains(@class,'dxgvDataRow dxgvFocusedRow')]//td[1]");
            this.driver.ClickElement(byClaim, "saved claim");
            return accidentdate;
        }

        public void VerifyAccidentDate(string expectedvalue)
        {
            this.TESTREPORT.LogInfo("Verify the Accident Date in the table with the date of occurence");
            string actualvalue = this.driver.GetElementAttribute(byDateofOccurenceField, "value");
            this.driver.AssertTextMatching(actualvalue, expectedvalue);
        }

        public void VerifySavedDraftsTableHeaders(string value)
        {
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//table[@id='MainContent_griddata_DXMainTable']//th[contains(@class,'dxgvHeader')]"));
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify TableHeaders in SavedDrafts Table", string.Format("Header contains:<mark>{0}</mark>", item.Text));
                    break;
                }
            }
        }
    }
}
