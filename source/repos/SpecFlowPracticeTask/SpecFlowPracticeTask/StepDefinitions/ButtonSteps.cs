using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class ButtonSteps
    {
        private readonly WebDriver driver;

        public ButtonSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I navigate to the ""Elements"" category and ""Buttons")]
        public void NavigateToButtonsSections()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        [When(@"I interact with the ""(.*)"" button")]
        public void InteractWithButton(string buttonName)
        {
            var button = driver.FindElement(By.XPath($"//button[text()='{buttonName}']"));
            button.Click();
        }

        private void InteractWithButton(WebElement button)
        {
            var buttonText = button.Text.ToLower();

            switch (buttonText)
            {
                case "double click":
                    Actions actions = new Actions(driver);
                    actions.DoubleClick(button).Perform();
                    break;
                case "right click ":
                    new Actions(driver).ContextClick(button).Perform();
                    break;
                default:
                    button.Click();
                    break;
            }
        }

        [Then(@"I should see the text ""(.*)""")]
        public void VerifyButtonText(string expectedMessage)
        {
            var resultText = driver.FindElement(By.Id("result")).Text;
            Assert.That(resultText, Is.EqualTo(expectedMessage));
        }
    }
}
