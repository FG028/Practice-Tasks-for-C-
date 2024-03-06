using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ButtonsPage
    {
        private WebDriverManager driverManager;
        private string _clickedButtonName; // to store the button name

        public ButtonsPage(WebDriverManager _driverManager)
        {
            driverManager = _driverManager;
        }

        public void PopUpButtonConfirmation()
        {
            var popup = driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public IWebElement GetButtonByName(string buttonName)
        {
            switch (buttonName)
            {
                case "Click Me":
                    return driverManager.Driver().FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div[2]/div[3]/button"));
                case "Double Click Me":
                    return driverManager.Driver().FindElement(By.Id("doubleClickBtn"));
                case "Right Click Me":
                    return driverManager.Driver().FindElement(By.Id("rightClickBtn"));
                default:
                    throw new ArgumentException($"Unsupported button name: {buttonName}");
            }
        }

        public void PerformButtonAction(string buttonName, IWebElement button)
        {  
                _clickedButtonName = buttonName;
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
            switch (_clickedButtonName)
            {
                case "Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#dynamicClickMessage")).Text;
                case "Double Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#doubleClickMessage")).Text;
                case "Right Click Me":
                    return driverManager.Driver().FindElement(By.CssSelector("#rightClickMessage")).Text;
                default:
                    throw new ArgumentException($"Unsupported button name: {_clickedButtonName}");
            }
        }
    }
}
