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
using AUT.Selenium.CommonReUsablePages;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class ToolsPageTest : PMA.TestBaseTemplate
    {
        #region parameters
        public static string HomePageTitle { get; set; }
        public static string ToolsPageTitle { get; set; }
        public static string AccountNumber { get; set; }
        public static string ConfirmationMsg { get; set; }
        public static string AcctNumberHeader { get; set; }
        public static string FeatureHeader { get; set; }
        public static string BrokerCode { get; set; }
        #endregion

        public ToolsPageTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            ToolsPageTitle = readCSV("ToolsPageTitle");
            AccountNumber = readCSV("AccountNumber");
            ConfirmationMsg = readCSV("ConfirmationMsg");
            AcctNumberHeader = readCSV("AcctNumberHeader");
            FeatureHeader = readCSV("FeatureHeader");
            BrokerCode = readCSV("BrokerCode");
        }

        [TestMethod, Description("Tools - Search by user name and add account to the user profile"), TestCategory("Regression")]
        public void TOOL_U1()
        {
            this.TESTREPORT.InitTestCase("TOOL_U1", "Search by user name and add account to the user profile");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();
            Tools.VerifyUserTab();
            Tools.EnterLoginID(Environment.UserName);
            Tools.ClickSearch();
            int BeforeCount = Tools.ToolsResultsCount();
            Tools.AddAccount(AccountNumber);
            string AccountExistsMsg = "Account " + AccountNumber + " already exixts for the user.";
            Tools.ConfirmationMsg(BeforeCount, ConfirmationMsg, AccountExistsMsg);
            this.TESTREPORT.LogInfo("Re-Login into application");
            login.OpenBrowser();
            diaryNotes.ClickHome();
            home.ClickMyAccount();
            home.SearchMyAccout(AccountNumber, "Number");
            string myAccountName = home.GetMyAccount();
            home.VerifyAccountHeader(myAccountName);
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }
        [TestMethod, Description("Tools - Modify the user permissions to an account"), TestCategory("Regression")]
        public void TOOL_U2()
        {
            this.TESTREPORT.InitTestCase("TOOL_U2", "Modify the user permissions to an account");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();
            Tools.VerifyUserTab();
            Tools.EnterLoginID(Environment.UserName);
            Tools.ClickSearch();
            Tools.VerifyHeaderLabel();
            Tools.VerifyFunctionalPermssionLabel();
            Tools.VerifyDataPermssionLabel();
            Tools.ClickFunctionCheckAll();
            Tools.ClickDataCheckAll();
            Tools.ClickSubmit();
            Tools.VerifyLabel();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search by user name and add account to the user profile"), TestCategory("Regression")]
        public void TOOL_U3()
        {
            this.TESTREPORT.InitTestCase("TOOL_U3", "Search by user name and add account to the user profile");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();
            Tools.VerifyUserTab();
            Tools.EnterLoginID(Environment.UserName);
            Tools.ClickSearch();
            Tools.ClickDelete();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }

        [TestMethod, Description("Tools - Verify available Tab present in Tools"), TestCategory("Regression")]
        public void TOOL_U4()
        {
            this.TESTREPORT.InitTestCase("TOOL_U4", "Verify available Tab present in Tools");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();
            Tools.VerifyAndClickBrokersTab();
            Tools.VerifySearchByLabel();
            Tools.VerifyAndClickReportsTab();
            Tools.VerifyAccountLevelAndNameLabel();
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search by Features/Report Attachment by Account Number"), TestCategory("Regression")]
        public void TOOL_U5()
        {
            this.TESTREPORT.InitTestCase("TOOL_U5", "Search by Features/Report Attachment by Account Number");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            if (home.ClickTools())
            {
                home.VerifyPageTitle(ToolsPageTitle);
                Tools.VerifyAdministrationLabel();
                Tools.VerifyAndClickReportsTab();
                Tools.VerifyAccountLevelAndNameLabel();
                Tools.SearchAccount(AccountNumber);
                string ExpectedLable = "Account Level Opt Out Rule(s) For " + AccountNumber + "";
                Tools.VerifyAccntMsgLabel(ExpectedLable);
                Tools.VerifyAccountsTableHeaders("AcctNumberHeader");
                Tools.VerifyAccountsTableHeaders("FeatureHeader");
            }
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search Information By Brokers code/Brokers Name"), TestCategory("Regression")]
        public void TOOL_U6()
        {
            this.TESTREPORT.InitTestCase("TOOL_U6", "Search Information By Brokers code/Brokers Name");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            if (home.ClickTools())
            {
                home.VerifyPageTitle(ToolsPageTitle);
                Tools.VerifyAdministrationLabel();
                Tools.VerifyAndClickBrokersTab();
                Tools.SearchBrokerCode(BrokerCode);
                Tools.VerifyBrokerSearchResults();
            }
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }


    }
}