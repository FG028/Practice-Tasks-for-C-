using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class SelectablePage : ElementsPage
    {
        private readonly WebDriverManager _driverManager;

        public SelectablePage(WebDriverManager driverManager) : base(driverManager)
        {
            _driverManager = driverManager;
        }

        public void SelectOption(string optionLabel)
        {
            var optionCheckbox = _driverManager.Driver().FindElement(By.XPath($"//label[text()='{optionLabel}']/input"));
            optionCheckbox.Click();
        }

        public List<string> GetSelectedOptions()
        {
            var selectedOptions = _driverManager.Driver().FindElements(By.XPath("//input[@type='checkbox' and @checked]"));
            return selectedOptions.Select(option => option.FindElement(By.XPath("preceding-sibling::label")).Text).ToList();
        }
    }
}
