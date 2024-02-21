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

        [Given(@"I am on the DemoQA page ""https://demoqa.com/buttons""")]
        public void NavigateToDemoQA()
        {
            string url = "https://demoqa.com/buttons";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I navigate to the ""Elements"" category and ""Buttons"" section")]
        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/div/ul/li[5]")).Click();
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
