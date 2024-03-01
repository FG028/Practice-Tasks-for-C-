using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class Page
    {
        protected readonly WebDriverManager driverManager;

        public Page(WebDriverManager _driverManager)
        {
            driverManager = _driverManager;
        }

        public bool IsAt(string expectedTitle)
        {
            return driverManager.Driver().Title.Contains(expectedTitle);
        }

        public void WaitForElementToBeVisible(By locator, int timeout = 10)
        {
            new WebDriverWait(driverManager.Driver(), TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement FindElement(By locator)
        {
            return driverManager.Driver().FindElement(locator);
        }

        public IList<IWebElement> FindElements(By locator)
        {
            return driverManager.Driver().FindElements(locator);
        }
    }
}
