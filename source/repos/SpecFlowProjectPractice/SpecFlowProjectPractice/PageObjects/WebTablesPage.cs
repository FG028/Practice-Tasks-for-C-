using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class WebTablesPage
    {
        private readonly WebDriverManager _driverManager;

        public WebTablesPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public void PopUpButtonConfirmation()
        {
            var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public IWebElement SalaryColumn => _driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[3]/div[1]/div[1]/div/div[5]"));

        public bool AreSalaryValuesAscending()
        {
            var salaryValues = _driverManager.Driver().FindElements(By.XPath("//*/div[@class='rt-tr-group']/div/div[5][text()!='']"))
                    .Select(element => int.Parse(element.Text));
            return salaryValues.SequenceEqual(salaryValues.OrderBy(value => value));
        }

        public int GetRowCount()
        {
            // Find the table element (assuming you have a method to get it)
            var tableElement = _driverManager.Driver().FindElement(By.XPath("//*[@id='app']/div/div/div/div[2]/div[2]/div[3]/div[1]/div[2]")); // Replace with your actual table XPath

            // Find all rows within the table
            var rows = tableElement.FindElements(By.XPath(".//div[@class='rt-tr-group']")); // Adjust the XPath for rows if needed

            // Count the elements at the salary column index (assuming it's the 5th position)
            int count = rows.Select(row => row.FindElements(By.TagName("div"))[4])
                 .Where(element => !string.IsNullOrEmpty(element.Text.Trim()))
                 .Count();

            return count;
        }

        public void ClickSalaryColumn() => SalaryColumn.Click();

        public void DeleteSecondRow() => DeleteButton.Click();

        public bool IsComplianceDepartmentValuePresent() => DepartmentValues.Any(element => element.Text == "Compliance");

        public IWebElement DeleteButton => _driverManager.Driver().FindElement(By.Id("delete-record-2")); // Example selector, adjust if needed

        public IReadOnlyCollection<IWebElement> DepartmentValues => _driverManager.Driver().FindElements(By.XPath("//table[@id='table1']//tbody//tr//td[text()='Department']")); // Example selector, adjust if needed
    }
}
