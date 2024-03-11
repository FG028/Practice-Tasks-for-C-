using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.Linq;

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

        /* [When(@"I select squares 1, 3, 5, 7, and 9")]
        public void WhenISelectTheFollowingOptions()
        {
            _selectablePage.SwitchToGridTab();
            _selectablePage.SelectOptions();
        }

        [Then(@"I verify the selected squares' values are ""(.*)""")]
        public void VerifyTheFollowingOptionsAreSelected(string expectedValues)
        {
            List<string> actualValues = _selectablePage.GetSelectedValuesFromSquares();
            List<string> expectedList = expectedValues.Split(',').Select(x => x.Trim()).ToList();

            CollectionAssert.AreEqual(expectedList, actualValues);
        } */

        [When(@"I switch to the Grid tab")]
        public void WhenISwitchToTheGridTab()
        {
            _selectablePage.SwitchToGridTab();
        }

        [Then(@"I select squares 1, 3, 5, 7, and 9")]
        public void WhenISelectSquares1357And9()
        {
            List<string> optionSelectors = new List<string>
            {
                "#row1 > li:nth-child(1)",
                "#row1 > li:nth-child(3)",
                "#row2 > li:nth-child(2)",
                "#row3 > li:nth-child(1)",
                "#row3 > li:nth-child(3)"
            };
            foreach (string selector in optionSelectors)
            {
                IWebElement option = _driverManager.Driver().FindElement(By.CssSelector(selector));
                option.Click();
            }
        }

        [Then(@"the selected squares should display One, Three, Five, Seven, and Nine")]
        public void ThenTheSelectedSquaresShouldDisplayOneThreeFiveSevenAndNine()
        {
            List<string> expectedValues = new List<string> { "One", "Three", "Five", "Seven", "Nine" };
            bool areValuesCorrect = _selectablePage.VerifySelectedValues(expectedValues);
            Assert.IsTrue(areValuesCorrect, "Selected square values do not match expected values.");
        }
    }
}
