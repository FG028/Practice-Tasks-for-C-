using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using SpecFlowProjectPractice.Helper;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class BrowserWindowsFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly BrowserWindowPage browserWindowPage;
        private PopUpHandler popUpHandler;

        public BrowserWindowsFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            popUpHandler = new PopUpHandler(driverManager);
            browserWindowPage = new BrowserWindowPage(_driverManager);
        }

        [When(@"I click the link ""(.*)"" button")]
        public void ClickButton(string buttonText)
        {
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