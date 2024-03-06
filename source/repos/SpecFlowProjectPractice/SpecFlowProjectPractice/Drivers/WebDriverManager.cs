using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace SpecFlowProjectPractice.Drivers
{
    public class WebDriverManager
    {
        private IWebDriver webDriver;

        public IWebDriver Driver()
        {
            return webDriver;
        }

        public IWebDriver GetDriver()
        {
            var browserType = TestContext.Parameters["BROWSER"];
            switch (browserType)
            {
                case "CHROME":
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "CHROMEHEADLESS":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");
                    webDriver = new ChromeDriver(chromeOptions);
                    webDriver.Manage().Window.Maximize();
                    break;

                case "INTERNETEXPLORER":
                    webDriver = new InternetExplorerDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "FIREFOX":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    break;

                case "FFHEADLESS":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--headless");
                    webDriver = new FirefoxDriver(firefoxOptions);
                    webDriver.Manage().Window.Maximize();
                    break;

                default:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;
            }
            return webDriver;
        }

        public void CloseBrowser() 
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
