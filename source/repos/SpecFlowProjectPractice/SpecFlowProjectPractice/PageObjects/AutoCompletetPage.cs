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
            var inputField = _driverManager.Driver().FindElement(By.CssSelector("#autoCompleteMultipleInput"));
            inputField.SendKeys(text);
            if (text.Length > 2)
            {
                inputField.SendKeys(Keys.Enter);
            }
        }

        public void ClearInputField()
        {
            var inputField = _driverManager.Driver().FindElement(By.CssSelector("#autoCompleteMultipleInput"));
            inputField.Clear();
        }

        public List<string> GetAutoCompleteSuggestions()
        {
            var suggestions = _driverManager.Driver().FindElements(By.CssSelector("#autoCompleteMultipleContainer > div"));
            return suggestions.Select(s => s.Text).ToList();
        }

        public List<string> GetSelectedColors()
        {
            List<string> colors = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                string xpath = $@"//*[@id=""autoCompleteMultipleContainer""]/div/div[1]/div[{i}]/div[1]";
                var colorElements = _driverManager.Driver().FindElements(By.XPath(xpath));

                foreach (var colorElement in colorElements)
                {
                    colors.Add(colorElement.Text);
                }
            }
            return colors;
        }

        public void AddMultipleColors(params string[] colors)
        {
            foreach (var color in colors)
            {
                EnterText(color);
            }
        }

        public void DeleteColors(params string[] colors)
        {
            foreach (var color in colors)
            {
                if (color == "Yellow")
                {
                    _driverManager.Driver().FindElement(By
                        .CssSelector("#autoCompleteMultipleContainer > div > div.auto-complete__value-container.auto-complete__value-container--is-multi.auto-complete__value-container--has-value.css-1hwfws3 > div:nth-child(2) > div.css-xb97g8.auto-complete__multi-value__remove > svg > path"))
                        .Click();
                }
                else if (color == "Purple")
                {
                    _driverManager.Driver().FindElement(By
                        .CssSelector("#autoCompleteMultipleContainer > div > div.auto-complete__value-container.auto-complete__value-container--is-multi.auto-complete__value-container--has-value.css-1hwfws3 > div:nth-child(4) > div.css-xb97g8.auto-complete__multi-value__remove > svg > path"))
                        .Click();
                }
                else
                {
                    return;
                }
            }
        }
    }
}