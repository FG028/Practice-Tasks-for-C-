using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.Helper
{
    public class PopUpHandler
    {
        WebDriverManager webDriverManager;

        public PopUpHandler(WebDriverManager _webDriverManager)
        {
            this.webDriverManager = _webDriverManager;
        }

        public bool TryHandlePopup()
        {
            try
            {
                var popup = webDriverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
                popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}