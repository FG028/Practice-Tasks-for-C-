using OpenQA.Selenium;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ButtonsPage : ElementsPage
    {
        private readonly IWebDriver _driver;

        public ButtonsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickButton(string buttonText)
        {
            _driver.FindElement(By.XPath($"//button[text()='{buttonText}']")).Click();
        }

        public string GetDisplayedText()
        {
            return _driver.FindElement(By.Id("displayed-text")).Text;
        }

        public string FeedbackText()
        {
            return _driver.FindElement(By.Id("feedbackMessage")).Text;
        }
    }
}
