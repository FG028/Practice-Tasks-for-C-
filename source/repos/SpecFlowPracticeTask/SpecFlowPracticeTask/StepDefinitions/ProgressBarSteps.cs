using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTask.POM;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ProgressBarSteps
    {
        private readonly WebDriver driver;
        private readonly ProgressBarPage progressBarPage;

        public ProgressBarSteps(WebDriver driver)
        {
            this.driver = driver;
            progressBarPage = new ProgressBarPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/progress-bar""")]
        public void NavigateToDemoQA()
        {
            progressBarPage.NavigateToDemoQA();
        }

        [Given(@"I navigate to the ""Widgets"" category and ""Progress Bar"" section")]
        public void NavigateToAutoCompleteSection()
        {
            progressBarPage.NavigateToAutoCompleteSection();
        }

        [Then(@"I click the ""(.*)"" button")]
        public void ClickButton(String buttonText)
        {
            progressBarPage.ClickStartButton();
        }


        [Then(@"I wait until the progress bar reaches (.*)%")]
        public void WaitUntilProgressBarCompletes(int expectedValue)
        {
            progressBarPage.WaitForProgressBar(expectedValue);
        }

        [Then(@"I verify that the button text becomes ""(.*)""")]
        public void VerifyButtonText(string expectedText)
        {
            Assert.That(progressBarPage.GetButtonText(), Is.EqualTo(expectedText));
        }

        [Then(@"I verify that the progress bar value is ""(.*)""%")]
        public void VerifyProgressBarValue(int expectedValue)
        {
            Assert.That(progressBarPage.GetProgressBarValue(), Is.EqualTo(expectedValue));
        }
    }
}
