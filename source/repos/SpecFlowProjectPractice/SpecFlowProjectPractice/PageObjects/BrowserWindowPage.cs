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