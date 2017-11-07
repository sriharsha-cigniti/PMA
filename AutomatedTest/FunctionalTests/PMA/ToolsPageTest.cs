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

            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            home.ClickTools();
            //Verify Tools page Title
            home.VerifyPageTitle(ToolsPageTitle);
            //Verify Label
            Tools.VerifyAdministrationLabel();
            //Verify Users Tab
            Tools.VerifyUserTab();
            //Enter Login Id
            Tools.EnterLoginID(Environment.UserName);
            //Click on Search
            Tools.ClickSearch();
            //Assigned Accounts count
            int BeforeCount = Tools.ToolsResultsCount();
            //Add new account
            Tools.AddAccount(AccountNumber);
            //Verify the Confirmation message
            string AccountExistsMsg = "Account " + AccountNumber + " already exixts for the user.";
            Tools.ConfirmationMsg(BeforeCount, ConfirmationMsg, AccountExistsMsg);
            //Re-login to the browser
            this.TESTREPORT.LogInfo("Re-Login into application");
            login.OpenBrowser();
            //Click on Home 
            diaryNotes.ClickHome();
            //Click on my account
            home.ClickMyAccount();
            //Search for the newly added account
            home.SearchMyAccout(AccountNumber, "Number");
            string myAccountName = home.GetMyAccount();
            //Verify Header
            home.VerifyAccountHeader(myAccountName);
            //Click on Exit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();
        }

        [TestMethod, Description("Tools - Modify the user permissions to an account"), TestCategory("Regression")]
        public void TOOL_U2()
        {
            this.TESTREPORT.InitTestCase("TOOL_U2", "Modify the user permissions to an account");
            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            home.ClickTools();
            //Verify Tools page Title
            home.VerifyPageTitle(ToolsPageTitle);
            //Verify Label
            Tools.VerifyAdministrationLabel();
            //Verify Users Tab
            Tools.VerifyUserTab();
            //Enter Login Id
            Tools.EnterLoginID(Environment.UserName);
            //Click on Search
            Tools.ClickSearch();
            //Verify Header Label
            Tools.VerifyHeaderLabel();
            //Verify Label
            Tools.VerifyFunctionalPermssionLabel();
            //Verify Label
            Tools.VerifyDataPermssionLabel();
            //Click on Check All button
            Tools.ClickFunctionCheckAll();
            Tools.ClickDataCheckAll();
            //Click on Submit
            Tools.ClickSubmit();
            //Verify Label
            Tools.VerifyLabel();
            //Click on Exit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search by user name and add account to the user profile"), TestCategory("Regression")]
        public void TOOL_U3()
        {
            this.TESTREPORT.InitTestCase("TOOL_U3", "Search by user name and add account to the user profile");

            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            home.ClickTools();
            //Verify Tools page Title
            home.VerifyPageTitle(ToolsPageTitle);
            //Verify Label
            Tools.VerifyAdministrationLabel();
            //Verify Users Tab
            Tools.VerifyUserTab();
            //Enter Login Id
            Tools.EnterLoginID(Environment.UserName);
            //Click on Search
            Tools.ClickSearch();
            //Click on Delete
            Tools.ClickDelete();
            //Click on Exit 
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();


        }

        [TestMethod, Description("Tools - Verify available Tab present in Tools"), TestCategory("Regression")]
        public void TOOL_U4()
        {
            this.TESTREPORT.InitTestCase("TOOL_U4", "Verify available Tab present in Tools");

            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            home.ClickTools();
            //Verify Tools page Title
            home.VerifyPageTitle(ToolsPageTitle);
            //Verify Label
            Tools.VerifyAdministrationLabel();
            //Verify brokers Tab
            Tools.VerifyAndClickBrokersTab();
            //Verify Label
            Tools.VerifySearchByLabel();
            //Verify and Click on Reports Tab
            Tools.VerifyAndClickReportsTab();
            //Verify Label
            Tools.VerifyAccountLevelAndNameLabel();
            //Click on EXit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search by Features/Report Attachment by Account Number"), TestCategory("Regression")]
        public void TOOL_U5()
        {
            this.TESTREPORT.InitTestCase("TOOL_U5", "Search by Features/Report Attachment by Account Number");

            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            if (home.ClickTools())
            {
                //Verify Tools page Title
                home.VerifyPageTitle(ToolsPageTitle);
                //Verify Page Title
                Tools.VerifyAdministrationLabel();
                //Verify and Click on Reports Tab
                Tools.VerifyAndClickReportsTab();
                //Verify Labels 
                Tools.VerifyAccountLevelAndNameLabel();
                //Search account number
                Tools.SearchAccount(AccountNumber);
                //Verify account message label
                string ExpectedLable = "Account Level Opt Out Rule(s) For " + AccountNumber + "";
                Tools.VerifyAccntMsgLabel(ExpectedLable);
                //Verify Tabel header values
                Tools.VerifyAccountsTableHeaders("AcctNumberHeader");
                Tools.VerifyAccountsTableHeaders("FeatureHeader");
            }
            //Click on Exit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }

        [TestMethod, Description("Tools - Search Information By Brokers code/Brokers Name"), TestCategory("Regression")]
        public void TOOL_U6()
        {
            this.TESTREPORT.InitTestCase("TOOL_U6", "Search Information By Brokers code/Brokers Name");
            //Verify Home page Title
            home.VerifyPageTitle(HomePageTitle);
            //Verify Cinch Welcome text
            home.VerifyCinchWelome();
            //Click on Tools
            if (home.ClickTools())
            {
                //Verify Page title
                home.VerifyPageTitle(ToolsPageTitle);
                //Verify Page title
                Tools.VerifyAdministrationLabel();
                //Verify and click on brokers tab
                Tools.VerifyAndClickBrokersTab();
                //Search brokers code
                Tools.SearchBrokerCode(BrokerCode);
                //Verify Search results
                Tools.VerifyBrokerSearchResults();
            }
            //Click on Exit
            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();

        }


    }
}