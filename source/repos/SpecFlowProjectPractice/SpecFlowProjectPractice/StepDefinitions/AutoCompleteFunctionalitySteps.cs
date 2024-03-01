using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;


namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class AutoCompleteFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly AutoCompletePage _autoCompletePage;

        public AutoCompleteFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _autoCompletePage = new AutoCompletePage(_driverManager);
        }

        [When(@"I enter the letter ""(.*)"" in the ""(.*)"" field")]
        public void WhenIEnterTheLetterInTheField(string text, string fieldName)
        {
            _autoCompletePage.EnterText(fieldName, text);
        }

        [Then(@"I verify the AutoComplete offers three variants, all containing ""(.*)""")]
        public void ThenIVerifyTheFollowingSuggestionsAreDisplayed(Table table)
        {
            List<string> expectedSuggestions = table.Rows.Select(row => row["Item"].ToString()).ToList();
            List<string> actualSuggestions = _autoCompletePage.GetSuggestions();

            CollectionAssert.AreEquivalent(expectedSuggestions, actualSuggestions);
        }

        [Then(@"I enter ""(.*)"" in the ""(.*)"" field")]
        public void WhenIEnterInTheField(string text, string fieldName)
        {
            _autoCompletePage.EnterText(text, fieldName);
        }

        [Then(@"I delete ""(.*)"" and ""(.*)""")]
        public void DeleteSpecificColors(string color1, string color2)
        {
            _autoCompletePage.DeleteColor(color1);
            _autoCompletePage.DeleteColor(color2);
        }

        [Then(@"I should see only ""(.*)"", ""(.*)"", and ""(.*)"" in the field")]
        public void ThenIVerifyTheSelectedValueInTheFieldIs(string color1, string color2, string color3)
        {
            string actualValue = _autoCompletePage.GetSelectedFieldValue();
            Assert.That(actualValue, Is.EquivalentTo(new List<string> { color1, color2, color3 }));
        }
    }
}
