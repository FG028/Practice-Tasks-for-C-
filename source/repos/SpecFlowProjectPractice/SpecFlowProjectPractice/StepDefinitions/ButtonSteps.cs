using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class ButtonsSteps
    {
        private readonly IWebDriver _driver;
        private readonly ButtonsPage _buttonsPage;

        public ButtonsSteps(IWebDriver driver)
        {
            _driver = driver;
            _buttonsPage = new ButtonsPage(_driver);
        }
        
        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string buttonLabel)
        {
            _buttonsPage.ClickButton(buttonLabel);
        }

        [Then(@"I verify the text is ""(.*)""")]
        public void ThenIVerifyTheFollowingTextIsDisplayed(string expectedText)
        {
            var actualText = _driver.FindElement(By.XPath("//h1")).Text;

            Assert.AreEqual(expectedText, actualText, $"Displayed text does not match expected text: '{expectedText}'");
        }
       
    }
}
