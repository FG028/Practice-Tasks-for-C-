using SpecFlowProjectPractice.Drivers;


namespace SpecFlowProjectPractice.PageObjects
{
    public class BrowserWindowPage
    {
        private readonly WebDriverManager _driverManager;

        public BrowserWindowPage(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
        }

        public void SwitchToNewWindow()
        {
            var originalWindow = _driverManager.Driver().CurrentWindowHandle;

            foreach (var handle in _driverManager.Driver().WindowHandles.Except(new[] { originalWindow }))
            {
                _driverManager.Driver().SwitchTo().Window(handle);
                break;
            }
        }
    }
}
