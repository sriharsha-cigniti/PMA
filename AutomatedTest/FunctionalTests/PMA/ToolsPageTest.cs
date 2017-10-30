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
        #endregion

        public ToolsPageTest()
        {
            // Read CSV values
            HomePageTitle = readCSV("HomePageTitle");
            ToolsPageTitle = readCSV("ToolsPageTitle");
            AccountNumber = readCSV("AccountNumber");
            ConfirmationMsg = readCSV("ConfirmationMsg");
        }

        [TestMethod, Description("NCEWorkersCompensation - Search by user name and add account to the user profile"), TestCategory("Regression")]
        public void TOOL_U1()
        {
            this.TESTREPORT.InitTestCase("TOOL_U1", "Search by user name and add account to the user profile");

            home.VerifyPageTitle(HomePageTitle);
            home.VerifyCinchWelome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();
            Tools.VerifyUserTab();
            string AccountExistsMsg = "Account " + AccountNumber + " already exixts for the user.";

            Tools.EnterLoginID(Environment.UserName);
            Tools.ClickSearch();            
            int BeforeCount= Tools.ToolsResultsCount();
            Tools.AddAccount(AccountNumber);           
            Tools.ConfirmationMsg(BeforeCount,ConfirmationMsg, AccountExistsMsg);
            diaryNotes.ClickHome();
            home.ClickTools();
            home.VerifyPageTitle(ToolsPageTitle);
            Tools.VerifyAdministrationLabel();





            home.ClickExit();
            this.TESTREPORT.UpdateTestCaseStatus();



        }

    }
}