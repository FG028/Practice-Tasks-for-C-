using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class SelectablePage
    {
        private readonly IWebDriver driver;
        
        public SelectablePage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/selectable");
        }

        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[5]/div/ul/li[2]")).Click();
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
