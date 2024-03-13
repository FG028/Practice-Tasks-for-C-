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

        public void SwitchToGridTab()
        {
            var selectGrid = _driverManager.Driver().FindElement(By.CssSelector("#demo-tab-grid"));
            if (selectGrid == null)
            {
                var elementYOffset = selectGrid.Location.Y;

                ((IJavaScriptExecutor)_driverManager.Driver()).ExecuteScript(
                    "arguments[0].scrollIntoView(true);", selectGrid);
                selectGrid.Click();
            }
            else
            {
                selectGrid.Click();
            }
        }

         public void SelectOptions()
        {
            string combinedSelector = "#row1 > li:nth-child(1), #row1 > li:nth-child(3), #row2 > li:nth-child(2), #row3 > li:nth-child(1), #row3 > li:nth-child(3)";

            IList<IWebElement> squares = _driverManager.Driver().FindElements(By.CssSelector(combinedSelector));

            foreach (IWebElement square in squares)
            {
                ((IJavaScriptExecutor)_driverManager.Driver()).ExecuteScript(
                        "arguments[0].scrollIntoView(true);", square);
                square.Click();
            }
        }

        public List<string> GetSelectedSquareValues()
        {
            string combinedSelector = ".list-group-item.active";
            IList<IWebElement> selectedSquares = _driverManager.Driver().FindElements(By.CssSelector(combinedSelector));

            return selectedSquares.Select(square => square.Text.Trim()).ToList();
        }

        public void VerifySelectedValues(List<string> expectedValues)
        {
        var actualValues = GetSelectedSquareValues();

        if (!actualValues.OrderBy(x => x).SequenceEqual(expectedValues.OrderBy(x => x)))
        {
            throw new AssertionException("Selected values do not match expected values!");
        }

        Console.WriteLine("Selected values match the expected values!");
        }
    }
}