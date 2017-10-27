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
    public class NCEGeneralLiability : AbstractTemplatePage
    {
        #region UI Objects
        private By byClaimNewInquirytab = By.XPath("//span[contains(text(),'New Claim Entry')]");
        private By byDropdOwnimage = By.XPath("//span[@id='MainContent_ddlob_B-1Img']");
        private By bySelectBusinessLabel = By.XPath("//div[@id='MainContent_up1']//label[contains(text(),'Select Line of Business:')]");
        private By byAutoSpan = By.XPath("//span[contains(text(),'General Liability')]");
        private By byLostInformation = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_HC");
        private By byContactBusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtConBusPhone_I");
        private By byAddress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempaddress_I");
        private By byCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtempcity_I");
        private By byTimeOccurence = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_timeEditoccurrence_I");
        private By byAUthoritytext = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtAuthority_I");
        private By bydescribeLoss = By.Name("ctl00$MainContent$CallbackPanel$ASPxRoundPanel1$pnlContent$memoccurrencedesc");
        private By byZipcode = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_txtLossZip_I");
        private By bySubmitButton = By.XPath("//div[@id='MainContent_btnSubmit']//span[contains(text(),'Submit')]");
        private By bySavedDraftButton = By.XPath("//div[@id='MainContent_btnSaveAsDraft_CD']//span[contains(text(),'Save Draft')]");
        private By byDataGridRows = By.XPath("//table[@id='MainContent_griddata_DXMainTable']/tbody/tr[contains(@id,'MainContent_griddata_DXDataRow')]");
        private By byTablerow = By.XPath("//table[@id='MainContent_griddata_DXMainTable']//tr[@id='MainContent_griddata_DXDataRow0']//td");
        private By byDeleteLink = By.XPath("//a[@id='MainContent_griddata_DXCBtn0']/span[contains(text(),'Delete')]");
        private By byFirstName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantFirstName_I");
        private By byLastName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantLastName_I");
        private By byOrganization = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantOrgName_I");
        private By byClaimantAdress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantAddress_I");
        private By byClaimCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantCity_I");
        private By byClaimState = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_ddClaimantState_B-1Img");
        private By byClaimZipCode = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantZip_I");
        private By byPhoneNumber = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtClaimantPhone_I");
        private By byDescriptionOfInjury = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_memClaimantInjuryDesc_I");
        private By byInjuryTaken = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_memInjuredTaken_I");
        private By byPriorToInjury = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_memInjuredPrior_I");
        private By byPropertyDescription = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_memPropertyDescription_I");
        private By byIndicateDamageRadio = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_rdVehicleOrProperty_RB1_I_D");
        private By byEstimateAmount = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_spEstimateAmount_I");
        private By bywhereCanPropertyCanSeen = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtWhereSeen_I");
        private By byWhenCAnpropertyCanseen = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_txtWhenSeen_I");
        private By bywitnessFIirstName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1FirstName_I");
        private By byWitnessLastName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1LastName_I");
        private By byWitnessAddress = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1Address_I");
        private By byWitnessCity = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1City_I");
        private By byWitnesszIp = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1Zip_I");
        private By byWitnessState = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_ddWitness1State_B-1Img");
        private By byWitnessResidentPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1Phone_I");
        private By byWitnessBusinessPhone = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtWitness1BusinessPhone_I");
        private By byWitnessOtherRemarks = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_memRemarks_I");
        private By byWitnessReportedByFirstName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtReportedByFirstName_I");
        private By byWitnessReportedByLastName = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtReportedByLastName_I");
        private By byWitnessReportedTo = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_txtReportedTo_I");
        private By byClaimSubmissionComments = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_memcomment_I");
        private By byClaimRecordOnly = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_chkrecordonly_S_D");
        private By byClaimEmailcheck = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_chkEmailCopy_S_D");
        private By byClaimMUltipleAdressTextbox = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_ASPxPanel3_mememailcc_I");
        private By byWitnessInformationBar = By.Id("MainContent_CallbackPanel_ASPxRoundPanel3_CBImg");
        private By byInjuredPropertyInfoBar = By.Id("MainContent_CallbackPanel_ASPxRoundPanel2_CBImg");
        private By byclaimSubmissionBar = By.Id("MainContent_CallbackPanel_ASPxRoundPanel5_CBImg");
        private By byLossInformationBar = By.Id("MainContent_CallbackPanel_ASPxRoundPanel1_CBImg");
        private By byLocationOfLossTextbox = By.XPath("div[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_dtOccurrence_AcAs']");
        private By byDateOfOccurenceTextbox = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_DDD_L_LBT']/tbody/tr/td[@class='dxeListBoxItem  dxeListBoxItemSelected dxeListBoxItemHover']");
        private By byLocationDropdOwnimage = By.XPath("//span[@id='MainContent_CallbackPanel_ASPxRoundPanel1_pnlContent_ddlocation_B-1Img']");

        #endregion

        #region Public Methods

        public void VerifyGeneralLIabilityForm(string dropDOwnText)
        {
            VerifyForm(dropDOwnText, byAutoSpan);
        }

        public void VerifyColorChange()
        {
            string getColor = this.driver.FindElement(byLostInformation).GetAttribute("style");
            
            if (getColor.Contains("background-color: rgb(0, 56, 135)") || getColor.Contains("background - color: red"))
            {
                this.TESTREPORT.LogSuccess("Verify Loss Information color change", string.Format("actual -<mark>{0}</mark> expected  {1} is equal", "", getColor));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Data Grid row count", string.Format("actual count -<mark>{0}</mark> expected count {1} is not equal", "background-color: red", getColor));
            }
        }

        public void VerifyErrorMessage(int Count, string InvalidData)
        {
            this.driver.ClickElement(byContactBusinessPhone, "Business phone textBox");
            this.driver.SendKeysToElementClearFirst(byContactBusinessPhone, InvalidData, "Business Phone Contact");
            this.driver.ClickElement(byZipcode, "Zip Code textBox");
            this.driver.SendKeysToElementClearFirst(byZipcode, InvalidData, "Zip codes Contact");
            this.driver.ClickElement(bySubmitButton, "Submit Button");
            IList<IWebElement> FieldError = driver.FindElements(By.XPath("//td[contains(text(),'Invalid Format')]"));
            if (FieldError.Count > 0 && FieldError.Count == Count)
                this.TESTREPORT.LogSuccess("Verify InvalidFormat field Error Message", String.Format("InvalidFormat field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
            else
                this.TESTREPORT.LogFailure("Verify InvalidFormat field Error Message", String.Format("InvalidFormat field error with count: <mark>{0}</mark>", FieldError.Count.ToString()));
        }

        public void EnterZipCode(string zipCode)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byZipcode, "Zip Code textBox");
            this.driver.SendKeysToElementClearFirst(byZipcode, zipCode, "Zip Code textBox");
        }

        public void EnterAddress(string address)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byAddress, "address textBox");
            this.driver.SendKeysToElementClearFirst(byAddress, address, "address textBox");
        }

        public void EnterCity(string city)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byCity, "city textBox");
            this.driver.SendKeysToElementClearFirst(byCity, city, "city textBox");
        }

        public void EnterAuthoritycontacted(string Authoritycontacted)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byAUthoritytext, "Authoritycontacted textBox");
            this.driver.SendKeysToElementClearFirst(byAUthoritytext, Authoritycontacted, "Authoritycontacted textBox");
        }

        public void EntertimeOccurence(string timeOccurence)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byTimeOccurence, "timeOccurence textBox");
            this.driver.SendKeysToElementClearFirst(byTimeOccurence, timeOccurence, "timeOccurences textBox");
        }

        public void EnterDescribeLoss(string DescribeLoss)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(bydescribeLoss, "Describe Loss textBox");
            this.driver.SendKeysToElementClearFirst(bydescribeLoss, DescribeLoss, "Describe Loss textBox");
        }

        public void ClickOnSavedraft()
        {
            this.driver.ClickElement(bySavedDraftButton, "Save Draft");
        }

        public void EnterInjuredDamagedPropertyInformation(string name, string Organization, string claimntadress, string city, string state, string Zip, string Phone, string DescriptionOfInJury, string whereInjuryTaken, string InjuredPriorToInjury, string DescribeProperty, int EstimatedAmount, string Whereproperty, string WhenProperty )
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byInjuredPropertyInfoBar, "Injured Property Information Bar");

            this.driver.SendKeysToElementClearFirst(byFirstName, name, "Claim first name");
            this.driver.SendKeysToElementClearFirst(byLastName, name, "Claim last name");
            this.driver.SendKeysToElementClearFirst(byOrganization, Organization, "Claim Organization name");
            this.driver.SendKeysToElementClearFirst(byClaimantAdress, claimntadress, "Claim Adress name");
            this.driver.SendKeysToElementClearFirst(byClaimCity, city, "Claim city");

            this.driver.ClickElement(byClaimState, "Claim state dropdown image");
            By Claimstatedropdown = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel2_ASPxPanel2_ddClaimantState_DDD_L_LBT']/tbody/tr[2]/td");
            this.driver.ClickElement(Claimstatedropdown, "Claim state dropdown");

            this.driver.SendKeysToElementClearFirst(byClaimZipCode, Zip, "Claim zip code");
            this.driver.SendKeysToElementClearFirst(byPhoneNumber, Phone, "Claim Phonenumber");
            this.driver.SendKeysToElementClearFirst(byDescriptionOfInjury, DescriptionOfInJury, "Description of injury");
            this.driver.SendKeysToElementClearFirst(byInjuryTaken, whereInjuryTaken, "Where Injury Taken");
            this.driver.SendKeysToElementClearFirst(byPriorToInjury, InjuredPriorToInjury, "InjuryTakenPriorToInjury");
            this.driver.ClickElement(byIndicateDamageRadio, "Property CheckBox");
            this.driver.SendKeysToElementClearFirst(byPropertyDescription, InjuredPriorToInjury, "Description of Property");
            this.driver.SendKeysToElementClearFirst(byEstimateAmount, EstimatedAmount.ToString(), "Estimate amount");
            this.driver.SendKeysToElementClearFirst(byWhenCAnpropertyCanseen, WhenProperty, "WhenPropertyseen");
            this.driver.SendKeysToElementClearFirst(bywhereCanPropertyCanSeen, Whereproperty, "WhenPropertyseen");
        }

        public void EnterWitnessInformation(string name, string Organization, string Witnessadress, string city, string state, string Zip, string Phone, string OtherRemarks)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byWitnessInformationBar, "Witness Information Bar");
            this.driver.SendKeysToElementClearFirst(bywitnessFIirstName, name, "Witness first name");
            this.driver.SendKeysToElementClearFirst(byWitnessLastName, name, "Witness last name");
            this.driver.SendKeysToElementClearFirst(byWitnessAddress, Witnessadress, "Witness Adress name");
            this.driver.SendKeysToElementClearFirst(byWitnessCity, city, "Witness city");

            this.driver.ClickElement(byWitnessState, "Witness state dropdown image");
            By WitnessStatedropdown = By.XPath("//table[@id='MainContent_CallbackPanel_ASPxRoundPanel3_ASPxPanel4_ddWitness1State_DDD_L_LBT']/tbody/tr[2]/td");
            this.driver.ClickElement(WitnessStatedropdown, "Witness state dropdown");

            this.driver.SendKeysToElementClearFirst(byWitnesszIp, Zip, "Witness zip code");
            this.driver.SendKeysToElementClearFirst(byWitnessBusinessPhone, Phone, "Witness Business Phonenumber");
            this.driver.SendKeysToElementClearFirst(byWitnessResidentPhone, Phone, "Witness Residence Phonenumber");
            this.driver.SendKeysToElementClearFirst(byWitnessOtherRemarks, OtherRemarks, "Witness Other remarks");
            this.driver.SendKeysToElementClearFirst(byWitnessReportedByLastName, name, "Witness reported by last name");
            this.driver.SendKeysToElementClearFirst(byWitnessReportedByFirstName, name, "Witness reported by first name");
            this.driver.SendKeysToElementClearFirst(byWitnessReportedTo, name, "Witness reported to");
        }

        public void EnterclaimSubmission(string comments, string EmailAdress)
        {
            Thread.Sleep(3000);
            this.driver.ClickElement(byclaimSubmissionBar, "Claim Submission Bar");

            this.driver.SendKeysToElementClearFirst(byClaimSubmissionComments, comments, "ClaimSubmissionComments");
            this.driver.ClickElement(byClaimRecordOnly, "Claim record only CheckBox");
            this.driver.ClickElement(byClaimEmailcheck, "Claim Email Check CheckBox");
            this.driver.SendKeysToElementClearFirst(byClaimMUltipleAdressTextbox, EmailAdress, "ClaimEmailTextbox");
        }

        public void VerifyGridView()
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

            this.driver.WaitElementPresent(byTablerow);
            if (this.driver.IsElementPresent(byTablerow))
                this.TESTREPORT.LogSuccess("Verify Grid row", String.Format("<mark>{0}</mark> Grid row <mark>{1}</mark> is appeared", byTablerow, byTablerow));
            else
                this.TESTREPORT.LogFailure("Verify Grid row", String.Format("<mark>{0}</mark> Grid row <mark>{1}</mark> is not appeared", byTablerow, byTablerow));
        }

        public void VerifyRowDataingGrid(int number, string value)
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

            IReadOnlyList<IWebElement> list = this.driver.FindElements(byTablerow);

            if (list[number].Text.Trim().ToLower().Contains(value.Trim().ToLower()))
            {
                this.TESTREPORT.LogSuccess("Verify Data Grid row data", string.Format("<mark>{0}</mark>", list[number].Text));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Data Grid row data", string.Format("Falied to Verify the row value"), this.SCREENSHOTFILE);
            }
        }

        public string GetColumnDataFromRowGrid(int number)
        {
            Thread.Sleep(3000);
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

            IReadOnlyList<IWebElement> list = this.driver.FindElements(byTablerow);
            return list[number].Text;
        }

        //public void ValidatecolumnDataInLiabilityForm(string columnName, string value)
        //{
        //    string valueToVerify = string.Empty;
        //    this.driver.SwitchTo().DefaultContent();
        //    this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));

        //    switch (columnName)
        //    {
        //        case "LocationOfLoss":
        //            this.driver.ClickElement(byLocationDropdOwnimage, "location dropdown image");
        //            valueToVerify = this.driver.FindElement(byLocationOfLossTextbox).Text;
        //            break;
        //        default:
        //            break;
        //    }

        //    if (valueToVerify.Trim().ToLower().Contains(value.Trim().ToLower()))
        //    {
        //        this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is equal", value, valueToVerify));
        //    }
        //    else
        //    {
        //        this.TESTREPORT.LogSuccess("Verify Text from saved claim for column ", string.Format("actual text -<mark>{0}</mark> expected count {1} is not equal", value, valueToVerify));
        //    }
        //}

        public void ClickOnDelete()
        {
            this.driver.ClickElement(byDeleteLink, "Delete Link");
        }

        public void HandleDeleteLiabilityAlert(string text)
        {
            Thread.Sleep(3000);
            IAlert deleteAlert = this.driver.SwitchTo().Alert();
            string getAlertText = deleteAlert.Text;
            this.TESTREPORT.LogInfo(string.Format("Get Text from delete saved claim", getAlertText));
            if (getAlertText.Contains(text))
            {
                this.TESTREPORT.LogSuccess("Verify Text from delete saved claim", string.Format("actual count -<mark>{0}</mark> expected count {1} is equal", getAlertText, text));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Text from delete saved claim", string.Format("actual count -<mark>{0}</mark> expected count {1} is not equal", getAlertText, text));
            }
            Thread.Sleep(3000);
            deleteAlert.Accept();
        }

        public int GetGridRowCount()
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byDataGridRows);
            this.TESTREPORT.LogInfo(string.Format("Get Grid Row Count : {0}", list.Count));
            return list.Count;
        }

        public void VerifyGridRowIsExistsAfterDeletion(int actualCount)
        {
            Thread.Sleep(3000);
            if (GetGridRowCount().Equals(actualCount))
            {
                this.TESTREPORT.LogSuccess("Verify Data Grid row count", string.Format("actual count -<mark>{0}</mark> expected count {1} is equal", actualCount, GetGridRowCount()));
            }
            else
            {
                this.TESTREPORT.LogFailure("Verify Data Grid row count", string.Format("actual count <mark>{0}</mark> expected count {1} is not equal", actualCount, GetGridRowCount()));
            }
        }

        public void ClickOnSavedClaiminGrid()
        {
            Thread.Sleep(4000);
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            
            IReadOnlyList<IWebElement> list = this.driver.FindElements(byTablerow);
            list[0].Click();
        }

        public void VerifyTextOnPage(string text)
        {
            this.driver.SwitchTo().DefaultContent();
            this.driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='MainContent_ASPxSplitter1_0_CC']")));
            
            By txtOnPage = By.XPath(string.Format("//span[contains(text(),'{0}')]", text));
            this.driver.WaitElementPresent(txtOnPage);
            if (this.driver.IsElementPresent(txtOnPage))
                this.TESTREPORT.LogSuccess("Verify text on page", String.Format("text - <mark>{0}</mark> appeared", text));
            else
                this.TESTREPORT.LogFailure("Verify text on page", String.Format("text - <mark>{0}</mark> doesn't appeared", text), this.SCREENSHOTFILE);

        }
        #endregion

    }
}
