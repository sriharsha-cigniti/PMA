﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReporter;
using System.IO;
using Engine.Factories;
namespace Engine.Setup
{
    /// <summary>
    /// @Author - Debasish Pradhan
    /// </summary>
    public class EngineSetup
    {
        private static string randomString = null;
        private const string FILETESTCONFIGURATION = "TestConfiguration.properties";
        private static string executablePath = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "executablePath");
        private static string reportType = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "reportType");
        private static string testReportFolder = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testReportFolder");
        private static string testReportFile = testReportFolder + "-"+DateTime.Now.ToString("ddmmssff") + StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "testReportFile");
        private static IReporter testReportInternal = null;
        private static string screenShotFolder = new FileInfo(testReportFile).Directory.FullName + Path.DirectorySeparatorChar + "ScreenShots";
        private static int lastScreenShotCount = 1;
        private static string browser = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "browser");
        private static int defaultTimeOutForSelenium = Int32.Parse(StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "seleniumDefaultTimeOut"));
        public const int TimeOutConstant = 60;
        private static string webUrl = StandardUtilities.FileUtilities.readPropertyFile(FILETESTCONFIGURATION, "webUrl");


        /// <summary>
        /// Initializes the <see cref="EngineSetup"/> class.
        /// </summary>
        static EngineSetup()
        {
            if (Directory.Exists(screenShotFolder))
            {
                Directory.Delete(screenShotFolder, true);
            }
        }
        /// <summary>
        /// Gets the random value.
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {
            if(EngineSetup.randomString == null)
            {
                EngineSetup.randomString = String.Format("{0}{1}", Environment.MachineName, DateTime.Now.ToString("ddmmssff"));
            }
            return EngineSetup.randomString;
        }

        /// <summary>
        /// Gets or sets the application path.
        /// </summary>
        /// <value>
        /// The application path.
        /// </value>
        public static string ApplicationPath
        {
            get { return new FileInfo(EngineSetup.executablePath).FullName; }
            set { EngineSetup.executablePath = value; }
           
        }
        /// <summary>
        /// Gets or sets the type of the test report.
        /// </summary>
        /// <value>
        /// The type of the test report.
        /// </value>
        public static string TestReportType
        {
            get { return EngineSetup.reportType; }
            set { EngineSetup.reportType = value; }
        }
        /// <summary>
        /// Gets or sets the name of the test report file.
        /// </summary>
        /// <value>
        /// The name of the test report file.
        /// </value>
        public static string TestReportFileName
        {
            get { return new FileInfo(EngineSetup.testReportFile).FullName; }
            set { EngineSetup.testReportFile = value; }
        }

        /// <summary>
        /// Gets or sets the test screen shot folder.
        /// </summary>
        /// <value>
        /// The test screen shot folder.
        /// </value>
        public static string TestScreenShotFolder
        {
            get { return EngineSetup.screenShotFolder; }
            set { EngineSetup.screenShotFolder = value; }
        }
        /// <summary>
        /// Gets the test report.
        /// </summary>
        /// <value>
        /// The test report.
        /// </value>
        public static IReporter TestReport
        {
            get
            {
                if(EngineSetup.testReportInternal == null)
                {

                    EngineSetup.testReportInternal = ReportFactory.GetReport(EngineSetup.TestReportType,true, true);
                }
                return EngineSetup.testReportInternal;
            }
        }

        /// <summary>
        /// Gets the screen shot path.
        /// </summary>
        /// <returns></returns>
        public static string GetScreenShotPath()
        {
            string fileName = String.Format("{0}{1}ScreenShot.jpeg", EngineSetup.TestScreenShotFolder, Path.DirectorySeparatorChar);
            try
            {
                //Verifying if the file already exists, if so append the numbers 1,2  so on to the fine name.			

                FileInfo myPngImage = new FileInfo(fileName);
                if(!myPngImage.Directory.Exists)
                {
                    myPngImage.Directory.Create();
                }
                
                while (myPngImage.Exists)
                {
                    try
                    {
                        string tempFileName = null;
                        if (fileName.Contains("_"))
                        {
                           tempFileName = fileName.Substring(0, fileName.IndexOf('_'));
                           
                        }
                        else
                        {
                            tempFileName = fileName.Substring(0, fileName.IndexOf(".jpeg"));
                        }
                        fileName = tempFileName;
                        fileName = String.Format("{0}_{1}.jpeg", fileName, EngineSetup.lastScreenShotCount++);
                        myPngImage = new FileInfo(fileName);
                    }
                    catch(Exception ex)
                    {
                        EngineSetup.TestReport.LogException(ex, EngineSetup.GetScreenShotPath());
                    }
                    
                   
                }
                return fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return fileName;
            }
        }

        /// <summary>
        /// Gets the default timeout for selenium.
        /// </summary>
        /// <value>
        /// The default timeout for selenium.
        /// </value>
        public static int DefaultTimeoutForSelenium
        {
            get
            {
                return EngineSetup.defaultTimeOutForSelenium;
            }
        }

        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public static string BROWSER
        {
            get
            {
               //environment variable will be read in case of Jenkins parameterized build execution
                return Environment.GetEnvironmentVariable("browser") !=null ? Environment.GetEnvironmentVariable("browser") : EngineSetup.browser;
            }
            set { EngineSetup.browser = value; }
        }

        /// <summary>
        /// Gets or sets the weburl.
        /// </summary>
        /// <value>
        /// The weburl.
        /// </value>
        public static string WEBURL
        {
            get { return EngineSetup.webUrl; }
            set { EngineSetup.webUrl = value;}
        }
    }
}
