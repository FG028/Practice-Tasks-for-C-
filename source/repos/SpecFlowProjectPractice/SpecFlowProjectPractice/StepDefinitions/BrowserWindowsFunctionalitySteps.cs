using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class BrowserWindowsFunctionalitySteps
    {
        private readonly IWebDriver _driver;
        private readonly BrowserWindowPage browserWindowPage;

        public BrowserWindowsFunctionalitySteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [When(@"I click the link ""(.*)""")]
        public void WhenIClickTheLink(string linkText)
        {
            _driver.FindElement(By.LinkText(linkText)).Click();
        }

        [Then(@"I switch to the new window")]
        public void WhenISwitchToTheNewWindow()
        {
            browserWindowPage.SwitchToNewWindow();
        }

        [Then(@"I verify the page contains the text ""(.*)""")]
        public void ThenIVerifyTheFollowingTextIsDisplayed(string expectedText)
        {
            // Use a more specific selector than 'body' based on your page structure
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[text()='{expectedText}']")));

            // Assert that the element exists and its text matches
            Assert.AreEqual(expectedText, element.Text, $"Expected text '{expectedText}' not found on the page.");
        }
    }
}
