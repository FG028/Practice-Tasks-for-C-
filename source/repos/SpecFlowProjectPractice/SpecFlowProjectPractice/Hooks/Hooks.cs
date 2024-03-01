using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProjectPractice.Hooks
{
    [Binding]
    public class Hooks
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverManager.GetWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverManager.CloseDriver();
        }
    }
}
