using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.POM
{
    public class SelectablePage
    {
        WebDriver driver = WebDriverManager.GetDriver();
        public SelectablePage(WebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/selectable");
        }

        [FindsBy(How = How.Id, Using = "gridTab")]
        public IWebElement GridTab { get; set; }

        public IReadOnlyCollection<IWebElement> SelectableSquares => driver.FindElements(By.CssSelector(".ui-selectable-item"));

        public void SelectSquare(int squareNumber)
        {
            var square = SelectableSquares.ElementAt(squareNumber - 1);
            if (!square.Selected)
            {
                Actions actions = new Actions(driver);
                actions.ClickAndHold(square).Build().Perform();
            }
        }
    }
}
