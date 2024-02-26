using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class ProgressBarPage
    {
        private readonly WebDriver driver;

        public ProgressBarPage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToDemoQA()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");
        }

        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[4]/div/ul/li[5]")).Click();
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
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => int.Parse(ProgressBarText.Text.Split('%')[0]) >= expectedValue);
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
