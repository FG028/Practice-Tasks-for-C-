using SpecFlowProjectPractice.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowProjectPractice.Hooks
{
    [Binding]
    public class Hooks
    {
        private WebDriverManager _driverManager;

        public Hooks(WebDriverManager driverManager) 
        {
            _driverManager = driverManager;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverManager.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverManager.CloseBrowser();
        }
    }
}