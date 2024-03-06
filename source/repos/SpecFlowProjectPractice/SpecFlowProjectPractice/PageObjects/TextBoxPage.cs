using OpenQA.Selenium;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class TextBoxPage
    {
        private readonly WebDriverManager _driverManager;

        public TextBoxPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public IWebElement FullNameField => _driverManager.Driver().FindElement(By.Id("userName"));

        public IWebElement EmailField => _driverManager.Driver().FindElement(By.Id("userEmail"));

        public IWebElement CurrentAddressField => _driverManager.Driver().FindElement(By.Id("currentAddress"));

        public IWebElement PermanentAddressField => _driverManager.Driver().FindElement(By.Id("permanentAddress"));

        public IWebElement Submit => _driverManager.Driver().FindElement(By.CssSelector("#submit"));

        public IWebElement FullNameLabel => _driverManager.Driver().FindElement(By.Id("name"));
        public IWebElement EmailLabel => _driverManager.Driver().FindElement(By.Id("email"));
        public IWebElement CurrentAddressLabel => _driverManager.Driver().FindElement(By.CssSelector("p#currentAddress"));
        public IWebElement PermanentAddressLabel => _driverManager.Driver().FindElement(By.CssSelector("p#permanentAddress"));


        public void PopUpButtonConfirmation()
        {
            var popup = _driverManager.Driver().FindElement(By.CssSelector("body > div.fc-consent-root > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-dialog-content"));
            popup.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p")).Click();
        }

        public void ClickSubmitButton()
        {
            var submitButton = Submit;
            if (submitButton != null)
            {
                var elementYOffset = submitButton.Location.Y; // Get the Y-coordinate of the button

                ((IJavaScriptExecutor)_driverManager.Driver()).ExecuteScript(
                    "arguments[0].scrollIntoView(true);", submitButton);
                submitButton.Click();
            }
            else
            {
                submitButton.Click();
            }
        }
    }
}
