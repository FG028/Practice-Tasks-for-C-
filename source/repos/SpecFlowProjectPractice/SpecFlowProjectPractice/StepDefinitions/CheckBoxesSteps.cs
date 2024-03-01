using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class CheckBoxesSteps
    {
        private WebDriverManager _driverManager;
        private readonly ElementsPage _elementsPage;

        public CheckBoxesSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _elementsPage = new ElementsPage(_driverManager);
    }

        [When(@"I select the following checkboxes:")]
        public void WhenISelectTheFollowingCheckBoxes(Table table)
        {
            foreach (var row in table.Rows)
            {
                string checkBoxLabel = row["Item"].ToString();
                _elementsPage.SelectCheckBox(checkBoxLabel);
            }
        }

        [Then(@"I verify the output is ""(.*)""")]
        public void ThenIVerifyTheOutputIs(string expectedOutput)
        {
            string actualOutput = _elementsPage.OutputText.Text;
            Assert.AreEqual(expectedOutput, actualOutput, "Output text does not match expected value");
        }
    }
}
