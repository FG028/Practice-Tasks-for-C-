using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;


namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class AutoCompleteFunctionalitySteps
    {
        private readonly IWebDriver _driver;
        private readonly AutoCompletePage _autoCompletePage;

        public AutoCompleteFunctionalitySteps(IWebDriver driver)
        {
            _driver = driver;
            _autoCompletePage = new AutoCompletePage(_driver);
        }

        [When(@"I enter the letter ""(.*)"" in the ""(.*)"" field")]
        public void WhenIEnterTheLetterInTheField(string text, string fieldName)
        {
            _autoCompletePage.EnterText(fieldName, text);
        }

        [Then(@"I verify the autocomplete offers three variants, all containing ""(.*)""")]
        public void ThenIVerifyTheFollowingSuggestionsAreDisplayed(Table table)
        {
            List<string> expectedSuggestions = table.Rows.Select(row => row["Item"].ToString()).ToList();
            List<string> actualSuggestions = _autoCompletePage.GetSuggestions();
            // Assert that actual suggestions match expected suggestions
            CollectionAssert.AreEquivalent(expectedSuggestions, actualSuggestions);
        }

        [When(@"I enter ""(.*)"" in the ""(.*)"" field")]
        public void WhenIEnterInTheField(string text, string fieldName)
        {
            _autoCompletePage.EnterText(fieldName, text);
        }

        [Then(@"I delete ""(.*)"" and ""(.*)""")]
        public void DeleteSpecificColors(string color1, string color2)
        {
            _autoCompletePage.DeleteColor(color1);
            _autoCompletePage.DeleteColor(color2);
        }

        [Then(@"I verify the selected value in the field is ""(.*)""")]
        public void ThenIVerifyTheSelectedValueInTheFieldIs(string expectedValue)
        {
            string actualValue = _autoCompletePage.GetSelectedFieldValue();
            Assert.AreEqual(expectedValue, actualValue, "Selected value in the field does not match expected value");
        }
    }
}
