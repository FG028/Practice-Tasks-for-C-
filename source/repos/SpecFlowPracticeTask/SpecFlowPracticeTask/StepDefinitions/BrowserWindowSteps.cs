using OpenQA.Selenium;
using System.Runtime.InteropServices;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTask.StepDefinitions
{
    [Binding]
    public class BrowserWindowSteps
    {
        private readonly WebDriver driver;

        public BrowserWindowSteps(WebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am on the DemoQA page")]
        [Given(@"I navigate to the ""Alerts, Frame & Windows"" category and ""Browser Windows"" section")]
        public void NavigateToBrowserWindowsSection()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alertsWindows");
            driver.FindElement(By.XPath("//h5[text()='Browser Windows']")).Click();
        }

        [When(@"I click on the ""(.*)"" button")]
        public void ClickButton(string buttonType)
        {
            var button = buttonType switch
            {
                "New Tab" => driver.FindElement(By.XPath("//button[@id='button1']")),
                "New Window" => driver.FindElement(By.XPath("//button[@id='button3']")),
                _ => throw new ArgumentException($"Unknown button type: {buttonType}"),
            };
            button.Click();
        }

        [Then(@"the new ""(.*)"" should be loaded")]
        public void VerifyWindowLoaded(string windowsType)
        {
            if (windowsType == "tab")
            {
                WaitForLoadAndSwitchToTab(driver);
            }
            else if (windowsType == "windows")
            {
                WaitForLoadAndSwitchToTab(driver);
            }
            else
            {
                throw new ArgumentException($"Unknown windows type: {windowsType}");
            }
        }

        private static void WaitForLoadAndSwitchToTab(WebDriver driver)
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

        private static void WaitForLoadAndSwitchToWindow(WebDriver driver)
        {
            var originalHandle = driver.CurrentWindowHandle;
            var newHandle = string.Empty;
            while (string.IsNullOrEmpty(newHandle) && newHandle != originalHandle)
            {
                newHandle = driver.WindowHandles.Except(new[] { originalHandle }).FirstOrDefault();
            } if (newHandle != originalHandle)
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
                Thread.Sleep(500);
                result = (string)driver.ExecuteScript(script);
            }
        }
    }
}
