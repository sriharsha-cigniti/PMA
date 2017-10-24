using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandardUtilities;
using OpenQA.Selenium;
using System.Collections;
using System.Threading;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class NCEAutoPageTest : PMA.TestBaseTemplate
    {

        [TestMethod, Description("NCEAutoPage-Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void NA_01nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_01", "NCE Auto-Create a new Auto claim and cancel");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NA_02nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_02", "Create a new Auto claim, fill out only the required fields and submit");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            this.TESTREPORT.LogInfo("Verify '!Required Field' error message");
            nceAuto.ClickSubmit();
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));

            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();


            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }


        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, fill out all fields and submit"), TestCategory("Regression")]
        public void NA_nce03AutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_03", "Create a new Auto claim, fill out all fields and submit");

            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            string Alertmessage = readCSV("Alertmessage");
            //InsuredVehicleInformation
            string VehicleNo = readCSV("VehicleNo");
            string Year = readCSV("Year");
            string Make = readCSV("Make");
            string Model = readCSV("Model");
            string VIN = readCSV("VIN");
            string PlateNo = readCSV("PlateNo");
            string DriverFirstName = readCSV("DriverFirstName");
            string DriverLastName = readCSV("DriverLastName");
            string Address = readCSV("Address");
            string City = readCSV("City");
            string Zip = readCSV("Zip");
            string ResidencePhone = readCSV("ResidencePhone");
            string BusinessPhone = readCSV("BusinessPhone");
            string DriversLicense = readCSV("DriversLicense");
            string Descriptionofinjury = readCSV("Descriptionofinjury");
            string DescribeDamage = readCSV("DescribeDamage");
            string EstimateAmount = readCSV("EstimateAmount");
            string WherecanVehiclebeseen = readCSV("WherecanVehiclebeseen");
            string WhencanVehiclebeseen = readCSV("WhencanVehiclebeseen");
            string OtherInsuranceonVehicle = readCSV("OtherInsuranceonVehicle");
            string TimeofOccurrence = readCSV("TimeofOccurrence");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            #region To fill all the fields before submittimg the claim


            //Fill the fields for LossInformation
            this.TESTREPORT.LogInfo("Fill the fields for LossInformation Section");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterDescribeLoss(DescribeLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            nceAuto.FillLossInformation(TimeofOccurrence, Address, City, Zip, ResidencePhone, DescribeDamage, DescribeLoss);


            //Fill the fields for InsuredVehicleInformation
            nceAuto.FillInsuredVehicleInformationSection(VehicleNo, Year, Make, Model, VIN, PlateNo, DriverFirstName, DriverLastName, Address, City, Zip, ResidencePhone, BusinessPhone, DriversLicense, Descriptionofinjury, DescribeDamage, EstimateAmount, WherecanVehiclebeseen, WhencanVehiclebeseen, OtherInsuranceonVehicle);

            //Fill the fields for PropertyDamageInformation 
            nceAuto.FillPropertyDamageInformationSection(DriverFirstName, DriverLastName, Address, City, Zip, ResidencePhone, BusinessPhone, Descriptionofinjury, DescribeDamage, EstimateAmount, WherecanVehiclebeseen, WhencanVehiclebeseen, DescribeLoss);


            //fill the fields for PartyInformation
            nceAuto.FillPartyInformationSection(DriverFirstName, DriverLastName, Address, City, Zip, BusinessPhone, Descriptionofinjury, DescribeDamage);

            //fill the fields for Claimsubmission
            nceAuto.FillClaimSubmission(DescribeLoss);

            #endregion

            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();


            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim and save as draft"), TestCategory("Regression")]
        public void NA_04nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_04", "Create a new Auto claim and save as draft");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            //Click save Draft
            nceAuto.ClickSaveDraft();

            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft and save draft
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterDescribeLoss(DescribeLoss);

            //Click save Draft again
            nceAuto.ClickSaveDraft();

            // Draft Saved Successfully text
            nceAuto.VerifyDraftSavedSuccessfullyText();

            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();

            string d = nceAuto.GetDescribeLoss();

            //click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();

            //verify saved drafts text in table
            nceAuto.SavedDraftsText();

            //verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);            
            //verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }


        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NA_05nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_05", "Create a new Auto claim, save as draft, return to the saved claim page and delete");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            string Alertmessage = readCSV("Alertmessage");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            //Click save Draft
            nceAuto.ClickSaveDraft();

            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft 
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterDescribeLoss(DescribeLoss);

            //Click save Draft again
            nceAuto.ClickSaveDraft();

            // Draft Saved Successfully text
            nceAuto.VerifyDraftSavedSuccessfullyText();

            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();
            string d = nceAuto.GetDescribeLoss();

            //click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();

            //verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //Get SavedDraft Table count
            int count = nceAuto.SavedDraftsTableCount();

            //verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);

            //verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            //click Delete
            nceAuto.ClickDelete(Alertmessage);
            //count saved drafts table
            nceAuto.VerifySavedDraftsTablecountAfterDelete(count);
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }


        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
        public void NA_06nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_06", "Create a new Auto claim, save as draft, navigate back to draft and submit claim with only required fields");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            string Alertmessage = readCSV("Alertmessage");
            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            //Click save Draft
            nceAuto.ClickSaveDraft();

            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft 
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterDescribeLoss(DescribeLoss);

            //Click save Draft again
            nceAuto.ClickSaveDraft();

            // Draft Saved Successfully text
            nceAuto.VerifyDraftSavedSuccessfullyText();

            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();
            string d = nceAuto.GetDescribeLoss();

            //click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();

            //verify saved drafts text in table
            nceAuto.SavedDraftsText();

            //verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //verify description in table
            nceAuto.VerifyDescriptioninTable(d);

            //click on the saved auto claim
            string Accidentdate = nceAuto.ClickontheSavedAutoClaim();
            //The Accident Date in the table should match with the field 'Date of Occurrence' 
            nceAuto.VerifyAccidentDate(Accidentdate);

            //click submit
            nceAuto.ClickSubmit();

            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //Fill the required fields(by providing contact business phone)
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //click submit
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();

            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }


        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NA_07nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_07", "Create a new Auto claim, save as draft, navigate back to draft and submit claim with all fields");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            string RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            string ContactBusinessPhone = readCSV("ContactBusinessPhone");
            string DataSaveMessage = readCSV("DataSaveMessage");
            string StateofLoss = readCSV("StateOfLoss");
            string LocationLoss = readCSV("LocationLoss");
            string DescribeLoss = readCSV("DescribeLoss");
            string Alertmessage = readCSV("Alertmessage");
            //InsuredVehicleInformation
            string VehicleNo = readCSV("VehicleNo");
            string Year = readCSV("Year");
            string Make = readCSV("Make");
            string Model = readCSV("Model");
            string VIN = readCSV("VIN");
            string PlateNo = readCSV("PlateNo");
            string DriverFirstName = readCSV("DriverFirstName");
            string DriverLastName = readCSV("DriverLastName");
            string Address = readCSV("Address");
            string City = readCSV("City");
            string Zip = readCSV("Zip");
            string ResidencePhone = readCSV("ResidencePhone");
            string BusinessPhone = readCSV("BusinessPhone");
            string DriversLicense = readCSV("DriversLicense");
            string Descriptionofinjury = readCSV("Descriptionofinjury");
            string DescribeDamage = readCSV("DescribeDamage");
            string EstimateAmount = readCSV("EstimateAmount");
            string WherecanVehiclebeseen = readCSV("WherecanVehiclebeseen");
            string WhencanVehiclebeseen = readCSV("WhencanVehiclebeseen");
            string OtherInsuranceonVehicle = readCSV("OtherInsuranceonVehicle");
            string TimeofOccurrence = readCSV("TimeofOccurrence");

            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            //Click save Draft
            nceAuto.ClickSaveDraft();

            //verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //To fill the required fields to save draft 
            this.TESTREPORT.LogInfo("To fill the required fields to save Draft");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterDescribeLoss(DescribeLoss);

            //Click save Draft again
            nceAuto.ClickSaveDraft();

            // Draft Saved Successfully text
            nceAuto.VerifyDraftSavedSuccessfullyText();

            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();
            string d = nceAuto.GetDescribeLoss();

            //click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();

            //verify saved drafts text in table
            nceAuto.SavedDraftsText();

            //verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //verify description in table
            nceAuto.VerifyDescriptioninTable(d);

            //click on the saved auto claim
            string Accidentdate = nceAuto.ClickontheSavedAutoClaim();
            //The Accident Date in the table should match with the field 'Date of Occurrence' 
            nceAuto.VerifyAccidentDate(Accidentdate);

            //Fill the required fields(by providing contact business phone)
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);

            #region To fill all the fields before submittimg the claim

            //Fill the fields for LossInformation
            this.TESTREPORT.LogInfo("Fill the fields for LossInformation Section");
            nceAuto.FillLossInformation(TimeofOccurrence, Address, City, Zip, ResidencePhone, DescribeDamage, DescribeLoss);

            //Fill the fields for InsuredVehicleInformation
            nceAuto.FillInsuredVehicleInformationSection(VehicleNo, Year, Make, Model, VIN, PlateNo, DriverFirstName, DriverLastName, Address, City, Zip, ResidencePhone, BusinessPhone, DriversLicense, Descriptionofinjury, DescribeDamage, EstimateAmount, WherecanVehiclebeseen, WhencanVehiclebeseen, OtherInsuranceonVehicle);

            //Fill the fields for PropertyDamageInformation 
            nceAuto.FillPropertyDamageInformationSection(DriverFirstName, DriverLastName, Address, City, Zip, ResidencePhone, BusinessPhone, Descriptionofinjury, DescribeDamage, EstimateAmount, WherecanVehiclebeseen, WhencanVehiclebeseen, DescribeLoss);


            //fill the fields for PartyInformation
            nceAuto.FillPartyInformationSection(DriverFirstName, DriverLastName, Address, City, Zip, BusinessPhone, Descriptionofinjury, DescribeDamage);

            //fill the fields for Claimsubmission
            nceAuto.FillClaimSubmission(DescribeLoss);

            #endregion
            //click submit
            nceAuto.ClickSubmit();
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();

            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();



        }


        [TestMethod, Description("NCEAutoPage-Verify the Tabs/sections present in the Auto Claim"), TestCategory("Regression")]
        public void NA_08nceAutoPage()
        {
            HomePage home = new HomePage();
            NCEAutoPage nceAuto = new NCEAutoPage();

            this.TESTREPORT.InitTestCase("NA_08", "Verify the Tabs/sections present in the Auto Claim");
            #region ReadCSV
            string HomePageTitle = readCSV("HomePageTitle");
            string SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");

            #endregion

            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();

            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);

            // verify the sections present in the auto Page
            nceAuto.VerifyLossInformation();
            nceAuto.VerifyInsuredVehicleInformation();
            nceAuto.VerifyPropertyDamageInformation();
            nceAuto.VerifyPartyInformation();
            nceAuto.VerifyClaimSubmission();
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();


        }



    }
}