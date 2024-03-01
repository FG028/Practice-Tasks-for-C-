using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Browser;
using TechTalk.SpecFlow;


namespace SpecFlowProjectPractice.Drivers
{
    public static class WebDriverManager
    {
        private static IWebDriver driver;
        public static IWebDriver GetWebDriver()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;
        }

        public static void CloseDriver() 
        {
            driver.Quit();
        }
    }
}
