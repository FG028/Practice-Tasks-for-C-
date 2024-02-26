using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class BrowserWindowSteps
    {
        private readonly WebDriver driver;
        private readonly BrowserWindowPage browserWindowPage;

        public BrowserWindowSteps(WebDriver driver)
        {
            this.driver = driver;
            browserWindowPage = new BrowserWindowPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/browser-windows""")]
        public void NavigateToSpecificPage()
        {
            browserWindowPage.NavigateToPage();
        }

        [Given(@"I navigate to the ""Alerts, Frame & Windows"" category and ""Browser Windows"" section")]
        public void NavigateToBrowserWindowsSection()
        {
            browserWindowPage.NavigateToAutoCompleteSection();
        }

        [When(@"I click on the ""(.*)"" button")]
        public void ClickButton(string buttonType)
        {
            browserWindowPage.GetButtonByType(buttonType).Click();
        }

        [Then(@"A new ""(.*)"" should be loaded")]
        public void VerifyWindowLoaded(string windowsType)
        {
            browserWindowPage.SwitchToNewWindowsOrTab(windowsType);
        }

    }
}
