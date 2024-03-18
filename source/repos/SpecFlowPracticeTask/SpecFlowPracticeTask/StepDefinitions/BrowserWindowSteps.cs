using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowPracticeTask.POM;
using SpecFlowPracticeTask.Hooks;


namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class BrowserWindowSteps
    {
        private readonly BrowserWindowPage browserWindowPage;
        WebDriver driver = WebDriverManager.GetDriver();

        public BrowserWindowSteps(WebDriver _driver)
        {
            driver = _driver;
            browserWindowPage = new BrowserWindowPage(driver);
        }

        [Given(@"I am on the DemoQA page ""https://demoqa.com/browser-windows""")]
        public void NavigateToDemoQA()
        {
            browserWindowPage.NavigateToPage();
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
