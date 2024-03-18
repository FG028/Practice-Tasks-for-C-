using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SpecFlowPracticeTask.Hooks;

namespace SpecFlowPracticeTask.POM
{
    public class ProgressBarPage
    {
        WebDriver driver = WebDriverManager.GetDriver();
        public ProgressBarPage(WebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToDemoQA()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");
        }

        [FindsBy(How = How.Id, Using = "startStopButton")]
        public IWebElement StartStopButton { get; set; }

        [FindsBy(How = How.Id, Using = "progressBarText")]
        public IWebElement ProgressBarText { get; set;}

        public void ClickStartButton()
        {
            StartStopButton.Click();
        }

        public void WaitForProgressBar(int expectedValue)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => int.Parse(ProgressBarText.Text.Split('%')[0]) >= expectedValue);
        }

        public string GetButtonText()
        {
            return StartStopButton.Text;
        }

        public int GetProgressBarValue()
        {
            return int.Parse(ProgressBarText.Text.Split('%')[0]);
        }
    }
}
