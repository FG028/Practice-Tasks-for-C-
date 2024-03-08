using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class SelectablePage
    {
        private readonly WebDriverManager _driverManager;

        public SelectablePage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public void PoPUpWindowConsent()
        {
            var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public void SelectGrid()
        {
            PoPUpWindowConsent();
            var selectGrid = _driverManager.Driver().FindElement(By.CssSelector("#demo-tab-grid"));
            if (selectGrid == null)
            {
                var elementYOffset = selectGrid.Location.Y; // Get the Y-coordinate of the button

                ((IJavaScriptExecutor)_driverManager.Driver()).ExecuteScript(
                    "arguments[0].scrollIntoView(true);", selectGrid);
                selectGrid.Click();
            }
            else
            {
                selectGrid.Click();
            }
        }

        public void SelectOption()
        {
            List<string> optionSelectors = new List<string>
            {
                "#row1 > li:nth-child(1)",
                "#row1 > li:nth-child(3)",
                "#row2 > li:nth-child(2)",
                "#row3 > li:nth-child(1)",
                "#row3 > li:nth-child(3)"
            };
            foreach (string selector in optionSelectors)
            {
                IWebElement option = _driverManager.Driver().FindElement(By.CssSelector(selector));
                option.Click();
            }
        }

        public List<string> GetSelectedValuesFromSquares()
        {
            /* List<string> actualValues = new List<string>();

            var selectedSquares = _driverManager.Driver().FindElements(By.CssSelector(".selected-square"));
            foreach (var square in selectedSquares)
            {
                actualValues.Add(square.Text);
            }
            return actualValues; */

            var selectedOptions = _driverManager.Driver().FindElements(By.CssSelector("#selectable li.selected"));
            return selectedOptions.Select(option => option.Text).ToList();
        }
    }
}