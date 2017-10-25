using AUT.Selenium.CommonReUsablePages;
using Engine.UIHandlers.Selenium;
using OpenQA.Selenium;
//using OpenQA.Selenium.Point;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using Engine.Factories;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class NewClaimEntryPage : AbstractTemplatePage
    {
        #region UI Objects
        private By byClaimNewInquirytab = By.XPath("//span[contains(text(),'New Claim Entry')]");
        private By bySavedDraft = By.XPath("//span[contains(text(),'Save Draft')]");
        private By byPageTableEntryItemcount = By.XPath("//div[@id='MainContent_griddata_DXPagerTop']//b[@class='dxp-lead dxp-summary']");
        private By bySavedDraftLable = By.XPath("//caption[contains(text(),'Saved Drafts')]");
        private By byClaiminquiryLink = By.Id("CinchMenu_DXI3_T");
        private By byLobtext = By.Id("MainContent_griddata_DXFREditorcol1_I");

        #endregion


        public void ClickSaveAsDraft()
        {
            this.TESTREPORT.LogInfo("Click Save as draft");
            this.driver.ClickElement(bySavedDraft, "Submit Button");
        }

        public void VerifyNewClaimEntryTabHighLightColor(string HighlightColor)
        {
            this.driver.WaitElementPresent(byClaiminquiryLink);
            this.driver.ClickElement(byClaiminquiryLink,"Claim Inquiry link");
           string actualHighlightcolor= this.driver.GetElementAttribute(byClaiminquiryLink, "style");
            string color=actualHighlightcolor.Split(':')[1];
            if (actualHighlightcolor.Equals(HighlightColor))
                this.TESTREPORT.LogSuccess("Verify New Claim Entry tab is highlighted",string.Format("New claim entry highlighted color is:<Mark>{0}</Mark>", color),this.SCREENSHOTFILE);
            else
                this.TESTREPORT.LogFailure("Verify New Claim Entry tab is highlighted", string.Format("New claim entry highlighted color is:<Mark>{0}</Mark>", color),this.SCREENSHOTFILE);

        }

        public void VerifyNewClaimantEntryTableHeaders(string value)
        {
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> list = this.driver.FindElements(By.XPath("//*[contains(@id,'MainContent_griddata_col')]"));
            bool headerfound = false;
            foreach (var item in list)
            {
                if (item.Text.ToLower().Contains(value.ToLower()))
                {
                    Thread.Sleep(2000);
                    this.TESTREPORT.LogSuccess("verify New Claimant Entry Table Headers", string.Format("Header contains:<mark>{0}</mark>", value));
                    headerfound = true;
                    break;
                }
            }
            if (!headerfound)
                this.TESTREPORT.LogFailure("verify New Claimant Entry Table Headers", string.Format("Header not contains:<mark>{0}</mark>", value));
        }

        public void ComparePageSizeItemCountWithClaimantEntryTableCount()
        {
            Thread.Sleep(2000);
            IReadOnlyList<IWebElement> Itemlist = this.driver.FindElements(By.XPath("//*[contains(@id, 'MainContent_griddata_DXDataRow')]"));
            this.driver.IsElementPresent(byPageTableEntryItemcount);
            IWebElement PageitemCountsize =this.driver.FindElement(byPageTableEntryItemcount);
            string Pageitemcount = PageitemCountsize.Text;
           
                if (Pageitemcount.Contains(Itemlist.Count.ToString()))
                {
                    this.TESTREPORT.LogSuccess("Compare pageSize item count with claimant entry table Count ", string.Format("Page Item count : <mark>{0}</mark> and Claim entry table count : <mark>{1}</mark>", Pageitemcount, Itemlist.Count.ToString()));
                }
                else
                this.TESTREPORT.LogFailure("Compare pageSize item count with claimant entry table Count", string.Format("Page Item count : <mark>{0}</mark> and Claim entry table count : <mark>{1}</mark>", Pageitemcount, Itemlist.Count.ToString()));
        }

            public void VerifySavedDraftsIsdisplayed()
        {
            Thread.Sleep(1000);
            //Switching to frame.......
            this.driver.SwitchTo().Frame("MainContent_ASPxSplitter1_0_CC");
            Thread.Sleep(1000);
            if (this.driver.IsElementPresent(bySavedDraftLable))
                this.TESTREPORT.LogSuccess("Verify Saved Drafts label",string.Format("Saved Drafts Label with Text :<Mark>{0} </Mark>", this.driver.GetElementAttribute(bySavedDraftLable,"text")));
            else
                this.TESTREPORT.LogFailure("Verify Saved Drafts label", string.Format("Saved Drafts Label with Text :<Mark> {0} </Mark>", this.driver.GetElementAttribute(bySavedDraftLable, "text")));

        }

        public void EnterLOB(string lob)
        {
            this.driver.SendKeysToElementClearFirst(byLobtext, lob, "lob filter textbox");
        }


    }
}
