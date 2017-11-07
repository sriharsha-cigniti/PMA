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
        #region parameters

        public static string HomePageTitle { get; set; }
        public static string SelectBusinessvalueDropDown { get; set; }   
        public static string RequiredErrorMessageCount { get; set; }
        public static string ContactBusinessPhone { get; set; }
        public static string DataSaveMessage { get; set; }
        public static string StateofLoss { get; set; }
        public static string LocationLoss { get; set; }
        public static string DescribeLoss { get; set; }
        public static string Alertmessage { get; set; }
        public static string VehicleNo { get; set; }
        public static string Year { get; set; }
        public static string Make { get; set; }
        public static string Model { get; set; }
        public static string VIN { get; set; }
        public static string PlateNo { get; set; }
        public static string DriverFirstName { get; set; }
        public static string DriverLastName { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Zip { get; set; }
        public static string ResidencePhone { get; set; }
        public static string BusinessPhone { get; set; }
        public static string DriversLicense { get; set; }
        public static string Descriptionofinjury { get; set; }
        public static string DescribeDamage { get; set; }
        public static string EstimateAmount { get; set; }
        public static string WherecanVehiclebeseen { get; set; }
        public static string WhencanVehiclebeseen { get; set; }
        public static string OtherInsuranceonVehicle { get; set; }
        public static string TimeofOccurrence { get; set; }

        
        
        #endregion

        public NCEAutoPageTest()
        {
            // Read CSV values

            HomePageTitle = readCSV("HomePageTitle");
            SelectBusinessvalueDropDown = readCSV("SelectBusinessvalueDropDown");
            RequiredErrorMessageCount = readCSV("RequiredErrorMessageCount");
            ContactBusinessPhone = readCSV("ContactBusinessPhone");
            DataSaveMessage = readCSV("DataSaveMessage");
            StateofLoss = readCSV("StateOfLoss");
            LocationLoss = readCSV("LocationLoss");
            DescribeLoss = readCSV("DescribeLoss");
            Alertmessage = readCSV("Alertmessage");
            VehicleNo = readCSV("VehicleNo");
            Year = readCSV("Year");
            Make = readCSV("Make");
            Model = readCSV("Model");
            VIN = readCSV("VIN");
            PlateNo = readCSV("PlateNo");
            DriverFirstName = readCSV("DriverFirstName");
            DriverLastName = readCSV("DriverLastName");
            Address = readCSV("Address");
            City = readCSV("City");
            Zip = readCSV("Zip");
            ResidencePhone = readCSV("ResidencePhone");
            BusinessPhone = readCSV("BusinessPhone");
            DriversLicense = readCSV("DriversLicense");
            Descriptionofinjury = readCSV("Descriptionofinjury");
            DescribeDamage = readCSV("DescribeDamage");
            EstimateAmount = readCSV("EstimateAmount");
            WherecanVehiclebeseen = readCSV("WherecanVehiclebeseen");
            WhencanVehiclebeseen = readCSV("WhencanVehiclebeseen");
            OtherInsuranceonVehicle = readCSV("OtherInsuranceonVehicle");
            TimeofOccurrence = readCSV("TimeofOccurrence");

    }

        [TestMethod, Description("NCEAutoPage-Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void NA_01nceAutoPage()
        {
            this.TESTREPORT.InitTestCase("NA_01", "NCE Auto-Create a new Auto claim and cancel");
            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //Click on New Claim Entry Tab
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify Auto text
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            //Click on Cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            //CLick on eXit 
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, fill out only the required fields and submit"), TestCategory("Regression")]
        public void NA_02nceAutoPage()
        {

            this.TESTREPORT.InitTestCase("NA_02", "Create a new Auto claim, fill out only the required fields and submit");
            //verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //verify cinch welcome
            home.VerifyCinchWelome();
            //Click on New Claim Entry Tab
            this.TESTREPORT.LogInfo("Verify New Claim Entry Tab and 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //Verify Auto text
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            //Click on Submit
            this.TESTREPORT.LogInfo("Verify '!Required Field' error message");
            nceAuto.ClickSubmit();
            //Verify Required field error message count
            nceAuto.VerifyRequiredfieldErrorMessage(Convert.ToInt32(RequiredErrorMessageCount));
            //Fill/Select the required fields
            this.TESTREPORT.LogInfo("Verify 'The claim information you entered has been recorded and saved' message");
            string Date = DateTime.Now.ToString("MM/dd/yyyy");
            nceAuto.EnterOccurenceDate();
            nceAuto.SelectLocationLoss(LocationLoss);
            nceAuto.SelectStateOfLoss(StateofLoss);
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //Click on Submit
            nceAuto.ClickSubmit();
            //VErify Confirmation message
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }
        
        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, fill out all fields and submit"), TestCategory("Regression")]
        public void NA_nce03AutoPage()
        {

            this.TESTREPORT.InitTestCase("NA_03", "Create a new Auto claim, fill out all fields and submit");
                        
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

            //Click on Submit
            nceAuto.ClickSubmit();
            //verify Confirmation message
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
            
        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim and save as draft"), TestCategory("Regression")]
        public void NA_04nceAutoPage()
        {

            this.TESTREPORT.InitTestCase("NA_04", "Create a new Auto claim and save as draft");
            
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

            //click on cancel
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
            //click on Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, return to the saved claim page and delete"), TestCategory("Regression")]
        public void NA_05nceAutoPage()
        {

            this.TESTREPORT.InitTestCase("NA_05", "Create a new Auto claim, save as draft, return to the saved claim page and delete");
           
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
            // Verify Confirmation message
            nceAuto.VerifyDraftSavedSuccessfullyText();
            //get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();
            string d = nceAuto.GetDescribeLoss();
            //Click on cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();
            //Verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //Get SavedDraft Table count
            int count = nceAuto.SavedDraftsTableCount();
            //Verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //Verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //Verfiy location in table
            nceAuto.VerifyLocationinTable(b);
            //Verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            //Click Delete
            nceAuto.ClickDelete(Alertmessage);
            //Count saved drafts table
            nceAuto.VerifySavedDraftsTablecountAfterDelete(count);
            nceAuto.SwitchToDefaultContent();
            //Click on Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, navigate back to draft and submit claim with only required fields"), TestCategory("Regression")]
        public void NA_06nceAutoPage()
        {
            this.TESTREPORT.InitTestCase("NA_06", "Create a new Auto claim, save as draft, navigate back to draft and submit claim with only required fields");

            //Verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //Verify cinch welcome
            home.VerifyCinchWelome();
            //Click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            //Click save Draft
            nceAuto.ClickSaveDraft();
            //Verify RequiredField Error message
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
            //Get elements text
            string a = nceAuto.GetDateofOccurence();
            string b = nceAuto.GetLocationofLoss();
            string d = nceAuto.GetDescribeLoss();
            //Click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();
            //Verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //Verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //Verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //Verify location in table
            nceAuto.VerifyLocationinTable(b);
            //Verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            //Click on the saved auto claim
            string Accidentdate = nceAuto.ClickontheSavedAutoClaim();
            //The Accident Date in the table should match with the field 'Date of Occurrence' 
            nceAuto.VerifyAccidentDate(Accidentdate);
            //Click submit
            nceAuto.ClickSubmit();
            //Verify RequiredField Error message
            nceAuto.VerifyRequiredFieldErrormessage();

            //Fill the required fields(by providing contact business phone)
            nceAuto.EnterContactBusinessPhone(ContactBusinessPhone);
            //Click submit
            nceAuto.ClickSubmit();
            //Verify Confirmation message
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            //Click on Exit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("NCEAutoPage-Create a new Auto claim, save as draft, navigate back to draft and submit claim with all fields"), TestCategory("Regression")]
        public void NA_07nceAutoPage()
        {
            this.TESTREPORT.InitTestCase("NA_07", "Create a new Auto claim, save as draft, navigate back to draft and submit claim with all fields");

            //Verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //Verify cinch welcome
            home.VerifyCinchWelome();
            //Click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            //Click save Draft
            nceAuto.ClickSaveDraft();
            //Verify RequiredField Error message
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

            //Click cancel
            this.TESTREPORT.LogInfo("Verify Cancel");
            nceAuto.ClickCancel();
            nceAuto.SwitchToDefaultContent();
            //Verify saved drafts text in table
            nceAuto.SavedDraftsText();
            //Verify LOB in table
            nceAuto.VerifyLineofBusinessinTable(SelectBusinessvalueDropDown);
            //Verify Accident date in table
            nceAuto.VerifyAccidentDateinTable(a);
            //Verify location in table
            nceAuto.VerifyLocationinTable(b);
            //Verify description in table
            nceAuto.VerifyDescriptioninTable(d);
            //Click on the saved auto claim
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
            //Click on submit
            nceAuto.ClickSubmit();
            //Verify confirmation message
            nceAuto.VerifyDataSaveMessage(DataSaveMessage);
            nceAuto.SwitchToDefaultContent();
            //click Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();
            
        }

        [TestMethod, Description("NCEAutoPage-Verify the Tabs/sections present in the Auto Claim"), TestCategory("Regression")]
        public void NA_08nceAutoPage()
        {
            this.TESTREPORT.InitTestCase("NA_08", "Verify the Tabs/sections present in the Auto Claim");

            //Verify home page title
            home.VerifyPageTitle(HomePageTitle);
            //Verify cinch welcome
            home.VerifyCinchWelome();
            //Click new Claim Entry and verify select line of business text
            this.TESTREPORT.LogInfo("click New Claim Entry Tab and verify 'Select Line of Business' text");
            nceAuto.ClickOnNewClaimEntry();
            //select 'Auto' from the select line of business
            this.TESTREPORT.LogInfo("Verify 'Auto' text");
            nceAuto.VerifyAutoForm(SelectBusinessvalueDropDown);
            //Verify the sections present in the auto Page
            nceAuto.VerifyLossInformation();
            nceAuto.VerifyInsuredVehicleInformation();
            nceAuto.VerifyPropertyDamageInformation();
            nceAuto.VerifyPartyInformation();
            nceAuto.VerifyClaimSubmission();
            nceAuto.SwitchToDefaultContent();
            //Click on Exit
            home.ClickExit();

            this.TESTREPORT.UpdateTestCaseStatus();

        }



    }
}