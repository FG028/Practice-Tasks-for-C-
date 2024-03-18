using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class AutoCompleteSteps
    {
        private readonly AutoCompletePage autoCompletePage;
        WebDriver driver = WebDriverManager.GetDriver();

        public AutoCompleteSteps(WebDriver _driver)
        {
            driver = _driver;
            autoCompletePage = new AutoCompletePage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/auto-complete""")]
        public void NavigateToDemoQA()
        {
            autoCompletePage.NavigateToDemoQA();
        }

        [When(@"I enter the letter ""(.*)"" in the ""Type multiple color names"" field")]
        public void EnterTextInInput(string text)
        {
            autoCompletePage.EnterText(text);
        }

        [Then(@"I should see (.*) unique color suggestions containing the letter ""(.*)""")]
        public void VerifyUniqueSuggestions(int expectedCount, string expectedLetter)
        {
            Assert.That(autoCompletePage.GetNumberOfSuggestion(), Is.EqualTo(expectedCount));
            var suggestions = autoCompletePage.GetSuggestionText();
            Assert.That(suggestions.All(s => s.Contains(expectedLetter)));
        }

        [Then(@"I add colors from the autoComplete suggestions:")]
        public void AddColorsFromSuggestions(Table table)
        {
            var colorsToAdd = table.CreateSet<string>().Where(s => !string.IsNullOrEmpty(s)).ToList();

            foreach (var color in colorsToAdd)
            {
                autoCompletePage.AddColor(color);
            }
        }

        [Then(@"I should see no duplicate colors in the field")]
        public void VerifyNoDuplicates()
        {
            var selectedColors = autoCompletePage.GetSelectedColorText();
            Assert.That(selectedColors.Count, Is.EqualTo(selectedColors.Distinct().Count()));
        }

        [Then(@"I delete ""(.*)"" and ""(.*)""")]
        public void DeleteSpecificColors(string color1, string color2)
        {
            autoCompletePage.DeleteColor(color1);
            autoCompletePage.DeleteColor(color2);
        }

        [Then(@"I should see only ""(.*)"", ""(.*)"", and ""(.*)"" in the field")]
        public void VerifySpecificColorsRemaining(string color1, string color2, string color3)
        {
            var selectedColors = autoCompletePage.GetSelectedColorText();
            Assert.That(selectedColors, Is.EquivalentTo(new List<string> { color1, color2, color3 }));
        }
    }
}
