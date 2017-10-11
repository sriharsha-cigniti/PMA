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
    public class SettingsPageTest : PMA.TestBaseTemplate
    {

        [TestMethod, Description("Settings-Navigate to the Settings area and set a default account"), TestCategory("Regression")]
        public void Settings_01settingsPage()
        {
            #region Objects
            HomePage home = new HomePage();
            SettingsPage settingsPage = new SettingsPage();
            LoginPage login = new LoginPage();
            #endregion

            this.TESTREPORT.InitTestCase("Settings_01", "Navigate to the Settings area and set a default account");
            #region
            string HomePageTitle = readCSV("HomePageTitle");
            string SettingsPageTitle = readCSV("SettingsPageTitle");
            string DefaultAccountvalue = readCSV("DefaultAccountvalue");
            string DataSaveMessage = readCSV("DataSaveMessage");
            #endregion

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();

            this.TESTREPORT.LogInfo("Verify Settings Click and Page title ");
            settingsPage.ClickOnSettings();
            home.VerifyPageTitle(SettingsPageTitle);

            this.TESTREPORT.LogInfo("Verify Text Message- 'Data has been saved successfully'" );

            settingsPage.SelectDefaultAccount(DefaultAccountvalue);
            settingsPage.SaveSettings();
            settingsPage.VerifyDataSaveMessage(DataSaveMessage);
            string accountDetails = settingsPage.GetAccountDetails();
            home.ClickExit();

            this.TESTREPORT.LogInfo("Re-Login into application");
            login.OpenBrowser();

            this.TESTREPORT.LogInfo("Verify Default Account details applied");
            settingsPage.VerifyDefaulAccountDetailsIsApplied(accountDetails);

            
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
            
        }
    }
}