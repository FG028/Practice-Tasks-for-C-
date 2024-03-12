using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.PageObjects
{
    public class ProgressBarPage
    {
        private readonly WebDriverManager _driverManager;

        public ProgressBarPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public IWebElement StartStopButton => _driverManager.Driver().FindElement(By.CssSelector("#startStopButton"));
        public IWebElement ProgressBarValue => _driverManager.Driver().FindElement(By.CssSelector("#progressBar > div"));
        public IWebElement ResetButton => _driverManager.Driver().FindElement(By.CssSelector("#resetButton"));

        public void ClickStartButton() => StartStopButton.Click();

        public bool IsProgressBarComplete()
        {
            var wait = new WebDriverWait(_driverManager.Driver(), TimeSpan.FromSeconds(24));
            return wait.Until(d => ProgressBarValue.GetAttribute("aria-valuenow") == "100");
        }

        public string GetStartButtonName() => ResetButton.Text;

        public void ClickResetButton() => ResetButton.Click();

        public bool IsProgressBarReset()
        {
            return StartStopButton.Text == "Start" && ProgressBarValue.GetAttribute("aria-valuenow") == "0";
        }
    }
}
