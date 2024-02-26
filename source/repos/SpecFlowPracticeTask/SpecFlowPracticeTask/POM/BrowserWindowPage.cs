using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowPracticeTask.POM
{
    public class BrowserWindowPage
    {
        private readonly WebDriver driver;

        public BrowserWindowPage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
        }

        public void NavigateToAutoCompleteSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[3]/div/ul/li[1]")).Click();
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='button1']")]
        public IWebElement NewTabButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='button3']")]
        public IWebElement NewWindowButton { get; set; }

        public IWebElement GetButtonByType(string buttonType)
        {
            switch (buttonType.ToLower()) 
            {
                case "new tab":
                    return NewTabButton;
                case "new windows":
                    return NewWindowButton;
                default:
                    throw new ArgumentException($"Unknown button type : {buttonType}");
            }
        }

        public void SwitchToNewWindowsOrTab(string windowType)
        {
            if (windowType == "tab")
            {
                WaitForLoadAndSwitchToTab(driver);
            }
            else if (windowType == "window")
            {
                WaitForLoadAndSwitchToWindow(driver);
            }
            else 
            {
                throw new ArgumentException($"Unknown windows type: {windowType}");
            };
        }

        public static void WaitForLoadAndSwitchToTab(WebDriver driver)
        {
            var handles = driver.WindowHandles;
            foreach (var handle in handles) 
            {
                if(handle != driver.CurrentWindowHandle) 
                {
                    driver.SwitchTo().Window(handle);
                    WaitForLoad(driver);
                    break;
                }
            }
        }

        public static void WaitForLoadAndSwitchToWindow(WebDriver driver)
        {
            var originalHandle = driver.CurrentWindowHandle;
            var newHandle = string.Empty;
            while (string.IsNullOrEmpty(newHandle) && newHandle != originalHandle)
            {
                newHandle = driver.WindowHandles.Except(new[] { originalHandle }).FirstOrDefault();
            }
            if (newHandle != originalHandle)
            {
                driver.SwitchTo().Window(newHandle);
                WaitForLoad(driver);
            }
        }

        private static void WaitForLoad(WebDriver driver)
        {
            var script = "return document.readyState;";
            var result = (string)driver.ExecuteScript(script);
            while (result != "complete")
            {
                Thread.Sleep(100);
                result = (string)driver.ExecuteScript(script);
            }
        }
    }
}
