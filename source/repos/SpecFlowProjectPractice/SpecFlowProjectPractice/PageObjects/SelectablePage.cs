using OpenQA.Selenium;

namespace SpecFlowProjectPractice.PageObjects
{
    public class SelectablePage : ElementsPage
    {
        private readonly IWebDriver _driver;

        public SelectablePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SelectOption(string optionLabel)
        {
            var optionCheckbox = _driver.FindElement(By.XPath($"//label[text()='{optionLabel}']/input"));
            optionCheckbox.Click();
        }

        public List<string> GetSelectedOptions()
        {
            var selectedOptions = _driver.FindElements(By.XPath("//input[@type='checkbox' and @checked]"));
            return selectedOptions.Select(option => option.FindElement(By.XPath("preceding-sibling::label")).Text).ToList();
        }
    }
}
