using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.POM
{
    public class WebTablePage
    {
        [FindsBy(How = How.CssSelector, Using = "#webtables")]
        public IWebElement Table { get; set; }

        public IWebElement GetColumnHeader(string columnName)
        {
            return driver.FindElement(By.XPath($"//th[text()='{columnName}']"));
        }

        public IList<IWebElement> GetColumnValues(string columnName) 
        {
            return driver.FindElements(By.XPath($"//td[text()='{columnName}']/following-sibling::td[text()!=' ']"));
        }
        
        public IWebElement GetDeleteButtonForRow(int rowIndex) 
        {
            var rows = Table.FindElements(By.TagName("tr"));
            return rows[rowIndex].FindElement(By.XPath(".//i[@class='fa fa-trash']"));
        }
        
        public int GetRowCount()
        {
            return Table.FindElements(By.TagName("tr")).Count;
        }
    }
}
