using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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

        [FindsBy(How = How.CssSelector, Using = "[id*='fullName']")]
        public IWebElement FullNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='userEmail']")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='currentAddress']")]
        public IWebElement CurrentAddressField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id*='permanentAddress']")]
        public IWebElement PermanentAddressField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[type='submit']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".rt-tr-group")]
        public IReadOnlyCollection<IWebElement> SubmittedDataRows { get; set; }

        public void ClickSubmitButton()
        {
            var submitButton = _driverManager.Driver().FindElement(By.CssSelector("[type='submit']"));
            submitButton.Click();
        }
    }
}
