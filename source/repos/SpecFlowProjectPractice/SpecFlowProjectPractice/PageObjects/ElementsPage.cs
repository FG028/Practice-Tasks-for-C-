using OpenQA.Selenium;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ElementsPage : Page
    {
        private readonly IWebDriver _driver;

        public ElementsPage(IWebDriver driver) : base (driver)
        {
            _driver = driver;
        }

        public IWebElement OutputText => _driver.FindElement(By.Id("output"));

        public List<string> GetColumnValues(string columnName)
        {
            var table = _driver.FindElement(By.Id("your-table-id"));
            var headerRow = _driver.FindElement(By.TagName("thead")).FindElement(By.TagName("tr"));
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

        public void ClickSubmitButton()
        {
            var submitButton = _driver.FindElement(By.Id("submitButton"));
            submitButton.Click();
        }

        public void SelectCheckBox(string checkBoxName)
        {
            // Replace with the appropriate logic to find the checkbox based on checkBoxName
            var checkBox = _driver.FindElement(By.Name(checkBoxName));

            if (!checkBox.Selected)
            {
                checkBox.Click();
            }
        }
        public int GetRowCount()
        {
            // Replace with actual selector based on your table structure
            var table = _driver.FindElement(By.Id("your-table-id"));
            return table.FindElements(By.TagName("tr")).Count;
        }

        public void ClickColumnHeader(string columnName)
        {
            // Replace with actual selector based on your table structure
            var table = _driver.FindElement(By.Id("your-table-id"));
            var headerRow = table.FindElement(By.TagName("tr"));
            headerRow.FindElements(By.TagName("th"))
                .First(x => x.Text == columnName)
                .Click();
        }

        public void DeleteRowByName(string name)
        {
            // Replace with actual selector based on your table structure
            var table = _driver.FindElement(By.Id("your-table-id"));
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
