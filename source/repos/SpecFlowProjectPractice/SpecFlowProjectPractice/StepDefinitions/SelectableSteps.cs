using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;

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
        public void WhenISelectTheFollowingOptions()
        {
            _selectablePage.SelectGrid();
            _selectablePage.SelectOption();
        }

        [Then(@"I verify the selected squares' values are ""(.*)""")]
        public void ThenIVerifyTheFollowingOptionsAreSelected(string expectedValues)
        {
            var actualValues = _selectablePage.GetSelectedValuesFromSquares();
            Assert.AreEqual(expectedValues.Split(','), actualValues.ToArray());
        }
    }
}
