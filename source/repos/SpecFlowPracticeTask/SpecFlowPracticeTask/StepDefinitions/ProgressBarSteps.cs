using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTask.Hooks;
using SpecFlowPracticeTask.POM;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ProgressBarSteps
    {
        private readonly ProgressBarPage progressBarPage;
        WebDriver driver = WebDriverManager.GetDriver();

        public ProgressBarSteps(WebDriver _driver)
        {
            driver = _driver;
            progressBarPage = new ProgressBarPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/progress-bar""")]
        public void NavigateToDemoQA()
        {
            progressBarPage.NavigateToDemoQA();
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
