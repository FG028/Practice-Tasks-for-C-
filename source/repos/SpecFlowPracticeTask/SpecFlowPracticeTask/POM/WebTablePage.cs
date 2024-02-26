using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class WebTablePage
    {
        private readonly IWebDriver driver;

        public WebTablePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
        }

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
