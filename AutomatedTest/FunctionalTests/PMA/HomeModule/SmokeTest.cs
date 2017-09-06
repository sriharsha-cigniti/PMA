//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using AUT.Selenium.ApplicationSpecific.PMA.Pages;
//using AutomatedTest.FunctionalTests.PMA;

//namespace AutomatedTest.FunctionalTests.HomeModule
//{
//    [TestClass]
//    public class SmokeTest : TestBaseTemplate
//    {
//        #region Page Initialization
//        HomePage homePage = new HomePage();
//        #endregion


//        [TestMethod]
//        public void TestHM_1()
//        {
//            this.TESTREPORT.InitTestCase("HM_1", "Verify Drop down value");
//            string strMyAccount = homePage.GetMyAccount();
//            //string strAccount = homePage.MyAccountHeader();



//            /* Default account verification*/
//            if (strMyAccount.Length > 0)
//            {
//                this.TESTREPORT.LogSuccess("Validate an Account is selected by default", String.Format("Account - {0} selected by default", strMyAccount));
//            }
//            else
//            {
//                this.TESTREPORT.LogFailure("Validate an Account is selected by default", "No Account was selected by default", this.SCREENSHOTFILE);
//            }


//            /* Account header verification*/
//            if (strAccount.Length > 0)
//            {
//                this.TESTREPORT.LogSuccess("Validate Default Account is displayed on header", String.Format("Account - {0} is displayed as header", strAccount));
//            }
//            else
//            {
//                this.TESTREPORT.LogFailure("Validate Default Account is displayed on header", "No Account was displayed by default", this.SCREENSHOTFILE);
//            }

//            /*Account text comparison */
//            if (strMyAccount.Equals(strAccount, StringComparison.OrdinalIgnoreCase))
//            {
//                this.TESTREPORT.LogSuccess("Account selected by default should reflect on Page header", String.Format("Default selected Account - <Mark>{0}</Mark> is displayed on Page Header", strMyAccount));
//            }
//            else
//            {
//                this.TESTREPORT.LogFailure("Account selected by default should reflect on Page header", "No Account was selected by default", this.SCREENSHOTFILE);
//            }
//            this.TESTREPORT.LogSuccess("Exit Application", "Logout succesfully from the application");
//            this.TESTREPORT.UpdateTestCaseStatus();
//        }

//        //[TestMethod]
//        //public void TestHM_2()
//        //{
//        //    this.TESTREPORT.InitTestCase("HM_2", "Verify My Diary and Quick claim search sections");
//        // homePage.VerifyLoggedUser("ESKODS");
//        //    //string strUserCredntial = homePage.UserName();
//        //    //string strDate = homePage.Date();
//        //    string strMydiary = homePage.MyDiary();
//        //    string strQuickClaimSearch = homePage.QuickClaimSearch();
//        //    if (homePage.contains)
//        //    {
//        //        this.TESTREPORT.LogSuccess("Verify My Diary on the home page", string.Format("My Diary text is present on the home page "));
//        //    }
//        //    else
//        //    {
//        //        this.TESTREPORT.LogFailure("Verify My Diary on the home page", string.Format("My Diary text is not present on the home page "));
//        //    }

//        //    //if (homePage..contains(strUserCredntial))
//        //    //{

//        //    //    this.TESTREPORT.LogSuccess("UserName with date should be displayed", String.Format("UserName with date is displayed on Page Header"));
//        //    //}
//        //    //else
//        //    //{
//        //    //    this.TESTREPORT.LogFailure("UserName with date should be displayed", String.Format("UserName with date is displayed on Page Header"),this.SCREENSHOTFILEs);
//        //    //}
//        //}
        
        


//    }
//}
