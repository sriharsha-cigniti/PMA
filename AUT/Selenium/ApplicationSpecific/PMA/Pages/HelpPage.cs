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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace AUT.Selenium.ApplicationSpecific.PMA.Pages
{
    public class HelpPage : AbstractTemplatePage
    {
        #region UI Objects
        private By byHelpTab = By.XPath("//a//span[contains(text(),'Help')]");
        private By byPMACinchSupport = By.XPath("//span[contains(text(),'PMA Cinch® Support')]");
        private By byHelpLink = By.XPath("//span[contains(text(),'Help')]/../../../..//a[contains(@id,'CinchMenu_DXI')]");

        #endregion

        #region variables
        string PdfURL = string.Empty;
        #endregion

        #region Public Methods

        public void ClickOnHelpTab()
        {
            this.TESTREPORT.LogInfo("Click on Help Tab");
            this.driver.ClickElement(byHelpTab, "Help Tab");
        }

        public void VerifyPMACinchText()
        {
            this.TESTREPORT.LogInfo("Verify PMA Cinch Support text ");
            this.driver.WaitElementPresent(byPMACinchSupport);
            if (this.driver.IsElementPresent(byPMACinchSupport))
                this.TESTREPORT.LogSuccess("Verify text on page", String.Format("text - <mark>{0}</mark> appeared", this.driver.GetElementText(byPMACinchSupport)));
            else
                this.TESTREPORT.LogFailure("Verify text on page", String.Format("text - <mark>{0}</mark> doesn't appeared", this.driver.GetElementText(byPMACinchSupport)), this.SCREENSHOTFILE);
        }

        public void ClickOnLink(string linkText)
        {
            By byLink = By.XPath(string.Format("//a[@title='{0}']", linkText));
            this.TESTREPORT.LogInfo(string.Format("Click on Link : {0}", linkText));
            this.driver.ClickElement(byLink, "Link Text");
        }

        public void VerifyPdfFile(string pdfText)
        {
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            PdfURL = driver.Url;
            if (PdfURL.Trim().ToLower().Contains(pdfText.Replace(" ", string.Empty).ToLower()))
                this.TESTREPORT.LogSuccess("Verify PDF text on page", String.Format("text -actual <mark>{0}</mark> : expected <mark>{1}</mark> :  appeared", PdfURL, pdfText));
            else
                this.TESTREPORT.LogFailure("Verify PDF text on page", String.Format("text -actual <mark>{0}</mark> : expected <mark>{1}</mark> : is not appeared", PdfURL, pdfText), this.SCREENSHOTFILE);
        }

        public void VerifyTextInPDFFile(int pageNumber, string textToVerify)
        {
            PdfReader reader = new PdfReader(PdfURL);
            string text = PdfTextExtractor.GetTextFromPage(reader, pageNumber);
            if (text.Replace("\n", "").Trim().ToLower().Contains(textToVerify.Trim().ToLower()))
                this.TESTREPORT.LogSuccess("Verify text on PDF", String.Format("text -actual <mark>{0}</mark> : expected <mark>{1}</mark> :  appeared", text, textToVerify));
            else
                this.TESTREPORT.LogFailure("Verify text on PDF", String.Format("text -actual <mark>{0}</mark> : expected <mark>{1}</mark> : is not appeared", text, textToVerify), this.SCREENSHOTFILE);
        }

        public void VerifyPdfClose()
        {
            IReadOnlyList<string> windows = driver.WindowHandles;
            if (windows.Count == 1)
                this.TESTREPORT.LogSuccess("Verify number of windows after pdf is closed", String.Format(" <mark>{0}</mark>  appeared", windows.Count));
            else
                this.TESTREPORT.LogFailure("Verify number of windows after pdf is closed", String.Format(" <mark>{0}</mark> appeared", windows.Count), this.SCREENSHOTFILE);

        }

        public void VerifyTabIsFocus(string HighlightColor, string TabName)
        {
            string actualHighlightcolor = string.Empty;
            IReadOnlyList <IWebElement> tabs = this.driver.FindElements(byHelpLink);
            foreach (IWebElement tab in tabs)
            {
                if (tab.Text.ToLower().Contains(TabName.ToLower()))
                {
                    actualHighlightcolor = tab.GetAttribute("style");
                    break;
                }
            }

            if (actualHighlightcolor.Contains(HighlightColor))
                this.TESTREPORT.LogSuccess("Verify Help tab is highlighted", string.Format("Help highlighted color is:<Mark>{0}</Mark>", actualHighlightcolor));
            else
                this.TESTREPORT.LogFailure("Verify Help tab is highlighted", string.Format("Help highlighted color is:<Mark>{0}</Mark>", actualHighlightcolor), this.SCREENSHOTFILE);
        }
        #endregion

    }
}
