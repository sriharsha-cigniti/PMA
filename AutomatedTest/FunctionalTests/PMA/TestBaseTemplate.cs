﻿
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
//using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Microsoft.VisualStudio.TestTools.UITest.Extension;
//using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using TestReporter;
using Engine.Setup;
using OpenQA.Selenium;
using StandardUtilities;
using Engine.Factories;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;

namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class TestBaseTemplate
    {
        private string dataFileName = null;
        private int currentFileRowPointer = 1;
        private TestContext testContextInstance;
        public static IWebDriver driver = null;
        public HomePage home = null;
        public ClaimInquiry cInquiry = null;
        public DiaryNotesPage diaryNotes = null;
        public NCEAutoPage nceAuto = null;
        public NCEGeneralLiability nceGE = null;
        public NCEPropertyPage nceProperty = null;
        public NCEWorkersCompensationPage nceWC = null;
        public OshaPage osha = null;
        public NewClaimEntryPage nce = null;
        public ToolsPage Tools = null;

        public TestBaseTemplate()
        {
            driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
            home = new HomePage();
            cInquiry = new ClaimInquiry();
            diaryNotes = new DiaryNotesPage();
            nceAuto = new NCEAutoPage();
            nceGE = new NCEGeneralLiability();
            nceProperty = new NCEPropertyPage();
            nceWC = new NCEWorkersCompensationPage();
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [AssemblyInitialize]
        public static void BeforeAllTestsExecution(TestContext testContext)
        {

            /*  #region WebApplication - PMA_Cinch
              //EngineSetup.TestReport.InitTestCase("Launch Application", "Verify Application Is Launched Successfully");
              driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
              driver.Navigate().GoToUrl(EngineSetup.WEBURL);
              //EngineSetup.TestReport.LogSuccess(String.Format("Launch Application On Browser - {0}",EngineSetup.BROWSER), String.Format("Application - {0} Launch Successful", EngineSetup.WEBURL));
              //EngineSetup.TestReport.UpdateTestCaseStatus();

              #endregion*/
        }
        [AssemblyCleanup]
        public static void AfterAllTestsExecution()
        {

            //after execution, update extent report with gallop logo 
            /*driver can not be initialized in static method as driver is instance variable*/
            //driver.Close();
            driver.Quit();
            WebDriverFactory.Free();
            EngineSetup.TestReport.Close();
            TestBaseTemplate.UpdateTestReport();
        }
        [ClassInitialize]
        public static void BeforeAllTestsInATestClassExecution(TestContext testContext)
        {

        }
        [ClassCleanup]
        public static void AfterAllTestsInATestClassExecution()
        {

        }

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void BeforeEachTestCaseExecution()
        {
            #region WebApplication - PMA_Cinch
            //EngineSetup.TestReport.InitTestCase("Launch Application", "Verify Application Is Launched Successfully");

            driver.Navigate().GoToUrl(EngineSetup.WEBURL);
            //EngineSetup.TestReport.LogSuccess(String.Format("Launch Application On Browser - {0}",EngineSetup.BROWSER), String.Format("Application - {0} Launch Successful", EngineSetup.WEBURL));
            // EngineSetup.TestReport.UpdateTestCaseStatus();

            #endregion
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void AfterEachTestCaseExecution()
        {
            //driver.Close();
            if (driver != null)
                driver.Quit();
            WebDriverFactory.Free();
            // EngineSetup.TestReport.Close();
            TestBaseTemplate.UpdateTestReport();
        }


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>




        protected string RANDVALUE
        {
            get { return EngineSetup.GetRandomValue(); }

        }

        protected string DATAFILENAME
        {

            get
            {
                String modulename = this.GetType().Namespace.Substring(this.GetType().Namespace.LastIndexOf('.') + 1);
                this.dataFileName = modulename + "\\" + this.GetType().Name + ".csv";
                Console.WriteLine("dataFileName " + dataFileName);
                return this.dataFileName;

            }

        }

        protected int DATAFILEROWPOINTER
        {
            get { return this.currentFileRowPointer; }
            set { this.currentFileRowPointer = value; }
        }

        protected IReporter TESTREPORT
        {
            get { return EngineSetup.TestReport; }
        }

        protected string SCREENSHOTFILE
        {
            get { return EngineSetup.GetScreenShotPath(); }
        }
        /*To update extentReport to have Gallop Logo*/
        protected static void UpdateTestReport()
        {
            /*Dictionary should contain
            * SourceFile
            * Text1ToBeReplaced
            * Text1ToReplace
            * Text2ToBeReplaced
            * Text2ToReplace 
            * Text3ToBeReplaced
            * Text3ToReplace 
         
            */
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>();
            if (EngineSetup.TestReport is ExtentReporter)
            {

                keyValuePair["SourceFile"] = EngineSetup.TestReportFileName;

                //Text1ToBeReplaced
                string str = "<div class='logo-container'>\r\n                                    <a class='logo-content' href='http://extentreports.relevantcodes.com'>\r\n                                        <span>ExtentReports</span>\r\n                                    </a>\r\n                                    <a href='#' data-activates='slide-out' class='button-collapse hide-on-large-only'><i class='mdi-navigation-apps'></i></a>\r\n                                </div>";


                keyValuePair["Text1ToBeReplaced"] = str;


                //Text1ToReplace
                str = "<div class='logo-container' style='height:50px;width:200px;'>\r\n                                    <a href='http://www.gallop.net/'>\r\n                                        <img border='0' alt='Gallop' src='gallop_logo.png' width='200' height='35'>\r\n                                    </a>\r\n                                    <a href='#' data-activates='slide-out' class='button-collapse hide-on-large-only'><i class='mdi-navigation-apps'></i></a>\r\n                                </div>";

                keyValuePair["Text1ToReplace"] = str;


                //Text2ToBeReplaced
                str = "<span class='report-name'>";
                keyValuePair["Text2ToBeReplaced"] = str;

                //Text2ToReplace
                str = "<span class='report-name'><div style='width:220px;' align='right'>";
                keyValuePair["Text2ToReplace"] = str;

                //Text3ToBeReplaced
                str = "</span> <span class='report-headline'>";
                keyValuePair["Text3ToBeReplaced"] = str;

                //Text3ToReplace
                str = "</div></span> <span class='report-headline'>";
                keyValuePair["Text3ToReplace"] = str;
            }
            ITestReportManipulator updateExtentReport = new ExtentReportManipulator(keyValuePair);
            EngineSetup.TestReport.ManipulateTestReport(updateExtentReport);

        }

        public string readCSV(string columnName)
        {
            string data = "";
            try
            {
                data = FileUtilities.GetCSVData(this.DATAFILENAME,
                                         columnName.Trim(), this.DATAFILEROWPOINTER);
                data = data.Replace("{random}", this.RANDVALUE);
            }
            catch (Exception ex)
            {
                this.TESTREPORT.LogFailure("readCSV", ex.Message);
            }
            return data;
        }

    }
}
