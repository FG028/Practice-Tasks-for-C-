using NUnit.Framework;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class WebTablesSteps
    {
        private readonly WebDriverManager _driverManager;
        private readonly WebTablesPage _webTablesPage;

        public WebTablesSteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            _webTablesPage = new WebTablesPage(_driverManager);
        }

        [When(@"I click on the Salary column")]
        public void WhenIClickOnTheSalaryColumn()
        {
            _webTablesPage.PopUpButtonConfirmation();
            _webTablesPage.ClickSalaryColumn();
        }

        [Then(@"the values in the Salary column should be in ascending order")]
        public void ThenTheValuesInTheSalaryColumnShouldBeInAscendingOrder()
        {
            Assert.IsTrue(_webTablesPage.AreSalaryValuesAscending());
        }

        [Then(@"I delete the second row")]
        public void WhenIDeleteTheSecondRow()
        {
            _webTablesPage.DeleteSecondRow();
        }

        [Then(@"there should be only two rows left in the table")]
        public void ThenThereShouldBeOnlyTwoRowsLeftInTheTable()
        {
             Assert.AreEqual(2, _webTablesPage.GetRowCount());
        }

        [Then(@"there should be no ""Compliance"" value among the values in the Department column")]
        public void ThenThereShouldBeNoComplianceValueAmongTheValuesInTheDepartmentColumn()
        {
            Assert.IsFalse(_webTablesPage.IsComplianceDepartmentValuePresent());
        }
    }
}
