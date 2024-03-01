using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class SelectableSteps
    {
        private WebDriverManager _driverManager;
        private readonly SelectablePage _selectablePage;

        public SelectableSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _selectablePage = new SelectablePage(_driverManager);
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
        // : 'Invalid cast from 'System.String' to 'TechTalk.SpecFlow.Table'.
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
