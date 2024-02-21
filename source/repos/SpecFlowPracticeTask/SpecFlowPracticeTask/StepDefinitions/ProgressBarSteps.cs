using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ProgressBarSteps
    {
        private readonly WebDriver driver;

        public ProgressBarSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/progress-bar""")]
        public void NavigateToDemoQA()
        {
            string url = "https://demoqa.com/progress-bar";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I navigate to the ""Widgets"" category and ""Progress Bar"" section")]
        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[4]/div/ul/li[5]")).Click();
        }

        [Then(@"I click the ""(.*)"" button")]
        public void ClickButton(string buttonText)
        {
            var button = driver.FindElement(By.Id("startStopButton"));
            button.Click();
        }


        [Then(@"I wait until the progress bar reaches (.*)%")]
        public void WaitUntilProgressBarCompletes(int expectedValue)
        {
            var progressBarText = driver.FindElement(By.Id("progressBarText"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => int.Parse(progressBarText.Text.Split('%')[0]) >= expectedValue);
        }

        [Then(@"I verify that the button text becomes ""(.*)""")]
        public void VerifyButtonText(string expectedText)
        {
            var button = driver.FindElement(By.Id("startStopButton"));
            Assert.That(button.Text, Is.EqualTo(expectedText));
        }

        [Then(@"I verify that the progress bar value is ""(.*)""%")]
        public void VerifyProgressBarValue(int expectedValue)
        {
            var progressBar = driver.FindElement(By.Id("progressBar"));
            Assert.That(progressBar.Text, Is.EqualTo(expectedValue + "%"));
        }
    }
}
