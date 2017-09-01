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
            string strAccount = homePage.MyAccountHeader();

            if (strMyAccount.Equals(strAccount, StringComparison.OrdinalIgnoreCase))
            {
                this.TESTREPORT.LogSuccess("Validate My default Account", "Successfully found My Account on the page header");
            }
            else
            {
                this.TESTREPORT.LogFailure("Validate My default Account", "NOT found My Account on the page header", this.SCREENSHOTFILE);
            }
            this.TESTREPORT.UpdateTestCaseStatus();




            /*if (!String.IsNullOrEmpty(strMyAccount))
            {
                this.TESTREPORT.LogSuccess("VALidate MY ACCount", "Successfully found MY ACCount");
            }
            else
            {
                this.TESTREPORT.LogFailure("VALidate MY ACCount", "Successfully NOT found MY ACCount", this.SCREENSHOTFILE);
            }
            this.TESTREPORT.UpdateTestCaseStatus();*/
        }
    }
}
