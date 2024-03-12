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

        public IWebElement SalaryColumn => _driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[3]/div[1]/div[1]/div/div[5]"));

        public bool AreSalaryValuesAscending()
        {
            var salaryValues = _driverManager.Driver().FindElements(By.XPath("//*/div[@class='rt-tr-group']/div/div[5][text()!='']"))
                    .Select(element => int.Parse(element.Text));
            return salaryValues.SequenceEqual(salaryValues.OrderBy(value => value));
        }

        public int GetRowCount()
        {
            var tableElement = _driverManager.Driver().FindElement(By.XPath("//*[@id='app']/div/div/div/div[2]/div[2]/div[3]/div[1]/div[2]"));

            var rows = tableElement.FindElements(By.XPath(".//div[@class='rt-tr-group']"));

            int count = rows.Select(row => row.FindElements(By.TagName("div"))[4])
                 .Where(element => !string.IsNullOrEmpty(element.Text.Trim()))
                 .Count();

            return count;
        }

        public void ClickSalaryColumn() => SalaryColumn.Click();

        public void DeleteSecondRow() => DeleteButton.Click();

        public bool IsComplianceDepartmentValuePresent() => DepartmentValues.Any(element => element.Text == "Compliance");

        public IWebElement DeleteButton => _driverManager.Driver().FindElement(By.Id("delete-record-2"));

        public IReadOnlyCollection<IWebElement> DepartmentValues => _driverManager.Driver().FindElements(By.XPath("//table[@id='table1']//tbody//tr//td[text()='Department']"));
    }
}