using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class WebTablesSteps
    {
        private readonly IWebDriver _driver;
        private readonly WebTablesPage _webTablesPage;

        public WebTablesSteps(IWebDriver driver)
        {
            _driver = driver;
            _webTablesPage = new WebTablesPage(_driver);
        }

        

        [When(@"I click the ""(.*)"" column")]
        public void WhenIClickTheColumn(string columnName)
        {
            _webTablesPage.ClickColumnHeader(columnName);
        }

        [Then(@"I verify the values in the ""(.*)"" column are in ascending order")]
        public void ThenIVerifyTheValuesInTheColumnAreInAscendingOrder(string columnName)
        {
            // Get all cells in the specified column
            List<string> cellValues = _webTablesPage.GetColumnValues(columnName);

            // Verify values are in ascending order using LINQ
            bool isAscending = cellValues.OrderBy(x => x).SequenceEqual(cellValues);
            Assert.IsTrue(isAscending, $"Values in '{columnName}' column are not in ascending order");
        }

        [Then(@"I delete the second row name Alden")]
        public void DeleteSecondRow()
        {
            _webTablesPage.DeleteRowByName("Alden");
        }

        [Then(@"I verify there are only two rows left in the table")]
        public void ThenIVerifyThereAreOnlyTwoRowsLeftInTheTable()
        {
            // Get the number of rows in the table
            int rowCount = _webTablesPage.GetRowCount();
            Assert.AreEqual(2, rowCount, "Row count is not equal to 2");
        }
        
        [Then(@"I verify that there is no ""(.*)"" value among the values in the ""(.*)"" column")]
        public void ThenIVerifyThatThereIsNoValueAmongTheValuesInTheColumn(string value, string columnName)
        {
            // Get all values in the specified column
            List<string> cellValues = _webTablesPage.GetColumnValues(columnName);
            // Verify that no cell value matches the expected value

            bool isValuePresent = cellValues.Any(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
            Assert.IsFalse(isValuePresent, $"Value '{value}' is present in the '{columnName}' column");
        }
    }
}
