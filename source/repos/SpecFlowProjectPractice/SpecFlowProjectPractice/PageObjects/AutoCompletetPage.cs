using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class AutoCompletePage
    {
        private readonly WebDriverManager _driverManager;

        public AutoCompletePage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public void EnterText(string text)
        {
            /* var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click(); */
            
            var inputField = _driverManager.Driver().FindElement(By.CssSelector("#autoCompleteMultipleContainer > div > div.auto-complete__value-container.auto-complete__value-container--is-multi.css-1hwfws3"));
            inputField.Click();
            inputField.SendKeys(text);
        }

        public List<string> GetAutoCompleteSuggestions()
        {
            var suggestions = _driverManager.Driver().FindElements(By.CssSelector("#autoCompleteMultipleContainer > div"));
            return suggestions.Select(s => s.Text).ToList();
        }

        public List<string> GetSelectedColors()
        {
            var selectedColors = _driverManager.Driver().FindElements(By.CssSelector("#autoCompleteMultipleContainer > div > div.auto-complete__value-container.auto-complete__value-container--is-multi.css-1hwfws3 > div.css-1g6gooi > div"));
            return selectedColors.Select(s => s.Text).ToList();
        }

        public void AddColors(params string[] colors)
        {
            foreach (var color in colors)
            {
                EnterText(color);
                _driverManager.Driver().FindElement(By.CssSelector("#autoCompleteSingleInput")).SendKeys(Keys.Enter);
            }
        }

        public void DeleteColors(params string[] colors)
        {
            foreach (var color in colors)
            {
                var colorTag = _driverManager.Driver().FindElement(By.XPath($"//span[@class='tag ui-tag' and text()='{color}']"));
                colorTag.FindElement(By.CssSelector(".ui-tag-icon-close")).Click();
            }
        }
    }
}
