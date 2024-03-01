using OpenQA.Selenium;

namespace SpecFlowProjectPractice.PageObjects
{
    public class WebTablesPage : ElementsPage
    {
        private readonly IWebDriver _driver;

        public WebTablesPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public IWebElement GetTableBody()
        {
            return _driver.FindElement(By.CssSelector("table.demo-table tbody"));
        }

        public int TableRowCount => GetTableBody().FindElements(By.TagName("tr")).Count;

        public IWebElement TableBody => _driver.FindElement(By.TagName("tbody"));

        public string GetCellValue(int rowIndex, int columnIndex)
        {
            var tableRows = TableBody.FindElements(By.TagName("tr"));
            ValidateIndex(rowIndex, "row", tableRows.Count);

            var tableCells = tableRows[rowIndex - 1].FindElements(By.TagName("td"));
            ValidateIndex(columnIndex, "column", tableCells.Count);

            return tableCells[columnIndex - 1].Text;
        }

        public List<string> GetRowValues(int rowIndex)
        {
            var tableRows = TableBody.FindElements(By.TagName("tr"));
            ValidateIndex(rowIndex, "row", tableRows.Count);

            var rowValues = tableRows[rowIndex - 1].FindElements(By.TagName("td")).Select(cell => cell.Text).ToList();
            return rowValues;
        }

        public List<string> GetColumnValues(int columnIndex)
        {
            var tableRows = TableBody.FindElements(By.TagName("tr"));
            ValidateIndex(columnIndex, "column", tableRows.Count); // Assuming consistent column count throughout

            var columnValues = new List<string>();
            foreach (var row in tableRows)
            {
                var cell = row.FindElements(By.TagName("td"))[columnIndex - 1];
                columnValues.Add(cell.Text);
            }

            return columnValues;
        }

        private void ValidateIndex(int index, string indexType, int maxCount)
        {
            if (index < 1 || index > maxCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{indexType} index must be between 1 and {maxCount}");
            }
        }
    }
}
