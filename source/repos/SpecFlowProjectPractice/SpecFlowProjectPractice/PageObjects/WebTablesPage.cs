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

        private IReadOnlyCollection<IWebElement> FindTableRowElements(int rowNumber)
        {
            // Use a generic selector for flexibility
            return _driverManager.Driver().FindElements(By.CssSelector($"#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody > div:nth-child({rowNumber}) > div"));
        }

        public bool AreSalaryValuesAscending()
        {
            try
            {
                if (!FindTableRowElements(1).Any(element => element.Text == "Salary") ||
                    !FindTableRowElements(2).Any(element => element.Text == "Salary") ||
                    !FindTableRowElements(3).Any(element => element.Text == "Salary"))
                {
                    return false;
                }

                int salary1 = int.Parse(FindTableRowElements(1).FirstOrDefault(element => element.Text == "Salary").Text.Trim());
                int salary2 = int.Parse(FindTableRowElements(2).FirstOrDefault(element => element.Text == "Salary").Text.Trim());
                int salary3 = int.Parse(FindTableRowElements(3).FirstOrDefault(element => element.Text == "Salary").Text.Trim());

                return salary1 <= salary2 && salary2 <= salary3;
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Failed to find elements while checking salary values.");
            }
            catch (FormatException)
            {
                throw new Exception("Failed to parse salary values to integers.");
            }
        }

        public void ClickSalaryColumn() => SalaryColumn.Click();

        public void DeleteSecondRow() => DeleteButton.Click();

        public int GetRowCount() => FindTableRowElements(1).Count; // Use the same selector as in AreSalaryValuesAscending

        public bool IsComplianceDepartmentValuePresent() => DepartmentValues.Any(element => element.Text == "Compliance");

        // Update the DeleteButton selector if the original is incorrect
        public IWebElement DeleteButton => _driverManager.Driver().FindElement(By.Id("delete-record-2")); // Example selector, adjust if needed

        // Update the DepartmentValues selector if the original is incorrect
        public IReadOnlyCollection<IWebElement> DepartmentValues => _driverManager.Driver().FindElements(By.XPath("//table[@id='table1']//tbody//tr//td[text()='Department']")); // Example selector, adjust if needed
    }
}
