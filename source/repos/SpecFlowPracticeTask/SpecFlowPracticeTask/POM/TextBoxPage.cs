using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class TextBoxPage
    {

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
    }
}