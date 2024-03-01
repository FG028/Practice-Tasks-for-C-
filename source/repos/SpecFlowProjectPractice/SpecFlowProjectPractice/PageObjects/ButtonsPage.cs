using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ButtonsPage : ElementsPage
    {
        private readonly WebDriverManager driverManager;

        public ButtonsPage(WebDriverManager _driverManager) : base(_driverManager)
        {
            driverManager = _driverManager;
        }

        public IWebElement GetButtonByName(string buttonName)
        {
            // Not able to find the XPath with this
            return driverManager.Driver().FindElement(By.XPath($"//button[text()='{buttonName}']"));
        }

        public void PerformButtonAction(string buttonName, IWebElement button)
        {
            switch (buttonName)
            {
                case "Click Me":
                    button.Click();
                    break;
                case "Double Click Me":
                    new Actions(driverManager.Driver()).DoubleClick(button).Perform();
                    break;
                case "Right Click Me":
                    new Actions(driverManager.Driver()).ContextClick(button).Perform();
                    break;
                default:
                    throw new ArgumentException($"Unsupported button name: {buttonName}");
            }
        }

        public string GetResultText()
        {
            // need to find a way to get the text after the click action
            return driverManager.Driver().FindElement(By.CssSelector(".result-text")).Text;
        }
    }
}
