﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProjectPractice.Helper;
using TechTalk.SpecFlow;
using SpecFlowProjectPractice.PageObjects;
using SpecFlowProjectPractice.Drivers;

namespace SpecFlowProjectPractice.StepDefinitions
{
    [Binding]
    public class BrowserWindowsFunctionalitySteps
    {
        private WebDriverManager _driverManager;
        private readonly BrowserWindowPage browserWindowPage;

        public BrowserWindowsFunctionalitySteps(WebDriverManager driverManager)
        {
            _driverManager = driverManager;
            browserWindowPage = new BrowserWindowPage(_driverManager);
        }

        [When(@"I click the link ""(.*)"" button")]
        public void WhenIClickTheLink(string linkText)
        {
            //  'no such element: Unable to locate element
            _driverManager.Driver().FindElement(By.LinkText(linkText)).Click();
        }

        [Then(@"I switch to the new window")]
        public void WhenISwitchToTheNewWindow()
        {
            browserWindowPage.SwitchToNewWindow();
        }

        [Then(@"I verify the page contains the text ""(.*)""")]
        public void ThenIVerifyTheFollowingTextIsDisplayed(string expectedText)
        {
            var wait = new WebDriverWait(_driverManager.Driver(), TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[text()='{expectedText}']")));

            Assert.AreEqual(expectedText, element.Text, $"Expected text '{expectedText}' not found on the page.");
        }
    }
}
