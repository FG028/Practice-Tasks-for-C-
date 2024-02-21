﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.Network;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

        [Given(@"I am on the DemoQA page ""(.*)""")]
        public void NavigateToSpecificPage(string url)
        {
            url = "https://demoqa.com/browser-windows";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I navigate to the ""Alerts, Frame & Windows"" category and ""Browser Windows"" section")]
        public void NavigateToBrowserWindowsSection()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div[3]/div/ul/li[1]")).Click();
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

        [Then(@"A new ""<window_type>"" should be loaded and ""<expected_content>"" should be displayed")]
        public void VerifyWindowLoaded(string windowsType)
        {
            if (windowsType == "tab")
            {
                WaitForLoadAndSwitchToTab(driver);
            }
            else if (windowsType == "windows")
            {
                WaitForLoadAndSwitchToWindow(driver);
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
                if (handle != driver.CurrentWindowHandle)
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
