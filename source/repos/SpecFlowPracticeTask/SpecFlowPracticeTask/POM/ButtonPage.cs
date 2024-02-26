using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
namespace SpecFlowPracticeTask.POM
{
    public class ButtonPage
    {
        private readonly IWebDriver driver;
        public ButtonPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[1]/div/ul/li[5]")).Click();
        }

        [FindsBy(How = How.XPath, Using = "//button[text()='Click Me']")]
        public IWebElement ClickMEButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Double Click']")]
        public IWebElement DoubleClickButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Right Click ']")]
        public IWebElement RightClickButton { get; set; }

        public IWebElement GetButtonByName(string buttonName)
        {
            return driver.FindElement(By.XPath($"//button[text()='{buttonName}']"));
        }

        public string GetResultText()
        {
            return driver.FindElement(By.Id("result")).Text;
        }

        public void PerformAction(IWebElement button)
        {
            var actions = new Actions(driver);
            switch (button.Text.ToLower()) 
            {
                case "double click":
                    actions.DoubleClick(button).Perform();
                    break;
                case "right click":
                    actions.ContextClick(button).Perform();
                    break;
                default:
                    button.Click();
                    break;
            }
        }
    }
}
