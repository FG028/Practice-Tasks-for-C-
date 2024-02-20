using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class AutoCompleteSteps
    {
        private readonly WebDriver driver;

        public AutoCompleteSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the DemoQA page ""(.*)""")]
        [Given(@"I navigate to the ""Forms"" category and "" Auto Complete"" section")]
        public void NavigateToAutoCompleteSection(string url)
        {
            driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");
        }

        [When(@"I enter the letter ""(.*)"" in the ""Type multiple color names"" field")]
        public void EnterTextInInput(string text)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            input.SendKeys(text);
        }

        [Then(@"I should see (.*) unique color suggestions containing the letter ""(.*)""")]
        public void VerifyUniqueSuggestions(int expectedCount, string expectedLetter)
        {
            var suggestions = driver.FindElements(By.CssSelector(".ui-menu-item"));
            
            var uniqueColors = suggestions.Select(s => s.Text.ToLower()).Distinct().ToList();

            Assert.That(suggestions.Count, Is.EqualTo(expectedCount));
            foreach(var color in uniqueColors)
            {
                Assert.That(color.Contains(expectedLetter), Is.True);
            }
        }

        [Then(@"I add colors from the autoComplete suggestions:")]
        public void AddColorsFromSuggestions(Table table)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));

            var colors = table.CreateSet<string>().Where(s => !string.IsNullOrEmpty(s)).ToList();

            foreach (var color in colors)
            {
                input.SendKeys(color + ", ");
                WaitForAndSelectSuggestion(color);
            }
        }

        private void WaitForAndSelectSuggestion(string expectedColor)
        {
            var expectedSelector = $".ui-menu-item:contains('{expectedColor}')";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(expectedSelector))); // implement method
            var suggestion = driver.FindElement(By.CssSelector(expectedSelector));
            suggestion.Click();
        }

        [Then(@"I should see no duplicate colors in the field")]
        public void VerifyNoDuplicates()
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            var words = input.Text.Split(',').Select(s => s.Trim().ToLower()).ToList();

            Assert.That(words.Distinct().Count(), Is.EqualTo(words.Count));
        }

        [Then(@"I type ""(.*)"" followed by down arrow and enter")]
        public void AddColorManually(string text)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            input.SendKeys(text);
            input.SendKeys(Keys.ArrowDown);
            input.SendKeys(Keys.Enter);
        }

        [Then(@"I should see only (.*) colors in the field")]
        public void VerifyColorCount(int expectedCount)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            var words = input.Text.Split(',').Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Trim()).ToList();

            Assert.That(words.Count, Is.EqualTo(expectedCount));
        }

        [Then(@"I should see ""(.*)"" in the field")]
        public void VerifyFieldValue(string expectedText)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            Assert.That(input.Text.Contains(expectedText), Is.True);
        }

        [Then(@"I delete ""(.*)"" and ""(.*)""")]
        public void DeleteSpecificColors(string color1, string color2)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));

            for (int i = 0; i < color1.Length + 1; i++)
            {
                input.SendKeys(Keys.Backspace);
            }
            for (int i = 0; i < color2.Length + 1; i++)
            {
                input.SendKeys(Keys.Backspace);
            }
        }

        [Then(@"I should see only ""(.*)"", ""(.*)"", and ""(.*)"" in the field")]
        public void VerifySpecificColorsRemaining(string color1, string color2, string color3)
        {
            var input = driver.FindElement(By.Id("autoCompleteMultipleInput"));
            var expectedColors = new List<string> { color1, color2, color3 };

            var actualColors = input.Text.Split(',').Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Trim()).ToList();

            Assert.That(actualColors, Is.EquivalentTo(expectedColors));
        }
    }
}
