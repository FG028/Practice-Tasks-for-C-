using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ButtonSteps
    {
        private readonly WebDriver driver;
        private readonly ButtonPage buttonPage;

        public ButtonSteps(WebDriver driver)
        {
            this.driver = driver;
            buttonPage = new ButtonPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/buttons""")]
        public void NavigateToDemoQA()
        {
            buttonPage.NavigateToPage();
        }

        [Given(@"I navigate to the ""Elements"" category and ""Buttons"" section")]
        public void NavigateToAutoCompleteSection()
        {
            buttonPage.NavigateToAutoCompleteSection();
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
