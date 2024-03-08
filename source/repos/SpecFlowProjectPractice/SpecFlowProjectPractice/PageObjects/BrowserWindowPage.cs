using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;


namespace SpecFlowProjectPractice.PageObjects
{
    public class BrowserWindowPage
    {
        private readonly WebDriverManager _driverManager;

        public BrowserWindowPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }
        public void PopUpButtonConfirmation()
        {
            var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public string GetPageText()
        {
            return _driverManager.Driver().FindElement(By.TagName("body")).Text;
        }

        public void SwitchToNewWindow()
        {
            string currentWindow = _driverManager.Driver().CurrentWindowHandle;
            foreach (string windowHandle in _driverManager.Driver().WindowHandles.Where(w => w != currentWindow))
            {
                _driverManager.Driver().SwitchTo().Window(windowHandle);
                break;
            }
        }
    }
}