using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using Engine.Factories;
using Engine.Setup;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class LoginPage : AbstractTemplatePage
    {
        #region UI Objects

        #endregion

        public void OpenBrowser()
        {
            #region WebApplication - PMA_Cinch
            driver = WebDriverFactory.getWebDriver(EngineSetup.BROWSER);
            driver.Navigate().GoToUrl(EngineSetup.WEBURL);
            //EngineSetup.TestReport.LogSuccess(String.Format("Launch Application On Browser - {0}",EngineSetup.BROWSER), String.Format("Application - {0} Launch Successful", EngineSetup.WEBURL));
            // EngineSetup.TestReport.UpdateTestCaseStatus();

            #endregion



        }


    }
}