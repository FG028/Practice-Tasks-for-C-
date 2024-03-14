using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ButtonsPage
    {
        private WebDriverManager driverManager;
        private string _clickedButtonName;

        public ButtonsPage(WebDriverManager _driverManager)
        {
            driverManager = _driverManager;
        }

        public IWebElement GetButtonByName(string buttonName)
        {
            switch (buttonName)
            {
                case "Right Click Me":
                    return driverManager.Driver().FindElement(By.Id("rightClickBtn"));
                case "Click Me":
                    return driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[3]/button"));
                case "Double Click Me":
                    return driverManager.Driver().FindElement(By.Id("doubleClickBtn"));
                default:
                    throw new ArgumentException($"Unsupported button name: {buttonName}");
            }
        }

        public void PerformButtonAction(string buttonName, IWebElement button)
        {
            _clickedButtonName = buttonName;
            ((IJavaScriptExecutor)driverManager.Driver()).ExecuteScript(
            "arguments[0].scrollIntoView(true);", button);

            switch (buttonName)
            {
                case "Double Click Me":
                    new Actions(driverManager.Driver()).DoubleClick(button).Perform();
                    break;
                case "Click Me":
                    button.Click();
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
            switch (_clickedButtonName)
            {
                case "Right Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#rightClickMessage")).Text;
                case "Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#dynamicClickMessage")).Text;
                case "Double Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#doubleClickMessage")).Text;
                default:
                    throw new ArgumentException($"Unsupported button name: {_clickedButtonName}");
            }
        }
    }
}