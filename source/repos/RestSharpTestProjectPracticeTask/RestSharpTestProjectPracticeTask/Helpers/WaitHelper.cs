using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace RestSharpTestProjectPracticeTask.Helpers
{
    public class WaitHelper
    {
        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
