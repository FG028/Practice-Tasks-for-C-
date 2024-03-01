using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class Page
    {
        protected readonly IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsAt(string expectedTitle)
        {
            return _driver.Title.Contains(expectedTitle);
        }

        public void WaitForElementToBeVisible(By locator, int timeout = 10)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement FindElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public IList<IWebElement> FindElements(By locator)
        {
            return _driver.FindElements(locator);
        }
    }
}
