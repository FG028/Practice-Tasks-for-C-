using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.POM
{
    public class ButtonPage
    {
        WebDriver driver = WebDriverManager.GetDriver();
        public ButtonPage(WebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        }

        [FindsBy(How = How.XPath, Using = "//button[text()='Click Me']")]
        public IWebElement ClickMeButton { get; set; }

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
