using OpenQA.Selenium;


namespace SpecFlowProjectPractice.PageObjects
{
    public class BrowserWindowPage
    {
        private readonly IWebDriver _driver;

        public BrowserWindowPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SwitchToNewWindow()
        {
            var originalWindow = _driver.CurrentWindowHandle;

            foreach (var handle in _driver.WindowHandles.Except(new[] { originalWindow }))
            {
                _driver.SwitchTo().Window(handle);
                break;
            }
        }
    }
}
