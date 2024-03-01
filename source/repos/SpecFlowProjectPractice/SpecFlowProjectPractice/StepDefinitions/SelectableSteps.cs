using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class SelectableSteps
    {
        private readonly IWebDriver _driver;
        private readonly SelectablePage _selectablePage;

        public SelectableSteps(IWebDriver driver)
        {
            _driver = driver;
            _selectablePage = new SelectablePage(_driver);
        }

        [When(@"I select squares ""(.*)""")]
        public void WhenISelectTheFollowingOptions(Table table)
        {
            foreach (var row in table.Rows)
            {
                string optionLabel = row["Item"].ToString();
                _selectablePage.SelectOption(optionLabel);
            }
        }
        [Then(@"I verify the selected squares' values are ""(.*)""")]
        public void ThenIVerifyTheFollowingOptionsAreSelected(Table table)
        {
            List<string> expectedSelectedOptions = table.Rows.Select(row => row["Item"].ToString()).ToList();
            List<string> actualSelectedOptions = _selectablePage.GetSelectedOptions();

            // Assert that actual and expected selected options are the same
            CollectionAssert.AreEquivalent(expectedSelectedOptions, actualSelectedOptions);
        }
    }
}
