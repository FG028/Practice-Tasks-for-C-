using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ElementsPage : Page
    {
        private readonly WebDriverManager _driverManager;

        public ElementsPage(WebDriverManager driverManager) : base (driverManager)
        {
            _driverManager = driverManager;
        }

        public IWebElement OutputText => _driverManager.Driver().FindElement(By.Id("output"));

        public List<string> GetColumnValues(string columnName)
        {
            var table = _driverManager.Driver().FindElement(By.XPath("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody"));
            var headerRow = _driverManager.Driver().FindElement(By.CssSelector("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-thead.-header > div"));
            var columnElements = headerRow.FindElements(By.TagName("th"));
            int columnIndex = -1; // Initialize to -1 in case the column isn't found

            for (int i = 0; i < columnElements.Count; i++)
            {
                if (columnElements[i].Text == columnName)
                {
                    columnIndex = i;
                    break;
                }
            }

            List<string> values = new List<string>();
            foreach (var row in table.FindElements(By.TagName("tr")).Skip(1))
            {
                values.Add(row.FindElements(By.TagName("td"))[columnIndex].Text);
            }

            return values;
        }

        public void SelectCheckBox(string checkBoxName)
        {
            // 'no such element: Unable to locate element:
            var checkBox = _driverManager.Driver().FindElement(By.Name(checkBoxName));

            if (!checkBox.Selected)
            {
                checkBox.Click();
            }
        }

        public int GetRowCount()
        {
            // 'no such element: Unable to locate element:
            var table = _driverManager.Driver().FindElement(By.XPath("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody"));
            return table.FindElements(By.TagName("tr")).Count;
        }

        public void ClickColumnHeader(string columnName)
        {
            // 'no such element: Unable to locate element:
            var table = _driverManager.Driver().FindElement(By.XPath("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody"));
            var headerRow = _driverManager.Driver().FindElement(By.CssSelector("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-thead.-header > div"));
            headerRow.FindElements(By.TagName("th"))
                .First(x => x.Text == columnName)
                .Click();
        }

        public void DeleteRowByName(string name)
        {
            // 'no such element: Unable to locate element:
            var table = _driverManager.Driver().FindElement(By.XPath("#app > div > div > div > div.col-12.mt-4.col-md-6 > div.web-tables-wrapper > div.ReactTable.-striped.-highlight > div.rt-table > div.rt-tbody"));
            foreach (var row in table.FindElements(By.TagName("tr")).Skip(1))
            {
                if (row.FindElement(By.TagName("td")).Text.Contains(name))
                {
                    row.FindElement(By.LinkText("Delete")).Click();
                    break;
                }
            }
        }
    }
}
