using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AUT.Selenium.ApplicationSpecific.PMA.Pages;
namespace AutomatedTest.FunctionalTests.PMA
{
    [TestClass]
    public class SmokeTest : TestBaseTemplate
    {
        #region Page Initialization
        HomePage homePage = new HomePage();
        #endregion


        [TestMethod]
        public void TestHM_1()
        {
            this.TESTREPORT.InitTestCase("HM_1", "Verify Drop down value");
            string strMyAccount = homePage.GetMyAccount();
            strMyAccount = null;
            if(!String.IsNullOrEmpty(strMyAccount))
            {
                this.TESTREPORT.LogSuccess("VALidate MY ACCount", "SUccessfully found MY ACCount");
            }
            else
            {
                this.TESTREPORT.LogFailure("VALidate MY ACCount", "SUccessfully NOT found MY ACCount", this.SCREENSHOTFILE);
            }
            this.TESTREPORT.UpdateTestCaseStatus();
        }
    }
}
