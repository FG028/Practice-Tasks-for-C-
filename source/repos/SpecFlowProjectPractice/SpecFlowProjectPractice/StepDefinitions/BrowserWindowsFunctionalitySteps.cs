using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class BrowserWindowsFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly BrowserWindowPage browserWindowPage;

        public BrowserWindowsFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            browserWindowPage = new BrowserWindowPage(_driverManager);
        }

        [When(@"I click the link ""(.*)"" button")]
        public void ClickButton(string buttonText)
        {
            browserWindowPage.PopUpButtonConfirmation();
            var button = _driverManager.Driver().FindElement(By.XPath($"//button[text()='{buttonText}']"));
            button.Click();
        }

        [Then(@"The new window contains the text ""(.*)""")]
        public void VerifyNewWindowText(string expectedText)
        {
            browserWindowPage.SwitchToNewWindow();
            string actualText = browserWindowPage.GetPageText();
            Assert.That(actualText.Contains(expectedText));
        }
    }
}
