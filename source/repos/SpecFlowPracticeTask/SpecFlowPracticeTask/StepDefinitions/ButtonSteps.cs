using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ButtonSteps
    {
        private readonly ButtonPage buttonPage;
        WebDriver driver = WebDriverManager.GetDriver();

        public ButtonSteps(WebDriver _driver)
        {
            driver = _driver;
            buttonPage = new ButtonPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/buttons""")]
        public void NavigateToDemoQA()
        {
            buttonPage.NavigateToPage();
        }

        [When(@"I interact with the ""(.*)"" button")]
        public void InteractWithButton(string buttonName)
        {
            var button = buttonPage.GetButtonByName(buttonName);
            buttonPage.PerformAction(button);
        }

        [Then(@"I should see the text ""(.*)""")]
        public void VerifyButtonText(string expectedMessage)
        {
            Assert.That(buttonPage.GetResultText(), Is.EqualTo(expectedMessage));
        }
    }
}
